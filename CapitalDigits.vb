Public Class CapitalDigits
    Public Shared Function CapitalRMB(ByVal Num As Decimal) As String   ' 得到大写金额
        '----------------------------------------------------------------------
        Dim vNum, vDec, ret
        '------------------------------------------------------------------
        vNum = Right(Format$(Int(Num), "000000000000"), 12) ' 取十二位整数
        vDec = Right(Format$(Int(Num * 100), "00"), 2) ' 取小数点后两位
        '------------------------------------------------------------------
        ret = Num2RMB(Left(vNum, 4), "亿", False)
        If Len(ret) = 0 Then
            ret = Num2RMB(Mid(vNum, 5, 4), "万", False)
        Else
            ret = ret + Num2RMB(Mid(vNum, 5, 4), "万", True)
        End If
        If Len(ret) = 0 Then
            ret = Num2RMB(Right(vNum, 4), "圆", False)
        Else
            ret = ret + Num2RMB(Right(vNum, 4), "圆", True)
        End If
        '------------------------------------------------------------------
        If ret = "圆" Then ret = ""
        '------------------------------------------------------------------
        If vDec = "00" And ret <> "" Then
            Return ret + "整"
        Else
            If Left(vDec, 1) <> "0" Then
                ret = ret + Num2Char(Left(vDec, 1)) + "角"
            End If
            If Right(vDec, 1) <> "0" Then
                If Right(ret, 1) = "角" Then
                    ret = ret + Num2Char(Right(vDec, 1)) + "分"
                Else
                    If ret <> "" Then
                        ret = ret + "零" + Num2Char(Right(vDec, 1)) + "分"
                    Else
                        ret = Num2Char(Right(vDec, 1)) + "分"
                    End If
                End If
            End If
            Return ret
        End If
    End Function

    Private Shared Function Num2RMB(ByVal sFourBitString As String, Optional _
            ByVal sUnit As String = "圆", Optional ByVal bMustHeader As _
            Boolean = False) As String
        '----------------------------------------------------------------------
        Dim vNum, i, RX, BR, hdr
        '------------------------------------------------------------------
        BR = "仟佰拾圆"
        '------------------------------------------------------------------
        vNum = Trim(Str(Val(sFourBitString))) ' 最多四位
        '------------------------------------------------------------------
        If (Len(vNum) < 4 And Len(vNum) > 0) And bMustHeader Then hdr = "零" _
        Else hdr = ""
        RX = ""
        Do While Len(vNum) > 0
            i = Right(vNum, 1)
            If i > 0 Then
                RX = Num2Char(i) + Right(BR, 1) + RX
            Else
                If Left(RX, 1) <> "零" Then RX = "零" + RX
            End If
            vNum = Left(vNum, Len(vNum) - 1)
            BR = Left(BR, Len(BR) - 1)
        Loop
        RX = Left(RX, Len(RX) - 1)
        If Right(RX, 1) = "零" Then ' 去除多余的零
            RX = Left(RX, Len(RX) - 1)
        End If
        If Len(RX) > 0 Then
            Return hdr + RX + sUnit
        Else
            Return RX + IIf(sUnit = "圆", "圆", "")
        End If
    End Function

    Private Shared Function Num2Char(ByVal i As Integer) As String
        If i >= 0 And i <= 9 Then
            Return Mid$("零壹贰叁肆伍陆柒捌玖", i + 1, 1)
        Else
            Return ""
        End If
    End Function
End Class
