Imports System.Data
Imports System.Data.SqlClient




Public Class FrmModifyControlValverecord
    Public StrCurrentFunction As String

    Public strColumnName As String
    Public strEditText As String
    Public strUnit As String
    Public strTagNameText As String
    Public strOrigenText As String
    Public IntOriginColIndex As Integer
    Public IntOriginRowIndex As Integer

    Public connectstring As String
    Public updataCmd As New SqlCommand

    Public conn As New SqlConnection
    Public connUpdataUnit As New SqlConnection
    Public set1 As DataSet = New DataSet
    Public adp1 As SqlDataAdapter
    Public str As String
    Public strSizingMode As String
    Public strProjectNm As String = MDISizingGroup.oProjectname.ToString
    Public boolChangePhase As Boolean
    Public strCondition As String

    Public douCaseNo

    'Public connectstring As String
    'Public conn As SqlConnection

    Public StrTagname As String
    Public douSG
    Public douMole
    Public douInletp
    Public dououtletp
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
    Public douRO '''''''''''''viscosity
    Public douZ
    Public StrType As String
    Public douLineSize
    Public douBodySize
    Public douSelectCV

    Public douXt
    Public douNoise
    Public douVaporP
    Public douCriticalP






    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
        FrmModify.ShowDialog()
    End Sub

    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click



        StrTagname = UCase(TxtTagName.Text)

        If StrTagname = Nothing Or StrTagname = "" Or StrTagname = DBNull.Value.ToString Then '''''''必須要有tagnm才可執行程式
            MsgBox("Please Insert Tag Name")
            GoTo nextone
        End If

        If TextSGMOLE.Text = Nothing Then
            douSG = "default"
        Else
            douSG = CDbl(TextSGMOLE.Text)
        End If

        If TextInletp.Text = Nothing Then
            douInletp = "default"
        Else
            douInletp = CDbl(TextInletp.Text)
        End If

        If Textoutletp.Text = Nothing Then
            dououtletp = "default"
        Else
            dououtletp = CDbl(Textoutletp.Text)
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
            douLineSize = CDbl(LineSizeTxt.Text)
        End If

        If TextXT.Text = Nothing Then
            douXt = "default"
        Else
            douXt = CDbl(TextXT.Text)
        End If


        If txtVaporP.Text = Nothing Then
            douVaporP = "default"
        Else
            douVaporP = CDbl(txtVaporP.Text)
        End If



        If txtCriticalP.Text = Nothing Then
            douCriticalP = "default"
        Else
            douCriticalP = CDbl(txtCriticalP.Text)
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

        If TxtMole.Text = Nothing Then
            douMole = "default"
        Else
            douMole = CDbl(TxtMole.Text)
        End If


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
            douRO = "default"
        Else
            douRO = CDbl(TextVISC.Text)
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


        Dim str As String = "Update " & MDISizingGroup.oProjectname.ToString & _
        " set Tag ='" & UCase(StrTagname) & "',SpecificGravity= " & douSG & ",Mole=" & douMole & ",InletPressure=" & douInletp & _
        ",OutputPressure=" & dououtletp & ",MinFlowRate=" & douMinFlowRate & ",NorFlowRate=" & douFlowRate & _
        ",MaxFlowRate=" & douMaxFlowRate & ",Unit='" & UCase(StrUnits) & "'," & _
        "Phase = '" & StrPhase & "'," & "Temperature =" & douTemp & "," & _
        "K =" & douK & "," & "Viscosity =" & douRO & "," & _
        "Z =" & douZ & "," & "Type ='" & ComboBodyType.Text & "'," & _
        "VaporPressure = " & douVaporP & "," & "CriticalPressure =" & douCriticalP & "," & _
        "LineSize = " & douLineSize & "," & "Xt =" & douXt & _
        " where id='" & Trim(FrmModify.txtID.Text) & "'"



        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)


        'Dim str1 As String = "Insert Into 資料表(name,chi)Values('jack',90)"

        Dim cmd As SqlCommand = New SqlCommand(str, conn)

        '執行資料庫指令SqlCommand
        cmd.ExecuteNonQuery()

        ToolStripStatusLabel1.Text = "Finish Modifying"

        conn.Close()

        TextFlowRate.Text = ""

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

            Label10.Visible = False
            Label13.Visible = False
            LabelSG.Visible = False
            txtVaporP.Visible = False
            txtCriticalP.Visible = False
            Labelmole.Visible = True
            TextSGMOLE.Visible = False
            TxtMole.Visible = True
            LabelSG.Visible = False

        End If
        StrUnits = LabelSG.Text

    End Sub




    Private Sub ComboBodyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBodyType.SelectedIndexChanged

    End Sub

    Private Sub RadioXT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextXT.TextChanged

    End Sub

    Private Sub CheckXT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckXT.CheckedChanged
        If CheckXT.Checked = True Then
            Dim selectBodyType As String
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
        ElseIf CheckXT.Checked = False Then
            CheckXT.Checked = False
            TextXT.ReadOnly = False
        End If


    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FrmAddNewRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

        'conn = New SqlConnection(connectstring)
        'conn.Open()

        ''查詢資料
        'str = "select * from " & MDISizingGroup.oProjectname.ToString
        'adp1 = New SqlDataAdapter(str, conn)

        ''將查詢結果放到記憶體set1上的"1a "表格內

        'adp1.Fill(set1, "Table")

        'DataGridFormModify.DataSource = set1.Tables("Table")


        'With Me
        '    .TxtTagName.Text = Trim(DataGridFormModify.Item("Tag", row).Value.ToString)
        '    .TextSGMOLE.Text = Trim(DataGridFormModify.Item("SpecificGravity", row).Value.ToString)
        '    .TxtMole.Text = Trim(DataGridFormModify.Item("Mole", row).Value.ToString)
        '    .TextInletp.Text = Trim(DataGridFormModify.Item("InletPressure", row).Value.ToString)
        '    .Textoutletp.Text = Trim(DataGridFormModify.Item("OutputPressure", row).Value.ToString)
        '    .TxtMinFL.Text = Trim(DataGridFormModify.Item("MinFlowRate", row).Value.ToString)
        '    .TextFlowRate.Text = Trim(DataGridFormModify.Item("NorFlowRate", row).Value.ToString)
        '    .txtMaxFl.Text = Trim(DataGridFormModify.Item("MaxFlowRate", row).Value.ToString)
        '    .LabelUnit.Text = Trim(DataGridFormModify.Item("Unit", row).Value.ToString)
        '    .ComboPhase.Text = Trim(DataGridFormModify.Item("Phase", row).Value.ToString)
        '    .TextTemp.Text = Trim(DataGridFormModify.Item("Temperature", row).Value.ToString)
        '    .TextK.Text = Trim(DataGridFormModify.Item("K", row).Value.ToString)
        '    .TextVISC.Text = Trim(DataGridFormModify.Item("Viscosity", row).Value.ToString)
        '    .TextZ.Text = Trim(DataGridFormModify.Item("Z", row).Value.ToString)
        '    .ComboBodyType.Text = Trim(DataGridFormModify.Item("Type", row).Value.ToString)
        '    .txtVaporP.Text = Trim(DataGridFormModify.Item("VaporPressure", row).Value.ToString)
        '    .txtCriticalP.Text = Trim(DataGridFormModify.Item("CriticalPressure", row).Value.ToString)

        '    .LineSizeTxt.Text = Trim(DataGridFormModify.Item("LineSize", row).Value.ToString)
        '    .TextXT.Text = Trim(DataGridFormModify.Item("Xt", row).Value.ToString)

        'End With

    End Sub

    Private Sub TxtTagName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTagName.TextChanged
        ToolStripStatusLabel1.Text = ""  ''''清空add finish 字
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub TxtMole_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMole.TextChanged

    End Sub

    Private Sub DataGridFormModify_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridFormModify.CellContentClick

    End Sub
End Class