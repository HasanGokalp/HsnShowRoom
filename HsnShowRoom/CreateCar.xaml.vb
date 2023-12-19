Public Class CreateCar
    Public Sub New()

        ' Bu çağrı tasarımcı için gerekli.
        InitializeComponent()
        Dim mainViewModel = New CreateCarViewModel
        DataContext = mainViewModel
        ' InitializeComponent() çağrısından sonra başlangıç değer ekleyin.

    End Sub
End Class
