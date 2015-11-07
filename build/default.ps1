$psake.use_exit_on_error = $true

properties {
  $baseDir  = Resolve-Path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolsDir = "$baseDir\tools"
  $binDir = "$baseDir\bin"
  $docSourceDir = "$baseDir\doc"
  
  $isAppVeyor = Test-Path -Path env:\APPVEYOR
  
  $version = "2.0.0"
  
  $tempDir = "$binDir\temp"
  $binariesDir = "$binDir\binaries"
  $zipDir = "$binDir\zip"
  $nupkgDir = "$binDir\nupkg"
  $docDir = "$binDir\doc"
  
  $nuget = "$toolsDir\nuget\nuget.exe"
  $7zip = "$toolsDir\7zip\7za.exe"
  $vstest = "${Env:ProgramFiles(x86)}\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
  
  $configurations = @{
    "Portable" = @{Suffix = " (Portable)"; Folder="portable-net45+wp8+win8+wpa81"};
    "WP8" = @{Suffix = " (WP8)"; Folder="wp8"};
    "WPA81" = @{Suffix = " (WPA81)"; Folder="wpa81"};
    "Win81" = @{Suffix = " (Win81)"; Folder="win81"};
    "UWP" = @{Suffix = " (UWP)"; Folder="uap10.0"}
  }
  
  $projects = @(
    @{Name = "Cimbalino.Toolkit"; Configurations = @("WP8", "WPA81", "Win81", "UWP")},
    @{Name = "Cimbalino.Toolkit.Core"; Configurations = @("Portable", "WP8", "WPA81", "Win81", "UWP")}
  )
}

Framework "4.6x86"

task default -depends ?

task Clean -description "Clean the output folder" {
  if (Test-Path -path $binDir) {
    Write-Host -ForegroundColor Green "Deleting Working Directory"
    Write-Host
    
    Remove-Item $binDir -Recurse -Force
  }
  
  New-Item -Path $binDir -ItemType Directory | Out-Null
}

task Setup -description "Setup environment" {
  if ($isAppVeyor) {
    $script:version = $version -replace '([0-9]+(\.[0-9]+){2}).*', ('$1-dev' + $env:APPVEYOR_BUILD_NUMBER)
    
    Update-AppveyorBuild -Version $script:version
  }
  else {
    $script:version = $version
  }
  
  Exec { .$nuget restore $packagesConfig "$sourceDir\Cimbalino.Toolkit.sln" } "Error pre-installing NuGet packages"
}

task Headers -description "Updates the headers in *.cs files" {
  $headerTemplate = [System.IO.File]::ReadAllText("$buildDir\header.txt")

  $projects | % {
    $projectName = $_.Name
    
    $_.Configurations | % {
      $configuration = $configurations[$_]
      $configurationSuffix = $configuration.Suffix
      $fullProjectName = "$projectName$configurationSuffix"
      
      $projectDir = "$sourceDir\$fullProjectName\"
      
      Get-ChildItem -Path $projectDir -Filter *.cs -Exclude *generated* -Recurse | % {
        $fullFilename = $_.FullName
        $filename = $_.Name
        
        $oldContent = [System.IO.File]::ReadAllText($fullFilename)
        
        $newContent = ($headerTemplate -f $projectName, $filename) + ($oldContent -Replace "(?s)^.*// \*+\r\n\r\n", "")
        
        if ($newContent -ne $oldContent) {
          [System.IO.File]::WriteAllText($fullFilename, $newContent, [System.Text.Encoding]::UTF8)
        }
      }
    }
  }
}

task Version -description "Updates the version entries in AssemblyInfo.cs files" {
  $assemblyVersion = $script:version -replace '([0-9]+(\.[0-9]+){2}).*', '$1.0'
  $fileVersion = $assemblyVersion
  $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $assemblyVersionValue = 'AssemblyVersion("' + $assemblyVersion + '")';
  $fileVersionValue = 'AssemblyFileVersion("' + $fileVersion + '")';
  
  $projects | % {
    $projectName = $_.Name
    
    $_.Configurations | % {
      $configuration = $configurations[$_]
      $configurationSuffix = $configuration.Suffix
      $fullProjectName = "$projectName$configurationSuffix"
      
      $projectDir = "$sourceDir\$fullProjectName\"
      
      Write-Host -ForegroundColor Green "Versioning $fullProjectName..."
      Write-Host
      
      Get-ChildItem -Path $projectDir -Filter AssemblyInfo.cs -Recurse | % {
        $fullFilename = $_.FullName
        
        $oldContent = [System.IO.File]::ReadAllText($fullFilename);
        
        $newContent = $oldContent -Replace $assemblyVersionPattern, $assemblyVersionValue -Replace $fileVersionPattern, $fileVersionValue
        
        if ($newContent -ne $oldContent) {
          [System.IO.File]::WriteAllText($fullFilename, $newContent, [System.Text.Encoding]::UTF8)
        }
      }
    }
  }
}

