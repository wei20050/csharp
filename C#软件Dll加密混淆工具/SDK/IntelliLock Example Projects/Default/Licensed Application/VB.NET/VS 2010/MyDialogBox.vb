<IntelliLock.DialogBox()> _
Public Class MyDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal message As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.label_message.Text = message
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.label_message = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'label_message
        '
        Me.label_message.Location = New System.Drawing.Point(8, 8)
        Me.label_message.Name = "label_message"
        Me.label_message.Size = New System.Drawing.Size(280, 48)
        Me.label_message.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(216, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        '
        'MyDialogBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 85)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.label_message)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MyDialogBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MyDialogBox"
        Me.ResumeLayout(False)

    End Sub
    Friend label_message As Label

#End Region

    Public Shared Sub ShowMessage(ByVal message As String)
        Dim dialogbox As New MyDialogBox(message)
        dialogbox.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyBase.Close()
    End Sub
End Class
