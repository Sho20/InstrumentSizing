
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient


Public Class FrmJobNoCollect
    Public connectstring As String
    Public conn As SqlConnection


    Public connOLE As OleDbConnection
    Public strconnstring As String
    Public str As String

    Public UserJobNo As String
    Public SelectJobNo As String
    Public UserTask As String
    Public S As Integer

    Public SizingMode As String


    Declare Function GetUserName Lib "advapi32.dll" Alias _
    "GetUserNameA" (ByVal lpBuffer As String, _
    ByRef nSize As Integer) As Integer

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function



    Private Sub FrmJobNoCollect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CreateNewRecordToolStripMenuItem.CheckState = CheckState.Unchecked  ''''''Mode status is empty

        Dim username As String
        username = GetUserName()

        MakesureUser(username)



        If UserTask = "REVIEW" Then
            'MDISizingGroup.OpenToolStripButton.Enabled = False
            'MDISizingGroup.NewToolStripButton.Enabled = False
            MDISizingGroup.OpenToolStripMenuItem.Enabled = False
            MDISizingGroup.SizingModeControlValve.Enabled = False
            MDISizingGroup.RunSizingToolStripMenuItem.Enabled = False
            MDISizingGroup.CreateNewControlValve.Enabled = False
            MDISizingGroup.CreateNewSafetyValve.Enabled = False
            MDISizingGroup.AddANewRecordToolStripMenuItem.Enabled = False

        End If
        ''''sql 認證
        connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim cs As String = "select * from information_schema.Tables where TABLE_TYPE='BASE TABLE'"  ''GET FORMS FROM SQL DATABASE

        Using cmdGetForm As New SqlCommand(cs, conn) ''''''''''''''''''''''''''''''''擷取資料庫的資料表
            Using dr As SqlDataReader = cmdGetForm.ExecuteReader()
                While dr.Read()
                    ListFORMS.Items.Add(dr("TABLE_NAME").ToString())
                End While
            End Using
        End Using




        Dim I As Integer
        Dim strProjectname As String
        strProjectname = UserJobNo



    End Sub

    Private Sub MakesureUser(ByVal username As String)
        connOLE = New OleDbConnection("Provider=VFPOLEDB.1;Data Source=\\intsrv1\SizingUserRight;")
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
                'Me.Show()
                'Exit Sub
            End If

        Next
    End Sub

    Public Function GetUserProperty(ByVal i, ByVal w, ByVal S, ByVal set1) As String

        UserTask = Trim(set1.Tables("User").Rows(w).Item(2).ToString)
        UserJobNo = Trim(set1.Tables("User").Rows(w).Item(1).ToString)
        Dim project As New ClassUploadfile
        'UserJobNo = project.Projectno

        If S = 1 Then
            GetUserProperty = UserTask
            S = 2
        ElseIf S = 2 Then
            GetUserProperty = UserJobNo
            LstJobNo.Items.Add(GetUserProperty)
        End If

    End Function

    Private Sub LstJobNo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstJobNo.DoubleClick
        If LstJobNo.SelectedIndex >= 0 Then
            LabProjectNum.Text = LstJobNo.Items(LstJobNo.SelectedIndex)
            MDISizingGroup.Show()
            Me.Close()
        Else
            MsgBox("PLEASE SELECT A PROJECT")

        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub LstJobNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstJobNo.SelectedIndexChanged
        If LstJobNo.SelectedIndex >= 0 Then
            LabProjectNum.Text = LstJobNo.Items(LstJobNo.SelectedIndex)
            MDISizingGroup.Show()
            Me.Close()
        Else
            MsgBox("PLEASE SELECT A PROJECT")

        End If
    End Sub
End Class