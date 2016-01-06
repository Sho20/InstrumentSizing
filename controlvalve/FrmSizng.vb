Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class FrmSizng
    Public strcondition As String
    ''0=id ,1=tag, 2=specific gravity  ,3=mole  , 4=minInletp , 5=notInletp,6=maxInletp,
    ' 7=mindp,8=nordp,9=maxdp,10=minflowrate,11=norflowrate
    ',12=maxflowrate , 13=unit ,14=phase , 15=temperature ,16=k,
    ' 17=viscosity ,18=z ,19=type ,20=vaporpressure ,21=criticalpressure ,22=mincv, 23=norcv , 24=maxcv
    ',25=linesize,26=bodtsize , 27=SelectCV, 28=xt , 29=DPcondition,30=noise,31=linewallT
    Public DouSelectCV
    Public connectstring As String = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"

    Public StrPhase As String
    Public lengthPhase As Integer

    Public MinFlowRate, NorFlowRate, MaxFlowRate, SG, Mole, DiffP
    Public CV '''''''''''''''''''NOR

    Public MAXCV
    Public MINCV


    Public LineSize

    Public douXt
    Public douNorNoise
    Public douMinNoise
    Public douMaxNoise
    Public douFinalNoise

    Public douVaporP
    Public douCriticalP
    Public Kheat

    Public NAME As String

    Public douminInletp, dounorInletp, doumaxInletp
    Public douminDP, dounorDP, doumaxDP
    Public strDPcodition
    Public strUnit

    Public Temperature  '''''''''C -->K
    Public douT ''PIPE area of metal(square inches)

    Private Sub FrmSizng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"


        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "InstrumentTable")

        DataGridView1.DataSource = set1.Tables("InstrumentTable")

        Dim I As Integer
        Dim ErrorCode As Boolean
        Dim Index As Integer
        Dim u As Integer

        For I = 0 To DataGridView1.Rows.Count - 1 '''''''''''清空cv ,bodysize值
            On Error Resume Next
            NAME = DataGridView1.Item("Tag", I).Value.ToString

            Dim strCV As String = "Update " & MDISizingGroup.oProjectname.ToString & " set MinCV=0,NorCV=0,MaxCV=0,BodySize=0,SelectCV=0 where TAG='" & Trim(NAME) & "'"
            Dim cmd As SqlCommand = New SqlClient.SqlCommand(strCV, conn)
            cmd.CommandTimeout = 100

            On Error Resume Next
            cmd.ExecuteNonQuery()
        Next

        For I = 0 To DataGridView1.Rows.Count - 1

            If DataGridView1.Item("Tag", I).Value <> Nothing Then

                NAME = Trim((DataGridView1.Item("Tag", I).Value).ToString)
                strUnit = Trim(DataGridView1.Item("Unit", I).Value.ToString)
                Kheat = Trim(DataGridView1.Item("k", I).Value.ToString)


                NorFlowRate = DataGridView1.Item("NorFlowRate", I).Value  'CHANGE TO kg/h
                MinFlowRate = DataGridView1.Item("MinFlowRate", I).Value  'CHANGE TO kg/h
                MaxFlowRate = DataGridView1.Item("MaxFlowRate", I).Value  'CHANGE TO kg/h

                SG = DataGridView1.Item("SpecificGravity", I).Value
                Mole = DataGridView1.Item("Mole", I).Value

                CellFillEmpty(I)

                '''''''''''''''''''''''''''''''''''''''''''''''check column value is null or not
                For col = 0 To DataGridView1.Columns.Count - 1 ''''''''''''''''''''''''''''''''''加1是因為多加了id的欄位
                    Dim calculateCol As String
                    If StrPhase = "L" Then
                        '''''欄位不可以是空值得我標在下面colnameCantBeEmpty副程式

                        If col <> 3 And col <> 4 And col <> 5 _
                                    And col <> 6 And col <> 7 _
                                    And col <> 8 And col <> 9 _
                                    And col <> 10 And col <> 11 _
                                    And col <> 12 And col <> 16 _
                                    And col <> 18 And col <> 22 _
                                    And col <> 23 And col <> 24 And col <> 26 _
                                    And col <> 27 And col <> 30 And col <> 31 Then

                            If DataGridView1.Item(col, I).Value.ToString = Nothing Then

                                GoTo nextone
                            End If
                        End If

                    ElseIf StrPhase = "G" Or StrPhase = "S" Then
                        DataGridView1.Columns(col).ToString()
                        '不等於這些欄位的若是空值，程式就會跳掉，因為那些不等於這些欄位的欄位都是必要有值的
                        If col <> 2 And col <> 4 And col <> 5 _
                                    And col <> 6 And col <> 7 _
                                    And col <> 8 And col <> 9 _
                                    And col <> 10 _
                                    And col <> 11 And col <> 12 _
                                    And col <> 17 And col <> 18 _
                                    And col <> 20 And col <> 21 _
                                    And col <> 22 And col <> 23 _
                                    And col <> 24 And col <> 26 _
                                    And col <> 27 And col <> 30 And col <> 31 Then
                            If DataGridView1.Item(col, I).Value.ToString = Nothing Then
                                GoTo nextone
                            End If
                        End If

                    Else

                        If col <> 22 And col <> 23 And col <> 24 And col <> 26 And col <> 27 Then ''''''''''''''''''''''''要避免cv跟body會是空值
                            If DataGridView1.Item(col, I).Value.ToString = Nothing Then
                                GoTo nextone
                            End If
                        End If

                    End If


                Next

                strDPcodition = Trim((DataGridView1.Item(29, I).Value).ToString)

                ''''''''計算cv值開始''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If strDPcodition = "NOR" Then  ''''都是用normal值算

                    Calculatecvbynor(I)


                ElseIf strDPcodition = "EACH" Then  ''''都是MIN 對MIN, NOR 對NOR,MAX對MAX


                    CalculateCVbyEACH(I)
                End If


                If CV > 0 Or CV.ToString = Nothing Or MINCV > 0 Or MAXCV > 0 Then

                    Dim strBodyType As String
                    Dim douNorCVValue As Double
                    Dim douMinCVValue As Double
                    Dim douMaxCVValue As Double
                    Dim StrbigCV As String
                    Dim condition As String
                    'Dim strCondition As String
                    douNorCVValue = CDbl(CV)
                    douMinCVValue = CDbl(MINCV)
                    douMaxCVValue = CDbl(MAXCV)

                    '''''find the big CV
                    For u = 0 To 1
                        If douNorCVValue > douMaxCVValue Then
                            StrbigCV = (douNorCVValue.ToString)
                            condition = "Nor"
                        Else
                            StrbigCV = (douMaxCVValue.ToString)
                            condition = "Max"
                        End If
                    Next


                    strBodyType = Trim(DataGridView1.Item("Type", I).Value)
                    'strCondition = Trim(DataGridView1.Item(13, I).Value)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''insert body size
                    'InsertBodySize(connectstring, strValue, I, LineSize, strBodyType, strCondition)
                    Dim DouBodySize


                    Dim BIGcv
                    BIGcv = StrbigCV
                    DouBodySize = InsertBodySize(connectstring, BIGcv, I, LineSize, strBodyType, condition)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim strCV As String = "Update " & MDISizingGroup.oProjectname.ToString & " set NorCV= '" & Mid(douNorCVValue, 1, 5) & "'," & _
                    "MinCV= '" & Mid(douMinCVValue, 1, 5) & "',MaxCV= '" & Mid(douMaxCVValue, 1, 5) & "',SelectCV= '" & DouSelectCV & "', BodySize= '" & DouBodySize & "' where TAG='" & NAME & "'"
                    Dim cmd As SqlCommand = New SqlClient.SqlCommand(strCV, conn)
                    cmd.CommandTimeout = 100


                    On Error Resume Next
                    cmd.ExecuteNonQuery()
                ElseIf CV < 0 Then
                    For k = 0 To DataGridView1.Columns.Count - 1
                        DataGridView1.Item(k, I).Style.BackColor = Color.Red
                    Next
                Else
                    For k = 0 To DataGridView1.Columns.Count - 1
                        DataGridView1.Item(k, I).Style.BackColor = Color.Red
                    Next
                End If
            End If


            'BodySizeSelect(connectstring, conn, NAME, CV, MDISizingGroup.oProjectname.ToString, )

