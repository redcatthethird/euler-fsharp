$existingSolutions = Get-ChildItem -Recurse -Filter ????.fs `
	| ForEach-Object { $_.Name.Substring(0, 4) -as [int] } `
	| Measure-Object -Maximum `
	| Select-Object -ExpandProperty Maximum

$newSolutionNumber = $existingSolutions + 1
$newFileName = '{0:0000}' -f $newSolutionNumber
$folderName = $newFileName.Substring(0, 2)

$oldFileName = "0001"
$oldPath = "00\$oldFileName.fs"
$newPath = "$folderName\$newFileName.fs"

Set-Location $PSScriptRoot\Solutions
Copy-Item $oldPath $newPath
$contents = Get-Content $newPath
$contents -replace $oldFileName, $newFileName | Set-Content $newPath

Set-Location $PSScriptRoot\Tests
Copy-Item $oldPath $newPath
$contents = Get-Content $newPath
$contents -replace $oldFileName, $newFileName | Set-Content $newPath

Set-Location $PSScriptRoot