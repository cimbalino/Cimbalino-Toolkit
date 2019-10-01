#addin "Cake.FileHelpers"

using System;
using System.Linq;
using System.Text.RegularExpressions;

var target = Argument("target", "Default");

var baseDir = MakeAbsolute(Directory("../")).ToString();
var buildDir = baseDir + "/build";
var sourceDir = baseDir + "/src";
var solutionFile = buildDir + "/Cimbalino.Toolkit.sln";

var binDir = baseDir + "/bin";
var tempDir = binDir + "/temp";
var packageDir = binDir + "/package";

Task("Clean")
    .Description("Clean the output folder")
    .Does(() =>
{
    Information("Deleting Working Directory...");

    if (DirectoryExists(binDir))
    {
        CleanDirectory(binDir);
    }
    else
    {
        CreateDirectory(binDir);
    }
});

Task("UpdateHeaders")
    .Description("Updates the headers in *.cs files")
    .Does(() =>
{
    var header = FileReadText("header.txt") + "\r\n";

    Func<IFileSystemInfo, bool> csFilesFilter = fileSystemInfo => {
        return !fileSystemInfo.Path.Segments.Contains("obj");
    };

    var csFiles = GetFiles(sourceDir + "/**/*.cs", csFilesFilter);

    Information(csFiles.Count);
});

Task("Build")
    .Description("Build all projects and get the assemblies")
    .IsDependentOn("Clean")
    .Does(() =>
{
    Information("Building Solution...");

    var buildSettings = new MSBuildSettings
    {
        MaxCpuCount = 0
    }
    .SetConfiguration("Release")
    .WithTarget("Pack")
    .WithProperty("GenerateLibraryLayout", "true")
	.WithProperty("PackageOutputPath", packageDir);

    MSBuild(solutionFile, buildSettings);
});

Task("Default")
    .IsDependentOn("UpdateHeaders")
    .Does(() =>
{
    Information("Hello World!");
});

RunTarget(target);
