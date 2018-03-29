<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    ' Fields

    Private columnHeader1 As ColumnHeader
    Private columnHeader2 As ColumnHeader
    Private hardwareidlabel As Label
    Private label1 As Label
    Private label2 As Label
    Private label3 As Label
    Private label4 As Label
    Private ListView1 As ListView
    Private valuelabel As Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.valuelabel = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.label3 = New System.Windows.Forms.Label
        Me.hardwareidlabel = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.PropertyComboBox = New System.Windows.Forms.ComboBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.label1.Location = New System.Drawing.Point(3, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(234, 14)
        Me.label1.Text = "EvaluationMonitor.CurrentLicense Properties:"
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.label2.Location = New System.Drawing.Point(3, 62)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(231, 14)
        Me.label2.Text = "Property Value:"
        '
        'valuelabel
        '
        Me.valuelabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.valuelabel.Location = New System.Drawing.Point(3, 76)
        Me.valuelabel.Name = "valuelabel"
        Me.valuelabel.Size = New System.Drawing.Size(234, 14)
        '
        'ListView1
        '
        Me.ListView1.Columns.Add(Me.columnHeader1)
        Me.ListView1.Columns.Add(Me.columnHeader2)
        Me.ListView1.Location = New System.Drawing.Point(3, 155)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(231, 84)
        Me.ListView1.TabIndex = 7
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Key"
        Me.columnHeader1.Width = 79
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Value"
        Me.columnHeader2.Width = 126
        '
        'label3
        '
        Me.label3.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.label3.Location = New System.Drawing.Point(3, 101)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(231, 14)
        Me.label3.Text = "Device Hardware ID:"
        '
        'hardwareidlabel
        '
        Me.hardwareidlabel.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.hardwareidlabel.Location = New System.Drawing.Point(0, 115)
        Me.hardwareidlabel.Name = "hardwareidlabel"
        Me.hardwareidlabel.Size = New System.Drawing.Size(234, 14)
        '
        'label4
        '
        Me.label4.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.label4.Location = New System.Drawing.Point(0, 138)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(231, 14)
        Me.label4.Text = "License Information:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(162, 245)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Close"
        '
        'PropertyComboBox
        '
        Me.PropertyComboBox.Location = New System.Drawing.Point(3, 27)
        Me.PropertyComboBox.Name = "PropertyComboBox"
        Me.PropertyComboBox.Size = New System.Drawing.Size(228, 22)
        Me.PropertyComboBox.TabIndex = 18
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.Text = "Tasks"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Deactivate License"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.PropertyComboBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.hardwareidlabel)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.valuelabel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "License Status Check"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PropertyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem

End Class
