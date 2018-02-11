Public Class frmInvoiceCancellation

    Private Sub frmInvoiceCancellation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txbInvoiceNo.Select()
        Me.txbInvoiceNo.SelectAll()
    End Sub

    Private Sub txbInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbInvoiceNo.KeyDown
        If e.Control OrElse e.Alt OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Back OrElse e.KeyCode = Keys.Delete Then Return
        If e.Shift Then e.SuppressKeyPress = True : Return
        If (e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9) Then
            If Me.txbInvoiceNo.SelectedText.Length > 0 AndAlso Me.txbInvoiceNo.SelectedText.Length = Me.txbInvoiceNo.Text.Length Then Me.txbInvoiceNo.Text = ""
            Return
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub txbInvoiceNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbInvoiceNo.TextChanged
        Me.btnOK.Enabled = (Me.txbInvoiceNo.Text.Trim <> "")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim sInvoiceNo As String = Me.txbInvoiceNo.Text.Trim
        Me.txbInvoiceNo.Text = sInvoiceNo
        If Not IsNumeric(sInvoiceNo) OrElse sInvoiceNo.Length <> 8 Then
            MessageBox.Show("��Ʊ����������� 8 λ������ɣ�    ", "��Ʊ����Ƿ���", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txbInvoiceNo.Select() : Me.txbInvoiceNo.SelectAll()
            Me.btnOK.Enabled = False : Return
        End If

        Me.Cursor = Cursors.WaitCursor
        frmMain.statusText.Text = "�������Ϸ�Ʊ����"
        frmMain.statusMain.Refresh()

        Dim objInvoice As Object = Nothing, sResult As String = ""
        Try
            objInvoice = CreateObject("PZHPrj.ComDLL")
            sResult = objInvoice.InvalidRegistry(sInvoiceNo, frmMain.sLoginUserRealName)
            If sResult = "0" Then
                sResult = objInvoice.SendData()
                If sResult = "0" Then
                    frmMain.statusText.Text = "������"
                Else
                    MessageBox.Show("��Ʊ�����ϣ���δ�ܽ����ݼ�ʱ���͵�˰��ַ������������Ǿ���Ĵ�����ʾ��    " & Chr(13) & Chr(13) & sResult.Substring(sResult.IndexOf(",") + 1) & "    " & Chr(13) & Chr(13) & "���η������ƹ��ϣ�����ϵ����IT��������������á�    ", "δ����Ʊ�������ݼ�ʱ���͵�˰��ַ�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    frmMain.statusText.Text = "δ����Ʊ�������ݼ�ʱ���͵�˰��ַ�������"
                End If
            Else
                MessageBox.Show("���Ϸ�Ʊʱ���ִ��󣡴�����룺" & sResult & "��    ", "�޷����ϵ�ǰ�ķ�Ʊ���룡", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                frmMain.statusText.Text = "���Ϸ�Ʊʧ�ܣ�"
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("���Ϸ�Ʊʱ���ִ��������Ǿ���Ĵ�����ʾ��    " & Chr(13) & Chr(13) & ex.Message & Space(4), "���Ϸ�Ʊʧ�ܣ�", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            frmMain.statusText.Text = "���Ϸ�Ʊʧ�ܣ�"
        End Try
        objInvoice = Nothing
        Me.Cursor = Cursors.Default
    End Sub
End Class