Imports System.Data.Entity
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class Course
    Public Property Id() As Integer
    Public Property Name() As String
    Public Property Description() As String
    Public Property StartDate() As DateTime
End Class
'Public Class CourseDBContext
'    Inherits DbContext
'    Public Property Courses() As DbSet(Of Course)
'End Class