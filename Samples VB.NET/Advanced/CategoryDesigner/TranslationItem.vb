Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Globalization
Imports Therefore.API

Namespace Therefore.Samples
	Public MustInherit Class TranslationItem
		Public Property Translations() As Dictionary(Of Integer, String)

		Public Overridable ReadOnly Property ItemType() As String

		Public MustOverride Sub SetTranslatedValues()
	End Class

	Public Class CategoryNameTranslationItem
		Inherits TranslationItem
		Private _category As TheCategory

		Public Sub New(ByVal cat As TheCategory)
			Translations = New Dictionary(Of Integer, String)()
			_category = cat
			Dim lcids As TheIntArray = cat.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				Translations.Add(lcid, cat.GetName(lcid))
			Next lcid
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return "Category Name"
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				If Translations(lcid) Is Nothing Then
					Throw New Exception(String.Format("Invalid category name for language {0}", CultureInfo.GetCultureInfo(lcid).Name))
				End If
				_category.SetName(lcid, Translations(lcid))
			Next lcid
		End Sub
	End Class

	Public Class CategoryDescriptionTranslationItem
		Inherits TranslationItem
		Private _category As TheCategory

		Public Sub New(ByVal cat As TheCategory)
			Translations = New Dictionary(Of Integer, String)()
			_category = cat
			Dim lcids As TheIntArray = cat.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				Translations.Add(lcid, cat.GetDescription(lcid))
			Next lcid
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return "Category Description"
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				Dim description As String = ""
				If Translations(lcid) IsNot Nothing Then
					description = Translations(lcid)
				End If
				_category.SetDescription(lcid, description)
			Next lcid
		End Sub
	End Class

	Public Class CaseDefinitionNameTranslationItem
		Inherits TranslationItem
		Private _casedef As TheCaseDefinition

		Public Sub New(ByVal casedef As TheCaseDefinition)
			Translations = New Dictionary(Of Integer, String)()
			_casedef = casedef
			Dim lcids As TheIntArray = casedef.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				Translations.Add(lcid, casedef.GetName(lcid))
			Next lcid
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return "Case Definition Name"
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				If Translations(lcid) Is Nothing Then
					Throw New Exception(String.Format("Invalid case definition name for language {0}", CultureInfo.GetCultureInfo(lcid).Name))
				End If
				_casedef.SetName(lcid, Translations(lcid))
			Next lcid
		End Sub
	End Class

	Public Class CaseDefinitionDescriptionTranslationItem
		Inherits TranslationItem
		Private _casedef As TheCaseDefinition

		Public Sub New(ByVal casedef As TheCaseDefinition)
			Translations = New Dictionary(Of Integer, String)()
			_casedef = casedef
			Dim lcids As TheIntArray = casedef.GetAvailableLCIDs()
			For Each lcid As Integer In lcids
				Translations.Add(lcid, casedef.GetDescription(lcid))
			Next lcid
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return "Case Definition Description"
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				Dim description As String = ""
				If Translations(lcid) IsNot Nothing Then
					description = Translations(lcid)
				End If
				_casedef.SetDescription(lcid, description)
			Next lcid
		End Sub
	End Class

	Public Class CategoryFieldTranslationItem
		Inherits TranslationItem
		Private _field As TheCategoryField

		Public Sub New(ByVal field As TheCategoryField)
			Translations = New Dictionary(Of Integer, String)()
			_field = field
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return _field.FieldType.ToString() & " (" & _field.FieldNo.ToString() & ")"
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				If Translations(lcid) Is Nothing Then
					Throw New Exception(String.Format("Invalid caption for field {0} language {1}", _field.FieldNo, CultureInfo.GetCultureInfo(lcid).Name))
				End If
				_field.SetCaption(lcid, Translations(lcid))
			Next lcid
		End Sub
	End Class

	Public Class TabInfoTranslationItem
		Inherits TranslationItem
		Private _tabinfo As TheTabInfo
		Private _fieldno As Integer

		Public Sub New(ByVal tabinfo As TheTabInfo, ByVal fieldno As Integer)
			Translations = New Dictionary(Of Integer, String)()
			_tabinfo = tabinfo
			_fieldno = fieldno
		End Sub

		Public Overrides ReadOnly Property ItemType() As String
			Get
				Return "TabControlField " & _fieldno & " Tab " & _tabinfo.TabNo.ToString()
			End Get
		End Property

		Public Overrides Sub SetTranslatedValues()
			For Each lcid As Integer In Translations.Keys
				If Translations(lcid) Is Nothing Then
					Throw New Exception(String.Format("Invalid caption for tab {0} of field {1} language {2}", _tabinfo.TabNo, _fieldno, CultureInfo.GetCultureInfo(lcid).Name))
				End If
				_tabinfo.SetCaption(lcid, Translations(lcid))
			Next lcid
		End Sub
	End Class
End Namespace
