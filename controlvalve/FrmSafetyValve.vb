
Imports System.Data
Imports System.Data.SqlClient


Public Class FrmSafetyValve


    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        MDISizingGroup.ToolStripProgressBar1.Value = 0
        Me.Close()
        MDISizingGroup.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataSafetyValve.CellContentClick

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub FrmSafetyValve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=Specification;User Id=sa;Password=ctciinst;"
        Dim connectstring As String = "Server=INTSRV1\CTCIINST;database=SafetyValve;User Id=sa;Password=ctciinst;"
        Dim conn As SqlConnection = New SqlConnection(connectstring)
        conn.Open()

        '查詢資料
        Dim str As String = "select * from " & MDISizingGroup.oProjectname.ToString
        Dim adp1 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set1 As DataSet = New DataSet
        adp1.Fill(set1, "SafetyTable")

        DataSafetyValve.DataSource = set1.Tables("SafetyTable")

        Dim dataGridViewColumn As New DataGridViewColumn
        'Dim direction As New ListSortDirection

        'DataSafetyValve.Sort(dataGridViewColumn, ListSortDirection.Descending)


        Dim InstTag As String
        Dim W As Double ''''''''''''''flow rate
        Dim Temperature As Double
        Dim totalBackPressure As Double

        Dim C As Double ''''''''''''''gas's property
        Dim Kd As Double '''''''''''''fix const
        Dim P1 As Double '''''''''''''inlet p
        Dim Kb As Double ''''''''''''''fix const
        Dim Kc As Double ''''''''''''have rupture =0.9, non rupture =1
        Dim OverPressure As Double
        Dim douSpGr As Double '''''''''''''for liquid
        Dim mole As Double ''''''''''mole for gas

        Dim phase As String
        Dim ruptureYN As String
        Dim safetyArea As Double
        Dim rowIndex As Integer
        Dim strValue As String
        Dim Kw As Double
        Dim Kv As Double
        Dim Kp As Double
        Dim Kn As Double
        Dim Ksh As Double
        Dim k As Double
        Dim douCaseNo

        Kd = 0.975
        Kb = 1


        For I = 0 To DataSafetyValve.Rows.Count - 1 '''''''''''清空Areasizein ,Designation值
            On Error Resume Next
            Name = DataSafetyValve.Item("Tag", I).Value.ToString

            Dim strAreasizein As String = "Update " & MDISizingGroup.oProjectname.ToString & _
                 " set Areasizein=0,Designation=" & "default" & " where TAG='" & Trim(Name) & "'"

            Dim cmd As SqlCommand = New SqlClient.SqlCommand(strAreasizein, conn)
            On Error Resume Next
            cmd.ExecuteNonQuery()
        Next



        For rowIndex = 0 To DataSafetyValve.Rows.Count - 1


            phase = Trim(DataSafetyValve.Item("Phase", rowIndex).Value)
            ruptureYN = Trim(DataSafetyValve.Item("Rupture", rowIndex).Value)
            douCaseNo = Trim(DataSafetyValve.Item("CaseNo", rowIndex).Value)

            If phase = "G" Then
                Kd = 0.975
                Dim Z As Double
                Z = DataSafetyValve.Item("z", rowIndex).Value
                If ruptureYN = "Y" Then
                    Kc = 0.9
                Else
                    Kc = 1
                End If

                InstTag = Trim(DataSafetyValve.Item("Tag", rowIndex).Value)
                W = DataSafetyValve.Item("RequiredCapacity", rowIndex).Value * 2.205 ''''''''''''''''kg->lb
                Temperature = (DataSafetyValve.Item("TemperatureC", rowIndex).Value + 273.15) * 1.8 '''''''''''c->R
                P1 = DataSafetyValve.Item("SetPressure", rowIndex).Value * 14.223 + 14.7 '''''''''''''''''''''''''''kg->psi
                OverPressure = P1 * (1 + (DataSafetyValve.Item("OverPressure", rowIndex).Value / 100)) '''''''''''14.7psi=1.03atm
                k = DataSafetyValve.Item("k", rowIndex).Value
                mole = DataSafetyValve.Item("MOLE", rowIndex).Value

                C = 520 * Math.Sqrt(k * (2 / (k + 1)) ^ ((k + 1) / (k - 1)))

                safetyArea = W / (C * Kd * OverPressure * Kb * Kc) * (Math.Sqrt(Temperature * Z / mole))

                strValue = safetyArea.ToString
                'Dim strAreain2 As String = "Update " & MDISizingGroup.oProjectname.ToString & " set AreaSizein= '" & Mid(strValue, 1, 7) & "' where TAG='" & InstTag & "'"
                'Dim cmd As SqlCommand = New SqlClient.SqlCommand(strAreain2, conn)

                'cmd.ExecuteNonQuery()

            ElseIf phase = "L" Then


                Kd = 0.62
                Kw = 1
                Kv = 1
                Kp = 1

                If ruptureYN = "Y" Then
                    Kc = 0.9
                Else
                    Kc = 1
                End If

                InstTag = Trim(DataSafetyValve.Item("Tag", rowIndex).Value)
                W = DataSafetyValve.Item("RequiredCapacity", rowIndex).Value / 4.54 / 60 ''''''''''''''''kg->GAL/MIN
                P1 = DataSafetyValve.Item("SetPressure", rowIndex).Value * 14.223 + 14.7 '''''''''''''''''''''''''''kg->psi
                OverPressure = P1 * (1 + DataSafetyValve.Item("OverPressure", rowIndex).Value / 100)  '''''''''''14.7psi=1.03atm

                douSpGr = DataSafetyValve.Item("SpGr", rowIndex).Value
                totalBackPressure = (DataSafetyValve.Item("TotalBackPressure", rowIndex).Value + 1.03) * 14.223 + 14.7 ''''''''PSI FOR LIQUID, 14.7PSI=1ATM


                safetyArea = W / (38 * Kd * Kw * Kp * Kc * Kv) * (Math.Sqrt(douSpGr / (OverPressure - totalBackPressure)))

                strValue = safetyArea.ToString
                'Dim strAreain2 As String = "Update " & MDISizingGroup.oProjectname.ToString & " set AreaSizein= '" & Mid(strValue, 1, 7) & "' where TAG='" & InstTag & "'"
                'Dim cmd As SqlCommand = New SqlClient.SqlCommand(strAreain2, conn)

                'cmd.ExecuteNonQuery()

            ElseIf phase = "S" Then

                If ruptureYN = "Y" Then
                    Kc = 0.9

                Else
                    Kc = 1
                End If

                Kd = 0.975
                Kw = 1
                Kv = 1
                Kp = 1
                Kn = 1
                Ksh = 1

                InstTag = Trim(DataSafetyValve.Item("Tag", rowIndex).Value)
                W = DataSafetyValve.Item("RequiredCapacity", rowIndex).Value * 2.2 ''''''''''''''''kg->lb
                P1 = DataSafetyValve.Item("SetPressure", rowIndex).Value * 14.223 + 14.7 '''''''''''''''''''''''''''kg->psi
                OverPressure = P1 * (1 + DataSafetyValve.Item("OverPressure", rowIndex).Value / 100)  '''''''''''14.7psi=1.03atm
                safetyArea = W / (51.5 * OverPressure * Kd * Kb * Kc * Kn * Ksh)
                strValue = safetyArea.ToString
                'Else
                '    strValue = "default"
                '    safetyArea = 0
            End If


            strValue = safetyArea.ToString

            Dim BOLTTYPE As New ClassUploadfile

            BOLTTYPE.boltSize = safetyArea ''''''''''''''將值傳入到class
            Dim BoltTypeFinal As String

            BOLTTYPE.SelectType()
            BoltTypeFinal = BOLTTYPE.boltSize
            Dim strAreain2 As String = "Update " & MDISizingGroup.oProjectname.ToString & " set AreaSizein= '" & Mid(strValue, 1, 7) & "',Designation='" & BoltTypeFinal & "' where TAG='" & InstTag & "' and CaseNo=" & douCaseNo & ""
            Dim cmd As SqlCommand = New SqlClient.SqlCommand(strAreain2, conn)
            cmd.ExecuteNonQuery()

        Next

        '''''''''''rebinding

        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(str, conn)

        '將查詢結果放到記憶體set1上的"1a "表格內
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "SafetyTable")

        DataSafetyValve.DataSource = set2.Tables("SafetyTable")

        DataSafetyValve.Refresh()



        conn.Close()

        REBINDING(str, conn)

        For I = 0 To DataSafetyValve.Rows.Count - 1
            If DataSafetyValve.Item("Tag", I).Value.ToString = "" Or DataSafetyValve.Item("Tag", I).ToString = Nothing Or DataSafetyValve.Item("Tag", I).ToString = DBNull.Value.ToString Then



            Else
                If Trim(DataSafetyValve.Item("Designation", I).Value.ToString) = "" Or DataSafetyValve.Item("Designation", I).ToString = Nothing Or DataSafetyValve.Item("Designation", I).ToString = DBNull.Value.ToString Then
                    For y = 0 To DataSafetyValve.Columns.Count - 1
                        DataSafetyValve.Item(y, I).Style.BackColor = Color.Bisque
                    Next
                End If
                DataSafetyValve.Item("Areasizein", I).Style.BackColor = Color.Yellow
            End If


        Next
        strValue = Nothing
        DataSafetyValve.Columns("id").Visible = False
    End Sub

    Private Sub REBINDING(ByVal STR As String, ByVal CONN As SqlConnection)
        Dim adp2 As SqlDataAdapter = New SqlDataAdapter(STR, CONN)
        Dim set2 As DataSet = New DataSet
        adp2.Fill(set2, "InstrumentTable")

        DataSafetyValve.DataSource = set2.Tables("InstrumentTable")

        DataSafetyValve.Refresh()
    End Sub



    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub exportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportExcel.Click
        'Dim MsExcel As New DataTable

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
            adp1.Fill(dsmas1, "OTable")

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
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            .Worksheets(1).name = "Sheet1"

            .Cells(1, 1).value = "Tag"
            .Cells(1, 2).value = "Required_kgh"
            .Cells(1, 3).value = "Temperature_C"
            .Cells(1, 4).value = "Set Pressure"
            .Cells(1, 5).value = "TotalBackPressure(Kg/cm2g)"
            .Cells(1, 6).value = "OverPressure(%)"
            .Cells(1, 7).value = "k(Cp/Cv,Specific heat)"
            .Cells(1, 8).value = "SpGr"
            .Cells(1, 9).value = "Mole"
            .Cells(1, 10).value = "Rupture"
            .Cells(1, 11).value = "Phase"
            .Cells(1, 12).value = "AreaSize_in"
            .Cells(1, 13).value = "Z(compressibility)"
            .Cells(1, 14).value = "CaseNo."
            .Cells(1, 15).value = "Designation"

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


            Dim filepath As String
            'Dim myStream As IO.Stream
            Dim saveFileDialog1 As New SaveFileDialog()


            saveFileDialog1.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls"

            saveFileDialog1.RestoreDirectory = True
            On Error Resume Next
            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim intcount As Integer = Len(saveFileDialog1.FileName)
                filepath = Mid(saveFileDialog1.FileName, 1, intcount)

            End If


            filename = filepath

            excel.Workbooks.Application.DisplayAlerts = False
            .ActiveCell.Worksheet.SaveAs(filename)
            excel.Quit()

            MsgBox("ok")
            'filename = "c:\File_Exported " & MDISizingGroup.SizingMode & ".xlsx"

            'excel.Workbooks.Application.DisplayAlerts = False
            '.ActiveCell.Worksheet.SaveAs(filename)
            'excel.Quit()

            'MsgBox("Save in " & filename)

        End With
    End Sub
End Class