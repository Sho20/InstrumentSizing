Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.IO
Imports System.Object
Imports System.Security.AccessControl
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms.Button
Imports Microsoft.Office.Tools.Excel.Controls
Imports Microsoft.Office.Tools.Excel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared




Public Class MDISizingGroup
    Public connectstring As String
    Public conn As SqlConnection
    Public username As String
    Public oProjectname As Object
    Public connOLE As OleDbConnection
    Public strconnstring As String
    Public str As String
    Public FileName As String
    Public UserJobNo As String
    Public SelectJobNo As String
    Public UserTask As String
    Public strTableTest As String
    Public S As Integer

    Public SizingMode As String
    Public StrCurrentFunction As String

    Public TStrTagname As String   ''''''T=test,control valve
    Public TdouSG As Double
    Public TdouInletp As Double
    Public Tdououtletp As Double
    Public TdouFlowRate As Double
    Public TStrPhase As String
    Public TdouTemp As Double
    Public TStrUnits As String
    Public TdouCv As Double
    Public TdouK As Double
    Public TdouRO As Double
    Public TdouZ As Double
    Public TStrType As String


    Public TdouWkg As Double ''''''T=test,safety valve
    Public TdouP1 As Double
    Public TdouTotalBack As Double
    Public TdouOverP As Double
    Public TStrRupture As String
    Public TdouMOLE As Double
    Public AreaSizein As Double

    Public strSelectTagName As String
    Public intSelectTagRow As Integer

    Public boolcheckbox As Boolean
    Public datacheckBox As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
    'Public boolcheckboxSelect As Boolean
    Public IntcheckboxforDELEtimes As Integer
    Public strBodyType As String
    Public PrintFileName As String


    Declare Function GetUserName Lib "advapi32.dll" Alias _
    "GetUserNameA" (ByVal lpBuffer As String, _
    ByRef nSize As Integer) As Integer


    Public I1528FileNme As String

    'Public PermUser As New SharePermissionEntry
    Private Const STYPE_DISKTREE As Long = 0 'disk drive
    Private Const STYPE_PRINTQ As Long = 1 'printer
    Private Const STYPE_DEVICE As Long = 2
    Private Const STYPE_IPC As Long = 3

    Private stringToPrint As String
    Private Const FontAdjustmentFactor = 1.1

    Private ReadOnly Property Connection() As SqlConnection
        Get
            If SizingMode = "ControlValve" Then
                connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

            ElseIf SizingMode = "SafetyValve" Then
                connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"

            ElseIf SizingMode = "OrificePlate" Then
                connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

            ElseIf SizingMode = "RestrictPlate" Then
                connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

            End If
            Dim ConnectionToFetch As New SqlConnection(connectstring)
            ConnectionToFetch.Open()
            Return ConnectionToFetch
        End Get
    End Property


    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function


    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "(*.xls)|*.xls|(*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: 在此加入程式碼，將表單目前的內容儲存成檔案。
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' 使用 My.Computer.Clipboard 將選取的文字或影像插入剪貼簿
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' 使用 My.Computer.Clipboard 將選取的文字或影像插入剪貼簿
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        '使用 My.Computer.Clipboard.GetText() 或 My.Computer.Clipboard.GetData 從剪貼簿擷取資訊。
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' 關閉父表單的所有子表單。
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub



    Private Sub MDISizingGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ToolStrip1.Width = 800


        ListBoxforDeleteList.Items.Clear()

        FileMenu.Text = FrmJobNoCollect.LabProjectNum.Text
        oProjectname = FrmJobNoCollect.LabProjectNum.Text
        ToolStripLabel2.Text = oProjectname.ToString
        ToolStripProgressBar1.Value = 0

        SizingModeControlValve.CheckState = CheckState.Unchecked  ''''''Mode status is empty


        username = GetUserName()


        MakesureUser(username)


        If Trim(UserTask) = "REVIEW" Then

            OpenToolStripMenuItem.Enabled = False
            SizingModeControlValve.Enabled = False
            RunSizingToolStripMenuItem.Enabled = False
            AddANewRecordToolStripMenuItem.Enabled = False




            CreateNewControlValve.Enabled = False
            CreateNewSafetyValve.Enabled = False
            CreateNewOr.Enabled = False
            RestrictPlateToolStripMenuItemCreate.Enabled = False


            DeleteToolStripMenuItem.Enabled = False
            ModifyRecordToolStripMenuItem.Enabled = False


            UploadControlValveToolStripMenuItem.Enabled = False
            UploadSafetyValveToolStripMenuItem.Enabled = False
            UploadROToolStripMenuItem.Enabled = False
            UploadRestrictPlateToolStripMenuItem.Enabled = False
        Else


            'GetObject("winmgmts:").Get("Win32_Share").Create("\\i1528\NORMALcontrolvalve", "NORMALcontrolvalve", 0, 20, "註解")
            'Dim dInfo As New DirectoryInfo("\\i1528\NORMALcontrolvalve")
            ''Dim addinfo As New System.IO.
            'Dim PermissionsList As New List(Of SharePermissionEntry)

            'Dim PermUser As New SharePermissionEntry("CTCI", "54477", SharedFolder.SharePermissions.FullControl, True)

            ''Add the two entries declared above to our list
            'PermissionsList.Add(PermUser)
            ''PermissionsList.Remove(PermUser)
            ''PermissionsList.Add(PermEveryone)

            ''Share the folder as "Test Share" and pass in the desired permissions list
            'Dim Result As SharedFolder.NET_API_STATUS = _
            'SharedFolder.ShareExistingFolder("aaa", "This is a test share", "D:\NORMALcontrolvalve", PermissionsList, "I1528")

            ''Show the result
            'If Result = SharedFolder.NET_API_STATUS.NERR_Success Then
            '    MessageBox.Show("Share created successfully!")
            'Else
            '    MessageBox.Show("Share was not created as the following error was returned: " & Result.ToString)
            'End If



            'Dim HaveUserRight As New System.Security.AccessControl.FileSystemAccessRule("CTCI\54833", Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)

            'dSecurity.AddAccessRule(New FileSystemAccessRule("CTCI\54833", FileSystemRights.FullControl, AccessControlType.Allow))
            'dSecurity.AddAccessRule(HaveUserRight)
            'dInfo.SetAccessControl(dSecurity)
        End If

        ToolStripProgressBar1.Value = 0
        connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        checkExistorNotTable()

        Dim strProjectname As String
        strProjectname = UserJobNo
        Me.WindowState = FormWindowState.Maximized


        'If SizingMode = "" Then


    End Sub

    Private Sub MakesureUser(ByVal username As String)

        ''''''browse i1528\sizinguseright 的dbf
        'Dim dInfo As New DirectoryInfo("\\i1528\SizingUserRight")

        'Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()
        'Dim HaveUserRight As New System.Security.AccessControl.FileSystemAccessRule("Administrators", Security.AccessControl.FileSystemRights.FullControl, Security.AccessControl.AccessControlType.Allow)
        'dSecurity.AddAccessRule(HaveUserRight)
        'dInfo.SetAccessControl(dSecurity)
        connOLE = New OleDbConnection("Provider=VFPOLEDB.1;Data Source=\\i1528\SizingUserRight\;")
        connOLE.Open()

        Dim cmd As New OleDbCommand("select * from userproject", connOLE)

        'str = "select * from userproject"
        Dim adp As OleDbDataAdapter = New OleDbDataAdapter(cmd)

        Dim set1 As DataSet = New DataSet
        adp.Fill(set1, "User")

        Dim i As Integer
        Dim w As Integer


        w = 0
        i = set1.Tables("User").Rows.Count

        For w = 0 To i - 1

            If username = Trim(set1.Tables("User").Rows(w).Item(0).ToString) Then

                S = 1  '''''''''''''''GET Property task
                UserTask = GetUserProperty(i, w, S, set1)
                S = 2
                UserJobNo = GetUserProperty(i, w, S, set1)

            Else
                Me.Show()
                Exit Sub
            End If

        Next
    End Sub

    Public Function GetUserProperty(ByVal i, ByVal w, ByVal S, ByVal set1) As String

        UserTask = Trim(set1.Tables("User").Rows(w).Item(2).ToString)
        UserJobNo = Trim(set1.Tables("User").Rows(w).Item(1).ToString)


        If S = 1 Then
            GetUserProperty = UserTask
            S = 2
        ElseIf S = 2 Then
            GetUserProperty = UserJobNo
            'LstJobNo.Items.Add(GetUserProperty)
        End If

    End Function

    Private Sub RunSizingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunSizingToolStripMenuItem.Click

        If SizingMode = "ControlValve" Then

            FrmSizng.Show()
            FrmSizng.WindowState = FormWindowState.Maximized

            Call ControlValveToolStripMenuItem_Click(sender, e)
            Me.Hide()
        ElseIf SizingMode = "SafetyValve" Then

            FrmSafetyValve.Show()
            FrmSafetyValve.WindowState = FormWindowState.Maximized
            Call SafetyValveToolStripMenuItem1_Click(sender, e)
            Me.Hide()
        ElseIf SizingMode = "OrificePlate" Then

            FrmOrSizing.Show()
            FrmOrSizing.WindowState = FormWindowState.Maximized
            Call OrToolStripMenuItem_Click(sender, e)
            Me.Hide()

        ElseIf SizingMode = "RestrictPlate" Then
            FrmROSizing.Show()
            FrmROSizing.WindowState = FormWindowState.Maximized
            Call BROWSERestrictPlateToolStripMenuItem_Click(sender, e)
            Me.Hide()

        End If

    End Sub

    Private Sub UploadControlValveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadControlValveToolStripMenuItem.Click


        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "ControlValve"
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        SizingModeControlValve.CheckState = CheckState.Unchecked
        If SizingMode = "ControlValve" Then

            SelectJobNo = FileMenu.Text
            SizingModeControlValve.CheckState = CheckState.Checked

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()
            ToolStripProgressBar1.Value = 0
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "(*.xlsx)|*.xlsx|(*.*)|*.*"
            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                FileName = OpenFileDialog.FileName

                '將EXCEL DATA 轉成DATAGRIDVIEW
                Call Button1_Click(sender, e)
                ''''''''''''''''''''''''''''''''''''''''''''''''
                connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

                conn = New SqlConnection(connectstring)
                conn.Open()
                Dim Foxfile As New DataSet

                Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
                Dim I As Integer
                ToolStripProgressBar1.Value = 20

                Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
                    Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                        While dr.Read()
                            ToolStripProgressBar1.Value = 30
                            ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                        End While
                    End Using
                End Using
                ToolStripProgressBar1.Value = 40

                Dim cmd As SqlCommand
                Dim cmddeletesttable As SqlCommand
                Dim Tablename As String
                Dim h As Integer
                h = InStr(OpenFileDialog.SafeFileName, ".")

                Tablename = SelectJobNo
                TextUploadFileName.Text = Tablename

                Dim StrImportToSql As String
                Dim StrdeleTableTestToSql As String


                strTableTest = Tablename & "test"

                ToolStripProgressBar1.Value = 50
                For I = 0 To ListFORMS.Items.Count - 1
                    If ListFORMS.Items(I).ToString = Tablename Then ''''''''''''''''delete正常的table
                        StrImportToSql = "drop table " & Tablename & " "
                        cmd = New SqlClient.SqlCommand(StrImportToSql, conn)
                        cmd.ExecuteNonQuery()
                    End If

                    If ListFORMS.Items(I).ToString = strTableTest Then ''''''''''''''''delete測試的table
                        StrdeleTableTestToSql = "drop table " & strTableTest & " "
                        cmddeletesttable = New SqlClient.SqlCommand(StrdeleTableTestToSql, conn)
                        cmddeletesttable.ExecuteNonQuery()
                    End If
                Next
                ToolStripProgressBar1.Value = 60

                '''''''''''''''''''''''''''''''''''''''''''Create a new table
                Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(0,1)," & _
                "Tag nchar(255),SpecificGravity float,Mole float," & _
                "MinInletp float,NorInletp float,MaxInletp float," & _
                "MinDP float,NorDP float,MaxDP float,MinFlowRate float,NorFlowRate float," & _
                "MaxFlowRate float,Unit nchar(255), Phase nchar(255), Temperature float," & _
                "K float, Viscosity float, Z float,Type nchar(255),VaporPressure float," & _
                "CriticalPressure float,MinCV float,NorCV float,MaxCV float, LineSize float," & _
                "BodySize float,SelectCV float,Xt float,DPcondition nchar(255)," & _
                "Noise float,LineWallT float)", conn)

                objCmd.CommandType = CommandType.Text

                objCmd.ExecuteNonQuery()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''將選好的excel新增到sql中
                Dim StrTagname As String
                Dim douSG
                Dim douMole
                Dim douminInletp
                Dim dounorInletp
                Dim doumaxInletp

                Dim douMinDP
                Dim douNorDP
                Dim douMaxDP

                Dim douMinFlowRate
                Dim douNorFlowRate
                Dim douMaxFlowRate

                Dim StrPhase As String
                Dim douTemp
                Dim StrUnits As String
                Dim douMinCv
                Dim douNorCv
                Dim douMaxCv

                Dim douK
                Dim douViscosity
                Dim douZ
                Dim StrType As String

                Dim douBodySizeIn
                Dim strExceltoDataset As String
                Dim DoulineSize
                Dim DouXt
                Dim DouNoise
                Dim DouVaporP
                Dim DouCriticalP
                Dim DouSelectCV

                Dim strdpCondition As String
                Dim douT As Double  '''''LineWallT

                ToolStripProgressBar1.Value = 70
                For R = 0 To DataGridViewEXCELtoDATASET.Rows.Count - 1
                    On Error Resume Next
                    If DataGridViewEXCELtoDATASET.Item("Tag", R).Value Is Nothing Or DataGridViewEXCELtoDATASET.Item("Tag", R).Value Is DBNull.Value Then

                    Else


                        StrTagname = UCase(DataGridViewEXCELtoDATASET.Item("Tag", R).Value.ToString)


                        For col = 1 To DataGridViewEXCELtoDATASET.Columns.Count - 1 ''''''''''''''''''''without tagname
                            ' MsgBox(DataGridViewEXCELtoDATASET.Columns(0).Name)
                            If DataGridViewEXCELtoDATASET.Item(col, R).Value.ToString = Nothing Then
                                If col = 1 Then

                                    douSG = "default"
                                ElseIf col = 2 Then
                                    douMole = "default"

                                ElseIf col = 3 Then
                                    douminInletp = "default"

                                ElseIf col = 4 Then
                                    dounorInletp = "default"

                                ElseIf col = 5 Then
                                    doumaxInletp = "default"

                                ElseIf col = 6 Then
                                    douMinDP = "default"

                                ElseIf col = 7 Then

                                    douNorDP = "default"

                                ElseIf col = 8 Then

                                    douMaxDP = "default"

                                ElseIf col = 9 Then
                                    douMinFlowRate = "default"

                                ElseIf col = 10 Then
                                    douNorFlowRate = "default"

                                ElseIf col = 11 Then
                                    douMaxFlowRate = "default"

                                ElseIf col = 12 Then

                                    StrUnits = ""

                                ElseIf col = 13 Then

                                    StrPhase = ""
                                ElseIf col = 14 Then

                                    douTemp = "default"

                                ElseIf col = 15 Then

                                    douK = "default"
                                ElseIf col = 16 Then

                                    douViscosity = "default"
                                ElseIf col = 17 Then

                                    douZ = "default"

                                ElseIf col = 18 Then

                                    StrType = ""

                                ElseIf col = 19 Then
                                    DouVaporP = "default"

                                ElseIf col = 20 Then
                                    DouCriticalP = "default"

                                ElseIf col = 21 Then
                                    douMinCv = "default"

                                ElseIf col = 22 Then
                                    douNorCv = "default"

                                ElseIf col = 23 Then
                                    douMaxCv = "default"

                                ElseIf col = 24 Then
                                    DoulineSize = "default"

                                ElseIf col = 25 Then


                                    douBodySizeIn = "default"

                                ElseIf col = 26 Then
                                    DouSelectCV = "default"

                                ElseIf col = 27 Then

                                    DouXt = "default"

                                ElseIf col = 28 Then
                                    strdpCondition = ""

                                ElseIf col = 29 Then
                                    DouNoise = "default"

                                ElseIf col = 30 Then
                                    douT = "default"

                                End If
                            Else
                                If col = 1 Then

                                    douSG = DataGridViewEXCELtoDATASET.Item(1, R).Value


                                ElseIf col = 2 Then
                                    douMole = DataGridViewEXCELtoDATASET.Item(2, R).Value

                                ElseIf col = 3 Then
                                    douminInletp = DataGridViewEXCELtoDATASET.Item(3, R).Value

                                ElseIf col = 4 Then
                                    dounorInletp = DataGridViewEXCELtoDATASET.Item(4, R).Value

                                ElseIf col = 5 Then
                                    doumaxInletp = DataGridViewEXCELtoDATASET.Item(5, R).Value

                                ElseIf col = 6 Then
                                    douMinDP = DataGridViewEXCELtoDATASET.Item(6, R).Value

                                ElseIf col = 7 Then
                                    douNorDP = DataGridViewEXCELtoDATASET.Item(7, R).Value

                                ElseIf col = 8 Then
                                    douMaxDP = DataGridViewEXCELtoDATASET.Item(8, R).Value

                                ElseIf col = 9 Then
                                    douMinFlowRate = DataGridViewEXCELtoDATASET.Item(9, R).Value

                                ElseIf col = 10 Then
                                    douNorFlowRate = DataGridViewEXCELtoDATASET.Item(10, R).Value


                                ElseIf col = 11 Then
                                    douMaxFlowRate = DataGridViewEXCELtoDATASET.Item(11, R).Value

                                ElseIf col = 12 Then

                                    StrUnits = UCase(DataGridViewEXCELtoDATASET.Item(12, R).Value.ToString)

                                ElseIf col = 13 Then

                                    StrPhase = UCase(DataGridViewEXCELtoDATASET.Item(13, R).Value.ToString)

                                ElseIf col = 14 Then

                                    douTemp = DataGridViewEXCELtoDATASET.Item(14, R).Value

                                ElseIf col = 15 Then

                                    douK = DataGridViewEXCELtoDATASET.Item(15, R).Value

                                ElseIf col = 16 Then

                                    douViscosity = DataGridViewEXCELtoDATASET.Item(16, R).Value


                                ElseIf col = 17 Then

                                    douZ = DataGridViewEXCELtoDATASET.Item(17, R).Value

                                ElseIf col = 18 Then

                                    StrType = UCase(DataGridViewEXCELtoDATASET.Item(18, R).Value.ToString)

                                ElseIf col = 19 Then
                                    DouVaporP = (DataGridViewEXCELtoDATASET.Item(19, R).Value)

                                ElseIf col = 20 Then
                                    DouCriticalP = (DataGridViewEXCELtoDATASET.Item(20, R).Value)


                                ElseIf col = 21 Then
                                    douMinCv = (DataGridViewEXCELtoDATASET.Item(21, R).Value)

                                ElseIf col = 22 Then
                                    douNorCv = (DataGridViewEXCELtoDATASET.Item(22, R).Value)

                                ElseIf col = 23 Then
                                    douMaxCv = (DataGridViewEXCELtoDATASET.Item(23, R).Value)

                                ElseIf col = 24 Then

                                    DoulineSize = (DataGridViewEXCELtoDATASET.Item(24, R).Value)

                                ElseIf col = 25 Then

                                    douBodySizeIn = (DataGridViewEXCELtoDATASET.Item(25, R).Value)


                                ElseIf col = 26 Then
                                    DouSelectCV = (DataGridViewEXCELtoDATASET.Item(26, R).Value)

                                ElseIf col = 27 Then
                                    DouXt = (DataGridViewEXCELtoDATASET.Item(27, R).Value)

                                ElseIf col = 28 Then
                                    strdpCondition = (DataGridViewEXCELtoDATASET.Item(28, R).Value)

                                ElseIf col = 29 Then
                                    DouNoise = (DataGridViewEXCELtoDATASET.Item(29, R).Value)

                                ElseIf col = 30 Then
                                    douT = (DataGridViewEXCELtoDATASET.Item(30, R).Value)

                                End If

                            End If
                        Next


                        '查詢資料
                        strExceltoDataset = "Insert Into " & Tablename & "(Tag,SpecificGravity,Mole," & _
                                   "MinInletp ,NorInletp,MaxInletp,MinDP,NorDP,MaxDP,MinFlowRate,NorFlowRate,MaxFlowRate,Unit," & _
                                   "Phase, Temperature,K, Viscosity, Z ,Type,VaporPressure," & _
                                   "CriticalPressure,MinCV,NorCV,MaxCV," & _
                                   "LineSize,BodySize,SelectCV,Xt,DPcondition,Noise,LineWallT)" & _
                         "Values('" & StrTagname & "', " & douSG & " ," & douMole & "," & douminInletp & "," & _
                              "" & dounorInletp & "," & doumaxInletp & "," & douMinDP & "," & _
                             "" & douNorDP & "," & douMaxDP & "," & _
                            "" & douMinFlowRate & "," & douNorFlowRate & "," & douMaxFlowRate & "," & _
                           "'" & StrUnits & "','" & StrPhase & "'," & douTemp & "," & douK & "," & _
                         "" & douViscosity & "," & douZ & ",'" & StrType & "'," & DouVaporP & "," & _
                        "" & DouCriticalP & "," & douMinCv & "," & douNorCv & "," & douMaxCv & "," & _
                       "" & DoulineSize & "," & douBodySizeIn & "," & DouSelectCV & "," & _
                      "" & DouXt & ",'" & strdpCondition & "'," & DouNoise & "," & douT & ")"

                        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(strExceltoDataset, conn)

                        Dim cmdEXCEL As SqlCommand = New SqlCommand(strExceltoDataset, conn)
                        cmdEXCEL.ExecuteNonQuery()

                    End If

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ToolStripProgressBar1.Value = 80
                ToolStripProgressBar1.Value = 90

                ToolStripProgressBar1.Value = 100
                ToolStripStatusLabel1.Text = "Upload Finish"


                conn.Close()

            End If

        End If

        Call ControlValveToolStripMenuItem_Click(sender, e)
        checkExistorNotTable()
    End Sub


    Private Sub UploadfileToServer(ByVal newfilename As String)
        'Dim SAVEFilePATH As String = "\\i1528\NORMALcontrolvalve"




        'If SizingMode = "ControlValve" Then

        '    I1528FileNme = SAVEFilePATH + "\" + username + "cv.xls"
        '    If My.Computer.FileSystem.FileExists(I1528FileNme) Then
        '        My.Computer.FileSystem.DeleteFile(I1528FileNme)
        '    End If
        '    My.Computer.FileSystem.CopyFile(newfilename, SAVEFilePATH + "\" + username + "cv.xls")

        'ElseIf SizingMode = "SafetyValve" Then



        '    I1528FileNme = SAVEFilePATH + "\" + username + "PSV.xls"

        '    If My.Computer.FileSystem.FileExists(I1528FileNme) Then
        '        My.Computer.FileSystem.DeleteFile(I1528FileNme)
        '    End If
        '    My.Computer.FileSystem.CopyFile(newfilename, SAVEFilePATH + "\" + username + "PSV.xls")
        'End If


    End Sub



    Private Sub AddANewRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddANewRecordToolStripMenuItem.Click

        Me.Hide()
        If SizingMode = "ControlValve" Then

            ToolStripProgressBar1.Value = 0
            FrmModifyControlValve.Show()


        ElseIf SizingMode = "SafetyValve" Then

            ToolStripProgressBar1.Value = 0
            frmAddNewDataSafetyValve.Show()


        ElseIf SizingMode = "OrificePlate" Then

            ToolStripProgressBar1.Value = 0
            FrmAddNewOrifice.ShowDialog()

        ElseIf SizingMode = "RestrictPlate" Then

            ToolStripProgressBar1.Value = 0
            FrmAddNewRestrictPlate.Show()

        End If


    End Sub

    Private Sub UploadSafetyValveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadSafetyValveToolStripMenuItem.Click
        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "SafetyValve"
        SelectJobNo = FileMenu.Text
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

        ListFORMS.Items.Clear()
        ToolStripProgressBar1.Value = 0
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "(*.xlsx)|*.xlsx|(*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

            FileName = OpenFileDialog.FileName

            '將EXCEL DATA 轉成DATAGRIDVIEW
            Call Button1_Click(sender, e)
            ''''''''''''''''''''''''''''''''''''''''''''''''

            connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()
            Dim Foxfile As New DataSet

            Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
            Dim I As Integer
            ToolStripProgressBar1.Value = 20

            Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
                Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                    While dr.Read()
                        ToolStripProgressBar1.Value = 30
                        ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                    End While
                End Using
            End Using
            ToolStripProgressBar1.Value = 40

            Dim cmd As SqlCommand
            Dim cmddeletesttable As SqlCommand

            Dim Tablename As String
            Dim h As Integer
            h = InStr(OpenFileDialog.SafeFileName, ".")

            Tablename = SelectJobNo
            TextUploadFileName.Text = Tablename

            Dim StrImportToSql As String

            ToolStripProgressBar1.Value = 50

            '''''''''''''''''''''''''''''''''''''''''''''''
            Dim StrdeleTableTestToSql As String

            strTableTest = Tablename & "test"

            ToolStripProgressBar1.Value = 60


            For I = 0 To ListFORMS.Items.Count - 1
                If ListFORMS.Items(I).ToString = Tablename Then
                    StrImportToSql = "drop table " & Tablename & " "
                    cmd = New SqlClient.SqlCommand(StrImportToSql, conn)
                    cmd.ExecuteNonQuery()
                End If

                If ListFORMS.Items(I).ToString = strTableTest Then ''''''''''''''''delete測試的table
                    StrdeleTableTestToSql = "drop table " & strTableTest & " "
                    cmddeletesttable = New SqlClient.SqlCommand(StrdeleTableTestToSql, conn)
                    cmddeletesttable.ExecuteNonQuery()
                End If

            Next


            ToolStripProgressBar1.Value = 60
            ''''''''''''''''''''''''''''''''''''''''''Create a new table
            Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(0,1),Tag nchar(255),RequiredCapacity float,TemperatureC float," & _
                                "SetPressure float,TotalBackPressure float, OverPressure float,k float,SpGr float,MOLE float," & _
                "Rupture nchar(255),Phase nchar(255),Areasizein float,z float,CaseNo nchar(10),Designation nchar(255))", conn)

            objCmd.CommandType = CommandType.Text

            objCmd.ExecuteNonQuery()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'strTableTest = Tablename & "test"
            'StrImportToSql = "SELECT * INTO " & strTableTest & " FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0','Excel 8.0;Database=" & I1528FileNme & "', [sheet1$])"
            ToolStripProgressBar1.Value = 70
            'Debug.Print(StrImportToSql)

            ToolStripProgressBar1.Value = 80

            Dim strTag As String
            Dim douFlowW
            Dim douTempC
            Dim douSetP
            Dim douTotalBackP
            Dim douOverP
            Dim douK
            Dim douSpGr
            Dim douMole
            Dim strRupture As String
            Dim strPhase As String
            Dim douAreaSize
            Dim douZ
            Dim textCaseNo
            Dim strDesignation As String

            ''''''''''''''''''''''''''''''''''''''''將EXCEL DATA 轉入 SQL TABLE
            Dim strExceltoDataset As String
            For R = 0 To DataGridViewEXCELtoDATASET.Rows.Count - 1
                If DataGridViewEXCELtoDATASET.Item(0, R).Value Is Nothing Then

                Else

                    strTag = UCase(DataGridViewEXCELtoDATASET.Item(0, R).Value.ToString)

                    For col = 1 To DataGridViewEXCELtoDATASET.Columns.Count - 1 ''''''''''''''''''''without tagname
                        If DataGridViewEXCELtoDATASET.Item(col, R).Value.ToString = Nothing Then
                            If col = 1 Then

                                douFlowW = "default"

                            ElseIf col = 2 Then
                                douTempC = "default"

                            ElseIf col = 3 Then
                                douSetP = "default"

                            ElseIf col = 4 Then
                                douTotalBackP = "default"

                            ElseIf col = 5 Then

                                douOverP = "default"
                            ElseIf col = 6 Then

                                douK = "default"
                            ElseIf col = 7 Then
                                douSpGr = "default"

                            ElseIf col = 8 Then

                                douMole = "default"
                            ElseIf col = 9 Then

                                strRupture = ""
                            ElseIf col = 10 Then

                                strPhase = ""
                            ElseIf col = 11 Then

                                douAreaSize = "default"
                            ElseIf col = 12 Then

                                douZ = "default"

                            ElseIf col = 13 Then

                                textCaseNo = ""

                            ElseIf col = 14 Then

                                strDesignation = ""

                            End If
                        Else
                            If col = 1 Then

                                douFlowW = DataGridViewEXCELtoDATASET.Item(1, R).Value

                            ElseIf col = 2 Then
                                douTempC = DataGridViewEXCELtoDATASET.Item(2, R).Value

                            ElseIf col = 3 Then
                                douSetP = DataGridViewEXCELtoDATASET.Item(3, R).Value

                            ElseIf col = 4 Then
                                douTotalBackP = DataGridViewEXCELtoDATASET.Item(4, R).Value

                            ElseIf col = 5 Then

                                douOverP = DataGridViewEXCELtoDATASET.Item(5, R).Value
                            ElseIf col = 6 Then

                                douK = DataGridViewEXCELtoDATASET.Item(6, R).Value
                            ElseIf col = 7 Then

                                douSpGr = DataGridViewEXCELtoDATASET.Item(7, R).Value

                            ElseIf col = 8 Then

                                douMole = DataGridViewEXCELtoDATASET.Item(8, R).Value
                            ElseIf col = 9 Then

                                strRupture = UCase(DataGridViewEXCELtoDATASET.Item(9, R).Value.ToString)
                            ElseIf col = 10 Then

                                strPhase = UCase(DataGridViewEXCELtoDATASET.Item(10, R).Value.ToString)
                            ElseIf col = 11 Then

                                douAreaSize = DataGridViewEXCELtoDATASET.Item(11, R).Value
                            ElseIf col = 12 Then

                                douZ = DataGridViewEXCELtoDATASET.Item(12, R).Value

                            ElseIf col = 13 Then

                                textCaseNo = DataGridViewEXCELtoDATASET.Item(13, R).Value.ToString

                            ElseIf col = 14 Then

                                strDesignation = DataGridViewEXCELtoDATASET.Item(14, R).Value.ToString

                            End If

                        End If
                    Next


                    '查詢資料
                    strExceltoDataset = "INSERT INTO " & Tablename & " (Tag,RequiredCapacity,TemperatureC," & _
                                           "SetPressure, TotalBackPressure, OverPressure," & _
                                             "k,SpGr,MOLE,Rupture,Phase,Areasizein,z,CaseNo,Designation)" & _
                          "VALUES ('" & strTag & "', " & douFlowW & " ," & douTempC & "," & _
                                   "" & douSetP & "," & douTotalBackP & "," & _
                                   "" & douOverP & "," & douK & "," & douSpGr & "," & _
                                   "" & douMole & ",'" & strRupture & "','" & strPhase & "'," & douAreaSize & "," & _
                                   "" & douZ & ",'" & textCaseNo & "','" & strDesignation & "')"

                    Dim adp1 As SqlDataAdapter = New SqlDataAdapter(strExceltoDataset, conn)

                    Dim cmdEXCEL As SqlCommand = New SqlCommand(strExceltoDataset, conn)
                    cmdEXCEL.ExecuteNonQuery()

                End If

            Next

            ToolStripProgressBar1.Value = 90

            ToolStripProgressBar1.Value = 100


            conn.Close()
            ToolStripStatusLabel1.Text = "Upload Finish"

        End If

        Call SafetyValveToolStripMenuItem1_Click(sender, e)
        checkExistorNotTable()


        cvCount.Text = DataGridViewEXCELtoDATASET.Rows.Count - 1

    End Sub

    Private Sub ImportTestTabletoDataGridForTestTable(ByVal Tablename As String, ByVal connectstring As String, ByVal conn As SqlConnection)
        'If SizingMode = "ControlValve" Then
        '    '查詢資料
        '    Dim str As String = "select * from " & strTableTest
        '    Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '    '將查詢結果放到記憶體set1上的"1a "表格內
        '    Dim Testset As DataSet = New DataSet
        '    adp1.Fill(Testset, "TestTable")

        '    DataGridForTestTable.DataSource = Testset.Tables("TestTable")

        '    Dim i As Integer
        '    Dim cmd As New SqlCommand

        '    For i = 0 To DataGridForTestTable.Rows.Count - 1
        '        If DataGridForTestTable.Item(0, i).Value <> Nothing Then
        '            TStrTagname = DataGridForTestTable.Item(0, i).Value.ToString
        '            TdouSG = CDbl(DataGridForTestTable.Item(1, i).Value)
        '            TdouInletp = CDbl(DataGridForTestTable.Item(2, i).Value)
        '            Tdououtletp = CDbl(DataGridForTestTable.Item(3, i).Value)
        '            TdouFlowRate = CDbl(DataGridForTestTable.Item(4, i).Value)
        '            TStrPhase = UCase(DataGridForTestTable.Item(5, i).Value.ToString)
        '            TdouTemp = CDbl(DataGridForTestTable.Item(6, i).Value)
        '            TStrUnits = UCase(DataGridForTestTable.Item(7, i).Value.ToString)
        '            TdouCv = CDbl(DataGridForTestTable.Item(8, i).Value)
        '            TdouK = CDbl(DataGridForTestTable.Item(9, i).Value)
        '            TdouRO = CDbl(DataGridForTestTable.Item(10, i).Value)
        '            TdouZ = CDbl(DataGridForTestTable.Item(11, i).Value)
        '            TStrType = UCase(DataGridForTestTable.Item(12, i).Value.ToString)

        '            cmd.CommandText = "INSERT INTO " & Tablename & " (Tag,SGMOLE,IP," & _
        '                   "OP, FlowRate, Phase, Temperature,Unit, CV, K, Viscosity, Z,Type)" & _
        '                   "VALUES ('" & TStrTagname & "', " & TdouSG & " ," & TdouInletp & "," & _
        '                            "" & Tdououtletp & "," & TdouFlowRate & "," & _
        '                            "'" & TStrPhase & "'," & TdouTemp & ",'" & TStrUnits & "'," & _
        '                            "" & TdouCv & "," & TdouK & "," & TdouRO & "," & TdouZ & "," & _
        '                            "'" & TStrType & "')"

        '            cmd.Connection = conn
        '            cmd.ExecuteNonQuery()
        '        End If
        '    Next

        'ElseIf SizingMode = "SafetyValve" Then
        '    Dim str As String = "select * from " & strTableTest
        '    Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '    '將查詢結果放到記憶體set1上的"1a "表格內
        '    Dim Testset As DataSet = New DataSet
        '    adp1.Fill(Testset, "TestTable")

        '    DataGridForTestTable.DataSource = Testset.Tables("TestTable")

        '    Dim i As Integer
        '    Dim cmd As New SqlCommand

        '    For i = 0 To DataGridForTestTable.Rows.Count - 1
        '        If DataGridForTestTable.Item(0, i).Value <> Nothing Then
        '            TStrTagname = Trim(DataGridForTestTable.Item(0, i).Value.ToString)
        '            TdouWkg = CDbl(DataGridForTestTable.Item(1, i).Value)
        '            TdouTemp = CDbl(DataGridForTestTable.Item(2, i).Value)
        '            TdouP1 = CDbl(DataGridForTestTable.Item(3, i).Value)
        '            TdouTotalBack = CDbl(DataGridForTestTable.Item(4, i).Value)
        '            TdouOverP = CDbl(DataGridForTestTable.Item(5, i).Value)
        '            'TdouK = CDbl(DataGridForTestTable.Item(6, i).Value)
        '            TdouK = CDbl(DataGridForTestTable.Item(6, i).Value)
        '            TdouMOLE = CDbl(DataGridForTestTable.Item(7, i).Value)
        '            TStrRupture = UCase(Trim(DataGridForTestTable.Item(8, i).Value.ToString))
        '            TStrPhase = UCase(Trim(DataGridForTestTable.Item(9, i).Value.ToString))
        '            AreaSizein = CDbl(DataGridForTestTable.Item(10, i).Value)
        '            TdouZ = CDbl(DataGridForTestTable.Item(11, i).Value)


        '            cmd.CommandText = "INSERT INTO " & Tablename & " (Tag,RequiredCapacity,TemperatureC," & _
        '                                    "SetPressure, TotalBackPressure, OverPressure," & _
        '                                      "k, MOLE,Rupture,Phase,Areasizein,z)" & _
        '                   "VALUES ('" & TStrTagname & "', " & TdouWkg & " ," & TdouTemp & "," & _
        '                            "" & TdouP1 & "," & TdouTotalBack & "," & _
        '                            "" & TdouOverP & ",'" & TdouK & "'," & _
        '                            "" & TdouMOLE & ",'" & TStrRupture & "','" & TStrPhase & "'," & AreaSizein & "," & _
        '                            "" & TdouZ & ")"

        '            cmd.Connection = conn
        '            cmd.ExecuteNonQuery()
        '        End If
        '    Next
        'End If


    End Sub
    Private Sub ControlValveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlValveToolStripMenuItem.Click
        SizingModeControlValve.Checked = True
        SizingModeSafetyValve.Checked = False
        OrificePlateToolStripMenuItem.Checked = False
        RestrictPlateToolStripMenuItem1.Checked = False
        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False
        SizingMode = "ControlValve"
        StrCurrentFunction = "Browse" & " " & Me.oProjectname.ToString & " " & SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        DataGridBrowseData.DataSource = Nothing
        Dim str As String = "select * from " & oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "InstrumentTable")

        DataGridBrowseData.DataSource = set1.Tables("InstrumentTable")

        ''''''''''''''''''''add check box

        If boolcheckbox = False Then
            datacheckBox.HeaderText = "Delete"
            DataGridBrowseData.Columns.Insert(0, datacheckBox)
            boolcheckbox = True
        End If
        CheckDisplay.Checked = True
        displayErrorRecord.Checked = True

        conn.Close()
        DataGridBrowseData.Columns("id").Visible = False

        cvCount.Text = DataGridBrowseData.RowCount - 1

        Dim SortCol As DataGridViewColumn = DataGridBrowseData.Columns(2)
        DataGridBrowseData.Sort(SortCol, System.ComponentModel.ListSortDirection.Ascending)



    End Sub


    Private Sub SafetyValveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SafetyValveMenuItem1.Click
        SizingModeSafetyValve.Checked = True
        SizingModeControlValve.Checked = False
        OrificePlateToolStripMenuItem.Checked = False
        RestrictPlateToolStripMenuItem1.Checked = False

        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "SafetyValve"
        StrCurrentFunction = "Browse" & " " & Me.oProjectname.ToString & " " & SizingMode
        ToolStripLabel2.Text = StrCurrentFunction


        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        DataGridBrowseData.DataSource = Nothing
        Dim str As String = "select * from " & oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "SafetyTable")

        DataGridBrowseData.DataSource = set1.Tables("SafetyTable")

        If boolcheckbox = False Then
            datacheckBox.HeaderText = "Delete"
            DataGridBrowseData.Columns.Insert(0, datacheckBox)
            boolcheckbox = True
        End If

        CheckDisplay.Checked = True
        displayErrorRecord.Checked = True

        conn.Close()

        DataGridBrowseData.Columns("id").Visible = False

        Dim SortCol As DataGridViewColumn = DataGridBrowseData.Columns(2)
        DataGridBrowseData.Sort(SortCol, System.ComponentModel.ListSortDirection.Ascending)

        cvCount.Text = DataGridBrowseData.Rows.Count - 1

    End Sub

    Private Sub checkExistorNotTable()
        Dim connectstring As String
        Dim conn As SqlConnection
        Dim tablename As String
        Dim boolExist As Boolean
        Dim i As Integer

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''check safetyvalve table
        connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)
        conn.Open()
        Dim Foxfile As New DataSet
        SelectJobNo = FileMenu.Text
        tablename = FileMenu.Text
        Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
            Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                While dr.Read()
                    ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                End While
            End Using
        End Using

        For i = 0 To ListFORMS.Items.Count - 1
            If ListFORMS.Items(i).ToString = tablename Then
                boolExist = True
            End If
        Next
        If boolExist = True Then
            SafetyValveMenuItem1.Enabled = True
            CreateNewSafetyValve.Enabled = False
        Else
            SafetyValveMenuItem1.Enabled = False
            SafetyValveMenuItem1.ToolTipText = "Please upload Safety Valve to database"
        End If
        conn.Close()


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''check ControlValve table
        ListFORMS.Items.Clear() ''''''''清除原本的items
        boolExist = False
        connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)
        conn.Open()

        SelectJobNo = FileMenu.Text
        tablename = FileMenu.Text
        cs = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Using cmdGetForm1 As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
            Using dr1 As SqlDataReader = cmdGetForm1.ExecuteReader()
                While dr1.Read()
                    ListFORMS.Items.Add(dr1("TABLE_NAME").ToString())
                End While
            End Using
        End Using

        For i = 0 To ListFORMS.Items.Count - 1
            If ListFORMS.Items(i).ToString = tablename Then
                boolExist = True
            End If
        Next
        If boolExist = True Then
            ControlValveToolStripMenuItem.Enabled = True
            CreateNewControlValve.Enabled = False
        Else
            ControlValveToolStripMenuItem.Enabled = False
            ControlValveToolStripMenuItem.ToolTipText = "Please upload Control Valve to database"
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''check orifice table
        ListFORMS.Items.Clear() ''''''''清除原本的items
        boolExist = False
        connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)
        conn.Open()

        SelectJobNo = FileMenu.Text
        tablename = FileMenu.Text
        cs = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Using cmdGetForm1 As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
            Using dr1 As SqlDataReader = cmdGetForm1.ExecuteReader()
                While dr1.Read()
                    ListFORMS.Items.Add(dr1("TABLE_NAME").ToString())
                End While
            End Using
        End Using

        For i = 0 To ListFORMS.Items.Count - 1
            If ListFORMS.Items(i).ToString = tablename Then
                boolExist = True
            End If
        Next
        If boolExist = True Then
            OrToolStripMenuItem.Enabled = True
            CreateNewOr.Enabled = False
        Else
            OrToolStripMenuItem.Enabled = False ''''''''''''''browse button
            OrToolStripMenuItem.ToolTipText = "Please upload Orifice Plate to database"
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''check Restrict table
        ListFORMS.Items.Clear() ''''''''清除原本的items
        boolExist = False
        connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)
        conn.Open()

        SelectJobNo = FileMenu.Text
        tablename = FileMenu.Text
        cs = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Using cmdGetForm1 As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
            Using dr1 As SqlDataReader = cmdGetForm1.ExecuteReader()
                While dr1.Read()
                    ListFORMS.Items.Add(dr1("TABLE_NAME").ToString())
                End While
            End Using
        End Using

        For i = 0 To ListFORMS.Items.Count - 1
            If ListFORMS.Items(i).ToString = tablename Then
                boolExist = True
            End If
        Next
        If boolExist = True Then
            BROWSERestrictPlateToolStripMenuItem.Enabled = True
            RestrictPlateToolStripMenuItemCreate.Enabled = False
        Else
            BROWSERestrictPlateToolStripMenuItem.Enabled = False
            BROWSERestrictPlateToolStripMenuItem.ToolTipText = "Please upload Restrict Plate to database"
        End If



        conn.Close()

    End Sub




    Private Sub FileMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileMenu.Click
        'SizingModeControlValve.Checked = False
        'SizingModeSafetyValve.Checked = False
        'OrificePlateToolStripMenuItem.Checked = False
        'RestrictPlateToolStripMenuItem1.Checked = False
    End Sub


    Private Sub BrowseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseToolStripMenuItem.Click
        'DataGridBrowseData.Columns("id").Visible = False
        ListBoxforDeleteList.Items.Clear()
        ToolStripProgressBar1.Value = 0

        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

    End Sub



    Private Sub CreateANewTemplateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateANewTemplateToolStripMenuItem.Click
        ToolStripProgressBar1.Value = 0
    End Sub


    Private Sub CheckDisplay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDisplay.CheckedChanged


        If SizingMode = "ControlValve" Then
            If CheckDisplay.Checked = True Then
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    DataGridBrowseData.Item("NorCV", I).Style.BackColor = Color.Yellow
                    DataGridBrowseData.Item("BodySize", I).Style.BackColor = Color.Yellow
                Next
            Else
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    DataGridBrowseData.Item(24, I).Style.BackColor = Color.White 'COL="NorCV"
                    DataGridBrowseData.Item(27, I).Style.BackColor = Color.White 'COL="BodySize"
                Next
            End If

        ElseIf SizingMode = "SafetyValve" Then
            If CheckDisplay.Checked = True Then
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    DataGridBrowseData.Item("Areasizein", I).Style.BackColor = Color.Yellow
                    DataGridBrowseData.Item("Designation", I).Style.BackColor = Color.Yellow
                Next
            Else
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    On Error Resume Next
                    DataGridBrowseData.Item(13, I).Style.BackColor = Color.White   'COL="Areasizein"
                    DataGridBrowseData.Item(16, I).Style.BackColor = Color.White   'COL="Designation"
                Next
            End If

        ElseIf SizingMode = "OrificePlate" Then
            If CheckDisplay.Checked = True Then
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    '''''''''''''''''''''''''''''''''''''''''''''''''有加delete那一欄位
                    DataGridBrowseData.Item("OrificeBore", I).Style.BackColor = Color.Yellow
                Next
            Else
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    DataGridBrowseData.Item(13, I).Style.BackColor = Color.White  ''''COL ="OrificeBore"
                Next
            End If

        ElseIf SizingMode = "RestrictPlate" Then
            If CheckDisplay.Checked = True Then
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    '''''''''''''''''''''''''''''''''''''''''''''''''有加delete那一欄位
                    DataGridBrowseData.Item("OrificeBore", I).Style.BackColor = Color.Yellow
                Next
            Else
                For I = 0 To DataGridBrowseData.Rows.Count - 1
                    DataGridBrowseData.Item(12, I).Style.BackColor = Color.White  ''''COL ="OrificeBore"
                Next
            End If

        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If SizingMode = "ControlValve" Then

            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim cmdDelete As New SqlCommand
            Dim strdeleNm As String
            Dim index = 1

            '查詢資料
            For i = 0 To ListViewDeleteList.Items.Count - 1
                strdeleNm = ListViewDeleteList.Items(i).Text
                'strConditionText = ListViewDeleteList.Items(i).SubItems(index).Text

                Dim str As String = "delete from " & oProjectname.ToString & _
                                       " " & "where Tag= " & "'" & strdeleNm & "'"
                cmdDelete.CommandText = str
                cmdDelete.Connection = conn
                cmdDelete.ExecuteNonQuery()
            Next

            Call ControlValveToolStripMenuItem_Click(sender, e)
            conn.Close()

        ElseIf SizingMode = "SafetyValve" Then
            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim cmdDelete As New SqlCommand
            Dim strdeleNm As String
            '查詢資料
            For i = 0 To ListViewDeleteList.Items.Count - 1
                strdeleNm = ListViewDeleteList.Items(i).Text
                Dim str As String = "delete from " & oProjectname.ToString & _
                                       " " & "where Tag= " & "'" & strdeleNm & "'"
                cmdDelete.CommandText = str
                cmdDelete.Connection = conn
                cmdDelete.ExecuteNonQuery()
            Next

            Call SafetyValveToolStripMenuItem1_Click(sender, e)
            conn.Close()

        ElseIf SizingMode = "OrificePlate" Then
            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim cmdDelete As New SqlCommand
            Dim strdeleNm As String
            '查詢資料
            For i = 0 To ListViewDeleteList.Items.Count - 1
                strdeleNm = ListViewDeleteList.Items(i).Text
                Dim str As String = "delete from " & oProjectname.ToString & _
                                       " " & "where Tag= " & "'" & strdeleNm & "'"
                cmdDelete.CommandText = str
                cmdDelete.Connection = conn
                cmdDelete.ExecuteNonQuery()
            Next

            Call OrToolStripMenuItem_Click(sender, e)
            conn.Close()

        ElseIf SizingMode = "RestrictPlate" Then
            Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim cmdDelete As New SqlCommand
            Dim strdeleNm As String
            '查詢資料
            For i = 0 To ListViewDeleteList.Items.Count - 1
                strdeleNm = ListViewDeleteList.Items(i).Text
                Dim str As String = "delete from " & oProjectname.ToString & _
                                       " " & "where Tag= " & "'" & strdeleNm & "'"
                cmdDelete.CommandText = str
                cmdDelete.Connection = conn
                cmdDelete.ExecuteNonQuery()
            Next

            Call BROWSERestrictPlateToolStripMenuItem_Click(sender, e)
            conn.Close()

        End If
        ListViewDeleteList.Items.Clear()
        CheckBoxforDeleALL.Checked = False
    End Sub

    Private Sub CreateNewSafetyValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewSafetyValve.Click
        SizingMode = "SafetyValve"
        SelectJobNo = FileMenu.Text
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

        ListFORMS.Items.Clear()

        connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim Foxfile As New DataSet
        Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Dim Tablename As String

        Tablename = SelectJobNo
        TextUploadFileName.Text = Tablename

        Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(1,1),Tag nchar(10),RequiredCapacity float,TemperatureC float," & _
                                        "SetPressure float,TotalBackPressure float, OverPressure float," & _
                                          "k float,SpGr float,MOLE float," & _
                                            "Rupture nchar(10),Phase nchar(10),Areasizein float,z float,CaseNo nchar(10),Designation nchar(10))", conn)

        objCmd.CommandType = CommandType.Text

        objCmd.ExecuteNonQuery()

        Call SafetyValveToolStripMenuItem1_Click(sender, e)
        checkExistorNotTable()
    End Sub

    Private Sub CreateNewControlValve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewControlValve.Click
        SizingMode = "ControlValve"
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        SizingModeControlValve.CheckState = CheckState.Unchecked
        If SizingMode = "ControlValve" Then

            SelectJobNo = FileMenu.Text
            SizingModeControlValve.CheckState = CheckState.Checked

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()

            connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()
            Dim Foxfile As New DataSet

            Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
            Dim I As Integer
            Dim cmd As SqlCommand
            Dim Tablename As String


            Tablename = SelectJobNo
            TextUploadFileName.Text = Tablename


            ''''''''''''''''''''''''''''''''''''''''''Create a new table

            Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(0,1)," & _
            "Tag nchar(255),SpecificGravity float,Mole float,MinInletp float,NorInletp float,MaxInletp float," & _
            "MinDP float,NorDP float,MaxDP float,MinFlowRate float,NorFlowRate float," & _
            "MaxFlowRate float,Unit nchar(255), Phase nchar(255), Temperature float," & _
            "K float, Viscosity float, Z float,Type nchar(255),VaporPressure float," & _
            "CriticalPressure float,MinCV float,NorCV float,MaxCV float, LineSize float," & _
            "BodySize float,SelectCV float,Xt float,DPcondition nchar(255)," & _
            "Noise float,LineWallT float)", conn)

            objCmd.CommandType = CommandType.Text
            objCmd.ExecuteNonQuery()


        End If

        Call ControlValveToolStripMenuItem_Click(sender, e)


        checkExistorNotTable()
    End Sub


    Private Sub CheckBoxforDeleALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxforDeleALL.CheckedChanged
        ListViewDeleteList.Items.Clear()
        If CheckBoxforDeleALL.Checked = True Then

            For i = 0 To DataGridBrowseData.Rows.Count - 2
                DataGridBrowseData.Item(0, i).Value = True
                ListViewDeleteList.Items.Add(Trim(DataGridBrowseData.Item("Tag", i).Value))
                If SizingMode = "ControlValve" Then
                    ListViewDeleteList.Items(i).SubItems.Add(Trim(DataGridBrowseData.Item("Type", i).Value))

                ElseIf SizingMode = "SafetyValve" Then
                    ListViewDeleteList.Items(i).SubItems.Add(Trim(DataGridBrowseData.Item("CaseNo", i).Value))
                End If
            Next
        Else


            For i = 0 To DataGridBrowseData.Rows.Count - 2
                DataGridBrowseData.Item(0, i).Value = False
            Next
            ListViewDeleteList.Items.Clear()
        End If
    End Sub



    Private Sub ModifyRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyRecordToolStripMenuItem.Click
        FrmModify.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridBrowseData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridBrowseData.CellClick

        intSelectTagRow = e.RowIndex
        On Error Resume Next
        strSelectTagName = Trim(DataGridBrowseData.Item("Tag", intSelectTagRow).Value.ToString)

        '''''''''''''''''''''''''''''''''''''''有加delete那欄，所以全部順位加"1"

        If SizingMode = "ControlValve" Then
            strBodyType = Trim(DataGridBrowseData.Item("Type", intSelectTagRow).Value.ToString) '''''BODYTYPE那欄

        ElseIf SizingMode = "SafetyValve" Then

            strBodyType = Trim(DataGridBrowseData.Item("CaseNo", intSelectTagRow).Value.ToString) '''''CaseNo那欄

        End If


        '''''''''''''''''''''避免listbox加入重複項
        Dim Checkboxfinal As Boolean
        Checkboxfinal = DataGridBrowseData.Item(0, intSelectTagRow).Value
        If Checkboxfinal = True Then
            Checkboxfinal = False
        ElseIf Checkboxfinal = False Then
            Checkboxfinal = True
        End If


        checkdelectallOrNot(Checkboxfinal, strBodyType)
        DataGridBrowseData.Item(0, intSelectTagRow).Value = Checkboxfinal


    End Sub

    Private Sub checkdelectallOrNot(ByVal Checkboxfinal As Boolean, ByVal strConditionText As String)
        '''''''''''''''''''''避免listbox加入重複項
        If Checkboxfinal = True Then
            'If ListBoxforDeleteList.Items.Contains(strSelectTagName) = False Then
            'ListBoxforDeleteList.Items.Add(strSelectTagName)
            ListViewDeleteList.Items.Add(strSelectTagName)

            ListViewDeleteList.Items(ListViewDeleteList.Items.Count - 1).SubItems.Add(strConditionText)
            'End If

        ElseIf Checkboxfinal = False Then
            For i = ListViewDeleteList.Items.Count - 1 To 0 Step -1
                If SizingMode = "ControlValve" Or SizingMode = "SafetyValve" Then
                    If strSelectTagName = Trim(ListViewDeleteList.Items(i).Text) And strConditionText = Trim(ListViewDeleteList.Items(i).SubItems(1).Text) Then
                        ListBoxforDeleteList.Items.Remove(strSelectTagName)
                        ListViewDeleteList.Items.RemoveAt(i)
                    End If
                Else
                    If strSelectTagName = Trim(ListViewDeleteList.Items(i).Text) Then
                        ListBoxforDeleteList.Items.Remove(strSelectTagName)
                        ListViewDeleteList.Items.RemoveAt(i)
                    End If
                End If

            Next

        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayErrorRecord.CheckedChanged
        Dim cvValue
        Dim zero
        zero = 0

        If SizingMode = "ControlValve" Then
            For i = 0 To DataGridBrowseData.Rows.Count - 1
                If displayErrorRecord.Checked = False Then

                    DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.White
                    DataGridBrowseData.Item(24, i).Style.BackColor = Color.White 'COL="NorCV"
                    DataGridBrowseData.Item(27, i).Style.BackColor = Color.White 'COL="BodySize"
                Else
                    cvValue = DataGridBrowseData.Item("NorCV", i).Value
                    On Error Resume Next
                    If cvValue.ToString = Nothing Then

                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("NorCV", i).Style.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("BodySize", i).Style.BackColor = Color.MistyRose
                    ElseIf cvValue = zero Then
                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("NorCV", i).Style.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("BodySize", i).Style.BackColor = Color.MistyRose
                    End If
                End If

            Next
        ElseIf SizingMode = "SafetyValve" Then
            For i = 0 To DataGridBrowseData.Rows.Count - 1
                If displayErrorRecord.Checked = False Then

                    DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.White
                    DataGridBrowseData.Item(13, i).Style.BackColor = Color.White   'COL="Areasizein"
                    DataGridBrowseData.Item(16, i).Style.BackColor = Color.White   'COL="Designation"
                Else
                    cvValue = DataGridBrowseData.Item("Areasizein", i).Value
                    On Error Resume Next
                    If cvValue.ToString = Nothing Then

                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("Areasizein", i).Style.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("Designation", i).Style.BackColor = Color.MistyRose
                    ElseIf cvValue = zero Then
                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("Areasizein", i).Style.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("Designation", i).Style.BackColor = Color.MistyRose
                    End If
                End If

            Next

        ElseIf SizingMode = "OrificePlate" Then
            For i = 0 To DataGridBrowseData.Rows.Count - 1
                If displayErrorRecord.Checked = False Then

                    DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.White
                    DataGridBrowseData.Item(13, i).Style.BackColor = Color.White  ''''COL ="OrificeBore"
                Else
                    cvValue = DataGridBrowseData.Item("OrificeBore", i).Value
                    On Error Resume Next
                    If cvValue.ToString = Nothing Then

                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("OrificeBore", i).Style.BackColor = Color.MistyRose
                    ElseIf cvValue = zero Then
                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("OrificeBore", i).Style.BackColor = Color.MistyRose
                    End If

                End If

            Next

        ElseIf SizingMode = "RestrictPlate" Then
            For i = 0 To DataGridBrowseData.Rows.Count - 1
                If displayErrorRecord.Checked = False Then

                    DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.White
                    DataGridBrowseData.Item(12, i).Style.BackColor = Color.White  ''''COL ="OrificeBore"
                Else
                    cvValue = DataGridBrowseData.Item("OrificeBore", i).Value
                    On Error Resume Next
                    If cvValue.ToString = Nothing Then

                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("OrificeBore", i).Style.BackColor = Color.MistyRose
                    ElseIf cvValue = zero Then
                        DataGridBrowseData.Rows(i).DefaultCellStyle.BackColor = Color.MistyRose
                        DataGridBrowseData.Item("OrificeBore", i).Style.BackColor = Color.MistyRose
                    End If

                End If

            Next


        End If


    End Sub



    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim MsExcel As New DataTable

        '查詢資料
        Dim dsmas1 As DataSet = New DataSet
        Dim connectstring As String
        Dim str As String = "select * from " & oProjectname.ToString
        If SizingMode = "ControlValve" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "cTable")

        ElseIf SizingMode = "SafetyValve" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "sTable")

        ElseIf SizingMode = "OrificePlate" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "OTable")

        ElseIf SizingMode = "RestrictPlate" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "ROTable")
        End If




        '將查詢結果放到記憶體set1上的"1a "表格內



        Dim filename As String
        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        'Dim Workbooks As Microsoft.Office.Interop.Excel.Workbook
        'Dim Worksheets As Microsoft.Office.Interop.Excel.Worksheet

        With excel
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()

            If SizingMode = "ControlValve" Then

                .Cells(1, 1).value = "Tag"
                .Cells(1, 2).value = "S.G / Mole weight"
                .Cells(1, 3).value = "IP(kg/cm2)"
                .Cells(1, 4).value = "OP(kg/cm2)"
                .Cells(1, 5).value = "FlowRate(L=M3/h,V&G=NM3/h,S=Kg/h)"
                .Cells(1, 6).value = "Phase(G=V&G/L/S)"
                .Cells(1, 7).value = "Temperature(C)"
                .Cells(1, 8).value = "Unit(KG,NM3,M3)"
                .Cells(1, 9).value = "CV"
                .Cells(1, 10).value = "k(Cp/Cv,special heat)"
                .Cells(1, 11).value = "Viscosity"
                .Cells(1, 12).value = "Z(compressibility)"
                .Cells(1, 13).value = "TYPE(SGLO,ANGLE,BALL,BUTTE)"
                .Cells(1, 14).value = "Condition(Nor=Normal,Max=Maxmun,Min=Minmun)"
                .Cells(1, 15).value = "BodySize Size(in)"
                .Cells(1, 16).value = "LineSize(in)"
            ElseIf SizingMode = "SafetyValve" Then

                .Cells(1, 1).value = "Tag"
                .Cells(1, 2).value = "W_kgh"
                .Cells(1, 3).value = "Temp_C"
                .Cells(1, 4).value = "Set Pressure"
                .Cells(1, 5).value = "TotalBackPressure(Kg/cm2g)"
                .Cells(1, 6).value = "OverPressure(%)"
                .Cells(1, 7).value = "k(Cp/Cv,special heat)"
                .Cells(1, 8).value = "MOLE"
                .Cells(1, 9).value = "Rupture"
                .Cells(1, 10).value = "Phase"
                .Cells(1, 11).value = "AreaSize_in"
                .Cells(1, 12).value = "Z(compressibility)"
                .Cells(1, 13).value = "Designation"

            ElseIf SizingMode = "OrificePlate" Then
                .Cells(1, 1).value = "TAG"
                .Cells(1, 2).value = "Phase(L,V,S)"
                .Cells(1, 3).value = "Max Flow Rate(V&G=kg/h,L=m3/h,S=kg/h)"
                .Cells(1, 4).value = "Calculate Flow Rate(If It's RO,Calculate Flow Rate=Max Flow Rate)(V&G=kg/h,L=m3/h,S=kg/h)"
                .Cells(1, 5).value = "InletPressure(kg/cm2(Ga))"
                .Cells(1, 6).value = "Maxmun Differential (mmWC)"
                .Cells(1, 7).value = "Specific gravity"
                .Cells(1, 8).value = "Density(KG/M3)"
                .Cells(1, 9).value = "MoleWeight"
                .Cells(1, 10).value = "Temp(C)"
                .Cells(1, 11).value = "Pipe Inlet Diameter(mm)"
                .Cells(1, 12).value = "Orifice Bore(mm)"

            ElseIf SizingMode = "RestrictPlate" Then
                .Cells(1, 1).value = "TAG"
                .Cells(1, 2).value = "Phase(L,V,S)"
                .Cells(1, 3).value = "Max Flow Rate(V&G=kg/h,L=m3/h,S=kg/h)"
                .Cells(1, 4).value = "InletPressure(kg/cm2(Ga))"
                .Cells(1, 5).value = "Loss Pressure(kg/cm2)"
                .Cells(1, 6).value = "Specific gravity"
                .Cells(1, 7).value = "Density(KG/M3)"
                .Cells(1, 8).value = "MoleWeight"
                .Cells(1, 9).value = "Temp(C)"
                .Cells(1, 10).value = "Pipe Inlet Diameter(mm)"
                .Cells(1, 11).value = "Orifice Bore(mm)"

            End If





            Dim i As Integer = 1

            For col = 0 To dsmas1.Tables(0).Columns.Count - 1
                .Cells(1, i).EntireRow.Font.Bold = True
                i += 1
            Next

            i = 2

            Dim k As Integer = 1
            For col = 0 To dsmas1.Tables(0).Columns.Count - 1
                i = 2
                For row = 0 To dsmas1.Tables(0).Rows.Count - 1
                    If dsmas1.Tables(0).Rows(row).ItemArray(col).ToString = Nothing Then
                        .Cells(i, k).Value = ""
                    Else

                        .Cells(i, k).Value = Trim(dsmas1.Tables(0).Rows(row).ItemArray(col))

                    End If
                    i += 1
                Next
                k += 1
            Next


            filename = "c:\File_Exported " & SizingMode & ".xlsx"

            excel.Workbooks.Application.DisplayAlerts = False
            .ActiveCell.Worksheet.SaveAs(filename)
            excel.Quit()

            MsgBox("Save in " & filename)

        End With


    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click


    End Sub



    Private Sub ToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConvertExcelToDataset.Click
        ''''''''''ButtonConvertExcelToDataset  將excel 轉成dataset
        Dim connstring As String = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=Excel 12.0;"  '''''''''excel 2007
        'Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\NORMALcontrolvalve\control.xls;Extended Properties=Excel 8.0;"
        Dim conn As New OleDbConnection(connstring)
        Dim objDataset1 As New DataSet
        Dim cmd As New OleDbCommand("select * from [sheet1$]", conn)
        Dim newdataadapter As New OleDbDataAdapter
        newdataadapter.SelectCommand = cmd
        newdataadapter.Fill(objDataset1, "dd")
        DataGridViewEXCELtoDATASET.DataSource = objDataset1.Tables("DD")

    End Sub


    Private Sub ListViewDeleteList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDeleteList.SelectedIndexChanged

    End Sub

    'Private Sub DataGridBrowseData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridBrowseData.CellContentClick
    '    'Dim objteset As New ClassUploadfile
    '    'objteset.username = "aaa"

    '    'objteset.Capitalize()
    '    'MsgBox(objteset.username)
    'End Sub

    Private Sub UploadROToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadROToolStripMenuItem.Click
        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "OrificePlate"
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        SizingModeControlValve.CheckState = CheckState.Unchecked
        OrificePlateToolStripMenuItem.CheckState = CheckState.Unchecked
        SizingModeSafetyValve.CheckState = CheckState.Unchecked


        If SizingMode = "OrificePlate" Then

            SelectJobNo = FileMenu.Text
            OrificePlateToolStripMenuItem.CheckState = CheckState.Checked
            OrificePlateToolStripMenuItem.Checked = True

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()
            ToolStripProgressBar1.Value = 0
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "(*.xlsx)|*.xlsx|(*.*)|*.*"
            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                FileName = OpenFileDialog.FileName

                '將EXCEL DATA 轉成DATAGRIDVIEW
                Call Button1_Click(sender, e)
                ''''''''''''''''''''''''''''''''''''''''''''''''
                connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

                conn = New SqlConnection(connectstring)
                conn.Open()
                Dim Foxfile As New DataSet

                Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
                Dim I As Integer
                ToolStripProgressBar1.Value = 20

                Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
                    Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                        While dr.Read()
                            ToolStripProgressBar1.Value = 30
                            ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                        End While
                    End Using
                End Using
                ToolStripProgressBar1.Value = 40

                Dim cmd As SqlCommand
                Dim cmddeletesttable As SqlCommand
                Dim Tablename As String
                Dim h As Integer
                h = InStr(OpenFileDialog.SafeFileName, ".")

                Tablename = SelectJobNo
                TextUploadFileName.Text = Tablename

                Dim StrImportToSql As String
                Dim StrdeleTableTestToSql As String


                strTableTest = Tablename & "test"

                ToolStripProgressBar1.Value = 50
                For I = 0 To ListFORMS.Items.Count - 1
                    If ListFORMS.Items(I).ToString = Tablename Then ''''''''''''''''delete正常的table
                        StrImportToSql = "drop table " & Tablename & " "
                        cmd = New SqlClient.SqlCommand(StrImportToSql, conn)
                        cmd.ExecuteNonQuery()
                    End If

                    If ListFORMS.Items(I).ToString = strTableTest Then ''''''''''''''''delete測試的table
                        StrdeleTableTestToSql = "drop table " & strTableTest & " "
                        cmddeletesttable = New SqlClient.SqlCommand(StrdeleTableTestToSql, conn)
                        cmddeletesttable.ExecuteNonQuery()
                    End If
                Next
                ToolStripProgressBar1.Value = 60

                ''''''''''''''''''''''''''''''''''''''''''Create a new table
                Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(0,1),Tag nchar(255),Phase nchar(255)," & _
                                             "FlowRate float,CalculateFlowRate float,InletPressure float,LossPmmWC float,Gravity float, Density float," & _
                                             "Mole float,TemperatureC float,PipeInletD float,OrificeBore float,Viscosity float,Reo float,Betaratio float,CalculateMode float,PressureLoss float)", conn)

                objCmd.CommandType = CommandType.Text

                objCmd.ExecuteNonQuery()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''將選好的excel新增到sql中
                Dim StrTagname As String
                Dim StrPhase As String
                Dim douFlowRate
                Dim douCalculateFL
                Dim douInletp
                Dim douLosspmmWC
                Dim douSG
                Dim douDensity
                Dim douMole
                Dim douTemp
                Dim douPipeInletD
                Dim douOrificeBore
                Dim douViscosity
                Dim douReo
                Dim douCalculateMode
                Dim strExceltoDataset As String


                ToolStripProgressBar1.Value = 70
                For R = 0 To DataGridViewEXCELtoDATASET.Rows.Count - 1
                    If DataGridViewEXCELtoDATASET.Item(0, R).Value Is Nothing Then
                    Else

                        StrTagname = UCase(DataGridViewEXCELtoDATASET.Item(0, R).Value.ToString)

                        For col = 1 To DataGridViewEXCELtoDATASET.Columns.Count - 1 ''''''''''''''''''''without tagname
                            If DataGridViewEXCELtoDATASET.Item(col, R).Value.ToString = Nothing Then
                                If col = 1 Then

                                    StrPhase = ""
                                ElseIf col = 2 Then

                                    douFlowRate = "default"

                                ElseIf col = 3 Then
                                    douCalculateFL = "default"

                                ElseIf col = 4 Then
                                    douInletp = "default"

                                ElseIf col = 5 Then
                                    douLosspmmWC = "default"

                                ElseIf col = 6 Then
                                    douSG = "default"

                                ElseIf col = 7 Then
                                    douDensity = "default"

                                ElseIf col = 8 Then

                                    douMole = "default"
                                ElseIf col = 9 Then

                                    douTemp = "default"

                                ElseIf col = 10 Then

                                    douPipeInletD = "default"
                                ElseIf col = 11 Then

                                    douOrificeBore = "default"

                                ElseIf col = 12 Then

                                    douViscosity = "default"

                                ElseIf col = 13 Then

                                    douReo = "default"

                                ElseIf col = 14 Then

                                    douCalculateMode = "default"
                                End If
                            Else
                                If col = 1 Then
                                    StrPhase = UCase(DataGridViewEXCELtoDATASET.Item(1, R).Value.ToString)

                                ElseIf col = 2 Then

                                    douFlowRate = DataGridViewEXCELtoDATASET.Item(2, R).Value

                                ElseIf col = 3 Then
                                    douCalculateFL = DataGridViewEXCELtoDATASET.Item(3, R).Value

                                ElseIf col = 4 Then
                                    douInletp = DataGridViewEXCELtoDATASET.Item(4, R).Value

                                ElseIf col = 5 Then
                                    douLosspmmWC = DataGridViewEXCELtoDATASET.Item(5, R).Value

                                ElseIf col = 6 Then
                                    douSG = DataGridViewEXCELtoDATASET.Item(6, R).Value

                                ElseIf col = 7 Then
                                    douDensity = DataGridViewEXCELtoDATASET.Item(7, R).Value

                                ElseIf col = 8 Then

                                    douMole = DataGridViewEXCELtoDATASET.Item(8, R).Value
                                ElseIf col = 9 Then

                                    douTemp = DataGridViewEXCELtoDATASET.Item(9, R).Value

                                ElseIf col = 10 Then

                                    douPipeInletD = DataGridViewEXCELtoDATASET.Item(10, R).Value
                                ElseIf col = 11 Then

                                    douOrificeBore = DataGridViewEXCELtoDATASET.Item(11, R).Value

                                ElseIf col = 12 Then

                                    douViscosity = DataGridViewEXCELtoDATASET.Item(12, R).Value

                                ElseIf col = 13 Then

                                    douReo = DataGridViewEXCELtoDATASET.Item(13, R).Value

                                ElseIf col = 14 Then

                                    douCalculateMode = DataGridViewEXCELtoDATASET.Item(14, R).Value

                                End If

                            End If
                        Next


                        '查詢資料
                        strExceltoDataset = "Insert Into " & Tablename & "(Tag,Phase,FlowRate,CalculateFlowRate,InletPressure,LossPmmWC,Gravity,Density,Mole,TemperatureC,PipeInletD,OrificeBore,Viscosity,Reo,CalculateMode)" & _
                                              "Values( '" & StrTagname & "','" & StrPhase & "'," & douFlowRate & "," & douCalculateFL & "," & douInletp & "," & _
                                              "" & douLosspmmWC & "," & douSG & "," & douDensity & "," & douMole & "," & douTemp & "," & _
                                                       "" & douPipeInletD & "," & douOrificeBore & "," & douViscosity & "," & douReo & "," & douCalculateMode & ")"

                        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(strExceltoDataset, conn)

                        Dim cmdEXCEL As SqlCommand = New SqlCommand(strExceltoDataset, conn)
                        cmdEXCEL.ExecuteNonQuery()

                    End If

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ToolStripProgressBar1.Value = 80
                'ImportTestTabletoDataGridForTestTable(Tablename, connectstring, conn) ''''''''''將testTable讀入gridview


                ToolStripProgressBar1.Value = 90

                ToolStripProgressBar1.Value = 100
                ToolStripStatusLabel1.Text = "Upload Finish"

                '''''''''''''''''''''''''''''''delete testTable
                'StrdeleTableTestToSql = "drop table " & strTableTest & " "
                'cmddeletesttable = New SqlClient.SqlCommand(StrdeleTableTestToSql, conn)
                'cmddeletesttable.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''
                conn.Close()

            End If

        End If

        cvCount.Text = DataGridViewEXCELtoDATASET.Rows.Count - 1

        Call OrToolStripMenuItem_Click(sender, e)
        checkExistorNotTable()
    End Sub

    Private Sub OrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrToolStripMenuItem.Click
        OrificePlateToolStripMenuItem.Checked = CheckState.Checked

        RestrictPlateToolStripMenuItem1.Checked = False
        SizingModeSafetyValve.Checked = False
        SizingModeControlValve.Checked = False

        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "OrificePlate"
        StrCurrentFunction = "Browse" & " " & Me.oProjectname.ToString & " " & SizingMode

        ToolStripLabel2.Text = StrCurrentFunction


        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        DataGridBrowseData.DataSource = Nothing
        Dim str As String = "select * from " & oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "RoOrTable")

        DataGridBrowseData.DataSource = set1.Tables("RoOrTable")

        ''''''''''''''''''''add check box

        If boolcheckbox = False Then

            datacheckBox.HeaderText = "Delete"
            DataGridBrowseData.Columns.Insert(0, datacheckBox)
            boolcheckbox = True
        End If
        CheckDisplay.Checked = True
        displayErrorRecord.Checked = True


        conn.Close()
        DataGridBrowseData.Columns("id").Visible = False

        Dim SortCol As DataGridViewColumn = DataGridBrowseData.Columns(2)
        DataGridBrowseData.Sort(SortCol, System.ComponentModel.ListSortDirection.Ascending)

        cvCount.Text = DataGridBrowseData.Rows.Count - 1

    End Sub

    Private Sub CreateNewOr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewOr.Click
        SizingMode = "OrificePlate"  '''''''''''''將sizingmode塞入字串中~~
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction

        If SizingMode = "OrificePlate" Then

            SelectJobNo = FileMenu.Text
            OrificePlateToolStripMenuItem.CheckState = CheckState.Checked

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()

            connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()
            Dim Foxfile As New DataSet

            Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
            Dim I As Integer
            Dim cmd As SqlCommand
            Dim Tablename As String


            Tablename = SelectJobNo
            TextUploadFileName.Text = Tablename


            ''''''''''''''''''''''''''''''''''''''''''Create a new table
            Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(1,1),Tag nchar(255),Phase nchar(255),FlowRate float," & _
                                         "CalculateFlowRate float,InletPressure float,LossPmmWC float,Gravity float, Density float,Mole float,TemperatureC float," & _
                                         "PipeInletD float,OrificeBore float,Viscosity float,Reo float,Betaratio float,CalculateMode float,PressureLoss float)", conn)

            objCmd.CommandType = CommandType.Text

            objCmd.ExecuteNonQuery()


        End If


        Call OrToolStripMenuItem_Click(sender, e)
        checkExistorNotTable()
    End Sub

    Private Sub UploadRestrictPlateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadRestrictPlateToolStripMenuItem.Click
        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False


        SizingMode = "RestrictPlate"
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction
        SizingModeControlValve.CheckState = CheckState.Unchecked
        OrificePlateToolStripMenuItem.CheckState = CheckState.Unchecked
        SizingModeSafetyValve.CheckState = CheckState.Unchecked


        If SizingMode = "RestrictPlate" Then

            SelectJobNo = FileMenu.Text
            RestrictPlateToolStripMenuItem1.CheckState = CheckState.Checked

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()
            ToolStripProgressBar1.Value = 0
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "(*.xlsx)|*.xlsx|(*.*)|*.*"
            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                FileName = OpenFileDialog.FileName

                '將EXCEL DATA 轉成DATAGRIDVIEW
                Call Button1_Click(sender, e)
                ''''''''''''''''''''''''''''''''''''''''''''''''
                connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

                conn = New SqlConnection(connectstring)
                conn.Open()
                Dim Foxfile As New DataSet

                Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
                Dim I As Integer
                ToolStripProgressBar1.Value = 20

                Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
                    Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                        While dr.Read()
                            ToolStripProgressBar1.Value = 30
                            ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                        End While
                    End Using
                End Using
                ToolStripProgressBar1.Value = 40

                Dim cmd As SqlCommand
                Dim cmddeletesttable As SqlCommand
                Dim Tablename As String
                Dim h As Integer
                h = InStr(OpenFileDialog.SafeFileName, ".")

                Tablename = SelectJobNo
                TextUploadFileName.Text = Tablename

                Dim StrImportToSql As String
                Dim StrdeleTableTestToSql As String


                strTableTest = Tablename & "test"

                ToolStripProgressBar1.Value = 50
                For I = 0 To ListFORMS.Items.Count - 1
                    If ListFORMS.Items(I).ToString = Tablename Then ''''''''''''''''delete正常的table
                        StrImportToSql = "drop table " & Tablename & " "
                        cmd = New SqlClient.SqlCommand(StrImportToSql, conn)
                        cmd.ExecuteNonQuery()
                    End If

                    If ListFORMS.Items(I).ToString = strTableTest Then ''''''''''''''''delete測試的table
                        StrdeleTableTestToSql = "drop table " & strTableTest & " "
                        cmddeletesttable = New SqlClient.SqlCommand(StrdeleTableTestToSql, conn)
                        cmddeletesttable.ExecuteNonQuery()
                    End If
                Next
                ToolStripProgressBar1.Value = 60

                ''''''''''''''''''''''''''''''''''''''''''Create a new table
                Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(0,1),Tag nchar(255),Phase nchar(255)," & _
                                             "MaxFlowRate float,InletPressure float,LossPressure float,Gravity float, Density float," & _
                                             "Mole float,TemperatureC float,PipeInletD float,OrificeBore float,CalculateMode float)", conn)

                objCmd.CommandType = CommandType.Text

                objCmd.ExecuteNonQuery()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''將選好的excel新增到sql中
                Dim StrTagname As String
                Dim StrPhase As String
                Dim douFlowRate

                Dim douInletp
                Dim douLossp
                Dim douSG
                Dim douDensity
                Dim douMole
                Dim douTemp
                Dim douPipeInletD
                Dim douOrificeBore
                Dim strExceltoDataset As String
                Dim douCalculateMode

                ToolStripProgressBar1.Value = 70
                For R = 0 To DataGridViewEXCELtoDATASET.Rows.Count - 1
                    If DataGridViewEXCELtoDATASET.Item(0, R).Value Is Nothing Then
                    Else


                        StrTagname = UCase(DataGridViewEXCELtoDATASET.Item(0, R).Value.ToString)

                        For col = 1 To DataGridViewEXCELtoDATASET.Columns.Count - 1 ''''''''''''''''''''without tagname
                            If DataGridViewEXCELtoDATASET.Item(col, R).Value.ToString = Nothing Then
                                If col = 1 Then

                                    StrPhase = ""
                                ElseIf col = 2 Then

                                    douFlowRate = "default"

                                ElseIf col = 3 Then
                                    douInletp = "default"

                                ElseIf col = 4 Then
                                    douLossp = "default"

                                ElseIf col = 5 Then
                                    douSG = "default"

                                ElseIf col = 6 Then
                                    douDensity = "default"

                                ElseIf col = 7 Then

                                    douMole = "default"
                                ElseIf col = 8 Then

                                    douTemp = "default"

                                ElseIf col = 9 Then

                                    douPipeInletD = "default"
                                ElseIf col = 10 Then

                                    douOrificeBore = "default"

                                ElseIf col = 11 Then

                                    douCalculateMode = "default"

                                End If


                            Else
                                If col = 1 Then
                                    StrPhase = UCase(DataGridViewEXCELtoDATASET.Item(1, R).Value.ToString)

                                ElseIf col = 2 Then

                                    douFlowRate = DataGridViewEXCELtoDATASET.Item(2, R).Value

                                ElseIf col = 3 Then
                                    douInletp = DataGridViewEXCELtoDATASET.Item(3, R).Value

                                ElseIf col = 4 Then
                                    douLossp = DataGridViewEXCELtoDATASET.Item(4, R).Value

                                ElseIf col = 5 Then
                                    douSG = DataGridViewEXCELtoDATASET.Item(5, R).Value

                                ElseIf col = 6 Then
                                    douDensity = DataGridViewEXCELtoDATASET.Item(6, R).Value

                                ElseIf col = 7 Then

                                    douMole = DataGridViewEXCELtoDATASET.Item(7, R).Value
                                ElseIf col = 8 Then

                                    douTemp = DataGridViewEXCELtoDATASET.Item(8, R).Value

                                ElseIf col = 9 Then

                                    douPipeInletD = DataGridViewEXCELtoDATASET.Item(9, R).Value
                                ElseIf col = 10 Then

                                    douOrificeBore = DataGridViewEXCELtoDATASET.Item(10, R).Value

                                ElseIf col = 11 Then

                                    douCalculateMode = DataGridViewEXCELtoDATASET.Item(11, R).Value

                                End If

                            End If
                        Next


                        '查詢資料
                        strExceltoDataset = "Insert Into " & Tablename & "(Tag,Phase,MaxFlowRate,InletPressure,LossPressure,Gravity,Density,Mole,TemperatureC,PipeInletD,OrificeBore,CalculateMode)" & _
                                              "Values( '" & StrTagname & "','" & StrPhase & "'," & douFlowRate & "," & douInletp & "," & _
                                              "" & douLossp & "," & douSG & "," & douDensity & "," & douMole & "," & douTemp & "," & _
                                                       "" & douPipeInletD & "," & douOrificeBore & "," & douCalculateMode & ")"
                        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(strExceltoDataset, conn)

                        Dim cmdEXCEL As SqlCommand = New SqlCommand(strExceltoDataset, conn)
                        cmdEXCEL.ExecuteNonQuery()

                    End If

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ToolStripProgressBar1.Value = 80
                ToolStripProgressBar1.Value = 90
                ToolStripProgressBar1.Value = 100
                ToolStripStatusLabel1.Text = "Upload Finish"

                conn.Close()

            End If

        End If

        Call BROWSERestrictPlateToolStripMenuItem_Click(sender, e)
        checkExistorNotTable()

        cvCount.Text = DataGridViewEXCELtoDATASET.Rows.Count - 1

    End Sub

    Private Sub RestrictPlateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestrictPlateToolStripMenuItem1.Click

    End Sub


    Private Sub RestrictPlateToolStripMenuItemCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestrictPlateToolStripMenuItemCreate.Click
        SizingMode = "RestrictPlate"  '''''''''''''將sizingmode塞入字串中~~
        StrCurrentFunction = SizingMode
        ToolStripLabel2.Text = StrCurrentFunction

        If SizingMode = "RestrictPlate" Then

            SelectJobNo = FileMenu.Text
            RestrictPlateToolStripMenuItem1.CheckState = CheckState.Checked

            AddANewRecordToolStripMenuItem.Enabled = True ''''''''''''''''''''''ADD NEW RECORD

            ListFORMS.Items.Clear()

            connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

            conn = New SqlConnection(connectstring)
            conn.Open()
            Dim Foxfile As New DataSet

            Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE
            Dim Tablename As String


            Tablename = SelectJobNo
            TextUploadFileName.Text = Tablename


            ''''''''''''''''''''''''''''''''''''''''''Create a new table
            Dim objCmd As New SqlCommand("Create Table" & " " & Tablename & "([id] int primary key IDENTITY(1,1),Tag nchar(255),Phase nchar(255),MaxFlowRate float," & _
                                         "InletPressure float,LossPressure float,Gravity float, Density float,Mole float,TemperatureC float," & _
                                         "PipeInletD float,OrificeBore float,CalculateMode float)", conn)

            objCmd.CommandType = CommandType.Text

            objCmd.ExecuteNonQuery()


        End If


        Call BROWSERestrictPlateToolStripMenuItem_Click(sender, e)
        checkExistorNotTable()
    End Sub


    Private Sub BROWSERestrictPlateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BROWSERestrictPlateToolStripMenuItem.Click
        OrificePlateToolStripMenuItem.Checked = False
        SizingModeSafetyValve.Checked = False
        SizingModeControlValve.Checked = False
        RestrictPlateToolStripMenuItem1.Checked = CheckState.Checked

        CheckDisplay.Checked = False
        displayErrorRecord.Checked = False

        SizingMode = "RestrictPlate"
        StrCurrentFunction = "Browse" & " " & Me.oProjectname.ToString & " " & SizingMode

        ToolStripLabel2.Text = StrCurrentFunction


        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        DataGridBrowseData.DataSource = Nothing
        Dim str As String = "select * from " & oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "RestrictPlate")

        DataGridBrowseData.DataSource = set1.Tables("RestrictPlate")

        ''''''''''''''''''''add check box

        If boolcheckbox = False Then

            datacheckBox.HeaderText = "Delete"
            DataGridBrowseData.Columns.Insert(0, datacheckBox)
            boolcheckbox = True
        End If
        CheckDisplay.Checked = True
        displayErrorRecord.Checked = True

        conn.Close()
        DataGridBrowseData.Columns("id").Visible = False

        Dim SortCol As DataGridViewColumn = DataGridBrowseData.Columns(2)
        DataGridBrowseData.Sort(SortCol, System.ComponentModel.ListSortDirection.Ascending)

        cvCount.Text = DataGridBrowseData.Rows.Count - 1

    End Sub





    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
 
        Dim OpenFileDialog1 As New OpenFileDialog

        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog1.Filter = "(*.*)|*.*|(*.*)|*.*"
        If (OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            PrintFileName = OpenFileDialog1.FileName
        End If
        Dim docName As String = PrintFileName

        PrintDocument1.DocumentName = docName
        PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = True

        Dim x1 As New Excel.Application
        Dim WS As New Excel.Worksheet

        x1.Workbooks.Open(docName)  '測試用excel檔   
        WS.PageSetup.FitToPagesTall = AutoSize
        WS.PageSetup.FitToPagesWide = 1
        x1.ActiveWorkbook.PrintOut()
        x1.Quit()
        x1 = Nothing

        MsgBox("Finish")

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.FillRectangle(Brushes.Red, New Rectangle(500, 500, 500, 500))


        Dim charactersOnPage As Integer = 0
        Dim linesPerPage As Integer = 0

        ' Sets the value of charactersOnPage to the number of characters 
        ' of stringToPrint that will fit within the bounds of the page.
        e.Graphics.MeasureString(stringToPrint, Me.Font, e.MarginBounds.Size, _
            StringFormat.GenericTypographic, charactersOnPage, linesPerPage)

        ' Draws the string within the bounds of the page
        e.Graphics.DrawString(stringToPrint, Me.Font, Brushes.Black, _
            e.MarginBounds, StringFormat.GenericTypographic)

        ' Remove the portion of the string that has been printed.
        stringToPrint = stringToPrint.Substring(charactersOnPage)

        ' Check to see if more pages are to be printed.
        e.HasMorePages = stringToPrint.Length > 0

    End Sub


    'Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
    '    Dim linesPerPage As Single = 0
    '    Dim yPos As Single = 0
    '    Dim count As Integer = 0
    '    Dim leftMargin As Single = ev.MarginBounds.Left
    '    Dim topMargin As Single = ev.MarginBounds.Top
    '    Dim line As String = Nothing

    '    ' Calculate the number of lines per page.
    '    linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

    '    ' Print each line of the file.
    '    While count < linesPerPage
    '        line = streamToPrint.ReadLine()
    '        If line Is Nothing Then
    '            Exit While
    '        End If
    '        yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
    '        ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
    '        count += 1
    '    End While

    '    ' If more lines exist, print another page.
    '    If (line IsNot Nothing) Then
    '        ev.HasMorePages = True
    '    Else
    '        ev.HasMorePages = False
    '    End If
    'End Sub


    'Public Function GetData() As DataView
    '    Dim SelectQry = "select * from " & oProjectname.ToString
    '    'Dim SelectQry = "SELECT * FROM products "
    '    Dim SampleSource As New DataSet
    '    Dim TableView As DataView
    '    Try
    '        Dim SampleCommand As New SqlCommand()
    '        Dim SampleDataAdapter = New SqlDataAdapter()
    '        SampleCommand.CommandText = SelectQry
    '        SampleCommand.Connection = Connection
    '        SampleDataAdapter.SelectCommand = SampleCommand
    '        SampleDataAdapter.Fill(SampleSource)
    '        TableView = SampleSource.Tables(0).DefaultView
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return TableView
    'End Function
    ''Private Sub btnLoad_Click(ByVal sender As System.Object, _
    ''                          ByVal e As System.EventArgs) Handles btnLoad.Click
    ''    DataGridBrowseData.DataSource = GetData()
    ''End Sub
    'Private Sub GridViewPrintDocument_PrintPage(ByVal sender As Object, _
    '                           ByVal e As PrintPageEventArgs)
    '    PrintGridView(e.Graphics)
    'End Sub
    'Private Sub btnPrint_Click(ByVal sender As Object, _
    '                           ByVal e As System.EventArgs) Handles btnPrint.Click
    '    DataGridBrowseData.DataSource = GetData()
    '    Dim GridViewPrintDocument As New Printing.PrintDocument
    '    GridViewPrintDocument.DefaultPageSettings.Landscape = True
    '    AddHandler GridViewPrintDocument.PrintPage, _
    '    AddressOf GridViewPrintDocument_PrintPage
    '    GridViewPrintDocument.Print()
    'End Sub
    'Private Sub PrintGridView(ByVal GxPrint As Graphics)

    '    DrawGridViewBox(GxPrint)
    '    DrawGridViewHeader(GxPrint)
    '    DrawGridViewRows(GxPrint)
    'End Sub
    'Private Sub DrawGridViewHeader(ByVal GxPrint As Graphics)
    '    Dim CellText = String.Empty
    '    Dim StartTop = DataGridBrowseData.Top
    '    Dim PrintFont As New Font(New FontFamily("Microsoft Sans Serif"), _
    '                                     10, FontStyle.Bold)
    '    Dim StartLeft = DataGridBrowseData.Left

    '    For Each PrintCol As DataGridViewColumn In DataGridBrowseData.Columns
    '        'If PrintCol.HeaderText = "Delete" Then
    '        '    GoTo nextgoto
    '        'Else
    '        PrintCol.Width = DataGridBrowseData.Width / (DataGridBrowseData.Columns.Count + 2)
    '        CellText = PrintCol.HeaderText
    '        GxPrint.DrawString(CellText, PrintFont, Brushes.Gray, _
    '                               StartLeft, StartTop)
    '        GxPrint.DrawLine(Pens.Black, StartLeft, StartTop, _
    '                         StartLeft, StartTop + DataGridBrowseData.Rows(0).Height)
    '        'StartLeft += PrintCol.Width * FontAdjustmentFactor
    '        StartLeft += PrintCol.Width
    '        'End If
    '        'nextgoto:
    '    Next
    '    GxPrint.DrawLine(Pens.Black, DataGridBrowseData.Left, _
    '                     StartTop + DataGridBrowseData.Rows(0).Height, _
    '                      CInt(DataGridBrowseData.Width - 10), _
    '                     StartTop + DataGridBrowseData.Rows(0).Height)
    'End Sub

    'Private Sub DrawGridViewRows(ByVal GxPrint As Graphics)
    '    Dim RowIndex = 1 'since header is used so we start with 1
    '    Dim PrintFont As New Font(New FontFamily("Microsoft Sans Serif"), _
    '                                      10, FontStyle.Regular)
    '    For Each PrintRow As DataGridViewRow In DataGridBrowseData.Rows
    '        Dim StartTop = DataGridBrowseData.Top + (RowIndex * PrintRow.Height)
    '        Dim ColIndex = 0
    '        Dim StartLeft = DataGridBrowseData.Left
    '        For Each PrintCell As DataGridViewCell In PrintRow.Cells

    '            'StartLeft *= FontAdjustmentFactor
    '            Dim CellText = String.Empty
    '            If (Not IsDBNull(PrintCell.Value)) Then CellText = PrintCell.Value

    '            GxPrint.DrawString(Trim(CellText), PrintFont, Brushes.Gray, _
    '                               StartLeft, StartTop)
    '            GxPrint.DrawLine(Pens.Black, StartLeft, StartTop, _
    '                             StartLeft, StartTop + PrintRow.Height)
    '            StartLeft += DataGridBrowseData.Width / (PrintRow.Cells.Count + 2)
    '            ColIndex += 1

    '        Next
    '        GxPrint.DrawLine(Pens.Black, DataGridBrowseData.Left, _
    '                         StartTop + PrintRow.Height, _
    '                         CInt(DataGridBrowseData.Width) - 10, _
    '                         StartTop + PrintRow.Height)
    '        RowIndex += 1
    '    Next
    'End Sub

    'Private Sub DrawGridViewBox(ByVal GxPrint As Graphics)
    '    Dim GridViewRect As New Rectangle( _
    '                 DataGridBrowseData.Left, DataGridBrowseData.Top, _
    '                DataGridBrowseData.Width, _
    '                DataGridBrowseData.Height)

    '    GxPrint.DrawRectangle(Pens.Black, GridViewRect)
    'End Sub


 

End Class
