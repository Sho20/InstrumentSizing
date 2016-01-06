Imports System.Data
Imports System.Data.SqlClient




Public Class FrmModifyControlValve

    Public connectstring As String
    Public conn As SqlConnection

    Public StrTagname As String
    Public douSG
    Public douMole

    Public douMinInletp
    Public douNorInletp
    Public douMaxInletp

    Public douMinDP
    Public douNorDP
    Public douMaxDP

    Public douFlowRate ''''''''''''''NOR
    Public douMinFlowRate ''''''''''''''MIN
    Public douMaxFlowRate ''''''''''''''MAX

    Public StrPhase As String
    Public douTemp
    Public StrUnits As String
    Public douCv ''''''''''''''''nor

    Public douMinCv ''''''''''''''''min
    Public douMaxCv ''''''''''''''''max


    Public douK
    Public douViscosity '''''''''''''viscosity
    Public douZ
    Public StrType As String
    Public douBodySize
    Public strCondition As String
    Public douLineSize
    Public douXt
    Public douNoise
    Public douVaporP
    Public douCriticalP

    Public douSelectCV
    Public strDPCondition As String
    Public douT







    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
        MDISizingGroup.Show()

    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click



        FillCell() '''''將一些值填入


        'comboDPcondition.Text = "NOR"
        strDPCondition = comboDPcondition.SelectedItem



        '''''''''''''''''''''這邊的是不可以讓user填的
        StrUnits = UCase(LabelUnit.Text)
        douCv = "default"
        douminCv = "default"
        doumaxCv = "default"
        douBodySize = "default"
        douNoise = "default"
        douSelectCV = "default"

        If ComboPhase.SelectedIndex < 0 Then
            douK = "default"
            douZ = "default"
        Else
            If ComboPhase.Items(ComboPhase.SelectedIndex) = "L" Then
                douK = "default"
                douZ = "default"
            Else
                If TextZ.Text = "" Then
                    douZ = "default"
                Else
                    douZ = CDbl(TextZ.Text)
                End If

                If TextK.Text = "" Then
                    douK = "default"
                Else
                    douK = CDbl(TextK.Text)
                End If

            End If

        End If

        If TextVISC.Text = "" Then
            douViscosity = "default"
        Else
            douViscosity = CDbl(TextVISC.Text)
        End If

        If ComboBodyType.SelectedIndex < 0 Then
            StrType = ""
        Else
            StrType = ComboBodyType.Items(ComboBodyType.SelectedIndex)
        End If


        Dim strTablename As String
        strTablename = MDISizingGroup.oProjectname.ToString

        connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strOpenSQLtABLE As String = "SELECT * FROM " & strTablename & " where TAG =" & "'" & StrTagname & "' "
        Dim set2 As New DataSet
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(strOpenSQLtABLE, conn)
        adp2.Fill(set2, "excel")

        Dim set2rowcount As Integer        ''''''''''''''''''判定是否是唯一
        set2rowcount = set2.Tables(0).Rows.Count
        If set2rowcount > 0 Then
            MsgBox("TAG NAME IS Unique")
            GoTo nextone
        End If



        '查詢資料
        Dim str As String = "Insert Into " & strTablename & "(Tag,SpecificGravity,Mole," & _
                            "MinInletp ,NorInletp,MaxInletp,MinDP,NorDP," & _
                            "MaxDP,MinFlowRate,NorFlowRate,MaxFlowRate,Unit," & _
                            "Phase, Temperature,K, Viscosity, Z ,Type,VaporPressure," & _
                            "CriticalPressure,MinCV,NorCV,MaxCV," & _
                            "LineSize,BodySize,SelectCV,Xt,DPcondition,Noise,LineWallT)" & _
            "Values( '" & StrTagname & "', " & douSG & " ," & douMole & "," & douMinInletp & "," & _
            "" & douNorInletp & "," & douMaxInletp & "," & douMinDP & "," & _
            "" & douNorDP & "," & douMaxDP & "," & douMinFlowRate & "," & _
            "" & douFlowRate & "," & douMaxFlowRate & "," & _
            "'" & StrUnits & "','" & StrPhase & "'," & douTemp & "," & douK & "," & _
            "" & douViscosity & "," & douZ & ",'" & StrType & "'," & douVaporP & "," & _
            "" & douCriticalP & "," & douMinCv & "," & douCv & "," & douMaxCv & "," & _
            "" & douLineSize & "," & douBodySize & "," & douSelectCV & "," & _
            "" & douXt & ",'" & strDPCondition & "'," & douNoise & "," & Trim(douT) & ")"

        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)


        'Dim str1 As String = "Insert Into 資料表(name,chi)Values('jack',90)"

        Dim cmd As SqlCommand = New SqlCommand(str, conn)

        '執行資料庫指令SqlCommand
        cmd.ExecuteNonQuery()

        ToolStripStatusLabel1.Text = "Finish Adding"

        conn.Close()

        MDISizingGroup.ControlValveToolStripMenuItem.PerformClick()

        TextFlowRate.Text = ""

nextone:
     
    End Sub
    Private Sub FillCell()


        StrTagname = UCase(TxtTagName.Text)

        If StrTagname = Nothing Or StrTagname = "" Or StrTagname = DBNull.Value.ToString Then '''''''必須要有tagnm才可執行程式
            MsgBox("Please Insert Tag Name")
            GoTo nextone
        End If

        If TextSGMOLE.Visible = True Then
            If TextSGMOLE.Text = Nothing Then
                douSG = "default"
            Else
                douSG = CDbl(TextSGMOLE.Text)
            End If
        Else
            douSG = "default"
        End If


        If txtMinInletP.Text = Nothing Then
            douMinInletp = "default"
        Else
            douMinInletp = CDbl(txtMinInletP.Text)
        End If

        If txtNorInletp.Text = Nothing Then
            douNorInletp = "default"
        Else
            douNorInletp = CDbl(txtNorInletp.Text)
        End If

        If txtMaxInletP.Text = Nothing Then
            douMaxInletp = "default"
        Else
            douMaxInletp = CDbl(txtMaxInletP.Text)
        End If



        If TextFlowRate.Text = Nothing Then
            douFlowRate = "default"
        Else
            douFlowRate = CDbl(TextFlowRate.Text)
        End If

        If TextTemp.Text = Nothing Then
            douTemp = "default"
        Else
            douTemp = CDbl(TextTemp.Text)
        End If

        If LabelUnit.Text = Nothing Then
            StrUnits = ""
        Else
            StrUnits = UCase(LabelUnit.Text)
        End If

        If LineSizeTxt.Text = Nothing Then
            douLineSize = "default"
        Else
            douLineSize = UCase(LineSizeTxt.Text)
        End If

        If txtLineArea.Text = Nothing Then
            douT = "default"
        Else
            douT = UCase(txtLineArea.Text)
        End If

        If TextXT.Text = Nothing Then
            douXt = "default"
        Else
            douXt = UCase(TextXT.Text)
        End If

        If txtVaporP.Visible = True Then
            If txtVaporP.Text = Nothing Then
                douVaporP = "default"
            Else
                douVaporP = CDbl(txtVaporP.Text)
            End If
        Else
            douVaporP = "default"
        End If


        If txtCriticalP.Visible = True Then

            If txtCriticalP.Text = Nothing Then
                douCriticalP = "default"
            Else
                douCriticalP = CDbl(txtCriticalP.Text)
            End If
        Else
            douCriticalP = "default"
        End If




        If TxtMinFL.Text = Nothing Then
            douMinFlowRate = "default"
        Else
            douMinFlowRate = CDbl(TxtMinFL.Text)
        End If

        If txtMaxFl.Text = Nothing Then
            douMaxFlowRate = "default"
        Else
            douMaxFlowRate = CDbl(txtMaxFl.Text)
        End If

        If TxtMole.Visible = True Then
            If TxtMole.Text = Nothing Then
                douMole = "default"
            Else
                douMole = CDbl(TxtMole.Text)
            End If
        Else
            douMole = "default"
        End If



        If txtMinDP.Text = Nothing Then
            douMinDP = "default"
        Else
            douMinDP = CDbl(txtMinDP.Text)
        End If

        If txtNorDP.Text = Nothing Then
            douNorDP = "default"
        Else
            douNorDP = CDbl(txtNorDP.Text)
        End If

        If txtMaxDP.Text = Nothing Then
            douMaxDP = "default"
        Else
            douMaxDP = CDbl(txtMaxDP.Text)
        End If

nextone:
    End Sub
    Private Sub ComboPhase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPhase.SelectedIndexChanged
        StrPhase = ComboPhase.Items(ComboPhase.SelectedIndex).ToString
        LabelK.Visible = True
        LabelZ.Visible = True
        TextK.Visible = True
        TextZ.Visible = True
        Label8.Visible = True
        Label17.Visible = True
        Label20.Visible = True

        If StrPhase = "G" Then
        
            LabelUnit.Text = "NM3"
            LabelMINUNIT.Text = "NM3"
            LabelUNITMAX.Text = "NM3"


            LabelSG.Visible = False
            Label10.Visible = False
            Label13.Visible = False
            txtVaporP.Visible = False
            txtCriticalP.Visible = False
            Labelmole.Visible = True
            TextSGMOLE.Visible = False
            TxtMole.Visible = True

        ElseIf StrPhase = "L" Then
        
            LabelUnit.Text = "M3"
            LabelMINUNIT.Text = "M3"
            LabelUNITMAX.Text = "M3"

            LabelSG.Visible = True
            LabelK.Visible = False
            LabelZ.Visible = False
            TextK.Visible = False
            TextZ.Visible = False
            Label10.Visible = True
            Label13.Visible = True
            txtVaporP.Visible = True
            txtCriticalP.Visible = True
            Labelmole.Visible = False
            TxtMole.Visible = False
            TextSGMOLE.Visible = True

        ElseIf StrPhase = "S" Then

            LabelUnit.Text = "KG"
            LabelMINUNIT.Text = "KG"
            LabelUNITMAX.Text = "KG"
            LabelSG.Visible = False
            txtVaporP.Visible = False
            txtCriticalP.Visible = False
            Labelmole.Visible = True
            TextSGMOLE.Visible = False
            TxtMole.Visible = True
        End If
        StrUnits = LabelSG.Text

    End Sub




    Private Sub ComboBodyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBodyType.SelectedIndexChanged
        Dim selectBodyType As String

        If ComboBodyType.Text <> Nothing Then
            TextXT.ReadOnly = False

            selectBodyType = ComboBodyType.SelectedItem.ToString
            If selectBodyType = "GLOBE" Then
                CheckXT.Checked = True
                TextXT.Text = 0.621
                TextXT.ReadOnly = True
            ElseIf selectBodyType = "ANGLE" Then
                CheckXT.Checked = True
                TextXT.Text = 0.5736
                TextXT.ReadOnly = True

            ElseIf selectBodyType = "BALL" Then
                CheckXT.Checked = True
                TextXT.Text = 0.621
                TextXT.ReadOnly = True

            ElseIf selectBodyType = "BUTTERFLY" Then
                CheckXT.Checked = True
                TextXT.Text = 0.68
                TextXT.ReadOnly = True
            Else
                CheckXT.Checked = False
                TextXT.Text = ""
                TextXT.ReadOnly = False
            End If
        Else
            MsgBox("Please define body type")
            CheckXT.Checked = False
        End If

    


    End Sub

    Private Sub RadioXT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextXT.TextChanged

    End Sub

    Private Sub CheckXT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckXT.CheckedChanged
        If CheckXT.Checked = True Then
            Dim selectBodyType As String

            If ComboBodyType.Text <> Nothing Then


                selectBodyType = ComboBodyType.SelectedItem.ToString
                If selectBodyType = "GLOBE" Then
                    CheckXT.Checked = True
                    TextXT.Text = 0.621
                    TextXT.ReadOnly = True
                ElseIf selectBodyType = "ANGLE" Then
                    CheckXT.Checked = True
                    TextXT.Text = 0.5736
                    TextXT.ReadOnly = True

                ElseIf selectBodyType = "BALL" Then
                    CheckXT.Checked = True
                    TextXT.Text = 0.621
                    TextXT.ReadOnly = True

                ElseIf selectBodyType = "BUTTERFLY" Then
                    CheckXT.Checked = True
                    TextXT.Text = 0.68
                    TextXT.ReadOnly = True
                Else
                    CheckXT.Checked = False
                    TextXT.Text = ""
                    TextXT.ReadOnly = False
                End If
            Else
                MsgBox("Please define body type")
                CheckXT.Checked = False
            End If
        ElseIf CheckXT.Checked = False Then
            CheckXT.Checked = False
            TextXT.ReadOnly = False
        End If


    End Sub

   

    Private Sub TxtTagName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTagName.TextChanged
        ToolStripStatusLabel1.Text = ""  ''''清空add finish 字
    End Sub


 
    Private Sub ComboMASSorVolumeric_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConvert.Click
        frmConvertUnit.Show()
    End Sub
End Class