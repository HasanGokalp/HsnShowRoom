Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class GetByIdViewModel
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property Cars As ObservableCollection(Of Car) = New ObservableCollection(Of Car)

    'Command
    Public Property GetByIdCommand As ICommand
    Public Sub New()
        GetByIdCommand = New RelayCommand(AddressOf GetById, AddressOf CanShow)
    End Sub

    Public Sub GetById(obj As Object)
        Using ctx = New ShowRoomCtx
            Dim textBox As TextBox = TryCast(obj, TextBox)
            If textBox IsNot Nothing Then
                ' TextBox'ın içeriğini Integer'a dönüştürün.
                Dim entity As Integer
                If Integer.TryParse(textBox.Text, entity) Then
                    Dim result = ctx.Cars.Find(entity)
                    Cars = New ObservableCollection(Of Car)
                    If result IsNot Nothing Then
                        Cars.Add(result)
                    End If
                    OnPropertyChanged(NameOf(Cars))
                Else
                    ' TextBox içeriği bir tamsayıya dönüştürülemezse hata işleyin.
                    MessageBox.Show("Lütfen geçerli bir sayı giriniz.")
                End If
            End If
        End Using
    End Sub

    Public Function CanShow()
        Return True
    End Function

    Protected Overridable Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class
