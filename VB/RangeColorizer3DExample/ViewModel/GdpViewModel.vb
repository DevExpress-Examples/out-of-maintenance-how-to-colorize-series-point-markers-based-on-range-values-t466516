Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Resources
Imports System.Xml.Linq

Namespace RangeColorizer3DExample.ViewModel

    Public Class Gdp

        Private _Country As String, _Year As Integer, _Value As Double, _Region As String

        Public Property Country As String
            Get
                Return _Country
            End Get

            Private Set(ByVal value As String)
                _Country = value
            End Set
        End Property

        Public Property Year As Integer
            Get
                Return _Year
            End Get

            Private Set(ByVal value As Integer)
                _Year = value
            End Set
        End Property

        Public Property Value As Double
            Get
                Return _Value
            End Get

            Private Set(ByVal value As Double)
                _Value = value
            End Set
        End Property

        Public Property Region As String
            Get
                Return _Region
            End Get

            Private Set(ByVal value As String)
                _Region = value
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

        Private _Gdps As IEnumerable(Of RangeColorizer3DExample.ViewModel.Gdp)

        Public Property Gdps As IEnumerable(Of Gdp)
            Get
                Return _Gdps
            End Get

            Private Set(ByVal value As IEnumerable(Of Gdp))
                _Gdps = value
            End Set
        End Property

        Public Sub New()
            Gdps = New GdpResourceLoader("Data/GdpStatistics.xml").Load()
        End Sub
    End Class

    Public Class GdpResourceLoader

        Private Property Filepath As String

        Public Sub New(ByVal filepath As String)
            Me.Filepath = filepath
        End Sub

        Public Function Load() As IEnumerable(Of Gdp)
            Dim result As Collection(Of Gdp) = New Collection(Of Gdp)()
            Dim resourceUri As Uri = New Uri(Filepath, UriKind.RelativeOrAbsolute)
            Dim resourceInfo As StreamResourceInfo = Application.GetResourceStream(resourceUri)
            Dim xDoc As XDocument = XDocument.Load(resourceInfo.Stream)
            For Each xGdp In xDoc.Element("Statistics").Elements("Gdp")
                result.Add(New Gdp(country:=xGdp.Attribute("Country").Value, year:=Convert.ToInt32(xGdp.Attribute("Year").Value), value:=Convert.ToDouble(xGdp.Attribute("Value").Value), region:=xGdp.Attribute("Region").Value))
            Next

            Return result
        End Function
    End Class
End Namespace
