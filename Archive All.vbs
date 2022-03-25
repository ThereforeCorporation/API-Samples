Option Explicit
Dim TheServer
Dim TheDocument
Dim TheIndexData
Dim oFS
Dim oFolder
Dim oFile
Dim oSubFolder
Dim counter

ArchiveAll

Sub ArchiveAll

	Set TheServer = CreateObject("TheAPI.TheServer")
	Set TheDocument = CreateObject("TheAPI.TheDocument")
	Set oFS = CreateObject("Scripting.FileSystemObject")
    
	Set oFolder = oFS.GetFolder("Sample Documents")
	
	counter = 0
	
	TheServer.Connect(6)
	If (TheServer.Connected = 0) then
		MsgBox "Error Connecting to Therefore!"
		Exit Sub
	End If
	
	ArchiveFolder(oFolder)	

	MsgBox Cstr(counter) & " Documents succesfully saved to Therefore!" 
End Sub

Sub ArchiveFolder(Folder)

	For Each oFile in Folder.Files	
		Call TheDocument.Create("")
		Call TheDocument.AddStream(oFile.Path, "", 0)
		Set TheIndexData = TheDocument.IndexData
		Call TheIndexData.SetCategoryByName("Files",TheServer)
		Call TheIndexData.SetValueByIndexDataFieldName("Filename",oFile.Name)
		Call TheIndexData.SetValueByIndexDataFieldName("From_Folder",oFile.Path)
		Call TheIndexData.SetValueByIndexDataFieldName("Creation_Date",Now())
		Call TheIndexData.SetValueByIndexDataFieldName("Extension",oFS.GetExtensionName(oFile.Path))
		Call TheDocument.Archive(TheServer,0)
		Call TheDocument.Close()
		
		counter = counter + 1
	Next
	
	For Each oSubFolder in Folder.SubFolders
		ArchiveFolder(oSubFolder)
	Next
End Sub