Imports System.Web.Mvc

Namespace Controllers
    Public Class ModuleesController
        Inherits Controller
        Dim db As New ApplicationDbContext()
        ' GET: Modulees
        Function Index() As ActionResult
            Return View(db.Modulees.ToList())
        End Function

        'GET: Modulees/Create
        Function Create(ByVal id As Integer?) As ActionResult
            ViewData("Courses") = db.Courses.Where(Function(s) s.Id = id).[Select](Function(c) New SelectListItem With
            {
                .Text = c.Name,
                .Value = c.Id
            })


            Return View()
        End Function

        'POST: Modulees/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,Description,StartDate,EndDate,CourseId")> ByVal modulee As Modulee) As ActionResult

            db.Modulees.Add(modulee)
                db.SaveChanges()

            Return RedirectToAction("Index")
        End Function


        'GET: Modulees/ModuleeActivities
        Function ModuleeActivities(ByVal id As Integer?) As ActionResult
            Dim activities = (From a In db.Activities
                              Where a.ModuleeId = id).ToList()

            Return View(activities)
        End Function
    End Class
End Namespace