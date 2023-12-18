Public Class GetAllCar

    Public Sub New()

        ' Bu çağrı tasarımcı için gerekli.
        InitializeComponent()
        Dim mainViewModel = New MainViewModel
        DataContext = mainViewModel
        ' InitializeComponent() çağrısından sonra başlangıç değer ekleyin.

    End Sub

End Class
