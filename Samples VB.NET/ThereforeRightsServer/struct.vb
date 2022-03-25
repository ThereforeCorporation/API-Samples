Imports System.Collections

Namespace Therefore
	Public Structure TheUserStruct
		Public nUserNo As Integer
		Public strUserName As String
		Public anGroupList() As Integer

		Public Sub New(ByVal oUser As Object)
			Dim aoUser() As Object = CType(oUser, Object())
			nUserNo = CInt(Fix(aoUser(0)))
			strUserName = CStr(aoUser(1))

			Dim aoGroupList() As Object = CType(aoUser(2), Object())

			Dim temp(aoGroupList.Length - 1) As Integer
			For i As Integer = 0 To aoGroupList.Length - 1
				temp(i) = CInt(Fix(aoGroupList(i)))
			Next i
			anGroupList = temp
		End Sub
	End Structure

	Public Structure TheIndexDataStruct
		Public strCtgryName As String
		Public nCtgryNo As Integer
		Public nDocNo As Integer
		Public aIndexData As ArrayList

		Public Sub New(ByVal oIndexData As Object)
			Dim aoIndexData() As Object = CType(oIndexData, Object())
			strCtgryName = CStr(aoIndexData(0))
			nCtgryNo = CInt(Fix(aoIndexData(1)))
			nDocNo = CInt(Fix(aoIndexData(2)))

			Dim temp As New ArrayList()
			'read all index data values
			Dim oaIxDataValues() As Object = CType(aoIndexData(4), Object())
			For i As Integer = 0 To oaIxDataValues.Length - 1
				'get 4.n
				Dim objFieldVal() As Object = CType(oaIxDataValues(i), Object())
				'get 4.n.0
				Dim strIndexName As String = CStr(objFieldVal(0))

				'get 4.n.1             
				If objFieldVal(1) Is Nothing Then
					objFieldVal(1) = ""
				End If

				Dim strFieldValue As String = objFieldVal(1).ToString()

				Dim pair() As String = {strIndexName,strFieldValue}
				temp.Add(pair)
			Next i
			aIndexData = temp
		End Sub
	End Structure
End Namespace