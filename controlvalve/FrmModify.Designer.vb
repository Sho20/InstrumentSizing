<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModify
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModify))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripFrmName = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.DefaultXt = New System.Windows.Forms.ToolStripButton
        Me.InsertCalculateMode = New System.Windows.Forms.ToolStripButton
        Me.ImportCaseNo = New System.Windows.Forms.ToolStripButton
        Me.DataGridModify = New System.Windows.Forms.DataGridView
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtUseIdModify = New System.Windows.Forms.TextBox
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridModify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 360)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(794, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripFrmName, Me.ToolStripButtonExit, Me.ToolStripLabel1, Me.DefaultXt, Me.InsertCalculateMode, Me.ImportCaseNo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(794, 26)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripFrmName
        '
        Me.ToolStripFrmName.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripFrmName.Name = "ToolStripFrmName"
        Me.ToolStripFrmName.Size = New System.Drawing.Size(0, 23)
        '
        'ToolStripButtonExit
        '
        Me.ToolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonExit.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButtonExit.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripButtonExit.Image = CType(resources.GetObject("ToolStripButtonExit.Image"), System.Drawing.Image)
        Me.ToolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonExit.Name = "ToolStripButtonExit"
        Me.ToolStripButtonExit.Size = New System.Drawing.Size(39, 23)
        Me.ToolStripButtonExit.Text = "Exit"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Red
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(132, 23)
        Me.ToolStripLabel1.Text = "Green is Modified"
        '
        'DefaultXt
        '
        Me.DefaultXt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DefaultXt.Image = CType(resources.GetObject("DefaultXt.Image"), System.Drawing.Image)
        Me.DefaultXt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DefaultXt.Name = "DefaultXt"
        Me.DefaultXt.Size = New System.Drawing.Size(23, 23)
        Me.DefaultXt.Text = "DefaultXt"
        Me.DefaultXt.ToolTipText = "Insert Default Xt "
        Me.DefaultXt.Visible = False
        '
        'InsertCalculateMode
        '
        Me.InsertCalculateMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InsertCalculateMode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertCalculateMode.ForeColor = System.Drawing.Color.Blue
        Me.InsertCalculateMode.Image = CType(resources.GetObject("InsertCalculateMode.Image"), System.Drawing.Image)
        Me.InsertCalculateMode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InsertCalculateMode.Name = "InsertCalculateMode"
        Me.InsertCalculateMode.Size = New System.Drawing.Size(23, 23)
        Me.InsertCalculateMode.ToolTipText = "Insert Default CalculateMode=BoreSize(1)"
        Me.InsertCalculateMode.Visible = False
        '
        'ImportCaseNo
        '
        Me.ImportCaseNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImportCaseNo.Image = CType(resources.GetObject("ImportCaseNo.Image"), System.Drawing.Image)
        Me.ImportCaseNo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportCaseNo.Name = "ImportCaseNo"
        Me.ImportCaseNo.Size = New System.Drawing.Size(23, 23)
        Me.ImportCaseNo.Text = "ImportCaseNo"
        Me.ImportCaseNo.ToolTipText = "CaseNo Default=1"
        Me.ImportCaseNo.Visible = False
        '
        'DataGridModify
        '
        Me.DataGridModify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridModify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridModify.Location = New System.Drawing.Point(0, 26)
        Me.DataGridModify.Name = "DataGridModify"
        Me.DataGridModify.RowTemplate.Height = 24
        Me.DataGridModify.Size = New System.Drawing.Size(794, 334)
        Me.DataGridModify.TabIndex = 5
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(50, 365)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(59, 22)
        Me.txtID.TabIndex = 6
        '
        'txtUseIdModify
        '
        Me.txtUseIdModify.Location = New System.Drawing.Point(125, 360)
        Me.txtUseIdModify.Name = "txtUseIdModify"
        Me.txtUseIdModify.Size = New System.Drawing.Size(55, 22)
        Me.txtUseIdModify.TabIndex = 7
        Me.txtUseIdModify.Visible = False
        '
        'FrmModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 382)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtUseIdModify)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.DataGridModify)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.MinimizeBox = False
        Me.Name = "FrmModify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modify"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridModify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripFrmName As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridModify As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DefaultXt As System.Windows.Forms.ToolStripButton
    Friend WithEvents InsertCalculateMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportCaseNo As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtUseIdModify As System.Windows.Forms.TextBox
End Class
