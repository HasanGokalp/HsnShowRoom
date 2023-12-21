Imports System.Collections.ObjectModel
Imports System.Data.Entity.Migrations

Public Class MainViewModel
    Public Property EntityId As Integer
    Public Property SelectedCar As Car
    Public Property ctx As ShowRoomCtx = New ShowRoomCtx
    Public Property Cars As ObservableCollection(Of Car)
    Public Property ShowWindowCommandGetAllCar As ICommand
    Public Property ShowWindowCommandCreateCar As ICommand
    Public Property ShowEntityId As ICommand

    Private _updateEntityCommand As ICommand
    Public Property UpdateEntityCommand As ICommand
        Get
            If _updateEntityCommand IsNot Nothing Then
                _updateEntityCommand = New RelayCommand(Sub()
                                                            Dim deneme As Car = New Car
                                                            deneme.Id = SelectedCar.Id
                                                            deneme.Model = SelectedCar.Model
                                                            deneme.Name = SelectedCar.Name
                                                            ctx.Cars.AddOrUpdate(deneme)
                                                        End Sub, Function()
                                                                     Return True
                                                                 End Function)

            End If
            Return _updateEntityCommand
        End Get
        Set(value As ICommand)

        End Set
    End Property



    Public Sub New()
        Cars = New CarService().Cars
        ShowWindowCommandGetAllCar = New RelayCommand(AddressOf ShowWindowGetAllCar, AddressOf CanShowWindow)

        ShowWindowCommandCreateCar = New RelayCommand(AddressOf ShowWindowCreateCar, AddressOf CanShowWindow)

        ShowEntityId = New RelayCommand(AddressOf ShowWindowGetById, AddressOf CanShowWindow)

    End Sub

    Private Sub ShowWindowGetAllCar(obj As Object)
        Dim win As Window = obj
        Dim cars As GetAllCar = New GetAllCar
        cars.WindowStartupLocation = WindowStartupLocation.CenterScreen
        win.Close()
        cars.Show()
    End Sub

    Private Sub ShowWindowGetById(obj As Object)
        Dim win As Window = obj
        Dim cars As GetById = New GetById
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
