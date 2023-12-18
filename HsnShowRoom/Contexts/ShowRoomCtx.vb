Imports System.Data.Entity

Public Class ShowRoomCtx
    Inherits DbContext

    Public Property Cars As DbSet(Of Car)

    Public Sub New()
        MyBase.New("Server=.\SQLEXPRESS;Database=ShowRoom;Trusted_Connection=True;TrustServerCertificate=True")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

        modelBuilder.Entity(Of Car).HasKey(Function(c) c.Id)

        modelBuilder.Entity(Of Car).Property(Function(c) c.Id).HasColumnName("CAR_ID")

        modelBuilder.Entity(Of Car).Property(Function(c) c.Model).HasColumnName("CAR_MODEL")

        modelBuilder.Entity(Of Car).Property(Function(c) c.Name).HasColumnName("CAR_NAME")


    End Sub

End Class