nextone:
        Next




        REBINDING(str, conn)


    End Sub
    Private Sub CellFillEmpty(ByVal i As Integer)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''INLET表壓+1變一大氣壓
        If DataGridView1.Item("MinInletp", i).Value.ToString = "" Then
            douminInletp = "Default"
        Else
            douminInletp = DataGridView1.Item("MinInletp", i).Value

            If douminInletp <> 0 Then
                douminInletp = DataGridView1.Item("MinInletp", i).Value + 1
            Else
                douminInletp = "Default"
            End If

        End If

        If DataGridView1.Item("NorInletp", i).Value.ToString = "" Then
            dounorInletp = "Default"
        Else
            dounorInletp = DataGridView1.Item("NorInletp", i).Value
            If dounorInletp <> 0 Then
                dounorInletp = DataGridView1.Item("NorInletp", i).Value + 1
            Else
                dounorInletp = "Default"
            End If

        End If

        If DataGridView1.Item("MaxInletp", i).Value.ToString = "" Then
            doumaxInletp = "Default"
        Else
            doumaxInletp = DataGridView1.Item("MaxInletp", i).Value
            If doumaxInletp <> 0 Then
                doumaxInletp = DataGridView1.Item("MaxInletp", i).Value + 1
            Else
                doumaxInletp = "Default"
            End If

        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''DP
        If DataGridView1.Item("MinDP", i).Value.ToString = "" Then
            douminDP = "Default"
        Else
            douminDP = DataGridView1.Item("MinDP", i).Value
            If douminDP <> 0 Then
                douminDP = DataGridView1.Item("MinDP", i).Value
            Else
                douminDP = "Default"
            End If

        End If

        If DataGridView1.Item("NorDP", i).Value.ToString = "" Then
            dounorDP = "Default"
        Else
            dounorDP = DataGridView1.Item("NorDP", i).Value
            If dounorDP <> 0 Then
                dounorDP = DataGridView1.Item("NorDP", i).Value
            Else
                dounorDP = "Default"
            End If

        End If

        If DataGridView1.Item("MaxDP", i).Value.ToString = "" Then
            doumaxDP = "Default"
        Else
            doumaxDP = DataGridView1.Item("MaxDP", i).Value
            If doumaxDP <> 0 Then
                doumaxDP = DataGridView1.Item("MaxDP", i).Value
            Else
                doumaxDP = "Default"
            End If

        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If DataGridView1.Item("Xt", i).Value.ToString = "" Then
            douXt = "Default"
        Else

            douXt = DataGridView1.Item("Xt", i).Value
        End If



        If DataGridView1.Item("VaporPressure", i).Value.ToString = "" Then
            douVaporP = "Default"
        Else

            douVaporP = DataGridView1.Item("VaporPressure", i).Value
        End If


        If DataGridView1.Item("CriticalPressure", i).Value.ToString = "" Then
            douCriticalP = "Default"
        Else

            douCriticalP = DataGridView1.Item("CriticalPressure", i).Value
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        lengthPhase = Len(DataGridView1.Item("Phase", i).Value)

        StrPhase = Mid(DataGridView1.Item("Phase", i).Value, 1, 1)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''getLineSize

        If DataGridView1.Item("LineSize", i).Value.ToString = Nothing Then
            LineSize = ""
        Else
            LineSize = DataGridView1.Item("LineSize", i).Value.ToString
        End If
    End Sub

    Private Sub Calculatecvbynor(ByVal i As Integer)
        CV = 0
        MINCV = 0
        MAXCV = 0
        douFinalNoise = 0

        DiffP = dounorDP
        Dim cf = 0.75
        Dim n = 0.000005
        Dim slg = 0

        On Error Resume Next
        'douT = DataGridView1.Item("LineWallT", i).Value

        If StrPhase = "L" Then   '''''liquid(IS successful)----->use M3/H
            Dim Ff
            Dim FlowRate
            Dim Pmax

            On Error Resume Next
            Ff = 0.96 - 0.28 * Math.Sqrt(douVaporP / douCriticalP)
            FlowRate = Math.Sqrt(douXt / 0.84)
            Pmax = FlowRate ^ 2 * (dounorInletp - douVaporP * Ff)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算NorCV 
            If Pmax < DiffP Then '''''''''''''flashing condition

                CV = NorFlowRate / 0.865 / FlowRate / Math.Sqrt((dounorInletp - douVaporP * Ff) / SG)
            Else
                CV = NorFlowRate / Math.Sqrt(DiffP / SG) / 0.865

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算MINCV 
            If Pmax < DiffP Then '''''''''''''flashing condition

                MINCV = MinFlowRate / 0.865 / FlowRate / Math.Sqrt((dounorInletp - douVaporP * Ff) / SG)

            Else
                MINCV = MinFlowRate / Math.Sqrt(DiffP / SG) / 0.865
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算MAXCV 
            If Pmax < DiffP Then '''''''''''''flashing condition

                MAXCV = MaxFlowRate / 0.865 / FlowRate / Math.Sqrt((dounorInletp - douVaporP * Ff) / SG)
            Else
                MAXCV = MaxFlowRate / Math.Sqrt(DiffP / SG) / 0.865
            End If

            '''''''''''''''''計算噪音

            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(CV) + 20 * Math.Log10(DiffP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    douMinNoise = 10 * Math.Log10(MINCV) + 20 * Math.Log10(DiffP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    douMaxNoise = 10 * Math.Log10(MAXCV) + 20 * Math.Log10(DiffP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'ElseIf douNorNoise > douMaxNoise > douMinNoise Then
            '    douFinalNoise = douNorNoise
            'End If

        ElseIf StrPhase = "G" Then '''''gas and vapor USE Nm3/h, steam -->KG/H

            Temperature = DataGridView1.Item("Temperature", i).Value + 273.15  ''''''''''''''''''''unit k
            Dim Y As Double
            Dim x As Double
            Dim N9 As Double
            Dim fp As Double
            Dim k As Double
            Dim Fk As Double
            Dim xt As Double
            Dim FlowRate As Double
            Dim Z As Double


            k = DataGridView1.Item("K", i).Value
            x = DiffP / (dounorInletp)
            Fk = k / 1.4
            Dim charss As Char ''''''''''''''''''''body type

            charss = (DataGridView1.Item("Type", i).Value.ToString)

            fp = 1
            N9 = 2120
            Z = DataGridView1.Item("Z", i).Value
            Y = 1 - (x / (3 * Fk * douXt))

            CV = NorFlowRate / (N9 * fp * dounorInletp * Y * (Math.Sqrt(x / (Mole * Temperature * Z)))) ''''''''''norcv
            MINCV = MinFlowRate / (N9 * fp * dounorInletp * Y * (Math.Sqrt(x / (Mole * Temperature * Z)))) ''''''''''mincv
            MAXCV = MaxFlowRate / (N9 * fp * dounorInletp * Y * (Math.Sqrt(x / (Mole * Temperature * Z)))) ''''''''''maxcv

            '''''''fg在gas這邊當mole, Q=M3/H


            '''''''''''''''''計算噪音

            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * CV * cf * dounorInletp * _
            '      (dounorInletp - DiffP) * ((LineSize * 25.4) ^ 2) * n * Temperature / (douT ^ 3)) + slg
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    douMinNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MINCV * cf * dounorInletp * _
            '        (dounorInletp - DiffP) * (LineSize * 25.4) ^ 2 * n * Temperature / (douT ^ 3)) + slg
            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    douMaxNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MAXCV * cf * dounorInletp * _
            '        (dounorInletp - DiffP) * (LineSize * 25.4) ^ 2 * n * Temperature / (douT ^ 3)) + slg
            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'Else
            '    douFinalNoise = douNorNoise
            'End If

        ElseIf StrPhase = "S" Then '''''gas and vapor USE Nm3/h, steam -->KG/H
            Temperature = DataGridView1.Item("Temperature", i).Value + 273.15  ''''''''''''''''''''unit k
            Dim Y As Double
            Dim x As Double
            Dim N9 As Double
            Dim fp As Double
            Dim k As Double
            Dim Fk As Double
            Dim xt As Double
            Dim FlowRate As Double
            Dim Z As Double

            k = DataGridView1.Item("K", i).Value

            Dim charss As Char
            charss = (DataGridView1.Item("Type", i).Value.ToString) '''''''''''''''''valve type
            Fk = k / 1.4
            fp = 1
            N9 = 2120
            Z = DataGridView1.Item("Z", i).Value
            x = DiffP / (dounorInletp)

            Y = 1 - (x / (3 * Fk * douXt))

            CV = NorFlowRate / (94.8 * fp * dounorInletp * Y * Math.Sqrt((x * Mole) / Temperature / Z))  ''''Q=KG/H''''''''''norcv
            MINCV = MinFlowRate / (94.8 * fp * dounorInletp * Y * Math.Sqrt((x * Mole) / Temperature / Z)) ''''''mincv
            MAXCV = MaxFlowRate / (94.8 * fp * dounorInletp * Y * Math.Sqrt((x * Mole) / Temperature / Z)) ''''''maxcv

            ''''''''''''''''''計算噪音
            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * CV * cf * dounorInletp * (dounorInletp - DiffP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    douMinNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MINCV * cf * dounorInletp * (dounorInletp - DiffP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    douMaxNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MAXCV * cf * dounorInletp * (dounorInletp - DiffP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'Else
            '    douFinalNoise = douNorNoise
            'End If

        End If

    End Sub

    Private Sub CalculateCVbyEACH(ByVal I As Integer)
        CV = 0
        MINCV = 0
        MAXCV = 0
        Dim cf = 0.75

        Dim slg = 0

        If StrPhase = "L" Then   '''''liquid(IS successful)----->use M3/H
            Dim Ff
            Dim FlowRate
            Dim PMIN, PNOR, PMAX

            Ff = 0.96 - 0.28 * Math.Sqrt(douVaporP / douCriticalP)
            FlowRate = Math.Sqrt(douXt / 0.84)
            On Error Resume Next
            PMIN = FlowRate ^ 2 * (douminInletp - (douVaporP * Ff))
            PNOR = FlowRate ^ 2 * (dounorInletp - (douVaporP * Ff))
            PMAX = FlowRate ^ 2 * (doumaxInletp - (douVaporP * Ff))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算MINCV
            If PMIN < douminDP Then '''''''''''''flashing condition

                MINCV = MinFlowRate / 0.865 / FlowRate / Math.Sqrt((douminInletp - (douVaporP * Ff)) / SG)
            Else
                MINCV = MinFlowRate / Math.Sqrt(douminDP / SG) / 0.865
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算NorCV 

            If PNOR < dounorDP Then '''''''''''''flashing condition

                CV = NorFlowRate / 0.865 / FlowRate / Math.Sqrt((dounorInletp - douVaporP * Ff) / SG)

            Else
                CV = NorFlowRate / Math.Sqrt(dounorDP / SG) / 0.865
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''計算MAXCV 
            If PMAX < doumaxDP Then '''''''''''''flashing condition

                MAXCV = MaxFlowRate / 0.865 / FlowRate / Math.Sqrt((doumaxInletp - douVaporP * Ff) / SG)
            Else
                MAXCV = MaxFlowRate / Math.Sqrt(doumaxDP / SG) / 0.865
            End If


            '''''''''''''''''計算噪音

            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(CV) + 20 * Math.Log10(dounorDP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    douMinNoise = 10 * Math.Log10(MINCV) + 20 * Math.Log10(douminDP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    douMaxNoise = 10 * Math.Log10(MAXCV) + 20 * Math.Log10(doumaxDP) - 30 * Math.Log10(douT) + 70.5
            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'ElseIf douNorNoise > douMaxNoise > douMinNoise Then
            '    douFinalNoise = douNorNoise
            'End If


        ElseIf StrPhase = "G" Then '''''gas and vapor USE Nm3/h, steam -->KG/H
            Dim n = 0.000005
            On Error Resume Next
            Temperature = DataGridView1.Item("Temperature", I).Value + 273.15  ''''''''''''''''''''unit k
            Dim MINy As Double
            Dim NORy As Double
            Dim MAXy As Double


            Dim MINx As Double
            Dim NORx As Double
            Dim MAXx As Double

            Dim N9 As Double
            Dim fp As Double
            Dim k As Double
            Dim Fk As Double
            Dim xt As Double
            Dim FlowRate As Double
            Dim Z As Double

            k = DataGridView1.Item("K", I).Value

            MINx = douminDP / (douminInletp)
            NORx = dounorDP / (dounorInletp)
            MAXx = doumaxDP / (doumaxInletp)


            Fk = k / 1.4
            Dim charss As Char ''''''''''''''''''''body type

            charss = (DataGridView1.Item("Type", I).Value.ToString)

            fp = 1
            N9 = 2120
            Z = DataGridView1.Item("Z", I).Value

            MINy = 1 - (MINx / (3 * Fk * douXt))
            NORy = 1 - (NORx / (3 * Fk * douXt))
            MAXy = 1 - (MAXx / (3 * Fk * douXt))

            '''''''''''''''fg在gas這邊當mole, Q=M3/H
            CV = NorFlowRate / (N9 * fp * dounorInletp * NORy * (Math.Sqrt(NORx / (Mole * Temperature * Z)))) ''''''''''norcv
            MINCV = MinFlowRate / (N9 * fp * douminInletp * MINy * (Math.Sqrt(MINx / (Mole * Temperature * Z)))) ''''''''''mincv
            MAXCV = MaxFlowRate / (N9 * fp * doumaxInletp * MAXy * (Math.Sqrt(MAXx / (Mole * Temperature * Z)))) ''''''''''maxcv

            ''''''''''''''''''計算噪音

            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * CV * cf * dounorInletp * (dounorInletp - dounorDP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    douMinNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MINCV * cf * douminInletp * (douminInletp - douminDP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    douMaxNoise = 10 * Math.Log10(2.6 * 10 ^ 5 * MAXCV * cf * doumaxInletp * (doumaxInletp - doumaxDP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'Else
            '    douFinalNoise = douNorNoise
            'End If

        ElseIf StrPhase = "S" Then '''''gas and vapor USE Nm3/h, steam -->KG/H
            Dim n = 0.0002
            On Error Resume Next
            Temperature = DataGridView1.Item("Temperature", I).Value + 273.15  ''''''''''''''''''''unit k
            ' Dim Y As Double
            'Dim x As Double
            Dim N9 As Double
            Dim fp As Double
            Dim k As Double
            Dim Fk As Double
            Dim xt As Double
            Dim FlowRate As Double
            Dim Z As Double

            Dim MINy As Double
            Dim NORy As Double
            Dim MAXy As Double


            Dim MINx As Double
            Dim NORx As Double
            Dim MAXx As Double

            k = DataGridView1.Item("K", I).Value

            Dim charss As Char
            charss = (DataGridView1.Item("Type", I).Value.ToString) '''''''''''''''''valve type
            Fk = k / 1.4
            fp = 1
            N9 = 2120
            Z = DataGridView1.Item("Z", I).Value

            On Error Resume Next
            MINx = douminDP / (douminInletp)
            NORx = dounorDP / (dounorInletp)
            MAXx = doumaxDP / (doumaxInletp)


            MINy = 1 - (MINx / (3 * Fk * douXt))
            NORy = 1 - (NORx / (3 * Fk * douXt))
            MAXy = 1 - (MAXx / (3 * Fk * douXt))

            CV = NorFlowRate / (94.8 * fp * dounorInletp * NORy * Math.Sqrt((NORx * Mole) / Temperature / Z))  ''''Q=KG/H''''''''''norcv
            MINCV = MinFlowRate / (94.8 * fp * douminInletp * MINy * Math.Sqrt((MINx * Mole) / Temperature / Z)) ''''''mincv
            MAXCV = MaxFlowRate / (94.8 * fp * doumaxInletp * MAXy * Math.Sqrt((MAXx * Mole) / Temperature / Z)) ''''''maxcv

            '''''''''''''''''計算噪音

            'If NorFlowRate > 0 Then
            '    douNorNoise = 10 * Math.Log10(5.8 * 10 ^ 7 * CV * cf * dounorInletp * _
            '               (dounorInletp - dounorDP) * (LineSize * 25.4) ^ 2 * n * _
            '               (1 + 0.00126 * Temperature) ^ 6 / douT ^ 3)
            'End If

            'If Not (MinFlowRate Is System.DBNull.Value) Then
            '    'douMinNoise = 10 * Math.Log10(5.8 * 10 ^ 7 * MINCV * cf * douminInletp * (douminInletp - douminDP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            '    douMinNoise = 10 * Math.Log10(5.8 * 10 ^ 7 * MINCV * cf * douminInletp * _
            '              (douminInletp - douminDP) * (LineSize * 25.4) ^ 2 * n * _
            '              (1 + 0.00126 * Temperature) ^ 6 / douT ^ 3)

            'End If

            'If Not (MaxFlowRate Is System.DBNull.Value) Then
            '    'douMaxNoise = 10 * Math.Log10(5.8 * 10 ^ 7 * MAXCV * cf * doumaxInletp * (doumaxInletp - doumaxDP) * (LineSize * 25.4) ^ 2 * n * Temperature / douT ^ 3) + slg
            '    douMaxNoise = 10 * Math.Log10(5.8 * 10 ^ 7 * MAXCV * cf * doumaxInletp * _
            '            (doumaxInletp - doumaxDP) * (LineSize * 25.4) ^ 2 * n * _
            '            (1 + 0.00126 * Temperature) ^ 6 / douT ^ 3)

            'End If

            'If douMaxNoise > douNorNoise > douMinNoise Then
            '    douFinalNoise = douMaxNoise
            'Else
            '    douFinalNoise = douNorNoise
            'End If

        End If

    End Sub
    'Private Function colnameCantBeEmpty(ByVal col As Integer, ByVal i As Integer) As String

    ''''for phase =L,這些欄位不可以是空的

    '    Dim colname As String
    '    colname = DataGridView1.Columns(col).Name

    '    Select Case colname
    '        Case colname = "Tag"  
    '        Case colname = "SpecificGravity"  
    '        Case colname = "InletPressure" 
    '        Case colname = "OutputPressure"
    '        Case colname = "Unit" 
    '        Case colname = "Phase" 
    '        Case colname = "Temperature"'       
    '        Case colname = "Viscosity " 
    '        Case colname = "Type" 
    '        Case colname = "VaporPressure" 
    '        Case colname = "CriticalPressure" 
    '        Case colname = "LineSize" 
    '        Case colname = "Viscosity" 
    '    End Select

    ''''''for G/V ,這些欄位不可以是空的
    '        Case colname = "Tag"  
    '        Case colname = "MOLE"  
    '        Case colname = "InletPressure" 
    '        Case colname = "OutputPressure"
    '        Case colname = "Unit" 
    '        Case colname = "Phase" 
    '        Case colname = "Temperature"'
    '        Case colname = "K " 
    '        Case colname = "Viscosity " 
    '        Case colname = "Z"
    '        Case colname = "Type" 
    '        Case colname = "LineSize" 

    'End Function


    Private Function InsertBodySize(ByVal connectstring As String, ByVal BIGcv As String, ByVal IRow As Integer, ByVal LineSize As String, ByVal strBodyType As String, ByVal condition As String) As Double
        Dim connControlSpec As SqlConnection = New SqlConnection(connectstring)
        connControlSpec.Open()

        '查詢資料
        Dim str As String = "select * from ControlSpec order by id"

        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, connControlSpec)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "ControlSpec")
        Dim i As Integer

        For u = 0 To set1.Tables(0).Rows.Count - 1 '''''''''''''run controlspec

            If strBodyType = Trim(set1.Tables(0).Rows(u).Item(1).ToString) Then
                i = set1.Tables(0).Rows(u).Item(0)             ''''''''''''''control valve type第一筆的controlspec id
                Exit For
            End If
        Next


        Dim valvesize As Double
        Dim calculCV As Double
        Dim ValveCV As Double
        Dim notFoundthisValve As Boolean
        notFoundthisValve = False
        If Trim(condition) = "Nor" Then '''''''''''''condition
            BIGcv = BIGcv / 0.5
        ElseIf Trim(condition) = "Max" Then
            BIGcv = BIGcv / 0.8
        End If
        For u = 0 To set1.Tables(0).Rows.Count  '''''''''''''run controlspec

            If strBodyType = Trim(set1.Tables(0).Rows(u).Item(1).ToString) Then
                notFoundthisValve = False

                valvesize = set1.Tables(0).Rows(u).Item(2)

                ValveCV = set1.Tables(0).Rows(u).Item(3)
                calculCV = CDbl(BIGcv)

                ''''''''這邊u+1是為了要比對id number,u 是給table row的序號,從0開始; i 是 sql 的id從1開始

                If calculCV < ValveCV And (u + 1) >= i Then

                    InsertBodySize = set1.Tables(0).Rows(u).Item(2)  ''所以這邊的u不用加一,因為是讀取table的資料
                    DouSelectCV = set1.Tables(0).Rows(u).Item(3)
                    Exit For

                End If


            ElseIf LineSize <> valvesize Then
                notFoundthisValve = True

            ElseIf LineSize < set1.Tables(0).Rows(u).Item(2) Then '''若管線size小於bodysize,就選不到cv,所以只好填0
                notFoundthisValve = True
            End If

        Next



        connControlSpec.Close()
        If notFoundthisValve = True Then
            InsertBodySize = 0
            DouSelectCV = 0
        End If

    End Function
    Private Sub BodySizeSelect(ByVal strconn As String, ByVal conn As SqlConnection, ByVal TagNAME As String, ByVal CV As Double, ByVal ProjrctName As String, ByVal valvetype As String)

    End Sub


    Private Sub REBINDING(ByVal STR As String, ByVal CONN As SqlConnection)
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(STR, CONN)
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "InstrumentTable")

        DataGridView1.DataSource = set2.Tables("InstrumentTable")

        DataGridView1.Refresh()


        For h = 0 To DataGridView1.Rows.Count - 1

            If DataGridView1.Item("NorCV", h).Value.ToString = Nothing Or DataGridView1.Item("NorCV", h).Value = "0" Then
                On Error Resume Next
                If DataGridView1.Item("BodySize", h).Value = "0" Then
                    DataGridView1.Rows(h).DefaultCellStyle.BackColor = Color.Silver
                Else
                    DataGridView1.Rows(h).DefaultCellStyle.BackColor = Color.Yellow
                End If

            ElseIf DataGridView1.Item("BodySize", h).Value > DataGridView1.Item("LineSize", h).Value Then
                DataGridView1.Rows(h).DefaultCellStyle.BackColor = Color.Red
            End If
        Next
        DataGridView1.Columns("id").Visible = False
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        MDISizingGroup.ToolStripProgressBar1.Value = 0

        Me.Close()

        MDISizingGroup.Show()
    End Sub



    Private Sub exportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportExcel.Click
        Me.Cursor = Cursors.WaitCursor

        '查詢資料
        Dim dsmas1 As DataSet = New DataSet
        Dim connectstring As String
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString
        If MDISizingGroup.SizingMode = "ControlValve" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=ControlValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "cTable")

        ElseIf MDISizingGroup.SizingMode = "SafetyValve" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "sTable")

        ElseIf MDISizingGroup.SizingMode = "OrificePlate" Then
            connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
            Dim conn As SqlConnection = New SqlConnection(connectstring)
            conn.Open()
            Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
            adp1.Fill(dsmas1, "ORTable")

        ElseIf MDISizingGroup.SizingMode = "RestrictPlate" Then
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
            '.SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            .Worksheets(1).name = "Sheet1"

            .Cells(1, 1).value = "Tag"
            .Cells(1, 2).value = "Specific Gravity"
            .Cells(1, 3).value = "Mole Weight"
            .Cells(1, 4).value = "MinInletP(kg/cm2)"
            .Cells(1, 5).value = "NorInletP(kg/cm2)"
            .Cells(1, 6).value = "MaxInletP(kg/cm2)"

            .Cells(1, 7).value = "MinDP(kg/cm2)"
            .Cells(1, 8).value = "NorDP(kg/cm2)"
            .Cells(1, 9).value = "MaxDP(kg/cm2)"

            .Cells(1, 10).value = "MinFlowRate(L=M3/h,V&G=NM3/h,S=Kg/h)"
            .Cells(1, 11).value = "NorFlowRate(L=M3/h,V&G=NM3/h,S=Kg/h)"
            .Cells(1, 12).value = "MaxFlowRate(L=M3/h,V&G=NM3/h,S=Kg/h)"
            .Cells(1, 13).value = "Flow Rate Unit(S=KG,G=NM3,L=M3)"
            .Cells(1, 14).value = "PH(G=V&G/L/S)"
            .Cells(1, 15).value = "Temperature(C)"
            .Cells(1, 16).value = "k(Cp/Cv,specific heat)"
            .Cells(1, 17).value = "Viscosity"
            .Cells(1, 18).value = "Z(compressibility)"
            .Cells(1, 19).value = "TYPE(GLOBE,ANGLE,BALL,BUTTERFLY)"
            .Cells(1, 20).value = "Vapor Pressure(Kg/cm2)"
            .Cells(1, 21).value = "Critical Pressure(Kg/cm2)"

            .Cells(1, 22).value = "MinCV"
            .Cells(1, 23).value = "NorCV"
            .Cells(1, 24).value = "MaxCV"
            .Cells(1, 25).value = "LineSize(in)"
            .Cells(1, 26).value = "BodySize(in)"
            .Cells(1, 27).value = "SelectCV"
            .Cells(1, 28).value = "Xt(Pressure drop Ratio Factor,GLOBE=0.621,ANGLE=0.5736,BALL=0.621,BUTTERFLY=0.68)"
            .Cells(1, 29).value = "DPcondition(Each/Nor)"
            .Cells(1, 30).value = "Noise(dBA)"



            Dim i As Integer = 1

            For col = 1 To dsmas1.Tables(0).Columns.Count - 1
                .Cells(1, i).EntireRow.Font.Bold = True
                i += 1
            Next

            i = 2

            Dim k As Integer = 1
            Dim xlrange As Microsoft.Office.Interop.Excel.Range


            For row = 0 To dsmas1.Tables(0).Rows.Count - 1
                xlrange = .Rows(row + 2)

                If dsmas1.Tables(0).Rows(row).Item("NorCV") = 0 Or dsmas1.Tables(0).Rows(row).Item("NorCV") Is Nothing Then
                    If dsmas1.Tables(0).Rows(row).Item("BodySize") = 0 Then

                        xlrange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver)
                    Else
                        xlrange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)

                    End If



                ElseIf dsmas1.Tables(0).Rows(row).Item("BodySize") > dsmas1.Tables(0).Rows(row).Item("LineSize") Then

                    xlrange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)

                End If


                For col = 1 To dsmas1.Tables(0).Columns.Count - 1
                    If dsmas1.Tables(0).Rows(row).Item(col).ToString = Nothing Then
                        .Cells(row + 2, col).Value = ""
                        .Cells.EntireColumn.AutoFit()

                    Else

                        .Cells(row + 2, col).Value = Trim(dsmas1.Tables(0).Rows(row).Item(col))
                        .Cells.EntireColumn.AutoFit()
                    End If
                Next



            Next


            'Dim strDriverNm As String
            'strDriverNm = findClientOnDriverName()

            'Dim filepath As String

            'filename = "\\" & strDriverNm & "\c:\ControlValve.xlsx"


            'excel.Workbooks.Application.DisplayAlerts = False
            '.ActiveCell.Worksheet.SaveAs(filename)

            Dim filepath As String
            'Dim myStream As IO.Stream
            Dim saveFileDialog1 As New SaveFileDialog()

            saveFileDialog1.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls"
            'saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim intcount As Integer = Len(saveFileDialog1.FileName)
                filepath = Mid(saveFileDialog1.FileName, 1, intcount)

            End If


            filename = filepath

            excel.Workbooks.Application.DisplayAlerts = False
            .ActiveCell.Worksheet.SaveAs(filename)
            excel.Quit()

            MsgBox("ok")



        End With
        'excel.Workbooks.Close()
        'excel.Quit()

        'Me.Cursor = Cursors.Default

        'MsgBox("ok")
    End Sub

    Function findClientOnDriverName() As String
        Dim objFileSystem, objDriver, objDrivers As Object
        Dim strDriverName, strShareName As String

        strDriverName = ""
        objFileSystem = CreateObject("Scripting.FileSystemObject")
        objDrivers = objFileSystem.Drives
        For Each objDriver In objDrivers

            If InStr(1, objDriver.ShareName, "C$") Then
                strDriverName = objDriver.DriveLetter
                Exit For
            End If
        Next
        findClientOnDriverName = strDriverName
    End Function

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
