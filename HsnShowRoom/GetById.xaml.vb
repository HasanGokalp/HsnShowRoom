Public Class GetById

    Public Sub New()

        ' Bu çağrı tasarımcı için gerekli.
        InitializeComponent()
        Dim DCtx = New GetByIdViewModel
        DataContext = DCtx
        ' InitializeComponent() çağrısından sonra başlangıç değer ekleyin.

    End Sub

    Private Sub ListBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim selectedItem As Car = TryCast(List.SelectedItem, Car)
        If selectedItem IsNot Nothing Then
            txtUName.Text = selectedItem.Name
            txtUModel.Text = selectedItem.Model
        End If
    End Sub
End Class