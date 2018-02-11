Module ShoppingCardNo
    Public Function GetFullCardNo(ByVal sCardNo As String) As String
        '根据传入的18位卡号，返回包括校验位的19位卡号
        Dim bLength As Byte = sCardNo.Length - 1, bDigit As Byte, bNum As Byte, iTotalNum As Integer = 0
        For bDigit = 0 To bLength
            bNum = CByte(sCardNo.Substring(bDigit, 1))
            If (bDigit + 1) Mod 2 = 0 Then bNum = bNum * 2 '左起从1开始，位数除以2求模，如果结果为0，则将该位数的数值乘以2
            If bNum >= 10 Then bNum = bNum - 9 '如果该位数的数值乘以2结果大于10，则将该结果减去9
            iTotalNum = iTotalNum + bNum ' 将所有位数(即卡号前18位)算出来的结果求和
        Next
        iTotalNum = 10 - (iTotalNum Mod 10) ' 将求和的结果除以10求模，再用10减去该数值
        If iTotalNum = 10 Then iTotalNum = 1 ' 如果得出的结果等于10，则去除右侧的0，保留1
        Return sCardNo & iTotalNum.ToString ' 传入的18位卡号+卡号第19位(校验位)=完整19位卡号
    End Function
End Module
