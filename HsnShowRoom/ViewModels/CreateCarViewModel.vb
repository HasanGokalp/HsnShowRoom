Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class CreateCarViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Private _id As Integer
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set
            If _id <> Value Then
                _id = Value
                OnPropertyChanged(NameOf(Id))
            End If
        End Set
    End Property
    Private _make As String
    Public Property Make As String
        Get
            Return _make
        End Get
        Set
            If _make <> Value Then
                _make = Value
                OnPropertyChanged(NameOf(Make))
            End If
        End Set
    End Property
    Private _model As String
    Public Property Model As String
        Get
            Return _model
        End Get
        Set
            If _model <> Value Then
                _model = Value
                OnPropertyChanged(NameOf(Model))
            End If
        End Set
    End Property
    Public Property CreateCommand As ICommand
    Public Sub New()
        CreateCommand = New RelayCommand(AddressOf CreateEntity, AddressOf CanCreateEntity)
    End Sub

    Public Sub CreateEntity(obj As Object)
        If TypeOf obj Is Object() Then
            Dim parameters = DirectCast(obj, Object())
            Dim name = parameters(0).ToString()
            Dim model = parameters(1).ToString()

            Using ctx = New ShowRoomCtx
                Dim entity = New Car With {
                .Name = name,
                .Model = model,
                .Id = 1
            }
                ctx.Cars.Add(entity)
                ctx.SaveChanges()
            End Using
        End If
    End Sub

    Public Function CanCreateEntity(obj As Object) As Boolean
        ' Gerekirse kaydetme işlemini gerçekleştirmenin uygun olduğu bir durumu kontrol edin
        Return True
    End Function
End Class
