<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallLicenseForm
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
        Me.installbutton = New System.Windows.Forms.Button
        Me.okbutton = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'installbutton
        '
        Me.installbutton.Location = New System.Drawing.Point(15, 69)
        Me.installbutton.Name = "installbutton"
        Me.installbutton.Size = New System.Drawing.Size(93, 23)
        Me.installbutton.TabIndex = 5
        Me.installbutton.Text = "Install License"
        Me.installbutton.UseVisualStyleBackColor = True
        '
        'okbutton
        '
        Me.okbutton.Location = New System.Drawing.Point(246, 69)
        Me.okbutton.Name = "okbutton"
        Me.okbutton.Size = New System.Drawing.Size(75, 23)
        Me.okbutton.TabIndex = 4
        Me.okbutton.Text = "OK"
        Me.okbutton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(12, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(307, 46)
        Me.label1.TabIndex = 3
        Me.label1.Text = "This message will disappear when a valid license file is installed."
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        Me.openFileDialog1.Filter = "License files|*.license|All files|*.*"
        '
        'InstallLicenseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 102)
        Me.Controls.Add(Me.installbutton)
        Me.Controls.Add(Me.okbutton)
        Me.Controls.Add(Me.label1)
        Me.Name = "InstallLicenseForm"
        Me.Text = "My Control - Evaluation"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents installbutton As System.Windows.Forms.Button
    Private WithEvents okbutton As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
