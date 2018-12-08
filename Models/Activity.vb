Imports System.Data.Entity.Core

Public Class Activity
    Public Property Id() As Integer

    Public Property Type() As ActivityType
    <WebDisplayName("Type")>
    Public Property TypeId() As Integer

    Public Property Modulee() As Modulee
    <WebDisplayName("Modulee")>
    Public Property ModuleeId() As Integer

    Public Property Name() As String
    Public Property Description() As String

    <WebDisplayName("Start Time")>
    Public Property StartTime() As TimeSpan

    <WebDisplayName("End Time")>
    Public Property EndTime() As TimeSpan
End Class
