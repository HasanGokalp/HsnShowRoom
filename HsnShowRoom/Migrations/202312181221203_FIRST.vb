Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class FIRST
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Cars",
                Function(c) New With
                    {
                        .CAR_ID = c.Int(nullable := False, identity := True),
                        .CAR_NAME = c.String(),
                        .CAR_MODEL = c.String()
                    }) _
                .PrimaryKey(Function(t) t.CAR_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Cars")
        End Sub
    End Class
End Namespace
