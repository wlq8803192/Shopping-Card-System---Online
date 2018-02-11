Public Class frmSwitchMode

    Private Sub frmSwitchMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.IsInTraining Then
            If frmMain.blIsRollout Then
                If frmMain.blLockedTrainingMode Then
                    Me.rdbProducingMode.Checked = True
                    Me.rdbTrainingMode.Enabled = False
                Else
                    Me.pnlLockedTrainingMode.Visible = False
                    If frmMain.blNeedPrompt Then
                        Me.rdbProducingMode.Checked = True
                        frmMain.blNeedPrompt = False
                    Else
                        Me.rdbTrainingMode.Checked = True
                    End If
                End If
                Me.pnlNotRollout.Visible = False
            Else
                Me.rdbTrainingMode.Checked = True
                Me.pnlLockedTrainingMode.Visible = False
                Me.rdbProducingMode.Enabled = False
            End If
        Else
            Me.lblOperationMode.Text = "生产模式 Producing Mode"
            If frmMain.blIsRollout Then
                If frmMain.blLockedTrainingMode Then
                    Me.rdbTrainingMode.Enabled = False
                Else
                    Me.pnlLockedTrainingMode.Visible = False
                End If
                Me.rdbProducingMode.Checked = True
                Me.pnlNotRollout.Visible = False
            Else
                Me.rdbTrainingMode.Checked = True
                Me.pnlLockedTrainingMode.Visible = False
                Me.rdbProducingMode.Enabled = False
            End If
        End If
        Me.pnlPrompt.Visible = Me.btnOK.Enabled

        Me.grbSwitchMode.Height = Me.flpSwitchMode.Height + 19
        Me.Height = Me.grbSwitchMode.Height + 190
        Me.Location = New Point(Int((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2), Int((My.Computer.Screen.WorkingArea.Height - Me.Height) / 2))
    End Sub

    Private Sub rdbTrainingMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbTrainingMode.CheckedChanged
        If Me.rdbTrainingMode.Checked Then
            Me.rdbProducingMode.Checked = False
            Me.btnOK.Enabled = Not My.Settings.IsInTraining
        End If
    End Sub

    Private Sub lblTrainingMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTrainingMode.Click
        Me.rdbTrainingMode.PerformClick()
    End Sub

    Private Sub rdbProducingMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbProducingMode.CheckedChanged
        If Me.rdbProducingMode.Checked Then
            Me.rdbTrainingMode.Checked = False
            Me.btnOK.Enabled = My.Settings.IsInTraining
        End If
    End Sub

    Private Sub lblProducingMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProducingMode.Click
        Me.rdbProducingMode.PerformClick()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.rdbTrainingMode.Checked Then
            My.Settings.IsInTraining = True
        Else
            My.Settings.IsInTraining = False
        End If
        My.Settings.Save()
        frmMain.blNeedPrompt = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnOK_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.EnabledChanged
        Me.pnlPrompt.Visible = Me.btnOK.Enabled
    End Sub
End Class