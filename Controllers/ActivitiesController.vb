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
    Public Class ActivitiesController
        Inherits Controller

        Private db As New ApplicationDbContext

        ' GET: Activities
        Function Index() As ActionResult
            Dim activities = db.Activities.Include(Function(a) a.Modulee).Include(Function(a) a.Type)
            Return View(activities.ToList())
        End Function

        ' GET: Activities/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            Return View(activity)
        End Function

        ' GET: Activities/Create
        Function Create(ByVal id As Integer?) As ActionResult
            ViewData("Types") = db.ActivityTypes.[Select](Function(c) New SelectListItem With
                                {
                                .Text = c.Name,
                                .Value = c.Id
                                })
            ViewData("Modulees") = db.Modulees.Where(Function(a) a.Id = id).Select(Function(c) New SelectListItem With
                                   {
                                   .Text = c.Name,
                                   .Value = c.Id
                                   })

            'ViewBag.ModuleeId = New SelectList(db.Modulees, "Id", "Name")
            'ViewBag.TypeId = New SelectList(db.ActivityTypes, "Id", "Name")
            Return View()
        End Function

        ' POST: Activities/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,TypeId,ModuleeId,Name,Description,StartTime,EndTime")> ByVal activity As Activity) As ActionResult
            If ModelState.IsValid Then
                db.Activities.Add(activity)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ModuleeId = New SelectList(db.Modulees, "Id", "Name", activity.ModuleeId)
            ViewBag.TypeId = New SelectList(db.ActivityTypes, "Id", "Name", activity.TypeId)
            Return View(activity)
        End Function

        ' GET: Activities/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            ViewBag.ModuleeId = New SelectList(db.Modulees, "Id", "Name", activity.ModuleeId)
            ViewBag.TypeId = New SelectList(db.ActivityTypes, "Id", "Name", activity.TypeId)
            Return View(activity)
        End Function

        ' POST: Activities/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,TypeId,ModuleeId,Name,Description,StartTime,EndTime")> ByVal activity As Activity) As ActionResult
            If ModelState.IsValid Then
                db.Entry(activity).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ModuleeId = New SelectList(db.Modulees, "Id", "Name", activity.ModuleeId)
            ViewBag.TypeId = New SelectList(db.ActivityTypes, "Id", "Name", activity.TypeId)
            Return View(activity)
        End Function

        ' GET: Activities/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            Return View(activity)
        End Function

        ' POST: Activities/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim activity As Activity = db.Activities.Find(id)
            db.Activities.Remove(activity)
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
