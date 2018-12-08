Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity.EntityFramework

Public Class RegisterView
    Inherits IdentityUser

    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property
    <Required(ErrorMessage:="Last Name is required")>
    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property
    Private _cousre As Course
    Public Property Cousre() As Course
        Get
            Return _cousre
        End Get
        Set(ByVal value As Course)
            _cousre = value
        End Set
    End Property

    Private _courseId? As Integer
    Public Property CourseId()? As Integer
        Get

            Return _courseId
        End Get
        Set(ByVal value As Integer)
            _courseId = value
        End Set
    End Property


    Private _kind As Integer
    Public Property Kind() As Integer
        Get
            Return _kind
        End Get
        Set(ByVal value As Integer)
            _kind = value
        End Set
    End Property
End Class
