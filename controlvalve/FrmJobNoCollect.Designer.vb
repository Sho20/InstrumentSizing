<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJobNoCollect
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
        Me.LstJobNo = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListFORMS = New System.Windows.Forms.ListBox
        Me.LabProjectNum = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LstJobNo
        '
        Me.LstJobNo.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LstJobNo.FormattingEnabled = True
        Me.LstJobNo.ItemHeight = 16
        Me.LstJobNo.Location = New System.Drawing.Point(12, 24)
        Me.LstJobNo.Name = "LstJobNo"
        Me.LstJobNo.Size = New System.Drawing.Size(153, 196)
        Me.LstJobNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Project Collection"
        '
        'ListFORMS
        '
        Me.ListFORMS.FormattingEnabled = True
        Me.ListFORMS.ItemHeight = 12
        Me.ListFORMS.Location = New System.Drawing.Point(19, 226)
        Me.ListFORMS.Name = "ListFORMS"
        Me.ListFORMS.Size = New System.Drawing.Size(106, 16)
        Me.ListFORMS.TabIndex = 2
        Me.ListFORMS.Visible = False
        '
        'LabProjectNum
        '
        Me.LabProjectNum.AutoSize = True
        Me.LabProjectNum.Location = New System.Drawing.Point(169, 243)
        Me.LabProjectNum.Name = "LabProjectNum"
        Me.LabProjectNum.Size = New System.Drawing.Size(0, 12)
        Me.LabProjectNum.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(50, 226)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmJobNoCollect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(179, 257)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabProjectNum)
        Me.Controls.Add(Me.ListFORMS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LstJobNo)
        Me.MinimizeBox = False
        Me.Name = "FrmJobNoCollect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LstJobNo As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListFORMS As System.Windows.Forms.ListBox
    Friend WithEvents LabProjectNum As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
