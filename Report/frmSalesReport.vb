Public Class frmSalesReport

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmMain.menuDailyReport1.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmMain.menuDailyReport2.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmMain.menuDailyReport3.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmMain.menuDailyReport4.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmMain.menuDailyReport5.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmMain.menuDailyReport6.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmMain.menuMonthReport1.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmMain.menuMonthReport2.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        frmMain.menuMonthReport3.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        frmMain.menuMonthReport4.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnYearlyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYearlyReport.Click
        frmMain.menuYearlyReport.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        frmMain.menuDailybyCustomer.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        frmMain.menuFishReport.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
