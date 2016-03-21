param($installPath, $toolsPath, $package, $project)
  Write-Host "Adding System.Windows.Interactivity..."
  
  if (Test-Path "HKLM:\SOFTWARE\WOW6432Node\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\BlendPhoneSDK") {
    $blendSdkPath = Get-ItemPropertyValue "HKLM:\SOFTWARE\WOW6432Node\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\Windows Phone" -Name "(default)"
  }
  elseif (Test-Path "HKLM:\SOFTWARE\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\BlendPhoneSDK") {
    $blendSdkPath = Get-ItemPropertyValue "HKLM:\SOFTWARE\Microsoft\Microsoft SDKs\WindowsPhone\v8.0\AssemblyFoldersEx\Windows Phone" -Name "(default)"
  }
  
  $blendSdkAssemblyPath = "$blendSdkPath\System.Windows.Interactivity.dll"
  
  if (Test-Path $blendSdkAssemblyPath) {
    $project.Object.References.Add($blendSdkAssemblyPath)
  }
  else {
    Write-Host "Unable to find System.Windows.Interactivity, please add it manually!"
  }
  
  $project.Save()