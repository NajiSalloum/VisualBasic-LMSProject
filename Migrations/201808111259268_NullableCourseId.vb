Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class NullableCourseId
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses")
            DropIndex("dbo.AspNetUsers", New String() { "CourseId" })
            AlterColumn("dbo.AspNetUsers", "CourseId", Function(c) c.Int())
            CreateIndex("dbo.AspNetUsers", "CourseId")
            AddForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses", "Id")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses")
            DropIndex("dbo.AspNetUsers", New String() { "CourseId" })
            AlterColumn("dbo.AspNetUsers", "CourseId", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.AspNetUsers", "CourseId")
            AddForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses", "Id", cascadeDelete := True)
        End Sub
    End Class
End Namespace
