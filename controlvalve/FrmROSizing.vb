
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmROSizing
    Public strTag As String
    Public strPhase As String
    Public douMAXFL
    Public douInletP
    Public douLossP
    Public douSG
    Public douDensity
    Public douMole
    Public douTemp
    Public douPipeInletD
    Public douOrificeBore
    Public douCalculateMode

    Private Sub FrmROSizing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "Ro")

        DataGridRO.DataSource = set1.Tables("Ro")





        For rowIndex = 0 To DataGridRO.Rows.Count - 1

            If DataGridRO.Item(0, rowIndex).Value Is Nothing Then

            Else
                Name = Trim(DataGridRO.Item("Tag", rowIndex).Value.ToString)
                douCalculateMode = DataGridRO.Item("CalculateMode", rowIndex).Value
                strTag = UCase(Trim(DataGridRO.Item("Tag", rowIndex).Value.ToString))
                strPhase = UCase(Trim(DataGridRO.Item("Phase", rowIndex).Value.ToString))

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

        For I = 0 To DataGridRO.Rows.Count - 1
            On Error Resume Next
            If DataGridRO.Item("OrificeBore", I).Value.ToString = Nothing Or DataGridRO.Item("OrificeBore", I).Value = 0 Then
                For r = 0 To DataGridRO.Columns.Count - 1
                    If DataGridRO.Item("Tag", I).Value.ToString = "" Or DataGridRO.Item("Tag", I).ToString = Nothing Or DataGridRO.Item("Tag", I).ToString = DBNull.Value.ToString Then

                    Else
                        DataGridRO.Item(r, I).Style.BackColor = Color.YellowGreen
                    End If
                Next

            End If

        Next
        ToolStripStatusLabel1.Text = "Sizing Finish"
        DataGridRO.Columns("id").Visible = False
    End Sub

    Private Sub REBINDING(ByVal STR As String, ByVal CONN As SqlConnection)
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(STR, CONN)
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "Ro")

        DataGridRO.DataSource = set2.Tables("Ro")

        DataGridRO.Refresh()
    End Sub


    Private Sub UseCalculateBoreSize(ByVal rowIndex As Integer, ByVal name As String, ByVal conn As SqlConnection)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strOrificeBore As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set OrificeBore=0 where TAG='" & Trim(name) & "'" '''''''''''清空boresize的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strOrificeBore, conn)
        On Error Resume Next
        cmd.ExecuteNonQuery()
        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s





        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douSG = DataGridRO.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value

            For i = 0 To 3
                If douMAXFL.ToString = Nothing Then
                    douMAXFL = "default"
                    GoTo nextone
                ElseIf douLossP.ToString = Nothing Then
                    douLossP = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone

                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next

            ''體積流率 m3/s,比重x1000 g/m3, lossp(N/m2=lossp(kg/cm2)*9.81*10000).
            ''轉換單位
            'If douCalculateFL > 0 Then
            FlowrateM3s = douMAXFL / 3600
            LossPN = douLossP * 10000 * 9.81  'N/M2

            DensityGm3 = douSG * 1000
            Dim So

            So = FlowrateM3s / (0.61 * Math.Sqrt(2 * LossPN / DensityGm3))
            douOrificeBore = Math.Sqrt(So * 4 / 3.14) * 1000 '''''''''''''最後bore單位為MM

        ElseIf strPhase = "V" Or strPhase = "S" Then

            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douDensity = DataGridRO.Item("Density", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value

            For i = 0 To 3 '''''''''''''''''''''''''''''''''列出哪些必要參數不能為"0"
                If douMAXFL.ToString = Nothing Then

                    douMAXFL = "default"
                    GoTo nextone
                ElseIf douLossP.ToString = Nothing Then

                    douLossP = "default"
                    GoTo nextone

                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next


            ''體積流率 kg/s,比重x1000 g/m3, .
            ''轉換單位
            FlowrateM3s = douMAXFL / 3600
            Dim pipeinletMiter = douPipeInletD / 1000
            LossPN = douLossP * 10000
            Dim b
            b = Math.Sqrt(4 * FlowrateM3s / (0.61 * 3.14 * pipeinletMiter ^ 2 * Math.Sqrt(2 * 9.81 * LossPN * douDensity)))
            douOrificeBore = b * douPipeInletD  ''unit is mm

        Else
            GoTo nextone

        End If

        strOrificeBore = "Update " & MDISizingGroup.oProjectname.ToString & " set OrificeBore= '" & Mid(douOrificeBore, 1, 7) & "' where TAG='" & strTag & "'"
        cmd = New SqlClient.SqlCommand(strOrificeBore, conn)
        cmd.ExecuteNonQuery()

nextone:

    End Sub

    Private Sub UseCalculateFlowRate(ByVal rowIndex, ByVal Name, ByVal conn)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strMaxFL As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set MaxFlowRate=0 where TAG='" & Trim(Name) & "'" '''''''''''清空boresize的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strMaxFL, conn)
        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s
        On Error Resume Next
        cmd.ExecuteNonQuery()

        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douSG = DataGridRO.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value
            For i = 0 To 3
                If douOrificeBore.ToString = Nothing Then
                    douOrificeBore = "default"
                    GoTo nextone

                ElseIf douLossP.ToString = Nothing Then

                    douLossP = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone

                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next

            ''體積流率 m3/s,比重x1000 g/m3, lossp(N/m2=lossp(kg/cm2)*9.81*10000).
            ''轉換單位
            'If douCalculateFL > 0 Then
            'FlowrateM3s = douMAXFL / 3600
            LossPN = douLossP * 10000 * 9.81
            DensityGm3 = douSG * 1000
            Dim So

            So = ((douOrificeBore / 1000) ^ 2 * 3.14) / 4
            FlowrateM3s = Math.Ceiling(So * (0.61 * Math.Sqrt(2 * LossPN / DensityGm3)) * 3600)

            '''''將算出來的流速乘以3600=KG/H
            'douOrificeBore = Math.Sqrt(So * 4 / 3.14) * 1000 '''''''''''''最後bore單位為MM

        ElseIf strPhase = "V" Or strPhase = "S" Then

            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douDensity = DataGridRO.Item("Density", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value

            For i = 0 To 3 '''''''''''''''''''''''''''''''''列出哪些必要參數不能為"0"
                If douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douLossP.ToString = Nothing Then

                    douLossP = "default"
                    GoTo nextone

                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next

            ''體積流率 kg/s,比重x1000 g/m3, .
            ''轉換單位
            'Dim FlowrateM3s
            Dim pipeinletMiter = douPipeInletD / 1000
            LossPN = douLossP * 10000 '''''''''KG/M2
            Dim b
            b = douOrificeBore / douPipeInletD
            FlowrateM3s = Math.Ceiling((((b ^ 2) * (0.61 * 3.14 * (pipeinletMiter ^ 2) * Math.Sqrt(2 * 9.81 * LossPN * douDensity))) / 4) * 3600)

            '''''將算出來的流速乘以3600=KG/H
        Else
            GoTo nextone

        End If
        strMaxFL = "Update " & MDISizingGroup.oProjectname.ToString & " set MaxFlowRate= '" & Mid(FlowrateM3s, 1, 7) & "' where TAG='" & Name & "'"
        cmd = New SqlClient.SqlCommand(strMaxFL, conn)
        cmd.ExecuteNonQuery()

