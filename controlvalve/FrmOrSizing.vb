
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmOrSizing
    Public strTag As String
    Public strPhase As String
    Public douFlowRate
    Public douCalculateFL
    Public douInletP
    Public douLossPMMWC
    Public douSG
    Public douDensity
    Public douMole
    Public douTemp
    Public douPipeInletD
    Public douOrificeBore
    Public douViscosity
    Public douReo
    Public douSpeed
    Public douCalculateMode
    Public douPressureLoss

    ''REO 是PIPE的雷諾數

    Private Sub FrmOrSizing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "OrRo")

        DataGridOR.DataSource = set1.Tables("OrRo")



        For rowIndex = 0 To DataGridOR.Rows.Count - 1

            If DataGridOR.Item(0, rowIndex).Value Is Nothing Then

            Else
                Name = Trim(DataGridOR.Item(0, rowIndex).Value.ToString) ''''ID
                douCalculateMode = DataGridOR.Item("CalculateMode", rowIndex).Value
                strTag = UCase(Trim(DataGridOR.Item("Tag", rowIndex).Value.ToString))
                strPhase = UCase(Trim(DataGridOR.Item("Phase", rowIndex).Value.ToString))

                If douCalculateMode Is Nothing Or douCalculateMode Is DBNull.Value Then

                ElseIf douCalculateMode = 1 Then
                    UseCalculateBoreSize(rowIndex, Name, conn)

                ElseIf douCalculateMode = 2 Then

                    UseCalculateFlowRate(rowIndex, Name, conn)

                ElseIf douCalculateMode = 3 Then
                    UseLossP(rowIndex, Name, conn)

                End If


            End If

        Next


        REBINDING(str, conn)

        For I = 0 To DataGridOR.Rows.Count - 1
            On Error Resume Next
            If DataGridOR.Item("OrificeBore", I).Value.ToString = Nothing Or DataGridOR.Item("OrificeBore", I).Value = 0 Then
                For r = 0 To DataGridOR.Columns.Count - 1
                    If DataGridOR.Item("Tag", I).Value.ToString = "" Or _
                    DataGridOR.Item("Tag", I).ToString = Nothing Or _
                    DataGridOR.Item("Tag", I).ToString = DBNull.Value.ToString Then


                    Else
                        DataGridOR.Item(r, I).Style.BackColor = Color.YellowGreen
                    End If

                Next


            Else
                Dim douBeta As Double

                douBeta = DataGridOR.Item("Betaratio", I).Value

                If douBeta < 0.2 Or douBeta > 0.8 Or douBeta > 1 Then
                    For q = 0 To DataGridOR.Columns.Count - 1
                        DataGridOR.Item(q, I).Style.BackColor = Color.LightPink
                    Next
                End If
            End If

        Next

        DataGridOR.Columns("id").Visible = False

        ToolStripStatusLabel1.Text = "Sizing Finish"

    End Sub

    Private Sub UseCalculateBoreSize(ByVal rowIndex, ByVal Name, ByVal conn)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
        conn = New SqlConnection(connectstring)

        ''建立 DataAdapter   
        'Dim objDataAdapter = New SqlDataAdapter
        'objDataAdapter.SelectCommand = New SqlCommand
        'objDataAdapter.SelectCommand.Connection = conn
        'objDataAdapter.SelectCommand.CommandType = CommandType.Text
        'objDataAdapter.SelectCommand.CommandText = connectstring
        'objDataAdapter.SelectCommand.CommandTimeout = 900       '以秒計算   


        Dim strOrificeBore As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                     " set OrificeBore=0,Betaratio=0 where ID='" & Trim(Name) & "'" '''''''''''清空boresize的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strOrificeBore, conn)
        cmd.CommandTimeout = 1500
        conn.Open()



        On Error Resume Next
        cmd.ExecuteNonQuery()

        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s

        douInletP = DataGridOR.Item("InletPressure", rowIndex).Value + 1 ''''''''''變成絕對壓力
        douViscosity = DataGridOR.Item("Viscosity", rowIndex).Value

        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douSG = DataGridOR.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value


            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douCalculateFL.ToString = Nothing Then

                    douCalculateFL = "default"
                    GoTo nextone
                ElseIf douLossPMMWC.ToString = Nothing Then

                    douLossPMMWC = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next



            ''體積流率 m3/s,比重x1000 kg/m3, lossp(kg/ms2=lossp(kg/cm2)*9.81*10000).density =kg/m3
            ''轉換單位
            'If douCalculateFL > 0 Then
            FlowrateM3s = douCalculateFL / 3600
            LossPN = (douLossPMMWC / 10000) * 9.81 * 10000   ''1 mmWC-->0.0001kg/cm2, lossPN最後單位為kg/ms2

            DensityGm3 = douSG * 1000
            douDensity = DensityGm3 '''''液體不需要先給密度,可以透過比重換算,但還是要填,否則雷諾數不能算
            Dim So

            So = FlowrateM3s / (0.61 * Math.Sqrt(2 * LossPN / DensityGm3))
            douOrificeBore = Math.Sqrt(So * 4 / 3.14) * 1000 '''''''''''''最後bore單位為MM

        ElseIf strPhase = "V" Or strPhase = "S" Then

            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douDensity = DataGridOR.Item("Density", rowIndex).Value

            douMole = DataGridOR.Item("Mole", rowIndex).Value
            douTemp = DataGridOR.Item("TemperatureC", rowIndex).Value

            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value

            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douCalculateFL.ToString = Nothing Then

                    douCalculateFL = "default"
                    GoTo nextone
                ElseIf douLossPMMWC.ToString = Nothing Then

                    douLossPMMWC = "default"
                    GoTo nextone
                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    'GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next

            ''''''''''''''求密度pm=zrt*density..............R=8.314,P=kPA,T=273.15+C
            'Dim caldensity As Double
            If douDensity.ToString = "default" Then
                douDensity = douInletP * 101.3 * douMole / (8.314 * (273.15 + douTemp))
            End If


            ''體積流率 kg/s,比重x1000 kg/m3, .
            ''轉換單位
            FlowrateM3s = douCalculateFL / 3600
            Dim pipeinletMiter = douPipeInletD / 1000
            LossPN = (douLossPMMWC / 10000) * 10000 * 9.81
            Dim b
            b = Math.Sqrt(4 * FlowrateM3s / (0.61 * 3.14 * pipeinletMiter ^ 2 * Math.Sqrt(2 * LossPN * douDensity)))
            douOrificeBore = b * douPipeInletD  ''unit is mm


            ''''''''''''''''''''''''''''
        Else
            GoTo nextone

        End If

        ''''''''''''''Calculate Reo
        Dim Bate As Double
        Bate = douOrificeBore / douPipeInletD
        Dim finalDensity As Double
        If douDensity = 0 Or douDensity.ToString = "default" Then
            finalDensity = DensityGm3
        Else
            finalDensity = douDensity
        End If


        douSpeed = 0.61 * Math.Sqrt(2 * LossPN / finalDensity)

        douReo = (douOrificeBore / 1000) * douSpeed * finalDensity / (douViscosity / 1000) * Bate '''''Red*bate=Rrd(PIPE reynold)

        ''''C=0.61

        douPressureLoss = (Math.Sqrt(1 - Bate ^ 4 * (1 - 0.61 ^ 2)) - 0.61 * (Bate ^ 2)) / (Math.Sqrt(1 - Bate ^ 4 * (1 - 0.61 ^ 2)) + 0.61 * (Bate ^ 2))
        douPressureLoss = douPressureLoss * douLossPMMWC / 10000

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        strOrificeBore = "Update " & MDISizingGroup.oProjectname.ToString & " set OrificeBore= '" & Mid(douOrificeBore, 1, 7) & "',Reo='" & douReo & "',Betaratio=" & "'" & Mid(Bate, 1, 5) & "'" & ",PressureLoss='" & Mid(douPressureLoss, 1, 6) & "' where TAG='" & strTag & "'"
        cmd = New SqlClient.SqlCommand(strOrificeBore, conn)
        cmd.ExecuteNonQuery()

        conn.CLOSE()
nextone:


    End Sub

    Private Sub UseCalculateFlowRate(ByVal rowIndex, ByVal Name, ByVal conn)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)

        Dim strCalculateFL As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set CalculateFlowRate=0,Betaratio=0 where ID='" & Trim(Name) & "'" '''''''''''清空CalculateFlowRate的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strCalculateFL, conn)
        cmd.CommandTimeout = 1200
        conn.Open()

        On Error Resume Next
        cmd.ExecuteNonQuery()

        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s
        douInletP = DataGridOR.Item("InletPressure", rowIndex).Value + 1 ''''''''''變成絕對壓力
        douViscosity = DataGridOR.Item("Viscosity", rowIndex).Value


        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douSG = DataGridOR.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value

            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douLossPMMWC.ToString = Nothing Then

                    douLossPMMWC = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next



            ''體積流率 m3/s,比重x1000 kg/m3, lossp(kg/ms2=lossp(kg/cm2)*9.81*10000).
            ''轉換單位
            'If douCalculateFL > 0 Then
            'FlowrateM3s = douCalculateFL / 3600
            LossPN = (douLossPMMWC / 10000) * 9.81 * 10000   ''1 mmWC-->0.0001kg/cm2, lossPN最後單位為kg/ms2

            DensityGm3 = douSG * 1000

            '''''液體不需要先給密度,可以透過比重換算,但還是要填,否則雷諾數不能算
            douDensity = DensityGm3



            Dim So
            So = ((douOrificeBore / 1000) ^ 2) * 3.14 / 4
            FlowrateM3s = Math.Ceiling(So * (0.61 * Math.Sqrt(2 * LossPN / DensityGm3)) * 3600)

            'douOrificeBore = Math.Sqrt(So * 4 / 3.14) * 1000 '''''''''''''最後bore單位為MM

        ElseIf strPhase = "V" Or strPhase = "S" Then

            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douDensity = DataGridOR.Item("Density", rowIndex).Value

            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value

            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douLossPMMWC.ToString = Nothing Then

                    douLossPMMWC = "default"
                    GoTo nextone
                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    'GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next

            ''''''''''''''求密度pm=zrt*density..............R=8.314,P=kPA,T=273.15+C
            'Dim caldensity As Double
            If douDensity.ToString = "default" Then
                douDensity = douInletP * 101.3 * douMole / (8.314 * (273.15 + douTemp))
            End If


            ''體積流率 kg/s,比重x1000 kg/m3, .
            ''轉換單位
            'FlowrateM3s = douCalculateFL / 3600
            Dim pipeinletMiter = douPipeInletD / 1000
            LossPN = (douLossPMMWC / 10000) * 10000 * 9.81
            Dim b
            b = douOrificeBore / douPipeInletD
            FlowrateM3s = (b ^ 2) / 4 * (0.61 * 3.14 * pipeinletMiter ^ 2 * Math.Sqrt(2 * LossPN * douDensity)) * 3600 ''''KG/H
            'douOrificeBore = b * douPipeInletD  ''unit is mm


        Else
            GoTo nextone

        End If


        ''''''''''''''Calculate Reo
        Dim Bate As Double
        Bate = douOrificeBore / douPipeInletD
        Dim finalDensity As Double
        If douDensity = 0 Or douDensity = Nothing Then
            finalDensity = DensityGm3
        Else
            finalDensity = douDensity
        End If


        douSpeed = 0.61 * Math.Sqrt(2 * LossPN / finalDensity)

        douReo = (douOrificeBore / 1000) * douSpeed * finalDensity / (douViscosity / 1000) * Bate '''''Red*bate=Rrd(PIPE reynold)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        strCalculateFL = "Update " & MDISizingGroup.oProjectname.ToString & " set CalculateFlowRate= '" & Mid(FlowrateM3s, 1, 7) & "',Reo='" & douReo & "',Betaratio=" & "'" & Mid(Bate, 1, 5) & "'" & "' where TAG='" & strTag & "'"
        cmd = New SqlClient.SqlCommand(strCalculateFL, conn)
        cmd.ExecuteNonQuery()
        conn.CLOSE()
