Public Class RelayCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Private Property _Execute As Action(Of Object)
    Private Property _CanExecute As Predicate(Of Object)

    Public Sub New(execute As Action(Of Object), canExecute As Predicate(Of Object))
        _Execute = execute
        _CanExecute = canExecute
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return _CanExecute(parameter)
    End Function

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        _Execute.Invoke(parameter)
    End Sub
End Class
