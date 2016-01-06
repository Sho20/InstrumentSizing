

Imports System.Data
Imports System.Data.SqlClient


Public Class FrmAddNewOrifice

    Public connectstring As String
    Public conn As SqlConnection

    Public StrTagname As String
    Public douSG
    Public douDensity
    Public douInletp
    Public douFlowRate
    Public douCalculateFlowRate
    Public douMoleWeight
    Public douLosspMM
    Public StrPhase As String
    Public douTemp
    Public douPipeSize
    Public douOrificeSize
    Public douViscosity
    Public douReo
    Public douCalculateMode
    Public douPressureLoss  ''永久押損bar

    Private Sub ComboPhase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPhase.SelectedIndexChanged
        StrPhase = ComboPhase.Items(ComboPhase.SelectedIndex).ToString
        If StrPhase = "L" Then
            Label7.Visible = False
            TextDensity.Visible = False
            LabelUnit.Text = "M3/h"
            Label13.Visible = True
            TextGravity.Visible = True

            ''''''''''Liquid 沒有密度
        Else
            Label13.Visible = False
            TextGravity.Visible = False

            Label7.Visible = True
            TextDensity.Visible = True

            LabelUnit.Text = "Kg/h"
        End If

    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click

    End Sub

    Private Sub TextGravity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGravity.TextChanged

    End Sub

    Private Sub FrmAddNewOrifice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        StrTagname = UCase(TextTag.Text)

        douOrificeSize = 0
        douReo = 0

        If TextGravity.Text = "" Then
            douSG = "default"
        Else
            douSG = CDbl(TextGravity.Text)
        End If

        If TextTemp.Text = "" Then
            douTemp = "default"
        Else
            douTemp = CDbl(TextTemp.Text)
        End If

        If TextInletP.Text = "" Then
            douInletp = "default"
        Else
            douInletp = CDbl(TextInletP.Text)
        End If

        If TextFL.Text = "" Then
            douFlowRate = "default"
        Else
            douFlowRate = CDbl(TextFL.Text)
        End If

        If TextCalculateFL.Text = "" Then
            douCalculateFlowRate = "default"
        Else
            douCalculateFlowRate = CDbl(TextCalculateFL.Text)
        End If


        If TextDensity.Text = "" Then
            douDensity = "default"
        Else
            douDensity = CDbl(TextDensity.Text)
        End If

        If TextMoleW.Text = "" Then
            douMoleWeight = "default"
        Else
            douMoleWeight = CDbl(TextMoleW.Text)
        End If

        If TextPipeInletD.Text = "" Then
            douPipeSize = "default"
        Else
            douPipeSize = CDbl(TextPipeInletD.Text)
        End If

        If TextLossmm.Text = "" Then
            douLosspMM = "default"
        Else
            douLosspMM = CDbl(TextLossmm.Text)
        End If

        If txtVisocity.Text = "" Then
            douViscosity = "default"
        Else
            douViscosity = CDbl(txtVisocity.Text)
        End If


        If ComboPhase.SelectedIndex < 0 Then
            douDensity = "default"
            douSG = "default"
        Else

            If ComboPhase.Items(ComboPhase.SelectedIndex) = "L" Then
                douDensity = "default"

            Else
                  douSG = "default"

            End If
        End If

        If ComboPhase.SelectedIndex < 0 Then
            StrPhase = ""
        Else
            StrPhase = ComboPhase.Items(ComboPhase.SelectedIndex)
        End If

        If ComboCalculateMode.SelectedIndex < 0 Then
            douCalculateMode = 1
        Else

            If ComboCalculateMode.SelectedItem = "BoreSize" Then
                douCalculateMode = 1

            ElseIf ComboCalculateMode.SelectedItem = "FlowRate" Then

                douCalculateMode = 2

            ElseIf ComboCalculateMode.SelectedItem = "LossPressure" Then

                douCalculateMode = 3
            End If

        End If




        douOrificeSize = "default"
        douPressureLoss = "default"

        Dim strTablename As String

        strTablename = MDISizingGroup.oProjectname.ToString
        Dim cmd As New SqlCommand

        connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strOpenSQLtABLE As String = "SELECT * FROM " & strTablename & " where TAG =" & "'" & StrTagname & "'"
        Dim set2 As New DataSet
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(strOpenSQLtABLE, conn)
        adp2.Fill(set2, "excel")

        Dim set2rowcount As Integer
        set2rowcount = set2.Tables(0).Rows.Count
        If set2rowcount > 0 Then
            MsgBox("TAG NAME IS Unique")
            Call ButtonExit_Click(sender, e)
            Exit Sub
        End If

        '查詢資料

        cmd.CommandText = "Insert Into " & strTablename & "(Tag,Phase,FlowRate,CalculateFlowRate,InletPressure,LossPmmWC,Gravity,Density,Mole,TemperatureC,PipeInletD,OrificeBore,Viscosity,Reo,CalculateMode,PressureLoss)" & _
                        "Values( '" & StrTagname & "','" & StrPhase & "'," & douFlowRate & "," & douCalculateFlowRate & "," & douInletp & "," & _
                        "" & douLosspMM & "," & douSG & "," & douDensity & "," & douMoleWeight & "," & douTemp & "," & _
                            "" & douPipeSize & "," & douOrificeSize & "," & douViscosity & "," & douReo & "," & douCalculateMode & "," & douPressureLoss & ")"



        cmd.Connection = conn
        '執行資料庫指令SqlCommand
        cmd.ExecuteNonQuery()


        ToolStripStatusLabel1.Text = "Finish"
        conn.Close()

        MDISizingGroup.OrToolStripMenuItem.PerformClick()

        TextTag.Text = ""
        TextGravity.Text = ""
        TextInletP.Text = ""
        TextFL.Text = ""
        TextCalculateFL.Text = ""
        TextDensity.Text = ""
        TextMoleW.Text = ""
        TextTemp.Text = ""
        TextPipeInletD.Text = ""
        TextLossmm.Text = ""
        txtVisocity.Text = ""
    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
        MDISizingGroup.Show()
    End Sub

    
    Private Sub TextPipeInletD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPipeInletD.TextChanged

    End Sub

    Private Sub TextInletP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextInletP.TextChanged

    End Sub
End Class