nextone:

    End Sub


    Private Sub UseLossP(ByVal rowIndex, ByVal Name, ByVal conn)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)


        Dim strLossmmWc As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set LossPmmWC=0,Betaratio=0 where ID='" & Trim(Name) & "'" '''''''''''清空LossPmmWC的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strLossmmWc, conn)
        cmd.CommandTimeout = 900
        conn.Open()

        On Error Resume Next
        cmd.ExecuteNonQuery()

        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s


        douInletP = DataGridOR.Item("InletPressure", rowIndex).Value + 1 ''''''''''變成絕對壓力
        douViscosity = DataGridOR.Item("Viscosity", rowIndex).Value


        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douSG = DataGridOR.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value
            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douCalculateFL.ToString = Nothing Then

                    douCalculateFL = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next



            ''體積流率 m3/s,比重x1000 kg/m3, lossp(kg/ms2=lossp(kg/cm2)*9.81*10000).
            ''轉換單位
            'If douCalculateFL > 0 Then
            FlowrateM3s = douCalculateFL / 3600
            'LossPN = (douLossPMMWC / 10000) * 9.81 * 10000   ''1 mmWC-->0.0001kg/cm2, lossPN最後單位為kg/ms2

            DensityGm3 = douSG * 1000

            '''''液體不需要先給密度,可以透過比重換算,但還是要填,否則雷諾數不能算
            douDensity = DensityGm3

            Dim So
            So = ((douOrificeBore / 1000) ^ 2) * 3.14 / 4
            LossPN = ((FlowrateM3s / So / 0.61) ^ 2 * DensityGm3) / 2 / 9.81
            'LossPN = 16 * (FlowrateM3s ^ 2) / (((b ^ 2) * 0.61 * 3.14 * (pipeinletMiter ^ 2)) ^ 2) / 2 / 9.81 / douDensity
            'douOrificeBore = Math.Sqrt(So * 4 / 3.14) * 1000 '''''''''''''最後bore單位為MM

        ElseIf strPhase = "V" Or strPhase = "S" Then

            douFlowRate = DataGridOR.Item("FlowRate", rowIndex).Value
            douCalculateFL = DataGridOR.Item("CalculateFlowRate", rowIndex).Value
            douLossPMMWC = DataGridOR.Item("LossPmmWC", rowIndex).Value
            douDensity = DataGridOR.Item("Density", rowIndex).Value

            douPipeInletD = DataGridOR.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridOR.Item("OrificeBore", rowIndex).Value

            For i = 0 To 5
                If douFlowRate.ToString = Nothing Then
                    douFlowRate = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douCalculateFL.ToString = Nothing Then

                    douCalculateFL = "default"
                    GoTo nextone
                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next

            ''''''''''''''求密度pm=zrt*density..............R=8.314,P=kPA,T=273.15+C
            'Dim caldensity As Double
            If douDensity.ToString = "default" Then
                douDensity = douInletP * 101.3 * douMole / (8.314 * (273.15 + douTemp))
            End If


            ''MASS流率 kg/s,比重x1000 kg/m3, .
            ''轉換單位

            FlowrateM3s = douCalculateFL / 3600
            Dim pipeinletMiter = douPipeInletD / 1000
            'LossPN = (douLossPMMWC / 10000) * 10000
            Dim b
            b = douOrificeBore / douPipeInletD

            'douOrificeBore = b * douPipeInletD  ''unit is mm
            LossPN = (16 * (FlowrateM3s ^ 2) / (((b ^ 2) * 0.61 * 3.14 * (pipeinletMiter ^ 2)) ^ 2) / 2 / 9.81 / douDensity) ''''''mmWC

        Else
            GoTo nextone

        End If

        ''''''''''''''Calculate Reo
        Dim Bate As Double
        Bate = douOrificeBore / douPipeInletD
        Dim finalDensity As Double
        If douDensity = 0 Or douDensity = Nothing Then
            finalDensity = DensityGm3
        Else
            finalDensity = douDensity
        End If

        douSpeed = 0.61 * Math.Sqrt(2 * (LossPN / 10000) / finalDensity) '''''''''''''''''將losspn變成kg/cm2

        douReo = (douOrificeBore / 1000) * douSpeed * finalDensity / (douViscosity / 1000) * Bate '''''Red*bate=Rrd(PIPE reynold)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        strLossmmWc = "Update " & MDISizingGroup.oProjectname.ToString & " set LossPmmWC= '" & Mid(LossPN, 1, 7) & "',Reo='" & douReo & "',Betaratio=" & "'" & Mid(Bate, 1, 5) & "'" & "' where TAG='" & strTag & "'"
        cmd = New SqlClient.SqlCommand(strLossmmWc, conn)
        cmd.ExecuteNonQuery()
        conn.CLOSE()
