

Imports System.Data
Imports System.Data.SqlClient


Public Class FrmAddNewRestrictPlate

    Public connectstring As String
    Public conn As SqlConnection

    Public StrTagname As String
    Public douSG
    Public douDensity
    Public douInletp
    Public douMaxFlowRate
    Public douMoleWeight
    Public douLosspMM
    Public StrPhase As String
    Public douTemp
    Public douPipeSize
    Public douOrificeSize
    Public douCalculateMode




    Private Sub ComboPhase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPhase.SelectedIndexChanged
        StrPhase = ComboPhase.Items(ComboPhase.SelectedIndex).ToString
        If StrPhase = "L" Then
            Label7.Visible = False
            TextDensity.Visible = False

            Label13.Visible = True
            TextGravity.Visible = True

            LabelUnit.Text = "M3/h"
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


        If TextCalculateFL.Text = "" Then
            douMaxFlowRate = "default"
        Else
            douMaxFlowRate = CDbl(TextCalculateFL.Text)
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
            douCalculateMode = "default"
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


        Dim strTablename As String

        strTablename = MDISizingGroup.oProjectname.ToString
        Dim cmd As New SqlCommand

        connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strOpenSQLtABLE As String = "SELECT * FROM " & strTablename & " where TAG =" & "'" & StrTagname & "'" '''''''判斷是否唯一
        Dim set2 As New DataSet
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(strOpenSQLtABLE, conn)
        adp2.Fill(set2, "excel")


        '查詢資料

        cmd.CommandText = "Insert Into " & strTablename & "(Tag,Phase,MaxFlowRate,InletPressure,LossPressure,Gravity,Density,Mole,TemperatureC,PipeInletD,OrificeBore,CalculateMode)" & _
                        "Values( '" & StrTagname & "','" & StrPhase & "'," & douMaxFlowRate & "," & douInletp & "," & _
                        "" & douLosspMM & "," & douSG & "," & douDensity & "," & douMoleWeight & "," & douTemp & "," & _
                            "" & douPipeSize & "," & douOrificeSize & "," & douCalculateMode & ")"



        cmd.Connection = conn
        '執行資料庫指令SqlCommand
        cmd.ExecuteNonQuery()


        ToolStripStatusLabel1.Text = "Finish"
        conn.Close()

        MDISizingGroup.BROWSERestrictPlateToolStripMenuItem.PerformClick()

        TextTag.Text = ""
        TextGravity.Text = ""
        TextInletP.Text = ""
        TextCalculateFL.Text = ""
        TextDensity.Text = ""
        TextMoleW.Text = ""
        TextTemp.Text = ""
        TextPipeInletD.Text = ""
        TextLossmm.Text = ""

    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
        MDISizingGroup.Show()
    End Sub


    Private Sub ComboCalculateMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCalculateMode.SelectedIndexChanged


    End Sub

    Private Sub TextCalculateMode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextInletP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextInletP.TextChanged

    End Sub
End Class