
Imports System.Data
Imports System.Data.SqlClient
Module ModuleMain
    Public StrCurrentFunction As String




    Public Sub browse(ByVal strSizingMode As String, ByVal strProjectNm As String)
        If strSizingMode = "ControlValve" Then
            MDISizingGroup.SizingModeControlValve.Checked = True
            MDISizingGroup.SizingModeSafetyValve.Checked = False
            MDISizingGroup.OrificePlateToolStripMenuItem.Checked = False
            MDISizingGroup.RestrictPlateToolStripMenuItem1.Checked = False

            MDISizingGroup.SizingMode = "ControlValve"
            StrCurrentFunction = "Browse" & " " & strProjectNm & " " & strSizingMode

            MDISizingGroup.ToolStripLabel2.Text = MDISizingGroup.StrCurrentFunction


            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            Dim str As String = "select * from " & strProjectNm
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內
            Dim set1 As DataSet = New DataSet
            adp1.Fill(set1, "InstrumentTable")

            MDISizingGroup.DataGridBrowseData.DataSource = set1.Tables("InstrumentTable")

            ''''''''''''''''''''add check box

            If MDISizingGroup.boolcheckbox = False Then

                MDISizingGroup.datacheckBox.HeaderText = "Delete"
                MDISizingGroup.DataGridBrowseData.Columns.Insert(0, MDISizingGroup.datacheckBox)
                MDISizingGroup.boolcheckbox = True
            End If

            'DataGridBrowseData.Columns(6).ReadOnly = True
            'DataGridBrowseData.Columns(8).ReadOnly = True


            conn.Close()
        ElseIf strSizingMode = "SafetyValve" Then
            MDISizingGroup.SizingModeSafetyValve.Checked = True
            MDISizingGroup.SizingModeControlValve.Checked = False
            MDISizingGroup.OrificePlateToolStripMenuItem.Checked = False
            MDISizingGroup.RestrictPlateToolStripMenuItem1.Checked = False

            MDISizingGroup.SizingMode = "SafetyValve"
            StrCurrentFunction = "Browse" & " " & strProjectNm & " " & strSizingMode
            MDISizingGroup.ToolStripLabel2.Text = MDISizingGroup.StrCurrentFunction


            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            Dim str As String = "select * from " & strProjectNm
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內
            Dim set1 As DataSet = New DataSet
            adp1.Fill(set1, "SafetyTable")

            MDISizingGroup.DataGridBrowseData.DataSource = set1.Tables("SafetyTable")

            If MDISizingGroup.boolcheckbox = False Then
                MDISizingGroup.datacheckBox.HeaderText = "Delete"
                MDISizingGroup.DataGridBrowseData.Columns.Insert(0, MDISizingGroup.datacheckBox)
                MDISizingGroup.boolcheckbox = True
            End If
            conn.Close()
        ElseIf strSizingMode = "OrificePlate" Then
            MDISizingGroup.OrificePlateToolStripMenuItem.Checked = True
            MDISizingGroup.SizingModeControlValve.Checked = False
            MDISizingGroup.SizingModeSafetyValve.Checked = False
            MDISizingGroup.RestrictPlateToolStripMenuItem1.Checked = False

            MDISizingGroup.SizingMode = "OrificePlate"
            StrCurrentFunction = "Browse" & " " & strProjectNm & " " & strSizingMode
            MDISizingGroup.ToolStripLabel2.Text = MDISizingGroup.StrCurrentFunction


            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            Dim str As String = "select * from " & strProjectNm
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內
            Dim set1 As DataSet = New DataSet
            adp1.Fill(set1, "OrificePlate")

            MDISizingGroup.DataGridBrowseData.DataSource = set1.Tables("OrificePlate")

            If MDISizingGroup.boolcheckbox = False Then
                MDISizingGroup.datacheckBox.HeaderText = "Delete"
                MDISizingGroup.DataGridBrowseData.Columns.Insert(0, MDISizingGroup.datacheckBox)
                MDISizingGroup.boolcheckbox = True
            End If
            conn.Close()
        ElseIf strSizingMode = "RestrictPlate" Then
            MDISizingGroup.OrificePlateToolStripMenuItem.Checked = False
            MDISizingGroup.SizingModeControlValve.Checked = False
            MDISizingGroup.SizingModeSafetyValve.Checked = False
            MDISizingGroup.RestrictPlateToolStripMenuItem1.Checked = True

            MDISizingGroup.SizingMode = "RestrictPlate"
            StrCurrentFunction = "Browse" & " " & strProjectNm & " " & strSizingMode
            MDISizingGroup.ToolStripLabel2.Text = MDISizingGroup.StrCurrentFunction


            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()

            '查詢資料
            Dim str As String = "select * from " & strProjectNm
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

            '將查詢結果放到記憶體set1上的"1a "表格內
            Dim set1 As DataSet = New DataSet
            adp1.Fill(set1, "OrificePlate")

            MDISizingGroup.DataGridBrowseData.DataSource = set1.Tables("OrificePlate")

            If MDISizingGroup.boolcheckbox = False Then
                MDISizingGroup.datacheckBox.HeaderText = "Delete"
                MDISizingGroup.DataGridBrowseData.Columns.Insert(0, MDISizingGroup.datacheckBox)
                MDISizingGroup.boolcheckbox = True
            End If
            conn.Close()
            'DataGridBrowseData.Columns(10).ReadOnly = True

        End If







    End Sub



End Module
