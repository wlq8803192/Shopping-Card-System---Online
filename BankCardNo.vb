Module BankCardNo
    Public Function GetFullCardNo(ByVal sBankCardNo As String) As String
        '根据传入的15或18位银行卡号，返回包括校验位的16或19位银行卡号
        Dim bLength As Byte = sBankCardNo.Length - 1, bDigit As Byte = 0, bNum As Byte, iTotalNum As Integer = 0
        For iDigit As Int16 = bLength To 0 Step -1
            bDigit += 1
            bNum = CByte(sBankCardNo.Substring(iDigit, 1))
            If bDigit Mod 2 = 1 Then '如果是奇数位
                bNum = bNum * 2
                If bNum > 9 Then bNum -= 9
            End If
            iTotalNum += bNum
        Next
        iTotalNum = 10 - (iTotalNum Mod 10) ' 将求和的结果除以10求模，再用10减去该数值
        If iTotalNum = 10 Then iTotalNum = 0
        Return sBankCardNo & iTotalNum.ToString
    End Function
End Module
