# How to contribute

Contributions are quite welcome, though some rules should be followed!

## C# Coding Style

The general rule we follow is "use Visual Studio defaults".

1. Use [Allman style braces](http://en.wikipedia.org/wiki/Indent_style#Allman_style)
2. Use four spaces of indentation (no tabs)
3. Use `_camelCase` private members and use `readonly` where possible
4. Avoid `this.` unless absolutely necessary
5. Always specify the visiblity, even if it's the default (i.e. `private string _foo` not `string _foo`)
6. Namespace imports should be specified at the top of the file, outside of namespace declarations and should be sorted alphabetically, with `System.` namespaces at the top and blank lines between different top level groups