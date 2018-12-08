Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddActivityModels
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Activities",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .TypeId = c.Int(nullable := False),
                        .ModuleeId = c.Int(nullable := False),
                        .Name = c.String(),
                        .Description = c.String(),
                        .StartTime = c.Time(nullable := False, precision := 7),
                        .EndTime = c.Time(nullable := False, precision := 7)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Modulees", Function(t) t.ModuleeId, cascadeDelete := True) _
                .ForeignKey("dbo.ActivityTypes", Function(t) t.TypeId, cascadeDelete := True) _
                .Index(Function(t) t.TypeId) _
                .Index(Function(t) t.ModuleeId)
            
            CreateTable(
                "dbo.ActivityTypes",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Activities", "TypeId", "dbo.ActivityTypes")
            DropForeignKey("dbo.Activities", "ModuleeId", "dbo.Modulees")
            DropIndex("dbo.Activities", New String() { "ModuleeId" })
            DropIndex("dbo.Activities", New String() { "TypeId" })
            DropTable("dbo.ActivityTypes")
            DropTable("dbo.Activities")
        End Sub
    End Class
End Namespace
