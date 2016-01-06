<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvertUnit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtKg = New System.Windows.Forms.TextBox
        Me.txtnm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMole = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtm3 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDesity = New System.Windows.Forms.TextBox
        Me.ButNM3 = New System.Windows.Forms.Button
        Me.ButM3 = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtKg
        '
        Me.txtKg.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKg.Location = New System.Drawing.Point(121, 93)
        Me.txtKg.Name = "txtKg"
        Me.txtKg.Size = New System.Drawing.Size(102, 22)
        Me.txtKg.TabIndex = 0
        '
        'txtnm
        '
        Me.txtnm.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnm.Location = New System.Drawing.Point(121, 134)
        Me.txtnm.Name = "txtnm"
        Me.txtnm.Size = New System.Drawing.Size(102, 22)
        Me.txtnm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(229, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "kg/h"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(229, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "NM3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Molecular weight:"
        '
        'txtMole
        '
        Me.txtMole.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMole.Location = New System.Drawing.Point(121, 16)
        Me.txtMole.Name = "txtMole"
        Me.txtMole.Size = New System.Drawing.Size(102, 22)
        Me.txtMole.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(229, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "m3/h"
        '
        'txtm3
        '
        Me.txtm3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtm3.Location = New System.Drawing.Point(121, 176)
        Me.txtm3.Name = "txtm3"
        Me.txtm3.Size = New System.Drawing.Size(102, 22)
        Me.txtm3.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Desity:"
        '
        'txtDesity
        '
        Me.txtDesity.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesity.Location = New System.Drawing.Point(121, 44)
        Me.txtDesity.Name = "txtDesity"
        Me.txtDesity.Size = New System.Drawing.Size(102, 22)
        Me.txtDesity.TabIndex = 8
        '
        'ButNM3
        '
        Me.ButNM3.Location = New System.Drawing.Point(38, 137)
        Me.ButNM3.Name = "ButNM3"
        Me.ButNM3.Size = New System.Drawing.Size(66, 19)
        Me.ButNM3.TabIndex = 10
        Me.ButNM3.Text = "Convert"
        Me.ButNM3.UseVisualStyleBackColor = True
        '
        'ButM3
        '
        Me.ButM3.Location = New System.Drawing.Point(38, 176)
        Me.ButM3.Name = "ButM3"
        Me.ButM3.Size = New System.Drawing.Size(66, 19)
        Me.ButM3.TabIndex = 11
        Me.ButM3.Text = "Convert"
        Me.ButM3.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(276, 191)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 30)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'frmConvertUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 223)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.ButM3)
        Me.Controls.Add(Me.ButNM3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDesity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtm3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMole)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtnm)
        Me.Controls.Add(Me.txtKg)
        Me.Name = "frmConvertUnit"
        Me.Text = "frmConvertUnit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtKg As System.Windows.Forms.TextBox
    Friend WithEvents txtnm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMole As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtm3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDesity As System.Windows.Forms.TextBox
    Friend WithEvents ButNM3 As System.Windows.Forms.Button
    Friend WithEvents ButM3 As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
