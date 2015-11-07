using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

public class UnimplementModuleWeaver
{
    public Action<string> LogInfo { get; set; }

    public ModuleDefinition ModuleDefinition { get; set; }

    public UnimplementModuleWeaver()
    {
        LogInfo = m => { };
    }

    public void Execute()
    {
        var typeDefinitions = ModuleDefinition.GetTypes()
            .Where(x => x.IsClass)
            .ToArray();

        var createExceptionMethodDefinition = GenerateNotImplementedInReferenceAssemblyClass();

        foreach (var typeDefinition in typeDefinitions)
        {
            var methodDefinitions = typeDefinition.Methods
                .Where(x => !x.IsAbstract)
                .ToArray();

            foreach (var methodDefinition in methodDefinitions)
            {
                if (methodDefinition.HasCustomAttributes && methodDefinition.CustomAttributes != null)
                {
                    var asyncStateMachineAttribute = methodDefinition.CustomAttributes.FirstOrDefault(x => x.AttributeType.FullName == "System.Runtime.CompilerServices.AsyncStateMachineAttribute");

                    if (asyncStateMachineAttribute != null)
                    {
                        methodDefinition.CustomAttributes.Remove(asyncStateMachineAttribute);

                        var asyncClassTypeDefinition = (TypeDefinition)asyncStateMachineAttribute.ConstructorArguments[0].Value;

                        var asyncClass = typeDefinition.NestedTypes.FirstOrDefault(x => x.Name == asyncClassTypeDefinition.Name);

                        typeDefinition.NestedTypes.Remove(asyncClass);
                    }
                }

                var methodDefinitionBody = methodDefinition.Body = new MethodBody(methodDefinition);

                var processor = methodDefinitionBody.GetILProcessor();

                processor.Emit(OpCodes.Call, createExceptionMethodDefinition);
                processor.Emit(OpCodes.Throw);
            }
        }
    }

    private MethodDefinition GenerateNotImplementedInReferenceAssemblyClass()
    {
        var typeDefinition = new TypeDefinition(null, "NotImplementedInReferenceAssembly", TypeAttributes.NotPublic, ModuleDefinition.TypeSystem.Object);

        var exceptionTypeReference = ModuleDefinition.ImportReference(typeof(Exception));
        var notImplementedExceptionCtorMethodReference = ModuleDefinition.ImportReference(typeof(NotImplementedException).GetConstructor(new[] { typeof(string) }));

        var createExceptionMethodDefinition = new MethodDefinition("CreateException", MethodAttributes.Public | MethodAttributes.Static, exceptionTypeReference);

        var processor = createExceptionMethodDefinition.Body.GetILProcessor();

        processor.Emit(OpCodes.Ldstr, "This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        processor.Emit(OpCodes.Newobj, notImplementedExceptionCtorMethodReference);
        processor.Emit(OpCodes.Ret);

        typeDefinition.Methods.Add(createExceptionMethodDefinition);

        ModuleDefinition.Types.Add(typeDefinition);

        return createExceptionMethodDefinition;
    }
}