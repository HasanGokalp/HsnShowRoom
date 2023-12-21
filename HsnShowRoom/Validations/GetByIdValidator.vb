Public Class GetByIdValidator
    Inherits ValidationRule

    Public Overrides Function Validate(value As Object, cultureInfo As Globalization.CultureInfo) As ValidationResult

        Dim inputString As String = TryCast(value, String)

        ' Girdi boş mu kontrol edin
        If String.IsNullOrWhiteSpace(inputString) Then
            Return New ValidationResult(False, "Lütfen boş bırakmayınız.")
        End If

        ' Girdi sayısal bir değer mi kontrol edin
        Dim number As Integer
        If Integer.TryParse(inputString, number) Then
            Return New ValidationResult(False, "Lütfen sayısal olmayan bir değer giriniz.")
        End If

        ' Her iki koşulu da geçtiyse, girdi geçerlidir.
        Return ValidationResult.ValidResult

        'Dim inputString As String = DirectCast(value, String)
        'If String.IsNullOrEmpty(inputString) Then
        '    Return New ValidationResult(False, "Lütfen boş.")
        'End If

        'Dim number As Integer
        'If Not Integer.TryParse(inputString, number) Then
        '    Return New ValidationResult(False, "Lütfen geçerli.")
        'End If

        '' Burada ek olarak, sayının belirli bir aralıkta olup olmadığını kontrol edebilirsiniz.
        '' Örnek:
        '' If number < 0 OrElse number > 100 Then
        ''     Return New ValidationResult(False, "Sayı 0 ile 100 arasında olmalıdır.")
        '' End If

        'Return ValidationResult.ValidResult
    End Function
End Class
