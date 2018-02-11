Module CustomerIDNo
    Public Function GetFullIDNo(ByVal sCustomerIDNo As String) As String
        '根据传入的17位身份证号，返回包括校验位的18位身份证号
        Dim saVerifyCodes() As String = New String() {"1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2"}
        Dim baWeighs() As Byte = New Byte() {7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2}
        Dim iWeighTotal As Integer = 0
        For bDigit As Byte = 0 To 16
            iWeighTotal = iWeighTotal + CInt(sCustomerIDNo.Substring(bDigit, 1)) * baWeighs(bDigit)
        Next
        Dim bMode As Byte = iWeighTotal Mod 11
        Return sCustomerIDNo & saVerifyCodes(bMode)
    End Function
End Module
