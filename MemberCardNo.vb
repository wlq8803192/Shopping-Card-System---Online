Module MemberCardNo
    Public Function GetFullCardNo(ByVal sMemberCardNo As String) As String
        '根据传入的15位会员卡号，返回包括校验位的16位会员卡号
        '1. 先取其中第3,5,7,9,11,13,15位数字，乘2。得出的数不足7位前面补0 
        Dim iPart1 As Integer = 0
        For bChar As Byte = 0 To 6
            iPart1 += CInt(sMemberCardNo.Substring(14 - bChar * 2, 1)) * 10 ^ bChar
        Next
        Dim sPart1 As String = (iPart1 * 2).ToString
        If sPart1.Length < 7 Then sPart1 = StrDup(7 - sPart1.Length, "0") & sPart1
        '2. 再取第2,4,6,8,10,12,14位数字，得出每位数字相加的结果
        Dim iTotalNum As Integer = 0
        For bChar As Byte = 0 To 6
            iTotalNum += CInt(sMemberCardNo.Substring(13 - bChar * 2, 1))
        Next
        '3. 把第2项得出的结果加上第一项得出结果的各位数字的总合相加
        For bChar As Byte = 0 To 6
            iTotalNum += CInt(sPart1.Substring(6 - bChar, 1))
        Next
        '4. 取第三项得出结果的最后位，根据下列对应数字关系得到校验位
        iTotalNum -= Int(iTotalNum / 10) * 10
        iTotalNum = 10 - iTotalNum
        If iTotalNum = 10 Then iTotalNum = 0
        Return sMemberCardNo & iTotalNum.ToString
    End Function
End Module
