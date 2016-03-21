param($installPath, $toolsPath, $package, $project)
  Write-Host "Adding System.Windows.Interactivity..."
  
  $knownRegistryPaths = @(
    "HKLM:\SOFTWARE\WOW6432Node\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\BlendPhoneSDK",
    "HKLM:\SOFTWARE\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\BlendPhoneSDK"
  )
  
  $validRegistryPath = $knownRegistryPaths | ? { Test-Path $_ } | Select-Object -First 1
  
  if ($validRegistryPath) {
    $blendSdkPath = (Get-ItemProperty $validRegistryPath -Name "(default)")."(default)"
  }
  
  $blendSdkAssemblyPath = "$blendSdkPath\System.Windows.Interactivity.dll"
  
  if (Test-Path $blendSdkAssemblyPath) {
    $project.Object.References.Add($blendSdkAssemblyPath)
    
    $project.Save()
  }
  else {
    Write-Host "Unable to find System.Windows.Interactivity, please add it manually!"
  }