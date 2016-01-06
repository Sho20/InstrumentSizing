Imports System.Data
Imports System.Data.SqlClient



Public Class FrmModify
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

    Public dataCOMPBOX As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn


    Private Sub FrmModify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If MDISizingGroup.SizingMode = "ControlValve" Then
            DefaultXt.Visible = True
            ToolStripFrmName.Text = "Modify ControlValve"
            StrCurrentFunction = "Browse" & " " & MDISizingGroup.oProjectname.ToString & " " & MDISizingGroup.SizingMode

            MDISizingGroup.ToolStripLabel2.Text = StrCurrentFunction


            connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            str = "select * from " & MDISizingGroup.oProjectname.ToString
            adp1 = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內

            adp1.Fill(set1, "Table")

            DataGridModify.DataSource = set1.Tables("Table")




            'returnValue = Me.SetCurrentCellAddressCore(columnIndex, _
            ' rowIndex, setAnchorCellAddress, _
            ' validateCurrentCell, throughMouseClick)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DataGridModify.Columns("TYPE").ToolTipText = "GLOBE,BUTTERFLY,ANGLE,BALL"


            'LockCell(connectstring, str, conn)
            LockCell(DataGridModify, MDISizingGroup.SizingMode)


        ElseIf MDISizingGroup.SizingMode = "SafetyValve" Then
            ImportCaseNo.Visible = True
            ToolStripFrmName.Text = "Modify SafetyValve"

            StrCurrentFunction = "Browse" & " " & MDISizingGroup.oProjectname.ToString & " " & MDISizingGroup.SizingMode

            MDISizingGroup.ToolStripLabel2.Text = StrCurrentFunction


            connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            str = "select * from " & MDISizingGroup.oProjectname.ToString
            adp1 = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內

            adp1.Fill(set1, "Table")

            DataGridModify.DataSource = set1.Tables("Table")
            LockCell(DataGridModify, MDISizingGroup.SizingMode)

        ElseIf MDISizingGroup.SizingMode = "OrificePlate" Then
            InsertCalculateMode.Visible = True
            ToolStripFrmName.Text = "Modify OrificePlate"

            StrCurrentFunction = "Browse" & " " & MDISizingGroup.oProjectname.ToString & " " & MDISizingGroup.SizingMode

            MDISizingGroup.ToolStripLabel2.Text = StrCurrentFunction


            connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            str = "select * from " & MDISizingGroup.oProjectname.ToString
            adp1 = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內

            adp1.Fill(set1, "Table")

            DataGridModify.DataSource = set1.Tables("Table")
            LockCell(DataGridModify, MDISizingGroup.SizingMode) '''''''''''只針對phase來決定有哪些欄位要鎖住
            LockCalculateMode(DataGridModify, MDISizingGroup.SizingMode) ''''''看是要用哪個calculateMode計算



        ElseIf MDISizingGroup.SizingMode = "RestrictPlate" Then
            InsertCalculateMode.Visible = True
            ToolStripFrmName.Text = "Modify RestrictPlate"

            StrCurrentFunction = "Browse" & " " & MDISizingGroup.oProjectname.ToString & " " & MDISizingGroup.SizingMode

            MDISizingGroup.ToolStripLabel2.Text = StrCurrentFunction


            connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            str = "select * from " & MDISizingGroup.oProjectname.ToString
            adp1 = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內

            adp1.Fill(set1, "Table")

            DataGridModify.DataSource = set1.Tables("Table")
            LockCell(DataGridModify, MDISizingGroup.SizingMode)
            LockCalculateMode(DataGridModify, MDISizingGroup.SizingMode) ''''''看是要用哪個calculateMode計算

        End If

        conn.Close()

        Rebinding()


        If txtUseIdModify.Text = "TAG" Then

       

            For i = 0 To DataGridModify.Rows.Count - 2 ''''''''''''''''''''將有更改資料的那一列變顏色
                If DataGridModify.Item("id", i).Value.ToString = DBNull.Value.ToString Then


                Else

                    If DataGridModify.Item("id", i).Value.ToString = Trim(txtID.Text) Then
                        'For c = 0 To DataGridModify.Columns.Count - 1
                        'DataGridModify.CurrentCell. = DataGridModify.Item("TAG", i).Value.ToString
                        DataGridModify.Rows(i).DefaultCellStyle.BackColor = Color.GreenYellow


                        'Next

                    End If
                End If


            Next
        End If

        DataGridModify.ClearSelection()

        conn.Close()
        txtUseIdModify.Text = ""
        'txtID.Text = ""
        DataGridModify.Columns("id").Visible = False
    End Sub

    Private Sub FillColorToOrifice()
        For I = 0 To DataGridModify.Rows.Count - 1
            On Error Resume Next
            If DataGridModify.Item("OrificeBore", I).Value.ToString = Nothing Or DataGridModify.Item("OrificeBore", I).Value = 0 Then
                For r = 0 To DataGridModify.Columns.Count - 1
                    If DataGridModify.Item("Tag", I).Value.ToString = "" Or _
                    DataGridModify.Item("Tag", I).ToString = Nothing Or _
                    DataGridModify.Item("Tag", I).ToString = DBNull.Value.ToString Then


                    Else
                        DataGridModify.Item(r, I).Style.BackColor = Color.YellowGreen
                    End If

                Next
            Else
                Dim douBeta As Double

                douBeta = DataGridModify.Item("Betaratio", I).Value

                If douBeta < 0.2 Or douBeta > 0.8 Or douBeta > 1 Then
                    For q = 0 To DataGridModify.Columns.Count - 1
                        DataGridModify.Item(q, I).Style.BackColor = Color.LightPink
                    Next
                End If
            End If

        Next
        DataGridModify.Columns("id").Visible = False

    End Sub

    Private Sub LockCell(ByVal DataGridModify As DataGridView, ByVal SizingMode As String) '''''''''''只針對phase來決定有哪些欄位要鎖住
        If MDISizingGroup.SizingMode = "ControlValve" Then
            For row = 0 To DataGridModify.Rows.Count - 1 '''''''''''''''''''''''''''''''''多了id這個欄位
                DataGridModify.Item("MinCV", row).ReadOnly = True ''''''''''''''''mincv
                DataGridModify.Item("MinCV", row).Style.BackColor = Color.LightGray
                DataGridModify.Item("NorCV", row).ReadOnly = True ''''''''''''''''norcv
                DataGridModify.Item("NorCV", row).Style.BackColor = Color.LightGray
                DataGridModify.Item("MaxCV", row).ReadOnly = True ''''''''''''''''maxcv
                DataGridModify.Item("MaxCV", row).Style.BackColor = Color.LightGray

                DataGridModify.Item("BodySize", row).ReadOnly = True ''''''''''''''''body size
                DataGridModify.Item("BodySize", row).Style.BackColor = Color.LightGray

                DataGridModify.Item("SelectCV", row).ReadOnly = True ''''''''''''''''SelectCV
                DataGridModify.Item("SelectCV", row).Style.BackColor = Color.LightGray

                For col = 0 To DataGridModify.Columns.Count - 1

                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).ReadOnly = True ''''''''''''''''the last one
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).Style.BackColor = Color.White

                    On Error Resume Next
                    If row < DataGridModify.Rows.Count - 1 Then
                        If Trim(DataGridModify.Item("Phase", row).Value.ToString) = "L" Then

                            DataGridModify.Item("K", row).ReadOnly = True '''''''''''''''''''''''''K
                            DataGridModify.Item("K", row).Style.BackColor = Color.LightGray

                            DataGridModify.Item("Z", row).ReadOnly = True '''''''''''''''''''''''''Z
                            DataGridModify.Item("Z", row).Style.BackColor = Color.LightGray


                        End If
                    End If
                Next
            Next
        ElseIf MDISizingGroup.SizingMode = "SafetyValve" Then
            For row = 0 To DataGridModify.Rows.Count - 1
                DataGridModify.Item("AreaSizein", row).ReadOnly = True ''''''''''''''''areasize
                DataGridModify.Item("AreaSizein", row).Style.BackColor = Color.LightGray

                DataGridModify.Item("Designation", row).ReadOnly = True '''''''''''''''''''''''''designation
                DataGridModify.Item("Designation", row).Style.BackColor = Color.LightGray

                DataGridModify.Item("CaseNo", row).ReadOnly = True '''''''''''''''''''''''''designation
                DataGridModify.Item("CaseNo", row).Style.BackColor = Color.LightGray

                For col = 0 To DataGridModify.Columns.Count - 1
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).ReadOnly = True ''''''''''''''''the last one
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).Style.BackColor = Color.White

                    On Error Resume Next
                    If row < DataGridModify.Rows.Count - 1 Then
                        If Trim(DataGridModify.Item(9, row).Value.ToString) = "L" Then

                            DataGridModify.Item("k", row).ReadOnly = True '''''''''''''''''''''''''k
                            DataGridModify.Item("k", row).Style.BackColor = Color.LightGray

                            DataGridModify.Item("MOLE", row).ReadOnly = True '''''''''''''''''''''''''mole
                            DataGridModify.Item("MOLE", row).Style.BackColor = Color.LightGray

                            DataGridModify.Item("z", row).ReadOnly = True '''''''''''''''''''''''''z
                            DataGridModify.Item("z", row).Style.BackColor = Color.LightGray

                            DataGridModify.Item("Designation", row).ReadOnly = True '''''''''''''''''''''''''z
                            DataGridModify.Item("Designation", row).Style.BackColor = Color.LightGray

                        End If
                    End If
                Next
            Next

        ElseIf MDISizingGroup.SizingMode = "OrificePlate" Then
            For row = 0 To DataGridModify.Rows.Count - 1
                'DataGridModify.Item(11, row).ReadOnly = True ''''''''''''''''boresize
                'DataGridModify.Item(11, row).Style.BackColor = Color.LightGray

                For col = 0 To DataGridModify.Columns.Count - 1
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).ReadOnly = True ''''''''''''''''the last one
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).Style.BackColor = Color.White
                    If row < DataGridModify.Rows.Count - 1 Then
                        On Error Resume Next
                        If Trim(DataGridModify.Item("Phase", row).Value.ToString) = "L" Then

                            DataGridModify.Item("Density", row).ReadOnly = True '''''''''''''''''''''''''密度
                            DataGridModify.Item("Density", row).Style.BackColor = Color.LightGray
                        ElseIf Trim(DataGridModify.Item("Phase", row).Value.ToString) = "V" Or Trim(DataGridModify.Item(1, row).Value.ToString) = "S" Then
                            DataGridModify.Item("Gravity", row).ReadOnly = True '''''''''''''''''''''''''比重
                            DataGridModify.Item("Gravity", row).Style.BackColor = Color.LightGray

                        End If
                    End If
                Next
            Next

            FillColorToOrifice()

        ElseIf MDISizingGroup.SizingMode = "RestrictPlate" Then
            For row = 0 To DataGridModify.Rows.Count - 1
                'DataGridModify.Item(10, row).ReadOnly = True ''''''''''''''''boresize
                'DataGridModify.Item(10, row).Style.BackColor = Color.LightGray

                For col = 0 To DataGridModify.Columns.Count - 1
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).ReadOnly = True ''''''''''''''''the last one
                    DataGridModify.Item(col, DataGridModify.Rows.Count - 1).Style.BackColor = Color.White
                    If row < DataGridModify.Rows.Count - 1 Then
                        On Error Resume Next
                        If Trim(DataGridModify.Item("Phase", row).Value.ToString) = "L" Then

                            DataGridModify.Item("Density", row).ReadOnly = True '''''''''''''''''''''''''密度
                            DataGridModify.Item("Density", row).Style.BackColor = Color.LightGray
                        ElseIf Trim(DataGridModify.Item("Phase", row).Value.ToString) = "V" Or Trim(DataGridModify.Item(1, row).Value.ToString) = "S" Then
                            DataGridModify.Item("Gravity", row).ReadOnly = True '''''''''''''''''''''''''比重
                            DataGridModify.Item("Gravity", row).Style.BackColor = Color.LightGray

                        End If
                    End If
                Next
            Next
        End If




    End Sub

    Private Sub LockCalculateMode(ByVal DataGridModify As DataGridView, ByVal SizingMode As String)

        If MDISizingGroup.SizingMode = "OrificePlate" Then
            For row = 0 To DataGridModify.Rows.Count - 1
                If DataGridModify.Item("CalculateMode", row).Value Is DBNull.Value Or DataGridModify.Item("CalculateMode", row).Value Is Nothing Then

                    DataGridModify.Item("OrificeBore", row).ReadOnly = True
                    DataGridModify.Item("OrificeBore", row).Style.BackColor = Color.LightGray
                Else


                    If DataGridModify.Item("CalculateMode", row).Value = 1 Then ''''''求boreSize
                        DataGridModify.Item("OrificeBore", row).ReadOnly = True
                        DataGridModify.Item("OrificeBore", row).Style.BackColor = Color.LightGray

                    ElseIf DataGridModify.Item("CalculateMode", row).Value = 2 Then ''''''求flowrate

                        DataGridModify.Item("CalculateFlowRate", row).ReadOnly = True
                        DataGridModify.Item("CalculateFlowRate", row).Style.BackColor = Color.LightGray


                    ElseIf DataGridModify.Item("CalculateMode", row).Value = 3 Then ''''''求LossPressure

                        DataGridModify.Item("LossPmmWC", row).ReadOnly = True
                        DataGridModify.Item("LossPmmWC", row).Style.BackColor = Color.LightGray

                    End If

                End If

            Next

        ElseIf MDISizingGroup.SizingMode = "RestrictPlate" Then
            For row = 0 To DataGridModify.Rows.Count - 1
                If DataGridModify.Item("CalculateMode", row).Value Is DBNull.Value Or DataGridModify.Item("CalculateMode", row).Value Is Nothing Then
                    If DataGridModify.Item("Tag", row).Value Is DBNull.Value Or DataGridModify.Item("Tag", row).Value Is Nothing Then
                    Else

                        DataGridModify.Item("OrificeBore", row).ReadOnly = True
                        DataGridModify.Item("OrificeBore", row).Style.BackColor = Color.LightGray
                    End If

                Else
                    If DataGridModify.Item("CalculateMode", row).Value = 1 Then ''''''求boreSize
                        DataGridModify.Item("OrificeBore", row).ReadOnly = True
                        DataGridModify.Item("OrificeBore", row).Style.BackColor = Color.LightGray

                    ElseIf DataGridModify.Item("CalculateMode", row).Value = 2 Then ''''''求flowrate

                        DataGridModify.Item("MaxFlowRate", row).ReadOnly = True
                        DataGridModify.Item("MaxFlowRate", row).Style.BackColor = Color.LightGray

                    ElseIf DataGridModify.Item("CalculateMode", row).Value = 3 Then ''''''求LossPressure

                        DataGridModify.Item("LossPressure", row).ReadOnly = True
                        DataGridModify.Item("LossPressure", row).Style.BackColor = Color.LightGray

                    End If
                End If
            Next
        End If
    End Sub


    Private Sub ToolStripButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonExit.Click
        Me.Close()
        MDISizingGroup.Show()

    End Sub


    Private Sub DataGridModify_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridModify.CellBeginEdit

        txtID.Text = DataGridModify.Item("id", e.RowIndex).Value.ToString

        If MDISizingGroup.SizingMode = "ControlValve" Then
            strTagNameText = UCase(DataGridModify.Item("Tag", e.RowIndex).Value)


        ElseIf MDISizingGroup.SizingMode = "SafetyValve" Then
            strTagNameText = UCase(DataGridModify.Item("Tag", e.RowIndex).Value)
            douCaseNo = DataGridModify.Item("CaseNo", e.RowIndex).Value

        ElseIf MDISizingGroup.SizingMode = "OrificePlate" Then
            strTagNameText = UCase(DataGridModify.Item("Tag", e.RowIndex).Value)

        ElseIf MDISizingGroup.SizingMode = "RestrictPlate" Then
            strTagNameText = UCase(DataGridModify.Item("Tag", e.RowIndex).Value)
        End If

    End Sub



    Private Sub DataGridModify_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridModify.CellEndEdit

        ModuleMain.browse(strSizingMode, strProjectNm)
        Rebinding()
        DataGridModify.Item(e.ColumnIndex, e.RowIndex).Style.BackColor = Color.GreenYellow
        If boolChangePhase = True Then
            DataGridModify.Item("Unit", e.RowIndex).Style.BackColor = Color.GreenYellow
        End If
        boolChangePhase = False

    End Sub
    Private Sub Rebinding()
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(str, conn)
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "Table")
        On Error Resume Next
        DataGridModify.DataSource = set2.Tables("Table")
        DataGridModify.Refresh()
        LockCell(DataGridModify, MDISizingGroup.SizingMode)
        LockCalculateMode(DataGridModify, MDISizingGroup.SizingMode)

    End Sub

    Private Sub DataGridModify_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridModify.CellValueChanged

        strSizingMode = MDISizingGroup.SizingMode

        strColumnName = DataGridModify.Columns(e.ColumnIndex).HeaderText
        If DataGridModify.Item(e.ColumnIndex, e.RowIndex).Value.ToString = Nothing Then
            strEditText = "default"
        Else
            strEditText = Trim(DataGridModify.Item(e.ColumnIndex, e.RowIndex).Value)
        End If


        conn = New SqlConnection(connectstring)

        conn.Open()
        If strSizingMode = "ControlValve" Then
            If strColumnName = "Phase" Then

                If UCase(strEditText) = "G" Then
                    strUnit = "NM3"

                ElseIf UCase(strEditText) = "L" Then

                    strUnit = "M3"
                ElseIf UCase(strEditText) = "S" Then

                    strUnit = "KG"
                ElseIf UCase(strEditText) = Nothing Then
                    strUnit = ""
                Else
                    MsgBox("Please type correct Phase Type")
                    Exit Sub
                End If
                boolChangePhase = True
                updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set Unit=" & _
                                        "'" & strUnit & "', " & strColumnName & " =" & _
                                        "'" & UCase(strEditText) & "' where id=" & _
                                        "'" & Trim(txtID.Text) & "'"
                updataCmd.Connection = conn
                updataCmd.ExecuteNonQuery()

            ElseIf strColumnName = "Type" Then '''''''''''''''''''''''文字欄位
                If UCase(strEditText) = "ANGLE" Then
                    strUnit = "ANGLE"

                ElseIf UCase(strEditText) = "GLOBE" Then

                    strUnit = "GLOBE"
                ElseIf UCase(strEditText) = "BALL" Then

                    strUnit = "BALL"
                ElseIf UCase(strEditText) = "BUTTERFLY" Then

                    strUnit = "BUTTERFLY"
                Else
                    MsgBox("Please type correct BodySize Type")
                    Exit Sub
                End If

                updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                                        "'" & UCase(strEditText) & "' where id=" & _
                                        "'" & Trim(txtID.Text) & "'"
                updataCmd.Connection = conn
                updataCmd.ExecuteNonQuery()

            ElseIf strColumnName = "Tag" Then

                Dim strOpenSQLtABLE As String = "SELECT * FROM " & MDISizingGroup.oProjectname.ToString & " where TAG =" & "'" & UCase(strEditText) & "' "
                Dim set2 As New DataSet
                Dim adp2 As SqlDataAdapter = New SqlDataAdapter(strOpenSQLtABLE, conn)
                adp2.Fill(set2, "excel")

                Dim set2rowcount As Integer        ''''''''''''''''''判定是否是唯一
                set2rowcount = set2.Tables(0).Rows.Count
                If set2rowcount > 0 Then
                    MsgBox("TAG NAME IS Unique")
                    GoTo nextone
                    'Call ButtonExit_Click(sender, e)
                    'Exit Sub
                End If

                updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                                        "'" & UCase(strEditText) & "' where id=" & _
                                        "'" & Trim(txtID.Text) & "'"
                updataCmd.Connection = conn
                updataCmd.ExecuteNonQuery()
            Else
                updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " = '" & UCase(strEditText) & "' where id=" & _
                                         "'" & Trim(txtID.Text) & "'"
                updataCmd.Connection = conn
                updataCmd.ExecuteNonQuery()
            End If


        ElseIf strSizingMode = "SafetyValve" Then

            If strColumnName = "Phase" Then

                If UCase(strEditText) = "G" Or UCase(strEditText) = "L" Or UCase(strEditText) = "S" Or UCase(strEditText) = "" Then
                    updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                                            "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "' "
                    updataCmd.Connection = conn
                    updataCmd.ExecuteNonQuery()
                Else
                    MsgBox("Please type correct Type")
                    Exit Sub
                End If
            End If


            updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                    "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "'"
            updataCmd.Connection = conn
            updataCmd.ExecuteNonQuery()

        ElseIf strSizingMode = "OrificePlate" Then

            If strColumnName = "Phase" Then

                If UCase(strEditText) = "V" Or UCase(strEditText) = "L" Or UCase(strEditText) = "S" Or UCase(strEditText) = "" Then
                    updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                                            "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "'"
                    updataCmd.Connection = conn
                    updataCmd.ExecuteNonQuery()
                Else
                    MsgBox("Please type correct Type")
                    Exit Sub
                End If
            End If

            updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                      "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "'"
            updataCmd.Connection = conn
            updataCmd.ExecuteNonQuery()

        ElseIf strSizingMode = "RestrictPlate" Then

            If strColumnName = "Phase" Then

                If UCase(strEditText) = "V" Or UCase(strEditText) = "L" Or UCase(strEditText) = "S" Or UCase(strEditText) = "" Then
                    updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                                            "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "'"
                    updataCmd.Connection = conn
                    updataCmd.ExecuteNonQuery()
                Else
                    MsgBox("Please type correct Type")
                    Exit Sub
                End If
            End If

            updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " =" & _
                      "'" & UCase(strEditText) & "' where id='" & Trim(txtID.Text) & "'"
            updataCmd.Connection = conn
            updataCmd.ExecuteNonQuery()

        End If
