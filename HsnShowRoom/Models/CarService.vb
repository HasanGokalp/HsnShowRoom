Imports System.Collections.ObjectModel

Public Class CarService

    Public Property Cars As ObservableCollection(Of Car)

    Public Sub New()
        Cars = Initial()
    End Sub

    Public Function Initial() As ObservableCollection(Of Car)
        Using ctx = New ShowRoomCtx
            Dim result As ObservableCollection(Of Car) = New ObservableCollection(Of Car)
            For Each item As Car In ctx.Cars
                result.Add(item)
            Next
            Return result
        End Using
    End Function


    Public Sub AddCar(car As Car)
        Using ctx = New ShowRoomCtx
            ctx.Cars.Add(car)
            ctx.SaveChanges()
        End Using
    End Sub

End Class
