
Imports System.Data
Imports System.Data.SqlClient


Public Class frmAddNewDataSafetyValve
    Public connectstring As String
    Public conn As SqlConnection

    Public strTag As String
    Public douFlowW
    Public douTempC
    Public douSetP
    Public douTotalBackP
    Public douOverP
    Public douK
    Public douSpGr
    Public douMole
    Public strRupture As String
    Public strPhase As String
    Public douAreaSize
    Public douZ
    Public douCaseNo
    Public strDesignation As String




    Private Sub LabelMOLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelMOLE.Click

    End Sub

    Private Sub LabelC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LabelZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelZ.Click

    End Sub

    Private Sub ComboPhase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPhase.SelectedIndexChanged
        Labelk.Visible = True
        Textk.Visible = True
        LabelMOLE.Visible = True
        LabelZ.Visible = True
        TextZ.Visible = True
        TextMOLE.Visible = True
        labSpGr.Visible = True
        txtSpGr.Visible = True

        If ComboPhase.SelectedIndex >= 0 Then

            If ComboPhase.Items(ComboPhase.SelectedIndex) = "L" Then
                LabelMOLE.Visible = False
                Labelk.Visible = False
                LabelZ.Visible = False
                TextZ.Visible = False
                Textk.Visible = False
                TextMOLE.Visible = False

            Else
                labSpGr.Visible = False
                txtSpGr.Visible = False

            End If
        End If

    End Sub


    Private Sub ButtonEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEXIT.Click
        Me.Close()
        MDISizingGroup.Show()
    End Sub

    Private Sub ButtonADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonADD.Click

        strTag = UCase(TextTag.Text)

        If TextRequireP.Text = "" Then
            douFlowW = "default"
        Else
            douFlowW = CDbl(TextRequireP.Text)
        End If

        If TextTEMP.Text = "" Then
            douTempC = "default"
        Else
            douTempC = CDbl(TextTEMP.Text)
        End If

        If TextSETP.Text = "" Then
            douSetP = "default"
        Else
            douSetP = CDbl(TextSETP.Text)
        End If

        If TextTotalP.Text = "" Then
            douTotalBackP = "default"
        Else
            douTotalBackP = CDbl(TextTotalP.Text)
        End If

        If TextOP.Text = "" Then
            douOverP = "default"
        Else
            douOverP = CDbl(TextOP.Text)
        End If

        If txtCaseNo.Text = "" Then
            douCaseNo = "default"
        Else
            douCaseNo = CDbl(txtCaseNo.Text)
        End If

        If txtSpGr.Text = "" Then
            douSpGr = "default"
        Else
            douSpGr = CDbl(txtSpGr.Text)
        End If


        If ComboPhase.SelectedIndex < 0 Then
            douK = "default"
            douMole = "default"
            douZ = "default"
        Else

            If ComboPhase.Items(ComboPhase.SelectedIndex) = "L" Then
                douK = "default"
                douMole = "default"
                douZ = "default"

            Else
                If Textk.Text = "" Then
                    douK = "default"
                Else
                    douK = CDbl(Textk.Text)
                End If

                If TextMOLE.Text = "" Then
                    douMole = "default"
                Else
                    douMole = CDbl(TextMOLE.Text)
                End If

                If TextZ.Text = "" Then
                    douZ = "default"
                Else
                    douZ = CDbl(TextZ.Text)
                End If


            End If
        End If

        If ComboRupture.SelectedIndex < 0 Then
            strRupture = ""
        Else
            strRupture = ComboRupture.Items(ComboRupture.SelectedIndex)
        End If

        If ComboPhase.SelectedIndex < 0 Then
            strPhase = ""
        Else
            strPhase = ComboPhase.Items(ComboPhase.SelectedIndex)
        End If

        douAreaSize = "default"
        strDesignation = ""

        Dim strTablename As String

        strTablename = MDISizingGroup.oProjectname.ToString
        Dim cmd As New SqlCommand

        connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strOpenSQLtABLE As String = "SELECT * FROM " & strTablename & " where TAG =" & "'" & strTag & "' and CaseNo='" & douCaseNo & "'"
        Dim set2 As New DataSet
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(strOpenSQLtABLE, conn)
        adp2.Fill(set2, "excel")

        Dim set2rowcount As Integer
        set2rowcount = set2.Tables(0).Rows.Count
        If set2rowcount > 0 Then
            MsgBox("TAG NAME IS Unique")
            Call ButtonEXIT_Click(sender, e)
            Exit Sub
        End If

        '查詢資料

        cmd.CommandText = "INSERT INTO " & strTablename & " (Tag,RequiredCapacity,TemperatureC," & _
                                           "SetPressure, TotalBackPressure, OverPressure," & _
                                             "k,SpGr, MOLE,Rupture,Phase,Areasizein,z,CaseNo,Designation)" & _
                          "VALUES ('" & strTag & "', " & douFlowW & " ," & douTempC & "," & _
                                   "" & douSetP & "," & douTotalBackP & "," & _
                                   "" & douOverP & "," & douK & "," & douSpGr & "," & _
                                   "" & douMole & ",'" & strRupture & "','" & strPhase & "'," & douAreaSize & "," & _
                                   "" & douZ & "," & douCaseNo & ",'" & strDesignation & "')"
        ' conn.Open()
        cmd.Connection = conn
        '執行資料庫指令SqlCommand
        cmd.ExecuteNonQuery()


        ToolStripStatusLabelsAVETYVALVE.Text = "Finish"
        conn.Close()

        MDISizingGroup.SafetyValveMenuItem1.PerformClick()

        TextRequireP.Text = ""
        TextTEMP.Text = ""
        TextSETP.Text = ""
        TextTotalP.Text = ""
        TextOP.Text = ""
        TextMOLE.Text = ""
        TextZ.Text = ""
        Textk.Text = ""
        txtSpGr.Text = ""
        txtCaseNo.Text = ""
    End Sub


    Private Sub frmAddNewDataSafetyValve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LabelTEMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelTEMP.Click

    End Sub

    Private Sub Labelk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Labelk.Click

    End Sub
End Class