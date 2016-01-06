<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModifyControlValverecord
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridFormModify = New System.Windows.Forms.DataGridView
        Me.TxtMole = New System.Windows.Forms.TextBox
        Me.Labelmole = New System.Windows.Forms.Label
        Me.LabelUNITMAX = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.LabelMINUNIT = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMaxFl = New System.Windows.Forms.TextBox
        Me.TxtMinFL = New System.Windows.Forms.TextBox
        Me.txtCriticalP = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckXT = New System.Windows.Forms.CheckBox
        Me.txtVaporP = New System.Windows.Forms.TextBox
        Me.TextXT = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboPhase = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.LineSizeTxt = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtTagName = New System.Windows.Forms.TextBox
        Me.LabelUnit = New System.Windows.Forms.Label
        Me.ComboBodyType = New System.Windows.Forms.ComboBox
        Me.TextZ = New System.Windows.Forms.TextBox
        Me.TextVISC = New System.Windows.Forms.TextBox
        Me.TextK = New System.Windows.Forms.TextBox
        Me.TextTemp = New System.Windows.Forms.TextBox
        Me.TextFlowRate = New System.Windows.Forms.TextBox
        Me.Textoutletp = New System.Windows.Forms.TextBox
        Me.TextInletp = New System.Windows.Forms.TextBox
        Me.TextSGMOLE = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.LabelZ = New System.Windows.Forms.Label
        Me.LabelSG = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.LabelK = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridFormModify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Location = New System.Drawing.Point(9, 481)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(165, 49)
        Me.ButtonAdd.TabIndex = 0
        Me.ButtonAdd.Text = "Modify"
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(413, 481)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(174, 49)
        Me.ButtonExit.TabIndex = 1
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridFormModify)
        Me.GroupBox1.Controls.Add(Me.TxtMole)
        Me.GroupBox1.Controls.Add(Me.Labelmole)
        Me.GroupBox1.Controls.Add(Me.LabelUNITMAX)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.LabelMINUNIT)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtMaxFl)
        Me.GroupBox1.Controls.Add(Me.TxtMinFL)
        Me.GroupBox1.Controls.Add(Me.txtCriticalP)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.CheckXT)
        Me.GroupBox1.Controls.Add(Me.txtVaporP)
        Me.GroupBox1.Controls.Add(Me.TextXT)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboPhase)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LineSizeTxt)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtTagName)
        Me.GroupBox1.Controls.Add(Me.LabelUnit)
        Me.GroupBox1.Controls.Add(Me.ComboBodyType)
        Me.GroupBox1.Controls.Add(Me.TextZ)
        Me.GroupBox1.Controls.Add(Me.TextVISC)
        Me.GroupBox1.Controls.Add(Me.TextK)
        Me.GroupBox1.Controls.Add(Me.TextTemp)
        Me.GroupBox1.Controls.Add(Me.TextFlowRate)
        Me.GroupBox1.Controls.Add(Me.Textoutletp)
        Me.GroupBox1.Controls.Add(Me.TextInletp)
        Me.GroupBox1.Controls.Add(Me.TextSGMOLE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LabelZ)
        Me.GroupBox1.Controls.Add(Me.LabelSG)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.LabelK)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 442)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Record"
        '
        'DataGridFormModify
        '
        Me.DataGridFormModify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridFormModify.Location = New System.Drawing.Point(191, 434)
        Me.DataGridFormModify.Name = "DataGridFormModify"
        Me.DataGridFormModify.RowTemplate.Height = 24
        Me.DataGridFormModify.Size = New System.Drawing.Size(109, 78)
        Me.DataGridFormModify.TabIndex = 45
        '
        'TxtMole
        '
        Me.TxtMole.Location = New System.Drawing.Point(410, 264)
        Me.TxtMole.Name = "TxtMole"
        Me.TxtMole.Size = New System.Drawing.Size(97, 22)
        Me.TxtMole.TabIndex = 44
        '
        'Labelmole
        '
        Me.Labelmole.AutoSize = True
        Me.Labelmole.Location = New System.Drawing.Point(327, 268)
        Me.Labelmole.Name = "Labelmole"
        Me.Labelmole.Size = New System.Drawing.Size(69, 12)
        Me.Labelmole.TabIndex = 43
        Me.Labelmole.Text = "Mole Weight:"
        '
        'LabelUNITMAX
        '
        Me.LabelUNITMAX.AutoSize = True
        Me.LabelUNITMAX.BackColor = System.Drawing.Color.Yellow
        Me.LabelUNITMAX.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelUNITMAX.Location = New System.Drawing.Point(123, 163)
        Me.LabelUNITMAX.Name = "LabelUNITMAX"
        Me.LabelUNITMAX.Size = New System.Drawing.Size(0, 12)
        Me.LabelUNITMAX.TabIndex = 42
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(159, 163)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(14, 12)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "/h"
        Me.Label20.Visible = False
        '
        'LabelMINUNIT
        '
        Me.LabelMINUNIT.AutoSize = True
        Me.LabelMINUNIT.BackColor = System.Drawing.Color.Yellow
        Me.LabelMINUNIT.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelMINUNIT.Location = New System.Drawing.Point(123, 116)
        Me.LabelMINUNIT.Name = "LabelMINUNIT"
        Me.LabelMINUNIT.Size = New System.Drawing.Size(0, 12)
        Me.LabelMINUNIT.TabIndex = 40
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(159, 117)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 12)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "/h"
        Me.Label17.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 163)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 12)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Max. Flow Rate:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 12)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Min. Flow Rate:"
        '
        'txtMaxFl
        '
        Me.txtMaxFl.Location = New System.Drawing.Point(183, 158)
        Me.txtMaxFl.Name = "txtMaxFl"
        Me.txtMaxFl.Size = New System.Drawing.Size(92, 22)
        Me.txtMaxFl.TabIndex = 36
        '
        'TxtMinFL
        '
        Me.TxtMinFL.Location = New System.Drawing.Point(182, 113)
        Me.TxtMinFL.Name = "TxtMinFL"
        Me.TxtMinFL.Size = New System.Drawing.Size(93, 22)
        Me.TxtMinFL.TabIndex = 35
        '
        'txtCriticalP
        '
        Me.txtCriticalP.Location = New System.Drawing.Point(154, 392)
        Me.txtCriticalP.Name = "txtCriticalP"
        Me.txtCriticalP.Size = New System.Drawing.Size(53, 22)
        Me.txtCriticalP.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(408, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 12)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "/h"
        Me.Label8.Visible = False
        '
        'CheckXT
        '
        Me.CheckXT.AutoSize = True
        Me.CheckXT.Location = New System.Drawing.Point(292, 400)
        Me.CheckXT.Name = "CheckXT"
        Me.CheckXT.Size = New System.Drawing.Size(166, 16)
        Me.CheckXT.TabIndex = 29
        Me.CheckXT.Text = "Xt (Pressure drop ratio factor):"
        Me.CheckXT.UseVisualStyleBackColor = True
        '
        'txtVaporP
        '
        Me.txtVaporP.Location = New System.Drawing.Point(155, 354)
        Me.txtVaporP.Name = "txtVaporP"
        Me.txtVaporP.Size = New System.Drawing.Size(56, 22)
        Me.txtVaporP.TabIndex = 33
        '
        'TextXT
        '
        Me.TextXT.Location = New System.Drawing.Point(461, 397)
        Me.TextXT.Name = "TextXT"
        Me.TextXT.Size = New System.Drawing.Size(66, 22)
        Me.TextXT.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 12)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Critical Pressure (KG/CM2):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Phase:"
        '
        'ComboPhase
        '
        Me.ComboPhase.FormattingEnabled = True
        Me.ComboPhase.Items.AddRange(New Object() {"G", "L", "S"})
        Me.ComboPhase.Location = New System.Drawing.Point(84, 66)
        Me.ComboPhase.Name = "ComboPhase"
        Me.ComboPhase.Size = New System.Drawing.Size(89, 20)
        Me.ComboPhase.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 359)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 12)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Vapor Pressure (KG/CM2):"
        '
        'LineSizeTxt
        '
        Me.LineSizeTxt.Location = New System.Drawing.Point(86, 308)
        Me.LineSizeTxt.Name = "LineSizeTxt"
        Me.LineSizeTxt.Size = New System.Drawing.Size(106, 22)
        Me.LineSizeTxt.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 311)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "LineSize (IN):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tag:"
        '
        'TxtTagName
        '
        Me.TxtTagName.Location = New System.Drawing.Point(76, 21)
        Me.TxtTagName.Name = "TxtTagName"
        Me.TxtTagName.Size = New System.Drawing.Size(89, 22)
        Me.TxtTagName.TabIndex = 1
        '
        'LabelUnit
        '
        Me.LabelUnit.AutoSize = True
        Me.LabelUnit.BackColor = System.Drawing.Color.Yellow
        Me.LabelUnit.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabelUnit.Location = New System.Drawing.Point(389, 117)
        Me.LabelUnit.Name = "LabelUnit"
        Me.LabelUnit.Size = New System.Drawing.Size(0, 12)
        Me.LabelUnit.TabIndex = 21
        '
        'ComboBodyType
        '
        Me.ComboBodyType.FormattingEnabled = True
        Me.ComboBodyType.Items.AddRange(New Object() {"GLOBE", "ANGLE", "BALL", "BUTTERFLY"})
        Me.ComboBodyType.Location = New System.Drawing.Point(365, 28)
        Me.ComboBodyType.Name = "ComboBodyType"
        Me.ComboBodyType.Size = New System.Drawing.Size(150, 20)
        Me.ComboBodyType.TabIndex = 24
        '
        'TextZ
        '
        Me.TextZ.Location = New System.Drawing.Point(410, 354)
        Me.TextZ.Name = "TextZ"
        Me.TextZ.Size = New System.Drawing.Size(101, 22)
        Me.TextZ.TabIndex = 23
        '
        'TextVISC
        '
        Me.TextVISC.Location = New System.Drawing.Point(410, 306)
        Me.TextVISC.Name = "TextVISC"
        Me.TextVISC.Size = New System.Drawing.Size(101, 22)
        Me.TextVISC.TabIndex = 22
        '
        'TextK
        '
        Me.TextK.Location = New System.Drawing.Point(102, 264)
        Me.TextK.Name = "TextK"
        Me.TextK.Size = New System.Drawing.Size(105, 22)
        Me.TextK.TabIndex = 21
        '
        'TextTemp
        '
        Me.TextTemp.Location = New System.Drawing.Point(109, 215)
        Me.TextTemp.Name = "TextTemp"
        Me.TextTemp.Size = New System.Drawing.Size(89, 22)
        Me.TextTemp.TabIndex = 19
        '
        'TextFlowRate
        '
        Me.TextFlowRate.Location = New System.Drawing.Point(428, 113)
        Me.TextFlowRate.Name = "TextFlowRate"
        Me.TextFlowRate.Size = New System.Drawing.Size(89, 22)
        Me.TextFlowRate.TabIndex = 17
        '
        'Textoutletp
        '
        Me.Textoutletp.Location = New System.Drawing.Point(424, 157)
        Me.Textoutletp.Name = "Textoutletp"
        Me.Textoutletp.Size = New System.Drawing.Size(101, 22)
        Me.Textoutletp.TabIndex = 16
        '
        'TextInletp
        '
        Me.TextInletp.Location = New System.Drawing.Point(466, 69)
        Me.TextInletp.Name = "TextInletp"
        Me.TextInletp.Size = New System.Drawing.Size(45, 22)
        Me.TextInletp.TabIndex = 15
        '
        'TextSGMOLE
        '
        Me.TextSGMOLE.Location = New System.Drawing.Point(410, 210)
        Me.TextSGMOLE.Name = "TextSGMOLE"
        Me.TextSGMOLE.Size = New System.Drawing.Size(101, 22)
        Me.TextSGMOLE.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(336, 311)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 12)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Viscosity(CP):"
        '
        'LabelZ
        '
        Me.LabelZ.AutoSize = True
        Me.LabelZ.Location = New System.Drawing.Point(389, 358)
        Me.LabelZ.Name = "LabelZ"
        Me.LabelZ.Size = New System.Drawing.Size(15, 12)
        Me.LabelZ.TabIndex = 11
        Me.LabelZ.Text = "Z:"
        '
        'LabelSG
        '
        Me.LabelSG.AutoSize = True
        Me.LabelSG.Location = New System.Drawing.Point(321, 218)
        Me.LabelSG.Name = "LabelSG"
        Me.LabelSG.Size = New System.Drawing.Size(83, 12)
        Me.LabelSG.TabIndex = 3
        Me.LabelSG.Text = "Specific Gravity:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(327, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 12)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Type:"
        '
        'LabelK
        '
        Me.LabelK.AutoSize = True
        Me.LabelK.Location = New System.Drawing.Point(17, 269)
        Me.LabelK.Name = "LabelK"
        Me.LabelK.Size = New System.Drawing.Size(82, 12)
        Me.LabelK.TabIndex = 10
        Me.LabelK.Text = "k (Special Heat):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Temperature (C):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(290, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Nor.Flow Rate:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Outlet Pressure(KG/CM2-G):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(327, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Inlet Pressure (KG/CM2-G):"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 546)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(613, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(12, 452)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(374, 15)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "FlowRate Unit: L=M3/H, V AND G =NM3/H, S=KG/H"
        '
        'FrmModifyControlValverecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonAdd)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MinimizeBox = False
        Me.Name = "FrmModifyControlValverecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify Control Valve Record"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridFormModify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTagName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelSG As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabelZ As System.Windows.Forms.Label
    Friend WithEvents LabelK As System.Windows.Forms.Label
    Friend WithEvents Textoutletp As System.Windows.Forms.TextBox
    Friend WithEvents TextInletp As System.Windows.Forms.TextBox
    Friend WithEvents TextSGMOLE As System.Windows.Forms.TextBox
    Friend WithEvents TextTemp As System.Windows.Forms.TextBox
    Friend WithEvents ComboPhase As System.Windows.Forms.ComboBox
    Friend WithEvents TextFlowRate As System.Windows.Forms.TextBox
    Friend WithEvents ComboBodyType As System.Windows.Forms.ComboBox
    Friend WithEvents TextZ As System.Windows.Forms.TextBox
    Friend WithEvents TextVISC As System.Windows.Forms.TextBox
    Friend WithEvents TextK As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelUnit As System.Windows.Forms.Label
    Friend WithEvents LineSizeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextXT As System.Windows.Forms.TextBox
    Friend WithEvents CheckXT As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCriticalP As System.Windows.Forms.TextBox
    Friend WithEvents txtVaporP As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMaxFl As System.Windows.Forms.TextBox
    Friend WithEvents TxtMinFL As System.Windows.Forms.TextBox
    Friend WithEvents LabelMINUNIT As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LabelUNITMAX As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtMole As System.Windows.Forms.TextBox
    Friend WithEvents Labelmole As System.Windows.Forms.Label
    Friend WithEvents DataGridFormModify As System.Windows.Forms.DataGridView
End Class
