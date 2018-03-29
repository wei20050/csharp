Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        Me.InitializeComponent()
        Me.DisplayHardwareID()
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

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.button1 = New Button
        Me.label_ValidLicenseAvailable = New Label
        Me.listView1 = New ListView
        Me.columnHeader1 = New ColumnHeader
        Me.columnHeader2 = New ColumnHeader
        Me.label_ExpirationDays_Enabled = New Label
        Me.label_ExpirationDays = New Label
        Me.label_ExpirationDays_Current = New Label
        Me.label_ExpirationDate_Enabled = New Label
        Me.label_ExpirationDate = New Label
        Me.label9 = New Label
        Me.label_Executions = New Label
        Me.label_Executions_Enabled = New Label
        Me.label_Executions_Current = New Label
        Me.label_Instances_Enabled = New Label
        Me.label_Instances = New Label
        Me.label_LicenseServer_Enabled = New Label
        Me.label_LicenseServer = New Label
        Me.manager_groupbox = New GroupBox
        Me.label_HardwareLock_Bios = New Label
        Me.label_HardwareLock_OS = New Label
        Me.label_HardwareLock_Mainboard = New Label
        Me.label_HardwareLock_MAC = New Label
        Me.label_HardwareLock_HDD = New Label
        Me.label_HardwareLock_CPU = New Label
        Me.label_LicenseHardwareID = New Label
        Me.label_HardwareLock_Enabled = New Label
        Me.label_LicenseLocks_Enabled = New Label
        Me.locks_groupbox = New GroupBox
        Me.panel_devider = New Panel
        Me.label_Custom_Enabled = New Label
        Me.label_GlobalTime = New Label
        Me.label_GlobalTime_Enabled = New Label
        Me.label_GlobalTime_Current = New Label
        Me.label_Runtime_Enabled = New Label
        Me.label_Runtime = New Label
        Me.label_status_external_assembly = New Label
        Me.label_status_hdd = New Label
        Me.label_license_location = New Label
        Me.groupBox1 = New GroupBox
        Me.hid_textbox = New TextBox
        Me.hid_mainboard = New CheckBox
        Me.hid_os = New CheckBox
        Me.hid_hdd = New CheckBox
        Me.hid_cpu = New CheckBox
        Me.hid_mac = New CheckBox
        Me.hid_bios = New CheckBox
        Me.mainMenu1 = New MainMenu
        Me.menuItem1 = New MenuItem
        Me.menuItem2 = New MenuItem
        Me.menuItem3 = New MenuItem
        Me.manager_groupbox.SuspendLayout()
        Me.locks_groupbox.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        MyBase.SuspendLayout()
        Me.button1.Location = New Point(&HF8, 8)
        Me.button1.Name = "button1"
        Me.button1.Size = New Size(&H70, &H17)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Check License"
        AddHandler Me.button1.Click, New EventHandler(AddressOf Me.button1_Click)
        Me.label_ValidLicenseAvailable.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
        Me.label_ValidLicenseAvailable.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Me.label_ValidLicenseAvailable.Location = New Point(8, &H30)
        Me.label_ValidLicenseAvailable.Name = "label_ValidLicenseAvailable"
        Me.label_ValidLicenseAvailable.Size = New Size(&H268, &H10)
        Me.label_ValidLicenseAvailable.TabIndex = 1
        Me.label_ValidLicenseAvailable.Text = "CurrentLicense.LicenseStatus = "
        Me.label_ValidLicenseAvailable.TextAlign = ContentAlignment.MiddleLeft
        Me.listView1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
        Me.listView1.BorderStyle = BorderStyle.FixedSingle
        Me.listView1.Columns.AddRange(New ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
        Me.listView1.Location = New Point(8, 600)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New Size(&H260, &H88)
        Me.listView1.TabIndex = 2
        Me.listView1.View = View.Details
        Me.columnHeader1.Text = "Key"
        Me.columnHeader1.Width = &H94
        Me.columnHeader2.Text = "Value"
        Me.columnHeader2.Width = &H1B7
        Me.label_ExpirationDays_Enabled.AutoSize = True
        Me.label_ExpirationDays_Enabled.Location = New Point(8, &H18)
        Me.label_ExpirationDays_Enabled.Name = "label_ExpirationDays_Enabled"
        Me.label_ExpirationDays_Enabled.Size = New Size(&HDA, &H10)
        Me.label_ExpirationDays_Enabled.TabIndex = 3
        Me.label_ExpirationDays_Enabled.Text = "CurrentLicense.ExpirationDays_Enabled ="
        Me.label_ExpirationDays_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_ExpirationDays.AutoSize = True
        Me.label_ExpirationDays.Location = New Point(&H18, 40)
        Me.label_ExpirationDays.Name = "label_ExpirationDays"
        Me.label_ExpirationDays.Size = New Size(&HAD, &H10)
        Me.label_ExpirationDays.TabIndex = 4
        Me.label_ExpirationDays.Text = "CurrentLicense.ExpirationDays = "
        Me.label_ExpirationDays.TextAlign = ContentAlignment.MiddleLeft
        Me.label_ExpirationDays_Current.AutoSize = True
        Me.label_ExpirationDays_Current.Location = New Point(&H18, &H38)
        Me.label_ExpirationDays_Current.Name = "label_ExpirationDays_Current"
        Me.label_ExpirationDays_Current.Size = New Size(&HD9, &H10)
        Me.label_ExpirationDays_Current.TabIndex = 5
        Me.label_ExpirationDays_Current.Text = "CurrentLicense.ExpirationDays_Current = "
        Me.label_ExpirationDays_Current.TextAlign = ContentAlignment.MiddleLeft
        Me.label_ExpirationDate_Enabled.AutoSize = True
        Me.label_ExpirationDate_Enabled.Location = New Point(8, 80)
        Me.label_ExpirationDate_Enabled.Name = "label_ExpirationDate_Enabled"
        Me.label_ExpirationDate_Enabled.Size = New Size(&HDB, &H10)
        Me.label_ExpirationDate_Enabled.TabIndex = 8
        Me.label_ExpirationDate_Enabled.Text = "CurrentLicense.ExpirationDate_Enabled = "
        Me.label_ExpirationDate_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_ExpirationDate.AutoSize = True
        Me.label_ExpirationDate.Location = New Point(&H18, &H60)
        Me.label_ExpirationDate.Name = "label_ExpirationDate"
        Me.label_ExpirationDate.Size = New Size(&HAB, &H10)
        Me.label_ExpirationDate.TabIndex = 9
        Me.label_ExpirationDate.Text = "CurrentLicense.ExpirationDate = "
        Me.label_ExpirationDate.TextAlign = ContentAlignment.MiddleLeft
        Me.label9.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
        Me.label9.Location = New Point(8, &H248)
        Me.label9.Name = "label9"
        Me.label9.Size = New Size(400, &H10)
        Me.label9.TabIndex = 10
        Me.label9.Text = "License Information:"
        Me.label9.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Executions.AutoSize = True
        Me.label_Executions.Location = New Point(&H18, &H88)
        Me.label_Executions.Name = "label_Executions"
        Me.label_Executions.Size = New Size(&H98, &H10)
        Me.label_Executions.TabIndex = 13
        Me.label_Executions.Text = "CurrentLicense.Executions = "
        Me.label_Executions.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Executions_Enabled.AutoSize = True
        Me.label_Executions_Enabled.Location = New Point(8, 120)
        Me.label_Executions_Enabled.Name = "label_Executions_Enabled"
        Me.label_Executions_Enabled.Size = New Size(200, &H10)
        Me.label_Executions_Enabled.TabIndex = 12
        Me.label_Executions_Enabled.Text = "CurrentLicense.Executions_Enabled = "
        Me.label_Executions_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Executions_Current.AutoSize = True
        Me.label_Executions_Current.Location = New Point(&H18, &H98)
        Me.label_Executions_Current.Name = "label_Executions_Current"
        Me.label_Executions_Current.Size = New Size(&HC4, &H10)
        Me.label_Executions_Current.TabIndex = 14
        Me.label_Executions_Current.Text = "CurrentLicense.Executions_Current = "
        Me.label_Executions_Current.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Instances_Enabled.AutoSize = True
        Me.label_Instances_Enabled.Location = New Point(&H148, 80)
        Me.label_Instances_Enabled.Name = "label_Instances_Enabled"
        Me.label_Instances_Enabled.Size = New Size(&HC1, &H10)
        Me.label_Instances_Enabled.TabIndex = &H10
        Me.label_Instances_Enabled.Text = "CurrentLicense.Instances_Enabled = "
        Me.label_Instances_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Instances.AutoSize = True
        Me.label_Instances.Location = New Point(&H158, &H60)
        Me.label_Instances.Name = "label_Instances"
        Me.label_Instances.Size = New Size(&H91, &H10)
        Me.label_Instances.TabIndex = &H11
        Me.label_Instances.Text = "CurrentLicense.Instances = "
        Me.label_Instances.TextAlign = ContentAlignment.MiddleLeft
        Me.label_LicenseServer_Enabled.AutoSize = True
        Me.label_LicenseServer_Enabled.Location = New Point(8, &H18)
        Me.label_LicenseServer_Enabled.Name = "label_LicenseServer_Enabled"
        Me.label_LicenseServer_Enabled.Size = New Size(&H100, &H10)
        Me.label_LicenseServer_Enabled.TabIndex = &H12
        Me.label_LicenseServer_Enabled.Text = "CurrentLicense.RequireLicenseServerValidation ="
        Me.label_LicenseServer_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_LicenseServer.AutoSize = True
        Me.label_LicenseServer.Location = New Point(&H18, 40)
        Me.label_LicenseServer.Name = "label_LicenseServer"
        Me.label_LicenseServer.Size = New Size(&HA6, &H10)
        Me.label_LicenseServer.TabIndex = &H13
        Me.label_LicenseServer.Text = "CurrentLicense.LicenseServer ="
        Me.label_LicenseServer.TextAlign = ContentAlignment.MiddleLeft
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_Bios)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_OS)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_Mainboard)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_MAC)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_HDD)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_CPU)
        Me.manager_groupbox.Controls.Add(Me.label_LicenseHardwareID)
        Me.manager_groupbox.Controls.Add(Me.label_HardwareLock_Enabled)
        Me.manager_groupbox.Controls.Add(Me.label_LicenseServer)
        Me.manager_groupbox.Controls.Add(Me.label_LicenseServer_Enabled)
        Me.manager_groupbox.Controls.Add(Me.label_LicenseLocks_Enabled)
        Me.manager_groupbox.Location = New Point(8, &H80)
        Me.manager_groupbox.Name = "manager_groupbox"
        Me.manager_groupbox.Size = New Size(&H260, &HE0)
        Me.manager_groupbox.TabIndex = &H16
        Me.manager_groupbox.TabStop = False
        Me.manager_groupbox.Text = "License Settings"
        Me.label_HardwareLock_Bios.AutoSize = True
        Me.label_HardwareLock_Bios.Location = New Point(&H18, &H60)
        Me.label_HardwareLock_Bios.Name = "label_HardwareLock_Bios"
        Me.label_HardwareLock_Bios.Size = New Size(200, &H10)
        Me.label_HardwareLock_Bios.TabIndex = &H1D
        Me.label_HardwareLock_Bios.Text = "CurrentLicense.HardwareLock_BIOS ="
        Me.label_HardwareLock_Bios.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_OS.AutoSize = True
        Me.label_HardwareLock_OS.Location = New Point(&H18, &HB0)
        Me.label_HardwareLock_OS.Name = "label_HardwareLock_OS"
        Me.label_HardwareLock_OS.Size = New Size(&HBD, &H10)
        Me.label_HardwareLock_OS.TabIndex = &H1C
        Me.label_HardwareLock_OS.Text = "CurrentLicense.HardwareLock_OS ="
        Me.label_HardwareLock_OS.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_Mainboard.AutoSize = True
        Me.label_HardwareLock_Mainboard.Location = New Point(&H18, 160)
        Me.label_HardwareLock_Mainboard.Name = "label_HardwareLock_Mainboard"
        Me.label_HardwareLock_Mainboard.Size = New Size(&HE3, &H10)
        Me.label_HardwareLock_Mainboard.TabIndex = &H1B
        Me.label_HardwareLock_Mainboard.Text = "CurrentLicense.HardwareLock_Mainboard ="
        Me.label_HardwareLock_Mainboard.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_MAC.AutoSize = True
        Me.label_HardwareLock_MAC.Location = New Point(&H18, &H90)
        Me.label_HardwareLock_MAC.Name = "label_HardwareLock_MAC"
        Me.label_HardwareLock_MAC.Size = New Size(&HC6, &H10)
        Me.label_HardwareLock_MAC.TabIndex = &H1A
        Me.label_HardwareLock_MAC.Text = "CurrentLicense.HardwareLock_MAC ="
        Me.label_HardwareLock_MAC.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_HDD.AutoSize = True
        Me.label_HardwareLock_HDD.Location = New Point(&H18, &H80)
        Me.label_HardwareLock_HDD.Name = "label_HardwareLock_HDD"
        Me.label_HardwareLock_HDD.Size = New Size(&HC6, &H10)
        Me.label_HardwareLock_HDD.TabIndex = &H19
        Me.label_HardwareLock_HDD.Text = "CurrentLicense.HardwareLock_HDD ="
        Me.label_HardwareLock_HDD.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_CPU.AutoSize = True
        Me.label_HardwareLock_CPU.Location = New Point(&H18, &H70)
        Me.label_HardwareLock_CPU.Name = "label_HardwareLock_CPU"
        Me.label_HardwareLock_CPU.Size = New Size(&HC5, &H10)
        Me.label_HardwareLock_CPU.TabIndex = &H18
        Me.label_HardwareLock_CPU.Text = "CurrentLicense.HardwareLock_CPU ="
        Me.label_HardwareLock_CPU.TextAlign = ContentAlignment.MiddleLeft
        Me.label_LicenseHardwareID.AutoSize = True
        Me.label_LicenseHardwareID.Location = New Point(&H18, 80)
        Me.label_LicenseHardwareID.Name = "label_LicenseHardwareID"
        Me.label_LicenseHardwareID.Size = New Size(&H9A, &H10)
        Me.label_LicenseHardwareID.TabIndex = &H17
        Me.label_LicenseHardwareID.Text = "CurrentLicense.HardwareID ="
        Me.label_LicenseHardwareID.TextAlign = ContentAlignment.MiddleLeft
        Me.label_HardwareLock_Enabled.AutoSize = True
        Me.label_HardwareLock_Enabled.Location = New Point(8, &H40)
        Me.label_HardwareLock_Enabled.Name = "label_HardwareLock_Enabled"
        Me.label_HardwareLock_Enabled.Size = New Size(&HD7, &H10)
        Me.label_HardwareLock_Enabled.TabIndex = &H16
        Me.label_HardwareLock_Enabled.Text = "CurrentLicense.HardwareLock_Enabled ="
        Me.label_HardwareLock_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_LicenseLocks_Enabled.AutoSize = True
        Me.label_LicenseLocks_Enabled.Location = New Point(8, 200)
        Me.label_LicenseLocks_Enabled.Name = "label_LicenseLocks_Enabled"
        Me.label_LicenseLocks_Enabled.Size = New Size(&HA7, &H10)
        Me.label_LicenseLocks_Enabled.TabIndex = &H18
        Me.label_LicenseLocks_Enabled.Text = "CurrentLicense.TrialRestricted ="
        Me.label_LicenseLocks_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.locks_groupbox.Controls.Add(Me.panel_devider)
        Me.locks_groupbox.Controls.Add(Me.label_Custom_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_GlobalTime)
        Me.locks_groupbox.Controls.Add(Me.label_GlobalTime_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_GlobalTime_Current)
        Me.locks_groupbox.Controls.Add(Me.label_Runtime_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_Runtime)
        Me.locks_groupbox.Controls.Add(Me.label_ExpirationDays_Current)
        Me.locks_groupbox.Controls.Add(Me.label_ExpirationDate_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_ExpirationDate)
        Me.locks_groupbox.Controls.Add(Me.label_Executions)
        Me.locks_groupbox.Controls.Add(Me.label_Executions_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_Instances)
        Me.locks_groupbox.Controls.Add(Me.label_Executions_Current)
        Me.locks_groupbox.Controls.Add(Me.label_Instances_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_ExpirationDays_Enabled)
        Me.locks_groupbox.Controls.Add(Me.label_ExpirationDays)
        Me.locks_groupbox.Location = New Point(8, 360)
        Me.locks_groupbox.Name = "locks_groupbox"
        Me.locks_groupbox.Size = New Size(&H260, &HD8)
        Me.locks_groupbox.TabIndex = &H17
        Me.locks_groupbox.TabStop = False
        Me.locks_groupbox.Text = "Locks"
        Me.panel_devider.BorderStyle = BorderStyle.FixedSingle
        Me.panel_devider.Location = New Point(&H128, &H10)
        Me.panel_devider.Name = "panel_devider"
        Me.panel_devider.Size = New Size(1, &HC0)
        Me.panel_devider.TabIndex = &H18
        Me.label_Custom_Enabled.AutoSize = True
        Me.label_Custom_Enabled.Location = New Point(&H148, 120)
        Me.label_Custom_Enabled.Name = "label_Custom_Enabled"
        Me.label_Custom_Enabled.Size = New Size(&HB8, &H10)
        Me.label_Custom_Enabled.TabIndex = &H17
        Me.label_Custom_Enabled.Text = "CurrentLicense.Custom_Enabled = "
        Me.label_Custom_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_GlobalTime.AutoSize = True
        Me.label_GlobalTime.Location = New Point(&H158, 40)
        Me.label_GlobalTime.Name = "label_GlobalTime"
        Me.label_GlobalTime.Size = New Size(&H9B, &H10)
        Me.label_GlobalTime.TabIndex = &H15
        Me.label_GlobalTime.Text = "CurrentLicense.GlobalTime = "
        Me.label_GlobalTime.TextAlign = ContentAlignment.MiddleLeft
        Me.label_GlobalTime_Enabled.AutoSize = True
        Me.label_GlobalTime_Enabled.Location = New Point(&H148, &H18)
        Me.label_GlobalTime_Enabled.Name = "label_GlobalTime_Enabled"
        Me.label_GlobalTime_Enabled.Size = New Size(&HCB, &H10)
        Me.label_GlobalTime_Enabled.TabIndex = 20
        Me.label_GlobalTime_Enabled.Text = "CurrentLicense.GlobalTime_Enabled = "
        Me.label_GlobalTime_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_GlobalTime_Current.AutoSize = True
        Me.label_GlobalTime_Current.Location = New Point(&H158, &H38)
        Me.label_GlobalTime_Current.Name = "label_GlobalTime_Current"
        Me.label_GlobalTime_Current.Size = New Size(&HC7, &H10)
        Me.label_GlobalTime_Current.TabIndex = &H16
        Me.label_GlobalTime_Current.Text = "CurrentLicense.GlobalTime_Current = "
        Me.label_GlobalTime_Current.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Runtime_Enabled.AutoSize = True
        Me.label_Runtime_Enabled.Location = New Point(8, &HB0)
        Me.label_Runtime_Enabled.Name = "label_Runtime_Enabled"
        Me.label_Runtime_Enabled.Size = New Size(&HBB, &H10)
        Me.label_Runtime_Enabled.TabIndex = &H12
        Me.label_Runtime_Enabled.Text = "CurrentLicense.Runtime_Enabled = "
        Me.label_Runtime_Enabled.TextAlign = ContentAlignment.MiddleLeft
        Me.label_Runtime.AutoSize = True
        Me.label_Runtime.Location = New Point(&H18, &HC0)
        Me.label_Runtime.Name = "label_Runtime"
        Me.label_Runtime.Size = New Size(&H8B, &H10)
        Me.label_Runtime.TabIndex = &H13
        Me.label_Runtime.Text = "CurrentLicense.Runtime = "
        Me.label_Runtime.TextAlign = ContentAlignment.MiddleLeft
        Me.label_status_external_assembly.AutoSize = True
        Me.label_status_external_assembly.Location = New Point(&H18, &H40)
        Me.label_status_external_assembly.Name = "label_status_external_assembly"
        Me.label_status_external_assembly.Size = New Size(&H109, &H10)
        Me.label_status_external_assembly.TabIndex = &H18
        Me.label_status_external_assembly.Text = "CurrentLicense.LicenseStatus_ExternalAssembly = "
        Me.label_status_external_assembly.TextAlign = ContentAlignment.MiddleLeft
        Me.label_status_hdd.AutoSize = True
        Me.label_status_hdd.Location = New Point(&H18, 80)
        Me.label_status_hdd.Name = "label_status_hdd"
        Me.label_status_hdd.Size = New Size(&HC7, &H10)
        Me.label_status_hdd.TabIndex = &H19
        Me.label_status_hdd.Text = "CurrentLicense.LicenseStatus_HDD = "
        Me.label_status_hdd.TextAlign = ContentAlignment.MiddleLeft
        Me.label_license_location.AutoSize = True
        Me.label_license_location.Location = New Point(&H18, &H68)
        Me.label_license_location.Name = "label_license_location"
        Me.label_license_location.Size = New Size(&HB3, &H10)
        Me.label_license_location.TabIndex = &H1A
        Me.label_license_location.Text = "CurrentLicense.LicenseLocation = "
        Me.label_license_location.TextAlign = ContentAlignment.MiddleLeft
        Me.groupBox1.Controls.Add(Me.hid_textbox)
        Me.groupBox1.Controls.Add(Me.hid_mainboard)
        Me.groupBox1.Controls.Add(Me.hid_os)
        Me.groupBox1.Controls.Add(Me.hid_hdd)
        Me.groupBox1.Controls.Add(Me.hid_cpu)
        Me.groupBox1.Controls.Add(Me.hid_mac)
        Me.groupBox1.Controls.Add(Me.hid_bios)
        Me.groupBox1.Location = New Point(8, &H2E8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New Size(&H260, &H38)
        Me.groupBox1.TabIndex = &H1B
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Hardware ID"
        Me.hid_textbox.Location = New Point(&H170, &H18)
        Me.hid_textbox.Name = "hid_textbox"
        Me.hid_textbox.Size = New Size(&HE0, 20)
        Me.hid_textbox.TabIndex = 6
        Me.hid_textbox.Text = "####-####-####-####-####-####"
        Me.hid_mainboard.Location = New Point(&HE8, &H18)
        Me.hid_mainboard.Name = "hid_mainboard"
        Me.hid_mainboard.Size = New Size(80, &H18)
        Me.hid_mainboard.TabIndex = 5
        Me.hid_mainboard.Text = "Mainboard"
        AddHandler Me.hid_mainboard.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.hid_os.Location = New Point(&H138, &H18)
        Me.hid_os.Name = "hid_os"
        Me.hid_os.Size = New Size(40, &H18)
        Me.hid_os.TabIndex = 4
        Me.hid_os.Text = "OS"
        AddHandler Me.hid_os.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.hid_hdd.Location = New Point(120, &H18)
        Me.hid_hdd.Name = "hid_hdd"
        Me.hid_hdd.Size = New Size(&H30, &H18)
        Me.hid_hdd.TabIndex = 3
        Me.hid_hdd.Text = "HDD"
        AddHandler Me.hid_hdd.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.hid_cpu.Location = New Point(&H40, &H18)
        Me.hid_cpu.Name = "hid_cpu"
        Me.hid_cpu.Size = New Size(&H30, &H18)
        Me.hid_cpu.TabIndex = 2
        Me.hid_cpu.Text = "CPU"
        AddHandler Me.hid_cpu.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.hid_mac.Location = New Point(&HB0, &H18)
        Me.hid_mac.Name = "hid_mac"
        Me.hid_mac.Size = New Size(&H30, &H18)
        Me.hid_mac.TabIndex = 1
        Me.hid_mac.Text = "MAC"
        AddHandler Me.hid_mac.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.hid_bios.Location = New Point(8, &H18)
        Me.hid_bios.Name = "hid_bios"
        Me.hid_bios.Size = New Size(&H38, &H18)
        Me.hid_bios.TabIndex = 0
        Me.hid_bios.Text = "BIOS"
        AddHandler Me.hid_bios.CheckedChanged, New EventHandler(AddressOf Me.hid_item_checkedchanged)
        Me.mainMenu1.MenuItems.AddRange(New MenuItem() {Me.menuItem1})
        Me.menuItem1.Index = 0
        Me.menuItem1.MenuItems.AddRange(New MenuItem() {Me.menuItem2, Me.menuItem3})
        Me.menuItem1.Text = "Tasks"
        Me.menuItem2.Index = 0
        Me.menuItem2.Text = "Deactivate License"
        AddHandler Me.menuItem2.Click, New EventHandler(AddressOf Me.menuItem2_Click)
        Me.menuItem3.Index = 1
        Me.menuItem3.Text = "Reactivate License"
        Me.AutoScaleBaseSize = New Size(5, 13)
        MyBase.ClientSize = New Size(&H278, &H32D)
        MyBase.Controls.Add(Me.groupBox1)
        MyBase.Controls.Add(Me.label_license_location)
        MyBase.Controls.Add(Me.label_status_hdd)
        MyBase.Controls.Add(Me.listView1)
        MyBase.Controls.Add(Me.locks_groupbox)
        MyBase.Controls.Add(Me.manager_groupbox)
        MyBase.Controls.Add(Me.label_ValidLicenseAvailable)
        MyBase.Controls.Add(Me.button1)
        MyBase.Controls.Add(Me.label9)
        MyBase.Controls.Add(Me.label_status_external_assembly)
        MyBase.Menu = Me.mainMenu1
        MyBase.Name = "Form1"
        Me.Text = "License Status Checker"
        Me.manager_groupbox.ResumeLayout(False)
        Me.locks_groupbox.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        MyBase.ResumeLayout(False)
    End Sub
#End Region

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.UpdateSettings()
    End Sub

    Private Sub hid_item_checkedchanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.DisplayHardwareID()
    End Sub

    Public Sub DisplayHardwareID()
        Me.hid_textbox.Text = IntelliLock.Licensing.HardwareID.GetHardwareID(Me.hid_cpu.Checked, Me.hid_hdd.Checked, Me.hid_mac.Checked, Me.hid_mainboard.Checked, Me.hid_bios.Checked, Me.hid_os.Checked)
    End Sub

    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim data As String = IntelliLock.Licensing.License_DeActivator.DeactivateLicense
        If (data.Length > 0) Then
            Clipboard.SetDataObject(data, True)
            MessageBox.Show(("Deactivation Code: " & data), "License Deactivated!")
        End If
    End Sub

    Public Sub UpdateSettings()
        Me.label_ValidLicenseAvailable.Text = ("CurrentLicense.LicenseStatus = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString)
        Me.label_status_external_assembly.Text = ("CurrentLicense.LicenseStatus_ExternalAssembly = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_ExternalAssembly.ToString)
        Me.label_status_hdd.Text = ("CurrentLicense.LicenseStatus_HDD = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_HDD.ToString)
        Me.label_license_location.Text = ("CurrentLicense.LicenseLocation = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseLocation.ToString)
        Me.label_LicenseServer_Enabled.Text = ("CurrentLicense.RequireLicenseServerValidation = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.RequireLicenseServerValidation.ToString)
        Me.label_LicenseServer.Text = ("CurrentLicense.LicenseServer = """ & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseServer & """")
        Me.label_HardwareLock_Enabled.Text = ("CurrentLicense.HardwareLock_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_Enabled.ToString)
        Me.label_HardwareLock_Bios.Text = ("CurrentLicense.HardwareLock_BIOS = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_BIOS.ToString)
        Me.label_HardwareLock_OS.Text = ("CurrentLicense.HardwareLock_OS = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_OS.ToString)
        Me.label_HardwareLock_CPU.Text = ("CurrentLicense.HardwareLock_CPU = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_CPU.ToString)
        Me.label_HardwareLock_HDD.Text = ("CurrentLicense.HardwareLock_HDD = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_HDD.ToString)
        Me.label_HardwareLock_MAC.Text = ("CurrentLicense.HardwareLock_MAC = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_MAC.ToString)
        Me.label_HardwareLock_Mainboard.Text = ("CurrentLicense.HardwareLock_Mainboard = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_Mainboard.ToString)
        Me.label_LicenseLocks_Enabled.Text = ("CurrentLicense.TrialRestricted = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.TrialRestricted.ToString)
        Me.label_LicenseHardwareID.Text = ("CurrentLicense.HardwareID = """ & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareID & """")
        Me.label_ExpirationDays.Text = ("CurrentLicense.ExpirationDays = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays.ToString)
        Me.label_ExpirationDays_Current.Text = ("CurrentLicense.ExpirationDays_Current = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Current.ToString)
        Me.label_ExpirationDays_Enabled.Text = ("CurrentLicense.ExpirationDays_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Enabled.ToString)
        Me.label_ExpirationDate.Text = ("CurrentLicense.ExpirationDate = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate.ToString)
        Me.label_ExpirationDate_Enabled.Text = ("CurrentLicense.ExpirationDate_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate_Enabled.ToString)
        Me.label_Executions.Text = ("CurrentLicense.Executions = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions.ToString)
        Me.label_Executions_Current.Text = ("CurrentLicense.Executions_Current = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Current.ToString)
        Me.label_Executions_Enabled.Text = ("CurrentLicense.Executions_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Enabled.ToString)
        Me.label_Runtime.Text = ("CurrentLicense.Runtime = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime.ToString)
        Me.label_Runtime_Enabled.Text = ("CurrentLicense.Runtime_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime_Enabled.ToString)
        Me.label_GlobalTime.Text = ("CurrentLicense.GlobalTime = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime.ToString)
        Me.label_GlobalTime_Current.Text = ("CurrentLicense.GlobalTime_Current = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Current.ToString)
        Me.label_GlobalTime_Enabled.Text = ("CurrentLicense.GlobalTime_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Enabled.ToString)
        Me.label_Instances.Text = ("CurrentLicense.Instances = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Instances.ToString)
        Me.label_Instances_Enabled.Text = ("CurrentLicense.Instances_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Instances_Enabled.ToString)
        Me.label_Custom_Enabled.Text = ("CurrentLicense.Custom_Enabled = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Custom_Enabled.ToString)
        Me.listView1.Items.Clear()
        If ((IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus = IntelliLock.Licensing.LicenseStatus.EvaluationMode) OrElse (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus = IntelliLock.Licensing.LicenseStatus.Licensed)) Then
            Dim i As Integer
            For i = 0 To IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.Count - 1
                Me.listView1.Items.Add(New ListViewItem(New String() {IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetKey(i).ToString, IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetByIndex(i).ToString}))
            Next i
        End If
    End Sub


    ' Fields
    Private button1 As Button
    Private columnHeader1 As ColumnHeader
    Private columnHeader2 As ColumnHeader
    Private components As System.ComponentModel.IContainer = Nothing
    Private groupBox1 As GroupBox
    Private hid_bios As CheckBox
    Private hid_cpu As CheckBox
    Private hid_hdd As CheckBox
    Private hid_mac As CheckBox
    Private hid_mainboard As CheckBox
    Private hid_os As CheckBox
    Private hid_textbox As TextBox
    Private label_Custom_Enabled As Label
    Private label_Executions As Label
    Private label_Executions_Current As Label
    Private label_Executions_Enabled As Label
    Private label_ExpirationDate As Label
    Private label_ExpirationDate_Enabled As Label
    Private label_ExpirationDays As Label
    Private label_ExpirationDays_Current As Label
    Private label_ExpirationDays_Enabled As Label
    Private label_GlobalTime As Label
    Private label_GlobalTime_Current As Label
    Private label_GlobalTime_Enabled As Label
    Private label_HardwareLock_Bios As Label
    Private label_HardwareLock_CPU As Label
    Private label_HardwareLock_Enabled As Label
    Private label_HardwareLock_HDD As Label
    Private label_HardwareLock_MAC As Label
    Private label_HardwareLock_Mainboard As Label
    Private label_HardwareLock_OS As Label
    Private label_Instances As Label
    Private label_Instances_Enabled As Label
    Private label_license_location As Label
    Private label_LicenseHardwareID As Label
    Private label_LicenseLocks_Enabled As Label
    Private label_LicenseServer As Label
    Private label_LicenseServer_Enabled As Label
    Private label_Runtime As Label
    Private label_Runtime_Enabled As Label
    Private label_status_external_assembly As Label
    Private label_status_hdd As Label
    Private label_ValidLicenseAvailable As Label
    Private label9 As Label
    Private listView1 As ListView
    Private locks_groupbox As GroupBox
    Private mainMenu1 As MainMenu
    Private manager_groupbox As GroupBox
    Private menuItem1 As MenuItem
    Private menuItem2 As MenuItem
    Private menuItem3 As MenuItem
    Private panel_devider As Panel
End Class