nextone:
    End Sub


    Private Sub UseLossP(ByVal rowIndex, ByVal Name, ByVal conn)
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"

        conn = New SqlConnection(connectstring)
        conn.Open()

        Dim strLossP As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set LossPressure=0 where TAG='" & Trim(Name) & "'" '''''''''''清空boresize的值

        Dim cmd As SqlCommand = New SqlClient.SqlCommand(strLossP, conn)
        On Error Resume Next
        cmd.ExecuteNonQuery()
        Dim DensityGm3
        Dim LossPN
        Dim FlowrateM3s

        If strPhase = "L" Then
            '''''''''''''''''''''''液體不需要mole and temp,inletp，比重就可以了s.g
            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douSG = DataGridRO.Item("Gravity", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value

            For i = 0 To 3
                If douMAXFL.ToString = Nothing Then
                    douMAXFL = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then
                    douOrificeBore = "default"
                    GoTo nextone
                ElseIf douSG.ToString = Nothing Then
                    douSG = "default"
                    GoTo nextone

                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone
                End If
            Next

            ''體積流率 m3/s,比重x1000 g/m3, lossp(N/m2=lossp(kg/cm2)*9.81*10000).
            ''轉換單位
            'If douCalculateFL > 0 Then
            FlowrateM3s = douMAXFL / 3600
            'LossPN = douLossP * 10000 * 9.81  'N/M2

            DensityGm3 = douSG * 1000
            Dim So

            So = ((douOrificeBore / 1000) ^ 2 * 3.14) / 4

            LossPN = ((FlowrateM3s / So / 0.61) ^ 2 / 2 * DensityGm3) / 10000 / 9.81


        ElseIf strPhase = "V" Or strPhase = "S" Then

            douMAXFL = DataGridRO.Item("MaxFlowRate", rowIndex).Value
            douLossP = DataGridRO.Item("LossPressure", rowIndex).Value
            douDensity = DataGridRO.Item("Density", rowIndex).Value
            douPipeInletD = DataGridRO.Item("PipeInletD", rowIndex).Value
            douOrificeBore = DataGridRO.Item("OrificeBore", rowIndex).Value

            For i = 0 To 3 '''''''''''''''''''''''''''''''''列出哪些必要參數不能為"0"
                If douMAXFL.ToString = Nothing Then

                    douMAXFL = "default"
                    GoTo nextone
                ElseIf douOrificeBore.ToString = Nothing Then

                    douOrificeBore = "default"
                    GoTo nextone

                ElseIf douDensity.ToString = Nothing Then
                    douDensity = "default"
                    GoTo nextone
                ElseIf douPipeInletD.ToString = Nothing Then
                    douPipeInletD = "default"
                    GoTo nextone

                End If
            Next


            ''體積流率 kg/s,比重x1000 g/m3, .
            ''轉換單位
            FlowrateM3s = douMAXFL / 3600
            Dim pipeinletMiter = douPipeInletD / 1000
            'LossPN = douLossP * 10000
            Dim b
            b = douOrificeBore / douPipeInletD

            LossPN = (16 * (FlowrateM3s ^ 2) / (((b ^ 2) * 0.61 * 3.14 * (pipeinletMiter ^ 2)) ^ 2) / 2 / 9.81 / douDensity / 10000)
        Else
            GoTo nextone

        End If

        strLossP = "Update " & MDISizingGroup.oProjectname.ToString & " set LossPressure= '" & Mid(LossPN, 1, 7) & "' where TAG='" & strTag & "'"
        cmd = New SqlClient.SqlCommand(strLossP, conn)
        cmd.ExecuteNonQuery()
