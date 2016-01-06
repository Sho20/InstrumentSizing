<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddNewRestrictPlate
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
        Me.TextGravity = New System.Windows.Forms.TextBox
        Me.TextPipeInletD = New System.Windows.Forms.TextBox
        Me.TextTemp = New System.Windows.Forms.TextBox
        Me.TextMoleW = New System.Windows.Forms.TextBox
        Me.TextDensity = New System.Windows.Forms.TextBox
        Me.TextInletP = New System.Windows.Forms.TextBox
        Me.TextCalculateFL = New System.Windows.Forms.TextBox
        Me.TextLossmm = New System.Windows.Forms.TextBox
        Me.TextTag = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ComboCalculateMode = New System.Windows.Forms.ComboBox
        Me.LabeCalculatemode = New System.Windows.Forms.Label
        Me.GroupBoxOrifice.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdd.Location = New System.Drawing.Point(12, 336)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(91, 51)
        Me.ButtonAdd.TabIndex = 11
        Me.ButtonAdd.Text = "Add "
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExit.Location = New System.Drawing.Point(374, 336)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(91, 51)
        Me.ButtonExit.TabIndex = 12
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'ComboPhase
        '
        Me.ComboPhase.FormattingEnabled = True
        Me.ComboPhase.Items.AddRange(New Object() {"L", "S", "V"})
        Me.ComboPhase.Location = New System.Drawing.Point(300, 28)
        Me.ComboPhase.Name = "ComboPhase"
        Me.ComboPhase.Size = New System.Drawing.Size(105, 20)
        Me.ComboPhase.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(260, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Phase:"
        '
        'LabelUnit
        '
        Me.LabelUnit.AutoSize = True
        Me.LabelUnit.BackColor = System.Drawing.Color.Yellow
        Me.LabelUnit.Location = New System.Drawing.Point(97, 84)
        Me.LabelUnit.Name = "LabelUnit"
        Me.LabelUnit.Size = New System.Drawing.Size(0, 12)
        Me.LabelUnit.TabIndex = 5
        '
        'GroupBoxOrifice
        '
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
        Me.GroupBoxOrifice.Controls.Add(Me.TextLossmm)
        Me.GroupBoxOrifice.Controls.Add(Me.TextTag)
        Me.GroupBoxOrifice.Controls.Add(Me.Label13)
        Me.GroupBoxOrifice.Controls.Add(Me.Label11)
        Me.GroupBoxOrifice.Controls.Add(Me.Label9)
        Me.GroupBoxOrifice.Controls.Add(Me.Label8)
        Me.GroupBoxOrifice.Controls.Add(Me.Label7)
        Me.GroupBoxOrifice.Controls.Add(Me.Label6)
        Me.GroupBoxOrifice.Controls.Add(Me.Label5)
        Me.GroupBoxOrifice.Controls.Add(Me.Label4)
        Me.GroupBoxOrifice.Controls.Add(Me.Label3)
        Me.GroupBoxOrifice.Location = New System.Drawing.Point(12, 37)
        Me.GroupBoxOrifice.Name = "GroupBoxOrifice"
        Me.GroupBoxOrifice.Size = New System.Drawing.Size(453, 293)
        Me.GroupBoxOrifice.TabIndex = 6
        Me.GroupBoxOrifice.TabStop = False
        Me.GroupBoxOrifice.Text = "Restrict Plate"
        '
        'TextGravity
        '
        Me.TextGravity.Location = New System.Drawing.Point(113, 238)
        Me.TextGravity.Name = "TextGravity"
        Me.TextGravity.Size = New System.Drawing.Size(91, 22)
        Me.TextGravity.TabIndex = 9
        '
        'TextPipeInletD
        '
        Me.TextPipeInletD.Location = New System.Drawing.Point(346, 238)
        Me.TextPipeInletD.Name = "TextPipeInletD"
        Me.TextPipeInletD.Size = New System.Drawing.Size(83, 22)
        Me.TextPipeInletD.TabIndex = 10
        '
        'TextTemp
        '
        Me.TextTemp.Location = New System.Drawing.Point(317, 188)
        Me.TextTemp.Name = "TextTemp"
        Me.TextTemp.Size = New System.Drawing.Size(120, 22)
        Me.TextTemp.TabIndex = 8
        '
        'TextMoleW
        '
        Me.TextMoleW.Location = New System.Drawing.Point(335, 137)
        Me.TextMoleW.Name = "TextMoleW"
        Me.TextMoleW.Size = New System.Drawing.Size(102, 22)
        Me.TextMoleW.TabIndex = 6
        '
        'TextDensity
        '
        Me.TextDensity.Location = New System.Drawing.Point(113, 188)
        Me.TextDensity.Name = "TextDensity"
        Me.TextDensity.Size = New System.Drawing.Size(83, 22)
        Me.TextDensity.TabIndex = 7
        '
        'TextInletP
        '
        Me.TextInletP.Location = New System.Drawing.Point(136, 137)
        Me.TextInletP.Name = "TextInletP"
        Me.TextInletP.Size = New System.Drawing.Size(99, 22)
        Me.TextInletP.TabIndex = 5
        '
        'TextCalculateFL
        '
        Me.TextCalculateFL.Location = New System.Drawing.Point(136, 81)
        Me.TextCalculateFL.Name = "TextCalculateFL"
        Me.TextCalculateFL.Size = New System.Drawing.Size(68, 22)
        Me.TextCalculateFL.TabIndex = 3
        '
        'TextLossmm
        '
        Me.TextLossmm.Location = New System.Drawing.Point(389, 81)
        Me.TextLossmm.Name = "TextLossmm"
        Me.TextLossmm.Size = New System.Drawing.Size(48, 22)
        Me.TextLossmm.TabIndex = 4
        '
        'TextTag
        '
        Me.TextTag.Location = New System.Drawing.Point(82, 25)
        Me.TextTag.Name = "TextTag"
        Me.TextTag.Size = New System.Drawing.Size(114, 22)
        Me.TextTag.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(26, 241)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 12)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Specific Gravity:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(217, 241)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 12)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Pipe Inlet Diameter (MM):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(225, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 12)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Temperature (C):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(260, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Mole Weight:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Density (KG/M3):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 12)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Maxmun Differential (KG/CM2):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Inlet Pressure (KG/CM2):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Max. Flow Rate:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tag Name:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 396)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(485, 22)
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
        'ComboCalculateMode
        '
        Me.ComboCalculateMode.FormattingEnabled = True
        Me.ComboCalculateMode.Items.AddRange(New Object() {"BoreSize", "FlowRate", "LossPressure", ""})
        Me.ComboCalculateMode.Location = New System.Drawing.Point(95, 5)
        Me.ComboCalculateMode.Name = "ComboCalculateMode"
        Me.ComboCalculateMode.Size = New System.Drawing.Size(94, 20)
        Me.ComboCalculateMode.TabIndex = 0
        '
        'LabeCalculatemode
        '
        Me.LabeCalculatemode.AutoSize = True
        Me.LabeCalculatemode.Location = New System.Drawing.Point(12, 9)
        Me.LabeCalculatemode.Name = "LabeCalculatemode"
        Me.LabeCalculatemode.Size = New System.Drawing.Size(81, 12)
        Me.LabeCalculatemode.TabIndex = 9
        Me.LabeCalculatemode.Text = "Calculate Mode:"
        '
        'FrmAddNewRestrictPlate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 418)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabeCalculatemode)
        Me.Controls.Add(Me.ComboCalculateMode)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBoxOrifice)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonAdd)
        Me.MinimizeBox = False
        Me.Name = "FrmAddNewRestrictPlate"
        Me.Text = "Add New Restriction Plate Record"
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
    Friend WithEvents TextLossmm As System.Windows.Forms.TextBox
    Friend WithEvents TextTag As System.Windows.Forms.TextBox
    Friend WithEvents TextGravity As System.Windows.Forms.TextBox
    Friend WithEvents TextPipeInletD As System.Windows.Forms.TextBox
    Friend WithEvents TextTemp As System.Windows.Forms.TextBox
    Friend WithEvents TextMoleW As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ComboCalculateMode As System.Windows.Forms.ComboBox
    Friend WithEvents LabeCalculatemode As System.Windows.Forms.Label
End Class
