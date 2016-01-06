Public Class frmConvertUnit

    Private Sub ButNM3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButNM3.Click
        On Error Resume Next
        txtnm.Text = txtKg.Text / txtMole.Text * 22.4

        'NEXTLINE:
        ' MsgBox("Wrong Variable")
    End Sub

    Private Sub ButM3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButM3.Click
        On Error Resume Next
        txtm3.Text = txtKg.Text / txtDesity.Text
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub
End Class