nextone:
        ModuleMain.browse(strSizingMode, strProjectNm)

    End Sub

    Private Sub DataGridModify_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridModify.CellContentClick
        Dim r As Integer
        r = e.ColumnIndex
        Dim row As Integer
        row = e.RowIndex
        txtID.Text = DataGridModify.Item("id", row).Value.ToString

        If DataGridModify.Columns(r).HeaderText = "Unit" Then
            DataGridModify.Columns("Unit").ReadOnly = True
            MsgBox("This column can't be modify")
        End If

        If DataGridModify.Columns(r).HeaderText = "Designation" Then
            DataGridModify.Columns("Designation").ReadOnly = True
            MsgBox("This column can't be modify")

        End If
        If DataGridModify.Columns(r).HeaderText = "Areasizein" Then
            DataGridModify.Columns("Designation").ReadOnly = True
            MsgBox("This column can't be modify")

        End If


    End Sub




    Private Sub DataGridModify_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridModify.EditingControlShowing

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub DefaultXt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultXt.Click
        MsgBox("You sure use Default Xt to Database?")

        Dim doubleXT As Double
        Dim strTagNm As String

        If MsgBoxResult.Ok Then

            For row = 0 To DataGridModify.Rows.Count - 1

                On Error Resume Next
                If DataGridModify.Item("Tag", row).Value IsNot Nothing Then
                    On Error Resume Next
                    If DataGridModify.Item("Xt", row).Value.ToString = Nothing Then '''''''''''先判斷xt是否沒值
                        strTagNm = Trim(DataGridModify.Item("Tag", row).Value.ToString)
                        'strCondition = Trim(DataGridModify.Item("Condition", row).Value.ToString)
                        If Trim(DataGridModify.Item("Type", row).Value.ToString) = "GLOBE" Then
                            DataGridModify.Item("Xt", row).Value = 0.621
                            DataGridModify.Item("Xt", row).Style.BackColor = Color.GreenYellow

                        ElseIf Trim(DataGridModify.Item("Type", row).Value.ToString) = "ANGLE" Then
                            DataGridModify.Item("Xt", row).Value = 0.5736
                            DataGridModify.Item("Xt", row).Style.BackColor = Color.GreenYellow
                        ElseIf Trim(DataGridModify.Item("Type", row).Value.ToString) = "BUTTERFLY" Then
                            DataGridModify.Item("Xt", row).Value = 0.2541
                            DataGridModify.Item("Xt", row).Style.BackColor = Color.GreenYellow
                        ElseIf Trim(DataGridModify.Item("Type", row).Value.ToString) = "BALL" Then
                            DataGridModify.Item("Xt", row).Value = 0.2729
                            DataGridModify.Item("Xt", row).Style.BackColor = Color.GreenYellow
                        End If

                        updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set  " & strColumnName & " = " & UCase(strEditText) & " where TAG=" & _
                                        "'" & strTagNm & "'"
                        updataCmd.Connection = conn
                        updataCmd.ExecuteNonQuery()
                    End If


                End If
            Next

        End If

        MsgBox("Finish")

    End Sub

    Private Sub InsertCalculateMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertCalculateMode.Click
        MsgBox("You sure use Default CalculateMode to Database?")

        Dim doubleCalMode As Double
        Dim strTagNm As String

        If MsgBoxResult.Ok Then

            For row = 0 To DataGridModify.Rows.Count - 1

                On Error Resume Next
                If DataGridModify.Item("Tag", row).Value IsNot Nothing Then
                    On Error Resume Next
                    If DataGridModify.Item("CalculateMode", row).Value.ToString = Nothing Then '''''''''''先判斷xt是否沒值
                        strTagNm = Trim(DataGridModify.Item("Tag", row).Value.ToString)
                        doubleCalMode = 1
                        DataGridModify.Item("CalculateMode", row).Value = doubleCalMode
                        DataGridModify.Item("CalculateMode", row).Style.BackColor = Color.GreenYellow
                        updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set CalculateMode = " & doubleCalMode & " where TAG=" & _
                                        "'" & strTagNm & "' "
                        updataCmd.Connection = conn
                        updataCmd.ExecuteNonQuery()
                    End If


                End If
            Next

        End If

        MsgBox("Finish")

    End Sub

    Private Sub ImportCaseNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportCaseNo.Click
        MsgBox("You sure use Default CaseNo to Database?")

        Dim textCaseNo As String
        Dim strTagNm As String

        If MsgBoxResult.Ok Then

            For row = 0 To DataGridModify.Rows.Count - 1

                On Error Resume Next
                If DataGridModify.Item("Tag", row).Value IsNot Nothing Then
                    On Error Resume Next
                    If Trim(DataGridModify.Item("CaseNo", row).Value.ToString) = Nothing Or Trim(DataGridModify.Item("CaseNo", row).Value.ToString) = "" Then '''''''''''先判斷caseno是否沒值
                        strTagNm = Trim(DataGridModify.Item("Tag", row).Value.ToString)
                        textCaseNo = 1
                        DataGridModify.Item("CaseNo", row).Value = textCaseNo
                        DataGridModify.Item("CaseNo", row).Style.BackColor = Color.GreenYellow
                        updataCmd.CommandText = "Update " & MDISizingGroup.oProjectname.ToString & " set CaseNo =" & "'" & textCaseNo & "'" & " where TAG=" & _
                                        "'" & strTagNm & "' "
                        updataCmd.Connection = conn
                        updataCmd.ExecuteNonQuery()
                    End If


                End If
            Next

        End If

        MsgBox("Finish")

    End Sub

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged

    End Sub

    Private Sub TxtselectRow_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
