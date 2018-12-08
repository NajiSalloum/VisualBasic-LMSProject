Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Controllers
    Public Class MembersController
        Inherits Controller
        Dim db As New ApplicationDbContext()

        Dim userStore As New UserStore(Of ApplicationUser)(db)
        Dim userManager As New ApplicationUserManager(userStore)
        ' GET: Members
        Function Index() As ActionResult
            Return View()
        End Function

        'GET: Members/Register
        Function Register(ByVal k As Integer?) As ActionResult
            ViewData("Courses") = db.Courses.[Select](Function(c) New SelectListItem With
            {
                .Text = c.Name,
                .Value = c.Id
            })
            Dim model As New RegisterView() With
            {
            .Kind = k,
            .CourseId = 0
            }

            Return View(model)
        End Function

        'POST: Members/Register
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Register(ByVal Email As String, ByVal PasswordHash As String, ByVal FirstName As String, ByVal LastName As String, ByVal CourseId As Integer?, ByVal kind As Integer?) As ActionResult

            If kind = 2 Then
                Dim user As New ApplicationUser() With
                {.Email = Email,
                .PasswordHash = PasswordHash.GetHashCode(),
                .UserName = Email,
                .FirstName = FirstName,
                .LastName = LastName,
                .CourseId = CourseId}


                Dim resault = userManager.Create(user, PasswordHash)
                Dim UserToAdd = userManager.FindByName(Email)
                userManager.AddToRole(user.Id, "Student")
                Return RedirectToAction("AllStudents")
            Else
                Dim user As New ApplicationUser() With
                {.Email = Email,
                .PasswordHash = PasswordHash.GetHashCode(),
                .UserName = Email,
                .FirstName = FirstName,
                .LastName = LastName,
                .CourseId = Nothing
                }


                Dim resault = userManager.Create(user, PasswordHash)
                Dim UserToAdd = userManager.FindByName(Email)
                userManager.AddToRole(user.Id, "Teacher")
                Return RedirectToAction("AllTeachers")
            End If


            Return Nothing
        End Function

        'GET: Members/RegisterMember
        Function RegisterMember() As ActionResult
            ViewData("Courses") = db.Courses.[Select](Function(c) New SelectListItem With
            {
                .Text = c.Name,
                .Value = c.Id
            })
            Return View()
        End Function

        'POST: Members/RegisterMember
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function RegisterMember(ByVal Email As String, ByVal PasswordHash As String, ByVal FirstName As String, ByVal LastName As String, ByVal CourseId As Integer?, ByVal Kind As Integer?) As ActionResult
            If Kind = 2 Then
                Dim user As New ApplicationUser() With
                {.Email = Email,
                .PasswordHash = PasswordHash.GetHashCode(),
                .UserName = Email,
                .FirstName = FirstName,
                .LastName = LastName,
                .CourseId = CourseId}


                Dim resault = userManager.Create(user, PasswordHash)
                Dim UserToAdd = userManager.FindByName(Email)
                userManager.AddToRole(user.Id, "Student")
            Else
                Dim user As New ApplicationUser() With
                {.Email = Email,
                .PasswordHash = PasswordHash.GetHashCode(),
                .UserName = Email,
                .FirstName = FirstName,
                .LastName = LastName,
                .CourseId = Nothing
                }


                Dim resault = userManager.Create(user, PasswordHash)
                Dim UserToAdd = userManager.FindByName(Email)
                userManager.AddToRole(user.Id, "Teacher")
                Return RedirectToAction("AllTeachers")
            End If
            Return Nothing


        End Function

        'GET: Members/AllStudents
        Function AllStudents(Optional ByVal SearchName As String = "") As ActionResult
            Dim usersList As New List(Of AllStudentsView)
            Dim users = Nothing
            If SearchName Is Nothing Then
                users = (From u In db.Users
                         Where u.CourseId IsNot Nothing
                                ).ToList()
            Else
                users = (From u In db.Users
                         Where u.CourseId IsNot Nothing AndAlso u.FirstName.Contains(SearchName)
                         ).ToList()
            End If



            For Each user As ApplicationUser In users
                Dim courseName = (From c In db.Courses
                                  Where c.Id = user.CourseId
                                  Select c).First


                usersList.Add(New AllStudentsView() With
                              {.FirstName = user.FirstName,
                              .LastName = user.LastName,
                              .Email = user.Email,
                              .CourseId = user.CourseId,
                              .CourseName = courseName.Name
                              })
            Next
            Return View(usersList)
        End Function


        'GET: Members/AllTeachers
        Function AllTeachers(Optional ByVal SearchName As String = "") As ActionResult
            Dim usersList As New List(Of AllTeachersView)
            Dim users = Nothing
            If SearchName Is Nothing Then
                users = (From u In db.Users
                         Where u.CourseId Is Nothing
                                ).ToList()
            Else
                users = (From u In db.Users
                         Where u.CourseId Is Nothing AndAlso u.FirstName.Contains(SearchName)
                        ).ToList()
            End If



            For Each user As ApplicationUser In users
                usersList.Add(New AllTeachersView() With
                                              {.FirstName = user.FirstName,
                                              .LastName = user.LastName,
                                              .Email = user.Email
                                              })
            Next
            Return View(usersList)
        End Function

    End Class






End Namespace