nextone:
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
        MDISizingGroup.Show()
    End Sub

    Private Sub exportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportExcel.Click
        'Dim MsExcel As New DataTable

        '查詢資料
        Dim dsmas1 As DataSet = New DataSet
        Dim connectstring As String
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString



        connectstring = "Server=INTSRV1\CTCIINST;database=RestrictPlate;User Id=sa;Password=ctciinst;"
        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)
        adp1.Fill(dsmas1, "ROTable")



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
            .Cells(1, 4).value = "InletPressure(kg/cm2(Ga))"
            .Cells(1, 5).value = "Loss Pressure(kg/cm2)"
            .Cells(1, 6).value = "Specific gravity"
            .Cells(1, 7).value = "Density(KG/M3)"
            .Cells(1, 8).value = "MoleWeight"
            .Cells(1, 9).value = "Temp(C)"
            .Cells(1, 10).value = "Pipe Inlet Diameter(mm)"
            .Cells(1, 11).value = "Orifice Bore(mm)"
            .Cells(1, 12).value = "CalculateMode(1=BoreSize,2=FlowRate,3=LossPressure)"
            '.Cells(1, 13).value = "'1-1/2"



            Dim i As Integer = 1

            For col = 0 To dsmas1.Tables(0).Columns.Count - 1
                .Cells(1, i).EntireRow.Font.Bold = True
                i += 1
            Next

            i = 2

            Dim k As Integer = 1
            For col = 1 To dsmas1.Tables(0).Columns.Count - 1
                i = 2
                For row = 0 To dsmas1.Tables(0).Rows.Count - 1
                    If dsmas1.Tables(0).Rows(row).ItemArray(col).ToString = Nothing Then
                        .Cells(i, k).Value = ""
                        .Cells.EntireColumn.AutoFit()
                    Else

                        .Cells(i, k).Value = Trim(dsmas1.Tables(0).Rows(row).ItemArray(col))
                        .Cells.EntireColumn.AutoFit()
                    End If
                    i += 1
                Next
                k += 1
            Next


            'Dim filepath As String
            ''Dim myStream As IO.Stream
            'Dim saveFileDialog1 As New SaveFileDialog()

            'saveFileDialog1.Filter = ".xlsx|(*.xlsx)|*.xlsx|*.*"
            ''saveFileDialog1.FilterIndex = 2
            'saveFileDialog1.RestoreDirectory = True

            'If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            '    Dim intcount As Integer = Len(saveFileDialog1.FileName)
            '    filepath = Mid(saveFileDialog1.FileName, 1, intcount - 1)

            'End If


            'filename = filepath

            'excel.Workbooks.Application.DisplayAlerts = False
            '.ActiveCell.Worksheet.SaveAs(filename)
            'excel.Quit()

            'MsgBox("ok")

            '-----------------------------------------------------------------------------------
            'filename = "c:\File_Exported " & MDISizingGroup.SizingMode & ".xlsx"

            'excel.Workbooks.Application.DisplayAlerts = False
            '.ActiveCell.Worksheet.SaveAs(filename)
            'excel.Quit()

            'MsgBox("Save in " & filename)
            '-----------------------------------------------------------------------------------
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

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub DataGridRO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridRO.CellContentClick

    End Sub
End Class