<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddNewOrifice
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonAdd = New System.Windows.Forms.Button
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.ComboPhase = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelUnit = New System.Windows.Forms.Label
        Me.GroupBoxOrifice = New System.Windows.Forms.GroupBox
        Me.txtVisocity = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LabelUNIT2 = New System.Windows.Forms.Label
        Me.TextGravity = New System.Windows.Forms.TextBox
        Me.TextPipeInletD = New System.Windows.Forms.TextBox
        Me.TextTemp = New System.Windows.Forms.TextBox
        Me.TextMoleW = New System.Windows.Forms.TextBox
        Me.TextDensity = New System.Windows.Forms.TextBox
        Me.TextInletP = New System.Windows.Forms.TextBox
        Me.TextCalculateFL = New System.Windows.Forms.TextBox
        Me.TextFL = New System.Windows.Forms.TextBox
        Me.TextLossmm = New System.Windows.Forms.TextBox
        Me.TextTag = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LabeCalculatemode = New System.Windows.Forms.Label
        Me.ComboCalculateMode = New System.Windows.Forms.ComboBox
        Me.GroupBoxOrifice.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.Location = New System.Drawing.Point(16, 377)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(91, 55)
        Me.ButtonAdd.TabIndex = 12
        Me.ButtonAdd.Text = "Add "
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExit.Location = New System.Drawing.Point(397, 377)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(91, 55)
        Me.ButtonExit.TabIndex = 13
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'ComboPhase
        '
        Me.ComboPhase.FormattingEnabled = True
        Me.ComboPhase.Items.AddRange(New Object() {"L", "S", "V"})
        Me.ComboPhase.Location = New System.Drawing.Point(96, 77)
        Me.ComboPhase.Name = "ComboPhase"
        Me.ComboPhase.Size = New System.Drawing.Size(105, 21)
        Me.ComboPhase.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Phase:"
        '
        'LabelUnit
        '
        Me.LabelUnit.AutoSize = True
        Me.LabelUnit.BackColor = System.Drawing.Color.Yellow
        Me.LabelUnit.Location = New System.Drawing.Point(316, 80)
        Me.LabelUnit.Name = "LabelUnit"
        Me.LabelUnit.Size = New System.Drawing.Size(0, 13)
        Me.LabelUnit.TabIndex = 5
        '
        'GroupBoxOrifice
        '
        Me.GroupBoxOrifice.Controls.Add(Me.txtVisocity)
        Me.GroupBoxOrifice.Controls.Add(Me.Label2)
        Me.GroupBoxOrifice.Controls.Add(Me.LabelUNIT2)
        Me.GroupBoxOrifice.Controls.Add(Me.TextGravity)
        Me.GroupBoxOrifice.Controls.Add(Me.TextPipeInletD)
        Me.GroupBoxOrifice.Controls.Add(Me.Label1)
        Me.GroupBoxOrifice.Controls.Add(Me.ComboPhase)
        Me.GroupBoxOrifice.Controls.Add(Me.LabelUnit)
        Me.GroupBoxOrifice.Controls.Add(Me.TextTemp)
        Me.GroupBoxOrifice.Controls.Add(Me.TextMoleW)
        Me.GroupBoxOrifice.Controls.Add(Me.TextDensity)
        Me.GroupBoxOrifice.Controls.Add(Me.TextInletP)
        Me.GroupBoxOrifice.Controls.Add(Me.TextCalculateFL)
        Me.GroupBoxOrifice.Controls.Add(Me.TextFL)
        Me.GroupBoxOrifice.Controls.Add(Me.TextLossmm)
        Me.GroupBoxOrifice.Controls.Add(Me.TextTag)
        Me.GroupBoxOrifice.Controls.Add(Me.Label13)
        Me.GroupBoxOrifice.Controls.Add(Me.Label11)
        Me.GroupBoxOrifice.Controls.Add(Me.Label10)
        Me.GroupBoxOrifice.Controls.Add(Me.Label9)
        Me.GroupBoxOrifice.Controls.Add(Me.Label8)
        Me.GroupBoxOrifice.Controls.Add(Me.Label7)
        Me.GroupBoxOrifice.Controls.Add(Me.Label6)
        Me.GroupBoxOrifice.Controls.Add(Me.Label5)
        Me.GroupBoxOrifice.Controls.Add(Me.Label4)
        Me.GroupBoxOrifice.Controls.Add(Me.Label3)
        Me.GroupBoxOrifice.Location = New System.Drawing.Point(12, 49)
        Me.GroupBoxOrifice.Name = "GroupBoxOrifice"
        Me.GroupBoxOrifice.Size = New System.Drawing.Size(476, 322)
        Me.GroupBoxOrifice.TabIndex = 6
        Me.GroupBoxOrifice.TabStop = False
        Me.GroupBoxOrifice.Text = "Orifice Plate"
        '
        'txtVisocity
        '
        Me.txtVisocity.Location = New System.Drawing.Point(317, 277)
        Me.txtVisocity.Name = "txtVisocity"
        Me.txtVisocity.Size = New System.Drawing.Size(124, 20)
        Me.txtVisocity.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Viscosity(CP):"
        '
        'LabelUNIT2
        '
        Me.LabelUNIT2.AutoSize = True
        Me.LabelUNIT2.BackColor = System.Drawing.Color.Yellow
        Me.LabelUNIT2.Location = New System.Drawing.Point(206, 131)
        Me.LabelUNIT2.Name = "LabelUNIT2"
        Me.LabelUNIT2.Size = New System.Drawing.Size(0, 13)
        Me.LabelUNIT2.TabIndex = 21
        '
        'TextGravity
        '
        Me.TextGravity.Location = New System.Drawing.Point(348, 182)
        Me.TextGravity.Name = "TextGravity"
        Me.TextGravity.Size = New System.Drawing.Size(91, 20)
        Me.TextGravity.TabIndex = 8
        '
        'TextPipeInletD
        '
        Me.TextPipeInletD.Location = New System.Drawing.Point(355, 128)
        Me.TextPipeInletD.Name = "TextPipeInletD"
        Me.TextPipeInletD.Size = New System.Drawing.Size(83, 20)
        Me.TextPipeInletD.TabIndex = 6
        '
        'TextTemp
        '
        Me.TextTemp.Location = New System.Drawing.Point(318, 229)
        Me.TextTemp.Name = "TextTemp"
        Me.TextTemp.Size = New System.Drawing.Size(120, 20)
        Me.TextTemp.TabIndex = 10
        '
        'TextMoleW
        '
        Me.TextMoleW.Location = New System.Drawing.Point(101, 283)
        Me.TextMoleW.Name = "TextMoleW"
        Me.TextMoleW.Size = New System.Drawing.Size(102, 20)
        Me.TextMoleW.TabIndex = 11
        '
        'TextDensity
        '
        Me.TextDensity.Location = New System.Drawing.Point(117, 231)
        Me.TextDensity.Name = "TextDensity"
        Me.TextDensity.Size = New System.Drawing.Size(83, 20)
        Me.TextDensity.TabIndex = 9
        '
        'TextInletP
        '
        Me.TextInletP.Location = New System.Drawing.Point(166, 179)
        Me.TextInletP.Name = "TextInletP"
        Me.TextInletP.Size = New System.Drawing.Size(80, 20)
        Me.TextInletP.TabIndex = 7
        '
        'TextCalculateFL
        '
        Me.TextCalculateFL.Location = New System.Drawing.Point(127, 128)
        Me.TextCalculateFL.Name = "TextCalculateFL"
        Me.TextCalculateFL.Size = New System.Drawing.Size(68, 20)
        Me.TextCalculateFL.TabIndex = 5
        '
        'TextFL
        '
        Me.TextFL.Location = New System.Drawing.Point(355, 77)
        Me.TextFL.Name = "TextFL"
        Me.TextFL.Size = New System.Drawing.Size(114, 20)
        Me.TextFL.TabIndex = 4
        '
        'TextLossmm
        '
        Me.TextLossmm.Location = New System.Drawing.Point(376, 27)
        Me.TextLossmm.Name = "TextLossmm"
        Me.TextLossmm.Size = New System.Drawing.Size(66, 20)
        Me.TextLossmm.TabIndex = 2
        '
        'TextTag
        '
        Me.TextTag.Location = New System.Drawing.Point(82, 27)
        Me.TextTag.Name = "TextTag"
        Me.TextTag.Size = New System.Drawing.Size(114, 20)
        Me.TextTag.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(261, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Specific Gravity:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(226, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Pipe Inlet Diameter (MM):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(255, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Flow Rate:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(261, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Temp (C):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 286)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Mole Weight:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Density (KG/M3):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(217, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Maxmun Differential (mm-WC):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Inlet Pressure(KG/CM2-GA):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Calculate Flow Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tag Name:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 443)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(497, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'LabeCalculatemode
        '
        Me.LabeCalculatemode.AutoSize = True
        Me.LabeCalculatemode.Location = New System.Drawing.Point(14, 20)
        Me.LabeCalculatemode.Name = "LabeCalculatemode"
        Me.LabeCalculatemode.Size = New System.Drawing.Size(81, 13)
        Me.LabeCalculatemode.TabIndex = 11
        Me.LabeCalculatemode.Text = "CalculateMode:"
        '
        'ComboCalculateMode
        '
        Me.ComboCalculateMode.FormattingEnabled = True
        Me.ComboCalculateMode.Items.AddRange(New Object() {"BoreSize", "FlowRate", "LossPressure", ""})
        Me.ComboCalculateMode.Location = New System.Drawing.Point(98, 16)
        Me.ComboCalculateMode.Name = "ComboCalculateMode"
        Me.ComboCalculateMode.Size = New System.Drawing.Size(125, 21)
        Me.ComboCalculateMode.TabIndex = 0
        '
        'FrmAddNewOrifice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 465)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabeCalculatemode)
        Me.Controls.Add(Me.ComboCalculateMode)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBoxOrifice)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonAdd)
        Me.MinimizeBox = False
        Me.Name = "FrmAddNewOrifice"
        Me.Text = "Add New Orifice Record"
        Me.GroupBoxOrifice.ResumeLayout(False)
        Me.GroupBoxOrifice.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ComboPhase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelUnit As System.Windows.Forms.Label
    Friend WithEvents GroupBoxOrifice As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextDensity As System.Windows.Forms.TextBox
    Friend WithEvents TextInletP As System.Windows.Forms.TextBox
    Friend WithEvents TextCalculateFL As System.Windows.Forms.TextBox
    Friend WithEvents TextFL As System.Windows.Forms.TextBox
    Friend WithEvents TextLossmm As System.Windows.Forms.TextBox
    Friend WithEvents TextTag As System.Windows.Forms.TextBox
    Friend WithEvents TextGravity As System.Windows.Forms.TextBox
    Friend WithEvents TextPipeInletD As System.Windows.Forms.TextBox
    Friend WithEvents TextTemp As System.Windows.Forms.TextBox
    Friend WithEvents TextMoleW As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelUNIT2 As System.Windows.Forms.Label
    Friend WithEvents LabeCalculatemode As System.Windows.Forms.Label
    Friend WithEvents ComboCalculateMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtVisocity As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
