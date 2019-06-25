Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Resources
Imports System.Xml.Linq

Namespace RangeColorizer3DExample.ViewModel
	Public Class Gdp
		Private privateCountry As String
		Public Property Country() As String
			Get
				Return privateCountry
			End Get
			Private Set(ByVal value As String)
				privateCountry = value
			End Set
		End Property
		Private privateYear As Integer
		Public Property Year() As Integer
			Get
				Return privateYear
			End Get
			Private Set(ByVal value As Integer)
				privateYear = value
			End Set
		End Property
		Private privateValue As Double
		Public Property Value() As Double
			Get
				Return privateValue
			End Get
			Private Set(ByVal value As Double)
				privateValue = value
			End Set
		End Property
		Private privateRegion As String
		Public Property Region() As String
			Get
				Return privateRegion
			End Get
			Private Set(ByVal value As String)
				privateRegion = value
			End Set
		End Property

		Public Sub New(ByVal country As String, ByVal year As Integer, ByVal value As Double, ByVal region As String)
			Me.Country = country
			Me.Year = year
			Me.Value = value
			Me.Region = region
		End Sub
	End Class

	Public Class GdpViewModel
		Private privateGdps As IEnumerable(Of Gdp)
		Public Property Gdps() As IEnumerable(Of Gdp)
			Get
				Return privateGdps
			End Get
			Private Set(ByVal value As IEnumerable(Of Gdp))
				privateGdps = value
			End Set
		End Property

		Public Sub New()
			Gdps = (New GdpResourceLoader("Data/GdpStatistics.xml")).Load()
		End Sub
	End Class

	Public Class GdpResourceLoader
		Private Property Filepath() As String

		Public Sub New(ByVal filepath As String)
			Me.Filepath = filepath
		End Sub

		Public Function Load() As IEnumerable(Of Gdp)
			Dim result As New Collection(Of Gdp)()

			Dim resourceUri As New Uri(Filepath, UriKind.RelativeOrAbsolute)
			Dim resourceInfo As StreamResourceInfo = Application.GetResourceStream(resourceUri)
			Dim xDoc As XDocument = XDocument.Load(resourceInfo.Stream)
			For Each xGdp In xDoc.Element("Statistics").Elements("Gdp")
				result.Add(New Gdp(country:= xGdp.Attribute("Country").Value, year:= Convert.ToInt32(xGdp.Attribute("Year").Value), value:= Convert.ToDouble(xGdp.Attribute("Value").Value), region:= xGdp.Attribute("Region").Value))
			Next xGdp
			Return result
		End Function
	End Class
End Namespace
