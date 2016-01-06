<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddNewDataSafetyValve
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
        Me.ComboPhase = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SA = New System.Windows.Forms.GroupBox
        Me.TextTotalP = New System.Windows.Forms.TextBox
        Me.ComboRupture = New System.Windows.Forms.ComboBox
        Me.TextOP = New System.Windows.Forms.TextBox
        Me.TextRequireP = New System.Windows.Forms.TextBox
        Me.TextSETP = New System.Windows.Forms.TextBox
        Me.TextTEMP = New System.Windows.Forms.TextBox
        Me.TextTag = New System.Windows.Forms.TextBox
        Me.LabelWkGH = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LabelRupture = New System.Windows.Forms.Label
        Me.LabelOverP = New System.Windows.Forms.Label
        Me.LabelTEMP = New System.Windows.Forms.Label
        Me.LabelSET = New System.Windows.Forms.Label
        Me.LabelTAG = New System.Windows.Forms.Label
        Me.TextZ = New System.Windows.Forms.TextBox
        Me.TextMOLE = New System.Windows.Forms.TextBox
        Me.LabelZ = New System.Windows.Forms.Label
        Me.LabelMOLE = New System.Windows.Forms.Label
        Me.ButtonADD = New System.Windows.Forms.Button
        Me.ButtonEXIT = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSpGr = New System.Windows.Forms.TextBox
        Me.labSpGr = New System.Windows.Forms.Label
        Me.txtCaseNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Textk = New System.Windows.Forms.TextBox
        Me.Labelk = New System.Windows.Forms.Label
        Me.StatusStripSafetyValve = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabelsAVETYVALVE = New System.Windows.Forms.ToolStripStatusLabel
        Me.SA.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStripSafetyValve.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboPhase
        '
        Me.ComboPhase.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboPhase.FormattingEnabled = True
        Me.ComboPhase.Items.AddRange(New Object() {"G", "L", "S"})
        Me.ComboPhase.Location = New System.Drawing.Point(362, 28)
        Me.ComboPhase.Name = "ComboPhase"
        Me.ComboPhase.Size = New System.Drawing.Size(115, 24)
        Me.ComboPhase.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(312, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Phase:"
        '
        'SA
        '
        Me.SA.Controls.Add(Me.TextTotalP)
        Me.SA.Controls.Add(Me.ComboRupture)
        Me.SA.Controls.Add(Me.TextOP)
        Me.SA.Controls.Add(Me.TextRequireP)
        Me.SA.Controls.Add(Me.TextSETP)
        Me.SA.Controls.Add(Me.TextTEMP)
        Me.SA.Controls.Add(Me.TextTag)
        Me.SA.Controls.Add(Me.LabelWkGH)
        Me.SA.Controls.Add(Me.Label1)
        Me.SA.Controls.Add(Me.ComboPhase)
        Me.SA.Controls.Add(Me.Label7)
        Me.SA.Controls.Add(Me.LabelRupture)
        Me.SA.Controls.Add(Me.LabelOverP)
        Me.SA.Controls.Add(Me.LabelTEMP)
        Me.SA.Controls.Add(Me.LabelSET)
        Me.SA.Controls.Add(Me.LabelTAG)
        Me.SA.Location = New System.Drawing.Point(14, 13)
        Me.SA.Name = "SA"
        Me.SA.Size = New System.Drawing.Size(492, 204)
        Me.SA.TabIndex = 2
        Me.SA.TabStop = False
        Me.SA.Text = "New Record:"
        '
        'TextTotalP
        '
        Me.TextTotalP.Location = New System.Drawing.Point(166, 161)
        Me.TextTotalP.Name = "TextTotalP"
        Me.TextTotalP.Size = New System.Drawing.Size(66, 20)
        Me.TextTotalP.TabIndex = 6
        '
        'ComboRupture
        '
        Me.ComboRupture.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboRupture.FormattingEnabled = True
        Me.ComboRupture.Items.AddRange(New Object() {"N", "Y"})
        Me.ComboRupture.Location = New System.Drawing.Point(362, 163)
        Me.ComboRupture.Name = "ComboRupture"
        Me.ComboRupture.Size = New System.Drawing.Size(112, 23)
        Me.ComboRupture.TabIndex = 7
        '
        'TextOP
        '
        Me.TextOP.Location = New System.Drawing.Point(385, 119)
        Me.TextOP.Name = "TextOP"
        Me.TextOP.Size = New System.Drawing.Size(89, 20)
        Me.TextOP.TabIndex = 5
        '
        'TextRequireP
        '
        Me.TextRequireP.Location = New System.Drawing.Point(170, 74)
        Me.TextRequireP.Name = "TextRequireP"
        Me.TextRequireP.Size = New System.Drawing.Size(62, 20)
        Me.TextRequireP.TabIndex = 2
        '
        'TextSETP
        '
        Me.TextSETP.Location = New System.Drawing.Point(385, 74)
        Me.TextSETP.Name = "TextSETP"
        Me.TextSETP.Size = New System.Drawing.Size(89, 20)
        Me.TextSETP.TabIndex = 3
        '
        'TextTEMP
        '
        Me.TextTEMP.Location = New System.Drawing.Point(114, 116)
        Me.TextTEMP.Name = "TextTEMP"
        Me.TextTEMP.Size = New System.Drawing.Size(118, 20)
        Me.TextTEMP.TabIndex = 4
        '
        'TextTag
        '
        Me.TextTag.Location = New System.Drawing.Point(114, 28)
        Me.TextTag.Name = "TextTag"
        Me.TextTag.Size = New System.Drawing.Size(118, 20)
        Me.TextTag.TabIndex = 0
        '
        'LabelWkGH
        '
        Me.LabelWkGH.AutoSize = True
        Me.LabelWkGH.Location = New System.Drawing.Point(6, 77)
        Me.LabelWkGH.Name = "LabelWkGH"
        Me.LabelWkGH.Size = New System.Drawing.Size(141, 13)
        Me.LabelWkGH.TabIndex = 1
        Me.LabelWkGH.Text = "Required Flow Rate (KG/H):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(156, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Total Back Press. (KG/CM2-G):"
        '
        'LabelRupture
        '
        Me.LabelRupture.AutoSize = True
        Me.LabelRupture.Location = New System.Drawing.Point(310, 168)
        Me.LabelRupture.Name = "LabelRupture"
        Me.LabelRupture.Size = New System.Drawing.Size(48, 13)
        Me.LabelRupture.TabIndex = 8
        Me.LabelRupture.Text = "Rupture:"
        '
        'LabelOverP
        '
        Me.LabelOverP.AutoSize = True
        Me.LabelOverP.Location = New System.Drawing.Point(293, 122)
        Me.LabelOverP.Name = "LabelOverP"
        Me.LabelOverP.Size = New System.Drawing.Size(88, 13)
        Me.LabelOverP.TabIndex = 4
        Me.LabelOverP.Text = "OverPressure(%):"
        '
        'LabelTEMP
        '
        Me.LabelTEMP.AutoSize = True
        Me.LabelTEMP.Location = New System.Drawing.Point(6, 119)
        Me.LabelTEMP.Name = "LabelTEMP"
        Me.LabelTEMP.Size = New System.Drawing.Size(103, 13)
        Me.LabelTEMP.TabIndex = 3
        Me.LabelTEMP.Text = "Reliefting Temp. (C):"
        '
        'LabelSET
        '
        Me.LabelSET.AutoSize = True
        Me.LabelSET.Location = New System.Drawing.Point(256, 77)
        Me.LabelSET.Name = "LabelSET"
        Me.LabelSET.Size = New System.Drawing.Size(129, 13)
        Me.LabelSET.TabIndex = 2
        Me.LabelSET.Text = "Set Pressure(KG/CM2-G):"
        '
        'LabelTAG
        '
        Me.LabelTAG.AutoSize = True
        Me.LabelTAG.Location = New System.Drawing.Point(6, 31)
        Me.LabelTAG.Name = "LabelTAG"
        Me.LabelTAG.Size = New System.Drawing.Size(29, 13)
        Me.LabelTAG.TabIndex = 0
        Me.LabelTAG.Text = "Tag:"
        '
        'TextZ
        '
        Me.TextZ.Location = New System.Drawing.Point(147, 47)
        Me.TextZ.Name = "TextZ"
        Me.TextZ.Size = New System.Drawing.Size(102, 20)
        Me.TextZ.TabIndex = 10
        '
        'TextMOLE
        '
        Me.TextMOLE.Location = New System.Drawing.Point(315, 18)
        Me.TextMOLE.Name = "TextMOLE"
        Me.TextMOLE.Size = New System.Drawing.Size(100, 20)
        Me.TextMOLE.TabIndex = 9
        '
        'LabelZ
        '
        Me.LabelZ.AutoSize = True
        Me.LabelZ.Location = New System.Drawing.Point(33, 50)
        Me.LabelZ.Name = "LabelZ"
        Me.LabelZ.Size = New System.Drawing.Size(94, 13)
        Me.LabelZ.TabIndex = 11
        Me.LabelZ.Text = "Z (Compressibility):"
        '
        'LabelMOLE
        '
        Me.LabelMOLE.AutoSize = True
        Me.LabelMOLE.Location = New System.Drawing.Point(277, 21)
        Me.LabelMOLE.Name = "LabelMOLE"
        Me.LabelMOLE.Size = New System.Drawing.Size(33, 13)
        Me.LabelMOLE.TabIndex = 9
        Me.LabelMOLE.Text = "Mole:"
        '
        'ButtonADD
        '
        Me.ButtonADD.Location = New System.Drawing.Point(14, 326)
        Me.ButtonADD.Name = "ButtonADD"
        Me.ButtonADD.Size = New System.Drawing.Size(81, 50)
        Me.ButtonADD.TabIndex = 12
        Me.ButtonADD.Text = "Add"
        Me.ButtonADD.UseVisualStyleBackColor = True
        '
        'ButtonEXIT
        '
        Me.ButtonEXIT.Location = New System.Drawing.Point(430, 326)
        Me.ButtonEXIT.Name = "ButtonEXIT"
        Me.ButtonEXIT.Size = New System.Drawing.Size(88, 50)
        Me.ButtonEXIT.TabIndex = 13
        Me.ButtonEXIT.Text = "Exit"
        Me.ButtonEXIT.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSpGr)
        Me.GroupBox1.Controls.Add(Me.labSpGr)
        Me.GroupBox1.Controls.Add(Me.txtCaseNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Textk)
        Me.GroupBox1.Controls.Add(Me.Labelk)
        Me.GroupBox1.Controls.Add(Me.TextMOLE)
        Me.GroupBox1.Controls.Add(Me.TextZ)
        Me.GroupBox1.Controls.Add(Me.LabelZ)
        Me.GroupBox1.Controls.Add(Me.LabelMOLE)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 223)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 97)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Factor:"
        '
        'txtSpGr
        '
        Me.txtSpGr.Location = New System.Drawing.Point(147, 73)
        Me.txtSpGr.Name = "txtSpGr"
        Me.txtSpGr.Size = New System.Drawing.Size(102, 20)
        Me.txtSpGr.TabIndex = 26
        '
        'labSpGr
        '
        Me.labSpGr.AutoSize = True
        Me.labSpGr.Location = New System.Drawing.Point(33, 76)
        Me.labSpGr.Name = "labSpGr"
        Me.labSpGr.Size = New System.Drawing.Size(40, 13)
        Me.labSpGr.TabIndex = 27
        Me.labSpGr.Text = "Sp.Gr.:"
        '
        'txtCaseNo
        '
        Me.txtCaseNo.Location = New System.Drawing.Point(329, 47)
        Me.txtCaseNo.Name = "txtCaseNo"
        Me.txtCaseNo.Size = New System.Drawing.Size(104, 20)
        Me.txtCaseNo.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "CaseNo.:"
        '
        'Textk
        '
        Me.Textk.Location = New System.Drawing.Point(147, 16)
        Me.Textk.Name = "Textk"
        Me.Textk.Size = New System.Drawing.Size(102, 20)
        Me.Textk.TabIndex = 8
        '
        'Labelk
        '
        Me.Labelk.AutoSize = True
        Me.Labelk.Location = New System.Drawing.Point(33, 20)
        Me.Labelk.Name = "Labelk"
        Me.Labelk.Size = New System.Drawing.Size(89, 13)
        Me.Labelk.TabIndex = 23
        Me.Labelk.Text = "k (Specific Heat):"
        '
        'StatusStripSafetyValve
        '
        Me.StatusStripSafetyValve.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStripSafetyValve.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelsAVETYVALVE})
        Me.StatusStripSafetyValve.Location = New System.Drawing.Point(0, 381)
        Me.StatusStripSafetyValve.Name = "StatusStripSafetyValve"
        Me.StatusStripSafetyValve.Size = New System.Drawing.Size(518, 22)
        Me.StatusStripSafetyValve.TabIndex = 24
        Me.StatusStripSafetyValve.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelsAVETYVALVE
        '
        Me.ToolStripStatusLabelsAVETYVALVE.Name = "ToolStripStatusLabelsAVETYVALVE"
        Me.ToolStripStatusLabelsAVETYVALVE.Size = New System.Drawing.Size(0, 17)
        '
        'frmAddNewDataSafetyValve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 403)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStripSafetyValve)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonEXIT)
        Me.Controls.Add(Me.ButtonADD)
        Me.Controls.Add(Me.SA)
        Me.MinimizeBox = False
        Me.Name = "frmAddNewDataSafetyValve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Safety Valve Record"
        Me.SA.ResumeLayout(False)
        Me.SA.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStripSafetyValve.ResumeLayout(False)
        Me.StatusStripSafetyValve.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboPhase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SA As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonADD As System.Windows.Forms.Button
    Friend WithEvents ButtonEXIT As System.Windows.Forms.Button
    Friend WithEvents LabelZ As System.Windows.Forms.Label
    Friend WithEvents LabelMOLE As System.Windows.Forms.Label
    Friend WithEvents LabelRupture As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LabelOverP As System.Windows.Forms.Label
    Friend WithEvents LabelTEMP As System.Windows.Forms.Label
    Friend WithEvents LabelSET As System.Windows.Forms.Label
    Friend WithEvents LabelWkGH As System.Windows.Forms.Label
    Friend WithEvents LabelTAG As System.Windows.Forms.Label
    Friend WithEvents TextZ As System.Windows.Forms.TextBox
    Friend WithEvents TextMOLE As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalP As System.Windows.Forms.TextBox
    Friend WithEvents TextOP As System.Windows.Forms.TextBox
    Friend WithEvents TextRequireP As System.Windows.Forms.TextBox
    Friend WithEvents TextSETP As System.Windows.Forms.TextBox
    Friend WithEvents TextTEMP As System.Windows.Forms.TextBox
    Friend WithEvents TextTag As System.Windows.Forms.TextBox
    Friend WithEvents ComboRupture As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStripSafetyValve As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelsAVETYVALVE As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Textk As System.Windows.Forms.TextBox
    Friend WithEvents Labelk As System.Windows.Forms.Label
    Friend WithEvents txtCaseNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSpGr As System.Windows.Forms.TextBox
    Friend WithEvents labSpGr As System.Windows.Forms.Label
End Class
