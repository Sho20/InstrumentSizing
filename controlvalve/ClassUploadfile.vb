
Imports System.Data
Imports System.Data.SqlClient



Public Class ClassUploadfile

    'Public ObjValve As Object

    Private BoltSizeValue As Double
    Private BoltType As String
    Public strProjectno As String
    'Private UserRight As String

    Public connectstr As String


    Public Property boltSize() As String
        Get
            ''送值出去
            Return BoltType
        End Get


        Set(ByVal AreaSize As String)
            ''接值近來

            BoltSizeValue = AreaSize
        End Set


    End Property


    Public Property Projectno() As String
        Get
            Projectno = strProjectno
        End Get
        Set(ByVal value As String)
            strProjectno = value
        End Set
    End Property


    Public Sub SelectType()

        connectstr = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"

        Dim str As String = "select * from BoltType"

        Dim connSafetyBoltType As SqlConnection = New SqlConnection(connectstr)
        connSafetyBoltType.Open()

        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, connSafetyBoltType)
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "BoltType")

        For u = 0 To set1.Tables(0).Rows.Count - 1
            If CDbl(BoltSizeValue) < set1.Tables(0).Rows(u).Item(1) And CDbl(BoltSizeValue) <> 0 Then
                BoltType = Trim(set1.Tables(0).Rows(u).Item(0).ToString)
                Exit For
                'ElseIf CDbl(BoltSizeValue) = 0 Then
                '    BoltType = "default"
                '    Exit For
            End If
        Next

        connSafetyBoltType.Close()
    End Sub


    'Public Property username() As String
    '    Get
    '        ' Gets the property value.
    '        Return userNameValue
    '    End Get
    '    Set(ByVal Value As String)
    '        ' Sets the property value.
    '        userNameValue = Value
    '    End Set
    'End Property

    'Public Sub Capitalize()

    '    ' Capitalize the value of the property.
    '    userNameValue = UCase(userNameValue)
    'End Sub



    'Public Property bodysize() As Integer
    '    Get
    '        ' Gets the property value.
    '        Return bodyValue
    '    End Get
    '    Set(ByVal cv As Integer)
    '        ' Sets the property value.
    '        bodyValue = Value
    '    End Set
    'End Property







End Class