task Build -depends Clean, Setup, Version -description "Build all projects and get the assemblies" {
  $tempBinariesDir = "$tempDir\binaries"
  
  New-Item -Path $binariesDir -ItemType Directory | Out-Null
  New-Item -Path $tempBinariesDir -ItemType Directory | Out-Null
  
  Exec { msbuild "/t:Clean;Build" /p:Configuration=Release "/p:OutDir=$tempBinariesDir" /p:GenerateProjectSpecificOutputFolder=true /p:StyleCopTreatErrorsAsWarnings=true /m "$sourceDir\Cimbalino.Toolkit.sln" } "Error building $solutionFile"
  
  $projects | % {
    $projectName = $_.Name
    
    $projectDir = "$binariesDir\$projectName"
    
    $_.Configurations | % {
      $configuration = $configurations[$_]
      $configurationSuffix = $configuration.Suffix
      $configurationFolder = $configuration.Folder
      $fullProjectName = "$projectName$configurationSuffix"
      
      $configurationDir = "$projectDir\$configurationFolder"
    
      New-Item -Path $configurationDir -ItemType Directory | Out-Null
	  
	    Copy-Item -Path $tempBinariesDir\$fullProjectName\$projectName.* -Destination $configurationDir\ -Recurse	
    }
  }
}

task PackNuGet -depends Build -description "Create the NuGet packages" {
  $tempNupkgDir = "$tempDir\nupkg"
  
  New-Item -Path $nupkgDir -ItemType Directory | Out-Null
  New-Item -Path $tempNupkgDir -ItemType Directory | Out-Null
  
  $projects | % {
    $projectName = $_.Name
    $projectNugetFolder = "$tempNupkgDir\$projectName"
    $projectLibFolder = "$projectNugetFolder\lib"
    $projectNuspec = "$projectNugetFolder\$projectName.nuspec"
    
    New-Item -Path $projectNugetFolder -ItemType Directory | Out-Null
    
    Copy-Item -Path $buildDir\$projectName\* -Destination $projectNugetFolder\ -Recurse
    
    (Get-Content -Path $projectNuspec) | % {
          % { $_ -Replace '\$version\$', $script:version }
        } | Set-Content -Path $projectNuspec -Encoding UTF8
    
    $_.Configurations | % {
      $configuration = $configurations[$_]
      $configurationFolder = $configuration.Folder
      
      $configurationDir = "$projectLibFolder\$configurationFolder"
      
      New-Item -Path $configurationDir -ItemType Directory | Out-Null
      
      Copy-Item -Path $binariesDir\$projectName\$configurationFolder\* -Destination $configurationDir\ -Exclude '*.pdb' -Recurse
    }
	    
    Write-Host -ForegroundColor Green "Packaging $projectName..."
    Write-Host
    
    Exec { .$nuget pack "$projectNuspec" -Output "$nupkgDir" } "Error packaging $name"
  }
}

task PublishNuget -depends PackNuGet -description "Publish the NuGet packages to the remote repositories" {
  Get-ChildItem $nupkgDir\*.nupkg | % {
    $nupkg = $_.FullName
    
    Write-Host -ForegroundColor Green "Publishing $nupkg..."
    Write-Host
    
    if ($isAppVeyor) {
      Push-AppveyorArtifact $nupkg
    }
    else {
      Exec { .$nuget push "$nupkg" } "Error publishing $nupkg"
    }
  }
}

task Document -depends Build -description "Build the documentation" {
  New-Item -Path $docDir -ItemType Directory | Out-Null
  
  Exec { msbuild "/t:Clean;Build" /p:Configuration=Release /p:OutputPath=$docDir /m "$docSourceDir\doc.shfbproj" } "Error building documentation"
}


task ? -description "Show the help screen" {
  WriteDocumentation
}