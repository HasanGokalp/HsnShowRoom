Public Class CreateCommand
    Implements ICommand
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Private Property _Execute As Action(Of Dictionary(Of String, String))
    Private Property _CanExecute As Predicate(Of Dictionary(Of String, String))
    Public Sub New(execute As Action(Of Dictionary(Of String, String)), canExecute As Predicate(Of Dictionary(Of String, String)))
        _Execute = execute
        _CanExecute = canExecute
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        If _CanExecute IsNot Nothing Then
            Return _CanExecute.Invoke(DirectCast(parameter, Dictionary(Of String, String)))
        End If
        Return True
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        _Execute?.Invoke(DirectCast(parameter, Dictionary(Of String, String)))
    End Sub
End Class