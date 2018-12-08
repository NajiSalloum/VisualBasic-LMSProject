Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports HomeDesginProject

Namespace Controllers
    Public Class CoursesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Courses
        Function Index() As ActionResult
            Return View(db.Courses.ToList())
        End Function

        ' GET: Courses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' GET: Courses/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Courses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,Description,StartDate")> ByVal course As Course) As ActionResult
            If ModelState.IsValid Then
                db.Courses.Add(course)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(course)
        End Function


        'url: Courses/UniqueCourseName
        Function UniqueCourseName(ByVal DataName As String, ByVal Text As String) As JsonResult
            If DataName = "Name" Then
                Dim data = (From c In db.Courses
                            Where c.Name = Text).ToList()
                Return Json(data)
            End If
            Return Nothing
        End Function

        'GET: Courses/CourseModulees
        Function CourseModulees(ByVal id As Integer?) As ActionResult
            If id Is Nothing Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim modulees As IEnumerable(Of Modulee) = (From m In db.Modulees
                                                       Where m.CourseId = id).ToList()
            Return View(modulees)
        End Function


        ' GET: Courses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' POST: Courses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,Description,StartDate")> ByVal course As Course) As ActionResult
            If ModelState.IsValid Then
                db.Entry(course).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(course)
        End Function

        ' GET: Courses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim course As Course = db.Courses.Find(id)
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' POST: Courses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim course As Course = db.Courses.Find(id)
            db.Courses.Remove(course)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
