<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyControl
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.statuslabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'statuslabel
        '
        Me.statuslabel.AutoSize = True
        Me.statuslabel.Location = New System.Drawing.Point(14, 29)
        Me.statuslabel.Name = "statuslabel"
        Me.statuslabel.Size = New System.Drawing.Size(86, 13)
        Me.statuslabel.TabIndex = 1
        Me.statuslabel.Text = "License Status ="
        '
        'MyControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.statuslabel)
        Me.Name = "MyControl"
        Me.Size = New System.Drawing.Size(224, 73)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statuslabel As System.Windows.Forms.Label

End Class
