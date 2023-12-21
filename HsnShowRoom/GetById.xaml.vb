Public Class GetById

    Public Sub New()

        ' Bu çağrı tasarımcı için gerekli.
        InitializeComponent()
        Dim DCtx = New GetByIdViewModel
        DataContext = DCtx
        ' InitializeComponent() çağrısından sonra başlangıç değer ekleyin.

    End Sub

End Class
