Imports System.Collections.ObjectModel

Public Class MainViewModel
    Public Property Cars As ObservableCollection(Of Car)
    Public Property ShowWindowCommandGetAllCar As ICommand
    Public Property ShowWindowCommandCreateCar As ICommand

    Public Sub New()
        Cars = New CarService().Cars

        ShowWindowCommandGetAllCar = New RelayCommand(AddressOf ShowWindowGetAllCar, AddressOf CanShowWindow)

        ShowWindowCommandCreateCar = New RelayCommand(AddressOf ShowWindowCreateCar, AddressOf CanShowWindow)

    End Sub

    Private Sub ShowWindowGetAllCar(obj As Object)
        Dim win As Window = obj
        Dim cars As GetAllCar = New GetAllCar
        cars.WindowStartupLocation = WindowStartupLocation.CenterScreen
        win.Close()
        cars.Show()
    End Sub

    Private Sub ShowWindowCreateCar(obj As Object)
        Dim win As Window = obj
        Dim cars As CreateCar = New CreateCar
        cars.WindowStartupLocation = WindowStartupLocation.CenterScreen
        win.Close()
        cars.Show()
    End Sub

    Private Function CanShowWindow(obj As Object) As Boolean
        Return True
    End Function

End Class