nextone:
    End Sub

    Private Sub REBINDING(ByVal STR As String, ByVal CONN As SqlConnection)
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(STR, CONN)
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "OrRo")

        DataGridOR.DataSource = set2.Tables("OrRo")

        DataGridOR.Refresh()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        MDISizingGroup.Show()
    End Sub

    Private Sub exportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportExcel.Click

        '查詢資料
        Dim dsmas1 As DataSet = New DataSet
        Dim connectstring As String
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString

        connectstring = "Server=INTSRV1\CTCIINST;database=RoOr;User Id=sa;Password=ctciinst;"
        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
        adp1.Fill(dsmas1, "OTable")

        '將查詢結果放到記憶體set1上的"1a "表格內

        Dim filename As String
        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass

        With excel
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            .Worksheets(1).name = "Sheet1"

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
            .Cells(1, 13).value = "Viscosity"
            .Cells(1, 14).value = "Reo"
            .Cells(1, 15).value = "Beta ratio"
            .Cells(1, 16).value = " CalculateMode(1 = BoreSize, 2 = FlowRate, 3 = LossPressure)"
            .Cells(1, 17).value = "PressureLoss(Bar)"


            Dim xlrange As Microsoft.Office.Interop.Excel.Range


            Dim i As Integer = 1

            For col = 0 To dsmas1.Tables(0).Columns.Count - 1
                .Cells(1, i).EntireRow.Font.Bold = True
                i += 1
            Next


            Dim k As Integer = 1
            Dim douBeta As Double

            For col = 1 To dsmas1.Tables(0).Columns.Count - 1
                i = 2
                For row = 0 To dsmas1.Tables(0).Rows.Count - 1
                    If dsmas1.Tables(0).Rows(row).ItemArray(col).ToString = Nothing Then

                        .Cells(i, k).Value = ""
                        .Cells.EntireColumn.AutoFit()
                        'xlrange = .Rows(i)
                        'xlrange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)

                    Else

                        .Cells(i, k).Value = Trim(dsmas1.Tables(0).Rows(row).ItemArray(col))
                        .Cells.EntireColumn.AutoFit()

                        On Error Resume Next
                        douBeta = Trim(dsmas1.Tables(0).Rows(row).ItemArray(15))
                        xlrange = .Rows(i)
                        If douBeta > 0.7 Or douBeta < 0.2 Or douBeta > 1 Then
                            xlrange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightPink)

                        End If


                    End If
                    i += 1
                Next
                k += 1
            Next

            Dim filepath As String
            'Dim myStream As IO.Stream
            Dim saveFileDialog1 As New SaveFileDialog()

            'saveFileDialog1.Filter = ".xlsx|(*.xlsx)|*.xlsx|*.*"
            saveFileDialog1.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls"

            'saveFileDialog1.FilterIndex = 2
            saveFileDialog1.RestoreDirectory = True

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim intcount As Integer = Len(saveFileDialog1.FileName)
                'filepath = Mid(saveFileDialog1.FileName, 1, intcount - 1)
                filepath = Mid(saveFileDialog1.FileName, 1, intcount)

            End If


            filename = filepath

            excel.Workbooks.Application.DisplayAlerts = False
            .ActiveCell.Worksheet.SaveAs(filename)
            excel.Quit()

            MsgBox("ok")

        End With
    End Sub

    Private Sub DataGridOR_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridOR.CellContentClick
        FillcolorToOrifice()
    End Sub

    Private Sub DataGridOR_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridOR.ColumnHeaderMouseClick
        FillcolorToOrifice()
    End Sub
    Private Sub FillcolorToOrifice()
        For I = 0 To DataGridOR.Rows.Count - 1
            On Error Resume Next
            If DataGridOR.Item("OrificeBore", I).Value.ToString = Nothing Or DataGridOR.Item("OrificeBore", I).Value = 0 Then
                For r = 0 To DataGridOR.Columns.Count - 1
                    If DataGridOR.Item("Tag", I).Value.ToString = "" Or _
                    DataGridOR.Item("Tag", I).ToString = Nothing Or _
                    DataGridOR.Item("Tag", I).ToString = DBNull.Value.ToString Then


                    Else
                        DataGridOR.Item(r, I).Style.BackColor = Color.YellowGreen
                    End If

                Next
            Else
                Dim douBeta As Double

                douBeta = DataGridOR.Item("Betaratio", I).Value

                If douBeta < 0.2 Or douBeta > 0.8 Or douBeta > 1 Then
                    For q = 0 To DataGridOR.Columns.Count - 1
                        DataGridOR.Item(q, I).Style.BackColor = Color.LightPink
                    Next
                End If
            End If

        Next
        DataGridOR.Columns("id").Visible = False
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class