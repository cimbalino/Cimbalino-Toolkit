properties { 
  $baseDir  = Resolve-Path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolsDir = "$baseDir\tools"
  $binDir = "$baseDir\bin"
  
  $version = "4.0.0"
  
  $tempDir = "$binDir\temp"
  $binariesDir = "$binDir\binaries"
  $zipDir = "$binDir\zip"
  $nupkgDir = "$binDir\nupkg"
  
  $nuget = "$toolsDir\nuget\nuget.exe"
  $7zip = "$toolsDir\7zip\7za.exe"
  $vstest = "${Env:ProgramFiles(x86)}\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
  
  $projects = @(
    @{Name = "Cimbalino.Toolkit.Portable"}
  )
  $configurations = @(
    @{Name = "WP71"; Folder = "sl4-wp71"},
    @{Name = "WP8"; Folder = "wp8"}
  )
}

Framework "4.0x86"

task default -depends ?

task Clean -description "Clean the output folder" {
  if (Test-Path -path $binDir)
  {
    Write-Host -ForegroundColor Green "Deleting Working Directory"
    Write-Host
    
    Remove-Item $binDir -Recurse -Force
  }
  
  New-Item -Path $binDir -ItemType Directory | Out-Null
}

task Setup -description "Setup environment" {
  #Exec { .$nuget install $packagesConfig -solutionDir $sourceDir } "Error pre-installing NuGet packages"
}

task Headers -description "Updates the headers in *.cs files" {
  $headerTemplate = [System.IO.File]::ReadAllText("$buildDir\header.txt")

  $projects | % {
    $projectName = $_.Name
    $fullProjectName = "$projectName"
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

task Version -description "Updates the version entries in AssemblyInfo.cs files" {
  $assemblyVersion = $version -replace '([0-9]+(\.[0-9]+){2}).*', '$1.0'
  $fileVersion = $assemblyVersion
  $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $assemblyVersionValue = 'AssemblyVersion("' + $assemblyVersion + '")';
  $fileVersionValue = 'AssemblyFileVersion("' + $fileVersion + '")';
  
  $configurations | % {
    $configName = $_.Name

    $projects | % {
      $projectName = $_.Name
      $fullProjectName = "$projectName ($configName)"
      $projectDir = "$sourceDir\$fullProjectName\"
      
      Write-Host -ForegroundColor Green "Versioning $fullProjectName..."
      Write-Host
      
      Get-ChildItem -Path $projectDir -Filter AssemblyInfo.cs -Recurse | % {
        $fullFilename = $_.FullName
        
        (Get-Content -Path $fullFilename) | % {
          % { $_ -Replace $assemblyVersionPattern, $assemblyVersionValue } |
          % { $_ -Replace $fileVersionPattern, $fileVersionValue }
        } | Set-Content -Path $fullFilename -Encoding UTF8
      }
    }
  }
}

task ? -description "Show the help screen" {
  Write-Documentation
}