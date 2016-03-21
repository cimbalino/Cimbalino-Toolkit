param($installPath, $toolsPath, $package, $project)
  Write-Host "Adding System.Windows.Interactivity..."
  
  $project.Object.References.Add("System.Windows.Interactivity")
  
  $project.Save()