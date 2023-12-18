Imports System.Collections.ObjectModel

Public Class MainViewModel
    Public Property Cars As ObservableCollection(Of Car)
    Public Property ShowWindowCommand As ICommand

    Public Sub New()
        Cars = New CarService().Cars

        ShowWindowCommand = New RelayCommand(AddressOf ShowWindow, AddressOf CanShowWindow)
    End Sub

    Private Sub ShowWindow(obj As Object)
        Dim win As Window = obj
        Dim cars As GetAllCar = New GetAllCar
        cars.WindowStartupLocation = WindowStartupLocation.CenterScreen
        win.Close()
        cars.Show()
    End Sub

    Private Function CanShowWindow(obj As Object) As Boolean
        Return True
    End Function

End Class
