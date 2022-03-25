$TheServer = New-Object -ComObject TheAPI.TheServer
$TheDocument = New-Object -ComObject TheAPI.TheDocument

$TheServer.Connect(6)
if($TheServer.Connected -eq 0)
{
	Write-Output "Error Connecting to Therefore!"
	Exit
}

$counter = 0
foreach ($file in Get-Childitem ".\Sample Documents\" -recurse | Where-Object {-not $_.PsIsContainer})
{
	$counter = $counter + 1
	$TheDocument.Create([ref] "")
	$suppress = $TheDocument.AddStream($file.fullname, "", 0)
	$TheIndexData = $TheDocument.IndexData
	$TheIndexData.SetCategoryByName("Files",$TheServer)
	$TheIndexData.SetValueByIndexDataFieldName("Filename",$file.BaseName)
	$TheIndexData.SetValueByIndexDataFieldName("From_Folder",$file.DirectoryName)
	$TheIndexData.SetValueByIndexDataFieldName("Creation_Date",$file.CreationTime)
	$TheIndexData.SetValueByIndexDataFieldName("Extension",$file.extension.Remove(0,1))
	$suppress = $TheDocument.Archive($TheServer,0)
	$TheDocument.Close()
}
$out = $counter.ToString() + " Documents succesfully saved to Therefore!"
Write-Output $out