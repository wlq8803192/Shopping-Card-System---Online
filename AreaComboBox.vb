Public Class AreaComboBox
    Inherits ComboBox

    Private sAreaID As String = "", sAreaCode As String = "", sSortCode As String = "", blSkipDeal As Boolean = False

    Public ReadOnly Property SelectedAreaID() As String
        Get
            Return sAreaID
        End Get
    End Property

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        If frmDropDownArea.Visible = True Then frmDropDownArea.Visible = False
        If MyBase.Text.IndexOf(" ") = 4 AndAlso MyBase.SelectionStart + MyBase.SelectionLength > 4 Then
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = 4
        End If
        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        My.Computer.Clipboard.Clear()
        sAreaCode = MyBase.Text
        If sAreaCode.IndexOf(" ") = 4 Then
            sAreaCode = sAreaCode.Substring(0, 4)
            Try
                sAreaID = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("AreaID").ToString
                sSortCode = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("SortCode").ToString
            Catch
                sAreaID = "" : sAreaCode = "" : sSortCode = ""
            End Try
        Else
            sAreaID = "" : sAreaCode = "" : sSortCode = ""
        End If
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        If frmDropDownArea.Visible = True Then
            If Not blSkipDeal Then
                Dim nextControl As Control = frmDropDownArea.GetChildAtPoint(frmDropDownArea.PointToClient(Control.MousePosition))
                If nextControl Is Nothing OrElse nextControl.Name <> "trvArea" Then
                    frmDropDownArea.Visible = False
                Else
                    MyBase.Select()
                End If
            End If
        End If
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not e.Control AndAlso Not e.Alt Then
            If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab OrElse e.KeyCode = Keys.H OrElse e.KeyCode = Keys.T OrElse e.KeyCode = Keys.R OrElse e.KeyCode = Keys.C OrElse e.KeyCode = Keys.S OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete OrElse (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
                MyBase.Tag = "Inputting"
                If e.KeyCode <> Keys.Enter AndAlso e.KeyCode <> Keys.Tab AndAlso e.KeyCode <> Keys.Left AndAlso e.KeyCode <> Keys.Right Then
                    Dim sText As String = MyBase.Text, sSelectedText As String = MyBase.SelectedText
                    Select Case e.KeyCode
                        Case Keys.H, Keys.T, Keys.R, Keys.C, Keys.S
                            If MyBase.SelectionStart <> 0 OrElse (sText.IndexOf(e.KeyData.ToString) = 0 AndAlso sSelectedText.IndexOf(e.KeyData.ToString) = -1) Then e.SuppressKeyPress = True
                        Case Keys.Up
                            MyBase.Tag = Nothing
                            Try
                                sAreaCode = frmMain.dtLoginStructure.Select("SortCode<'" & sSortCode & "'", "SortCode DESC")(0)("AreaCode").ToString
                                sSortCode = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("SortCode").ToString
                            Catch
                                sAreaCode = frmMain.dtLoginStructure.Rows(0)("AreaCode").ToString
                                sSortCode = frmMain.dtLoginStructure.Rows(0)("SortCode").ToString
                            End Try
                            MyBase.Text = sAreaCode
                            MyBase.SelectAll()
                        Case Keys.Down
                            MyBase.Tag = Nothing
                            If sSortCode = "" Then sSortCode = "999999999999999"
                            Try
                                sAreaCode = frmMain.dtLoginStructure.Select("SortCode>'" & sSortCode & "'", "SortCode")(0)("AreaCode").ToString
                                sSortCode = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("SortCode").ToString
                            Catch
                                sAreaCode = frmMain.dtLoginStructure.Rows(frmMain.dtLoginStructure.Rows.Count - 1)("AreaCode").ToString
                                sSortCode = frmMain.dtLoginStructure.Rows(frmMain.dtLoginStructure.Rows.Count - 1)("SortCode").ToString
                            End Try
                            MyBase.Text = sAreaCode
                            MyBase.SelectAll()
                        Case Keys.Back, Keys.Delete
                            blSkipDeal = True
                            Dim bStart As Byte = MyBase.SelectionStart
                            If MyBase.SelectionStart + MyBase.SelectionLength > 4 Then
                                sText = ""
                                bStart = 0
                            Else
                                If sText.IndexOf(" ") = 4 Then sText = sText.Substring(0, 4)
                                If sSelectedText <> "" Then
                                    sText = sText.Remove(bStart, sSelectedText.Length)
                                ElseIf e.KeyCode = Keys.Back Then
                                    bStart -= 1
                                    sText = sText.Remove(bStart, 1)
                                Else
                                    sText = sText.Remove(bStart, 1)
                                End If
                            End If
                            MyBase.Text = sText
                            MyBase.SelectionLength = 0
                            MyBase.SelectionStart = bStart
                            blSkipDeal = False
                            sAreaID = "" : sAreaCode = "" : sSortCode = ""
                            If frmDropDownArea.Visible = True AndAlso frmDropDownArea.trvArea.SelectedNode IsNot Nothing Then
                                frmDropDownArea.trvArea.SelectedNode.BackColor = SystemColors.Window
                                frmDropDownArea.trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                                frmDropDownArea.trvArea.SelectedNode = Nothing
                            End If
                            e.SuppressKeyPress = True
                        Case Else
                            If MyBase.SelectionStart + MyBase.SelectionLength - sSelectedText.Length >= 4 Then e.SuppressKeyPress = True
                    End Select
                End If
            Else
                e.SuppressKeyPress = True
            End If
        End If

        MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        My.Computer.Clipboard.Clear()
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        If MyBase.Text.IndexOf(" ") = 4 AndAlso MyBase.SelectionStart + MyBase.SelectionLength > 4 Then
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = 4
        End If
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        If blSkipDeal Then Return
        If frmDropDownArea.Visible = True AndAlso frmDropDownArea.trvArea.Focused = True Then
            sAreaCode = MyBase.Text.ToUpper
            sAreaCode = sAreaCode.Substring(0, sAreaCode.IndexOf(" "))
            sAreaID = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("AreaID").ToString
            sSortCode = frmMain.dtLoginStructure.Select("AreaCode='" & sAreaCode & "'")(0)("SortCode").ToString
        ElseIf frmMain.dtLoginStructure IsNot Nothing AndAlso frmMain.dtLoginStructure.Rows.Count > 0 Then
            If frmDropDownArea.Visible = True Then frmDropDownArea.blSkipDeal = True
            blSkipDeal = True
            sAreaCode = MyBase.Text.ToUpper
            If sAreaCode.IndexOf(" ") > -1 Then sAreaCode = sAreaCode.Substring(0, sAreaCode.IndexOf(" "))
            If sAreaCode = "" Then
                sAreaID = ""
                sSortCode = ""
                MyBase.Text = ""
            Else
                Dim drAreas() As DataRow = frmMain.dtLoginStructure.Select("SUBSTRING(AreaCode,1," & sAreaCode.Length & ")='" & sAreaCode & "'", "SortCode")
                If drAreas.Length = 0 Then
                    If sAreaCode.Length = 4 Then
                        MyBase.Text = sAreaCode & " " & "（找不到此区域单元！）"
                        MyBase.SelectionLength = 4
                        MyBase.SelectionStart = 0
                    Else
                        MyBase.Text = sAreaCode
                        MyBase.SelectionLength = 0
                        MyBase.SelectionStart = sAreaCode.Length
                    End If
                    sAreaID = "" : sAreaCode = "" : sSortCode = ""
                    If frmDropDownArea.Visible = True AndAlso frmDropDownArea.trvArea.SelectedNode IsNot Nothing Then
                        frmDropDownArea.trvArea.SelectedNode.BackColor = SystemColors.Window
                        frmDropDownArea.trvArea.SelectedNode.ForeColor = SystemColors.ControlText
                        frmDropDownArea.trvArea.SelectedNode = Nothing
                    End If
                Else
                    Dim bStart As Byte = MyBase.SelectionStart, sOldCode As String = sAreaCode
                    sAreaCode = drAreas(0)("AreaCode").ToString
                    sAreaID = drAreas(0)("AreaID").ToString
                    sSortCode = drAreas(0)("SortCode").ToString
                    MyBase.Text = drAreas(0)("AreaFullName").ToString
                    MyBase.SelectionLength = sAreaCode.Length - sOldCode.Length
                    MyBase.SelectionStart = bStart
                    If frmDropDownArea.Visible = True Then
                        frmDropDownArea.trvArea.SelectedNode = frmDropDownArea.trvArea.Nodes.Find(sAreaCode, True)(0)
                        frmDropDownArea.trvArea.SelectedNode.EnsureVisible()
                        frmDropDownArea.trvArea.SelectedNode.BackColor = SystemColors.Highlight
                        frmDropDownArea.trvArea.SelectedNode.ForeColor = SystemColors.HighlightText
                    End If
                End If
            End If
            blSkipDeal = False
            If frmDropDownArea.Visible = True Then frmDropDownArea.blSkipDeal = False
        End If
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            If m.Msg = &H201 Then '按下鼠标左键时
                If frmDropDownArea.Visible = True Then
                    frmDropDownArea.Hide()
                    MyBase.FindForm.Select()
                    MyBase.Select()
                Else
                    MyBase.WndProc(m)
                End If
            ElseIf m.Msg = &H154 Then '即将出现下拉框时
                If frmMain.dtLoginStructure IsNot Nothing Then
                    Dim startPoint As Point = MyBase.PointToScreen(New Point(0, 0))
                    Dim iHeight As Int16 = frmMain.dtLoginStructure.Rows.Count * 18 + 2, iUpHeight = startPoint.Y, iDownHeight As Int16 = My.Computer.Screen.WorkingArea.Height - startPoint.Y - MyBase.Height
                    Dim iTop As Int16 = startPoint.Y + MyBase.Height
                    If iHeight > iDownHeight Then
                        If iUpHeight > iDownHeight Then
                            iHeight = iUpHeight
                            iTop = startPoint.Y - iHeight
                        Else
                            iHeight = iDownHeight
                        End If
                    End If
                    frmDropDownArea.Size = New Size(IIf(MyBase.Width < 154, 154, MyBase.Width), iHeight)
                    frmDropDownArea.Location = New Point(startPoint.X, iTop)
                End If

                blSkipDeal = True
                frmDropDownArea.Show()
                MyBase.FindForm.Select()
                MyBase.Select()
                blSkipDeal = False
            Else
                MyBase.WndProc(m)
            End If
        Catch
        End Try
    End Sub
End Class
