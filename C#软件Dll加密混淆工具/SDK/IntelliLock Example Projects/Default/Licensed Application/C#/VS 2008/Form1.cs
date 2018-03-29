using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using IntelliLock.Licensing;

namespace SDK_TestApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label_ValidLicenseAvailable;
		private System.Windows.Forms.Label label_ExpirationDays_Enabled;
		private System.Windows.Forms.Label label_ExpirationDays;
		private System.Windows.Forms.Label label_ExpirationDays_Current;
		private System.Windows.Forms.Label label_ExpirationDate_Enabled;
		private System.Windows.Forms.Label label_ExpirationDate;
		private System.Windows.Forms.Label label_Executions;
		private System.Windows.Forms.Label label_Executions_Enabled;
		private System.Windows.Forms.Label label_Executions_Current;
		private System.Windows.Forms.Label label_Instances_Enabled;
		private System.Windows.Forms.Label label_Instances;
		private System.Windows.Forms.Label label_LicenseServer_Enabled;
		private System.Windows.Forms.Label label_LicenseServer;
		private System.Windows.Forms.Label label_HardwareLock_Enabled;
		private System.Windows.Forms.Label label_LicenseHardwareID;
		private System.Windows.Forms.Label label_HardwareLock_CPU;
		private System.Windows.Forms.Label label_HardwareLock_HDD;
		private System.Windows.Forms.Label label_HardwareLock_MAC;
		private System.Windows.Forms.Label label_HardwareLock_Mainboard;
		private System.Windows.Forms.Label label_Runtime_Enabled;
		private System.Windows.Forms.Label label_Runtime;
		private System.Windows.Forms.Label label_GlobalTime;
		private System.Windows.Forms.Label label_GlobalTime_Enabled;
		private System.Windows.Forms.Label label_GlobalTime_Current;
		private System.Windows.Forms.Label label_Custom_Enabled;
		private System.Windows.Forms.Label label_LicenseLocks_Enabled;
		private System.Windows.Forms.GroupBox manager_groupbox;
		private System.Windows.Forms.GroupBox locks_groupbox;
		private System.Windows.Forms.Panel panel_devider;
		private System.Windows.Forms.Label label_HardwareLock_OS;
		private System.Windows.Forms.Label label_HardwareLock_Bios;
		private System.Windows.Forms.Label label_status_external_assembly;
		private System.Windows.Forms.Label label_status_hdd;
		private System.Windows.Forms.Label label_license_location;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox hid_bios;
		private System.Windows.Forms.CheckBox hid_mac;
		private System.Windows.Forms.CheckBox hid_cpu;
		private System.Windows.Forms.CheckBox hid_hdd;
		private System.Windows.Forms.CheckBox hid_os;
		private System.Windows.Forms.CheckBox hid_mainboard;
		private System.Windows.Forms.TextBox hid_textbox;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DisplayHardwareID();	

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label_ValidLicenseAvailable = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.label_ExpirationDays_Enabled = new System.Windows.Forms.Label();
			this.label_ExpirationDays = new System.Windows.Forms.Label();
			this.label_ExpirationDays_Current = new System.Windows.Forms.Label();
			this.label_ExpirationDate_Enabled = new System.Windows.Forms.Label();
			this.label_ExpirationDate = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label_Executions = new System.Windows.Forms.Label();
			this.label_Executions_Enabled = new System.Windows.Forms.Label();
			this.label_Executions_Current = new System.Windows.Forms.Label();
			this.label_Instances_Enabled = new System.Windows.Forms.Label();
			this.label_Instances = new System.Windows.Forms.Label();
			this.label_LicenseServer_Enabled = new System.Windows.Forms.Label();
			this.label_LicenseServer = new System.Windows.Forms.Label();
			this.manager_groupbox = new System.Windows.Forms.GroupBox();
			this.label_HardwareLock_Bios = new System.Windows.Forms.Label();
			this.label_HardwareLock_OS = new System.Windows.Forms.Label();
			this.label_HardwareLock_Mainboard = new System.Windows.Forms.Label();
			this.label_HardwareLock_MAC = new System.Windows.Forms.Label();
			this.label_HardwareLock_HDD = new System.Windows.Forms.Label();
			this.label_HardwareLock_CPU = new System.Windows.Forms.Label();
			this.label_LicenseHardwareID = new System.Windows.Forms.Label();
			this.label_HardwareLock_Enabled = new System.Windows.Forms.Label();
			this.label_LicenseLocks_Enabled = new System.Windows.Forms.Label();
			this.locks_groupbox = new System.Windows.Forms.GroupBox();
			this.panel_devider = new System.Windows.Forms.Panel();
			this.label_Custom_Enabled = new System.Windows.Forms.Label();
			this.label_GlobalTime = new System.Windows.Forms.Label();
			this.label_GlobalTime_Enabled = new System.Windows.Forms.Label();
			this.label_GlobalTime_Current = new System.Windows.Forms.Label();
			this.label_Runtime_Enabled = new System.Windows.Forms.Label();
			this.label_Runtime = new System.Windows.Forms.Label();
			this.label_status_external_assembly = new System.Windows.Forms.Label();
			this.label_status_hdd = new System.Windows.Forms.Label();
			this.label_license_location = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.hid_textbox = new System.Windows.Forms.TextBox();
			this.hid_mainboard = new System.Windows.Forms.CheckBox();
			this.hid_os = new System.Windows.Forms.CheckBox();
			this.hid_hdd = new System.Windows.Forms.CheckBox();
			this.hid_cpu = new System.Windows.Forms.CheckBox();
			this.hid_mac = new System.Windows.Forms.CheckBox();
			this.hid_bios = new System.Windows.Forms.CheckBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.manager_groupbox.SuspendLayout();
			this.locks_groupbox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(248, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Check License";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label_ValidLicenseAvailable
			// 
			this.label_ValidLicenseAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label_ValidLicenseAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label_ValidLicenseAvailable.Location = new System.Drawing.Point(8, 48);
			this.label_ValidLicenseAvailable.Name = "label_ValidLicenseAvailable";
			this.label_ValidLicenseAvailable.Size = new System.Drawing.Size(616, 16);
			this.label_ValidLicenseAvailable.TabIndex = 1;
			this.label_ValidLicenseAvailable.Text = "CurrentLicense.LicenseStatus = ";
			this.label_ValidLicenseAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.Location = new System.Drawing.Point(8, 600);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(608, 136);
			this.listView1.TabIndex = 2;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Key";
			this.columnHeader1.Width = 148;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 439;
			// 
			// label_ExpirationDays_Enabled
			// 
			this.label_ExpirationDays_Enabled.AutoSize = true;
			this.label_ExpirationDays_Enabled.Location = new System.Drawing.Point(8, 24);
			this.label_ExpirationDays_Enabled.Name = "label_ExpirationDays_Enabled";
			this.label_ExpirationDays_Enabled.Size = new System.Drawing.Size(218, 16);
			this.label_ExpirationDays_Enabled.TabIndex = 3;
			this.label_ExpirationDays_Enabled.Text = "CurrentLicense.ExpirationDays_Enabled =";
			this.label_ExpirationDays_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_ExpirationDays
			// 
			this.label_ExpirationDays.AutoSize = true;
			this.label_ExpirationDays.Location = new System.Drawing.Point(24, 40);
			this.label_ExpirationDays.Name = "label_ExpirationDays";
			this.label_ExpirationDays.Size = new System.Drawing.Size(173, 16);
			this.label_ExpirationDays.TabIndex = 4;
			this.label_ExpirationDays.Text = "CurrentLicense.ExpirationDays = ";
			this.label_ExpirationDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_ExpirationDays_Current
			// 
			this.label_ExpirationDays_Current.AutoSize = true;
			this.label_ExpirationDays_Current.Location = new System.Drawing.Point(24, 56);
			this.label_ExpirationDays_Current.Name = "label_ExpirationDays_Current";
			this.label_ExpirationDays_Current.Size = new System.Drawing.Size(217, 16);
			this.label_ExpirationDays_Current.TabIndex = 5;
			this.label_ExpirationDays_Current.Text = "CurrentLicense.ExpirationDays_Current = ";
			this.label_ExpirationDays_Current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_ExpirationDate_Enabled
			// 
			this.label_ExpirationDate_Enabled.AutoSize = true;
			this.label_ExpirationDate_Enabled.Location = new System.Drawing.Point(8, 80);
			this.label_ExpirationDate_Enabled.Name = "label_ExpirationDate_Enabled";
			this.label_ExpirationDate_Enabled.Size = new System.Drawing.Size(219, 16);
			this.label_ExpirationDate_Enabled.TabIndex = 8;
			this.label_ExpirationDate_Enabled.Text = "CurrentLicense.ExpirationDate_Enabled = ";
			this.label_ExpirationDate_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_ExpirationDate
			// 
			this.label_ExpirationDate.AutoSize = true;
			this.label_ExpirationDate.Location = new System.Drawing.Point(24, 96);
			this.label_ExpirationDate.Name = "label_ExpirationDate";
			this.label_ExpirationDate.Size = new System.Drawing.Size(171, 16);
			this.label_ExpirationDate.TabIndex = 9;
			this.label_ExpirationDate.Text = "CurrentLicense.ExpirationDate = ";
			this.label_ExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(8, 584);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(400, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "License Information:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Executions
			// 
			this.label_Executions.AutoSize = true;
			this.label_Executions.Location = new System.Drawing.Point(24, 136);
			this.label_Executions.Name = "label_Executions";
			this.label_Executions.Size = new System.Drawing.Size(152, 16);
			this.label_Executions.TabIndex = 13;
			this.label_Executions.Text = "CurrentLicense.Executions = ";
			this.label_Executions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Executions_Enabled
			// 
			this.label_Executions_Enabled.AutoSize = true;
			this.label_Executions_Enabled.Location = new System.Drawing.Point(8, 120);
			this.label_Executions_Enabled.Name = "label_Executions_Enabled";
			this.label_Executions_Enabled.Size = new System.Drawing.Size(200, 16);
			this.label_Executions_Enabled.TabIndex = 12;
			this.label_Executions_Enabled.Text = "CurrentLicense.Executions_Enabled = ";
			this.label_Executions_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Executions_Current
			// 
			this.label_Executions_Current.AutoSize = true;
			this.label_Executions_Current.Location = new System.Drawing.Point(24, 152);
			this.label_Executions_Current.Name = "label_Executions_Current";
			this.label_Executions_Current.Size = new System.Drawing.Size(196, 16);
			this.label_Executions_Current.TabIndex = 14;
			this.label_Executions_Current.Text = "CurrentLicense.Executions_Current = ";
			this.label_Executions_Current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Instances_Enabled
			// 
			this.label_Instances_Enabled.AutoSize = true;
			this.label_Instances_Enabled.Location = new System.Drawing.Point(328, 80);
			this.label_Instances_Enabled.Name = "label_Instances_Enabled";
			this.label_Instances_Enabled.Size = new System.Drawing.Size(193, 16);
			this.label_Instances_Enabled.TabIndex = 16;
			this.label_Instances_Enabled.Text = "CurrentLicense.Instances_Enabled = ";
			this.label_Instances_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Instances
			// 
			this.label_Instances.AutoSize = true;
			this.label_Instances.Location = new System.Drawing.Point(344, 96);
			this.label_Instances.Name = "label_Instances";
			this.label_Instances.Size = new System.Drawing.Size(145, 16);
			this.label_Instances.TabIndex = 17;
			this.label_Instances.Text = "CurrentLicense.Instances = ";
			this.label_Instances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_LicenseServer_Enabled
			// 
			this.label_LicenseServer_Enabled.AutoSize = true;
			this.label_LicenseServer_Enabled.Location = new System.Drawing.Point(8, 24);
			this.label_LicenseServer_Enabled.Name = "label_LicenseServer_Enabled";
			this.label_LicenseServer_Enabled.Size = new System.Drawing.Size(256, 16);
			this.label_LicenseServer_Enabled.TabIndex = 18;
			this.label_LicenseServer_Enabled.Text = "CurrentLicense.RequireLicenseServerValidation =";
			this.label_LicenseServer_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_LicenseServer
			// 
			this.label_LicenseServer.AutoSize = true;
			this.label_LicenseServer.Location = new System.Drawing.Point(24, 40);
			this.label_LicenseServer.Name = "label_LicenseServer";
			this.label_LicenseServer.Size = new System.Drawing.Size(166, 16);
			this.label_LicenseServer.TabIndex = 19;
			this.label_LicenseServer.Text = "CurrentLicense.LicenseServer =";
			this.label_LicenseServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// manager_groupbox
			// 
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_Bios);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_OS);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_Mainboard);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_MAC);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_HDD);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_CPU);
			this.manager_groupbox.Controls.Add(this.label_LicenseHardwareID);
			this.manager_groupbox.Controls.Add(this.label_HardwareLock_Enabled);
			this.manager_groupbox.Controls.Add(this.label_LicenseServer);
			this.manager_groupbox.Controls.Add(this.label_LicenseServer_Enabled);
			this.manager_groupbox.Controls.Add(this.label_LicenseLocks_Enabled);
			this.manager_groupbox.Location = new System.Drawing.Point(8, 128);
			this.manager_groupbox.Name = "manager_groupbox";
			this.manager_groupbox.Size = new System.Drawing.Size(608, 224);
			this.manager_groupbox.TabIndex = 22;
			this.manager_groupbox.TabStop = false;
			this.manager_groupbox.Text = "License Settings";
			// 
			// label_HardwareLock_Bios
			// 
			this.label_HardwareLock_Bios.AutoSize = true;
			this.label_HardwareLock_Bios.Location = new System.Drawing.Point(24, 96);
			this.label_HardwareLock_Bios.Name = "label_HardwareLock_Bios";
			this.label_HardwareLock_Bios.Size = new System.Drawing.Size(200, 16);
			this.label_HardwareLock_Bios.TabIndex = 29;
			this.label_HardwareLock_Bios.Text = "CurrentLicense.HardwareLock_BIOS =";
			this.label_HardwareLock_Bios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_OS
			// 
			this.label_HardwareLock_OS.AutoSize = true;
			this.label_HardwareLock_OS.Location = new System.Drawing.Point(24, 176);
			this.label_HardwareLock_OS.Name = "label_HardwareLock_OS";
			this.label_HardwareLock_OS.Size = new System.Drawing.Size(189, 16);
			this.label_HardwareLock_OS.TabIndex = 28;
			this.label_HardwareLock_OS.Text = "CurrentLicense.HardwareLock_OS =";
			this.label_HardwareLock_OS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_Mainboard
			// 
			this.label_HardwareLock_Mainboard.AutoSize = true;
			this.label_HardwareLock_Mainboard.Location = new System.Drawing.Point(24, 160);
			this.label_HardwareLock_Mainboard.Name = "label_HardwareLock_Mainboard";
			this.label_HardwareLock_Mainboard.Size = new System.Drawing.Size(227, 16);
			this.label_HardwareLock_Mainboard.TabIndex = 27;
			this.label_HardwareLock_Mainboard.Text = "CurrentLicense.HardwareLock_Mainboard =";
			this.label_HardwareLock_Mainboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_MAC
			// 
			this.label_HardwareLock_MAC.AutoSize = true;
			this.label_HardwareLock_MAC.Location = new System.Drawing.Point(24, 144);
			this.label_HardwareLock_MAC.Name = "label_HardwareLock_MAC";
			this.label_HardwareLock_MAC.Size = new System.Drawing.Size(198, 16);
			this.label_HardwareLock_MAC.TabIndex = 26;
			this.label_HardwareLock_MAC.Text = "CurrentLicense.HardwareLock_MAC =";
			this.label_HardwareLock_MAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_HDD
			// 
			this.label_HardwareLock_HDD.AutoSize = true;
			this.label_HardwareLock_HDD.Location = new System.Drawing.Point(24, 128);
			this.label_HardwareLock_HDD.Name = "label_HardwareLock_HDD";
			this.label_HardwareLock_HDD.Size = new System.Drawing.Size(198, 16);
			this.label_HardwareLock_HDD.TabIndex = 25;
			this.label_HardwareLock_HDD.Text = "CurrentLicense.HardwareLock_HDD =";
			this.label_HardwareLock_HDD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_CPU
			// 
			this.label_HardwareLock_CPU.AutoSize = true;
			this.label_HardwareLock_CPU.Location = new System.Drawing.Point(24, 112);
			this.label_HardwareLock_CPU.Name = "label_HardwareLock_CPU";
			this.label_HardwareLock_CPU.Size = new System.Drawing.Size(197, 16);
			this.label_HardwareLock_CPU.TabIndex = 24;
			this.label_HardwareLock_CPU.Text = "CurrentLicense.HardwareLock_CPU =";
			this.label_HardwareLock_CPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_LicenseHardwareID
			// 
			this.label_LicenseHardwareID.AutoSize = true;
			this.label_LicenseHardwareID.Location = new System.Drawing.Point(24, 80);
			this.label_LicenseHardwareID.Name = "label_LicenseHardwareID";
			this.label_LicenseHardwareID.Size = new System.Drawing.Size(154, 16);
			this.label_LicenseHardwareID.TabIndex = 23;
			this.label_LicenseHardwareID.Text = "CurrentLicense.HardwareID =";
			this.label_LicenseHardwareID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_HardwareLock_Enabled
			// 
			this.label_HardwareLock_Enabled.AutoSize = true;
			this.label_HardwareLock_Enabled.Location = new System.Drawing.Point(8, 64);
			this.label_HardwareLock_Enabled.Name = "label_HardwareLock_Enabled";
			this.label_HardwareLock_Enabled.Size = new System.Drawing.Size(215, 16);
			this.label_HardwareLock_Enabled.TabIndex = 22;
			this.label_HardwareLock_Enabled.Text = "CurrentLicense.HardwareLock_Enabled =";
			this.label_HardwareLock_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_LicenseLocks_Enabled
			// 
			this.label_LicenseLocks_Enabled.AutoSize = true;
			this.label_LicenseLocks_Enabled.Location = new System.Drawing.Point(8, 200);
			this.label_LicenseLocks_Enabled.Name = "label_LicenseLocks_Enabled";
			this.label_LicenseLocks_Enabled.Size = new System.Drawing.Size(167, 16);
			this.label_LicenseLocks_Enabled.TabIndex = 24;
			this.label_LicenseLocks_Enabled.Text = "CurrentLicense.TrialRestricted =";
			this.label_LicenseLocks_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// locks_groupbox
			// 
			this.locks_groupbox.Controls.Add(this.panel_devider);
			this.locks_groupbox.Controls.Add(this.label_Custom_Enabled);
			this.locks_groupbox.Controls.Add(this.label_GlobalTime);
			this.locks_groupbox.Controls.Add(this.label_GlobalTime_Enabled);
			this.locks_groupbox.Controls.Add(this.label_GlobalTime_Current);
			this.locks_groupbox.Controls.Add(this.label_Runtime_Enabled);
			this.locks_groupbox.Controls.Add(this.label_Runtime);
			this.locks_groupbox.Controls.Add(this.label_ExpirationDays_Current);
			this.locks_groupbox.Controls.Add(this.label_ExpirationDate_Enabled);
			this.locks_groupbox.Controls.Add(this.label_ExpirationDate);
			this.locks_groupbox.Controls.Add(this.label_Executions);
			this.locks_groupbox.Controls.Add(this.label_Executions_Enabled);
			this.locks_groupbox.Controls.Add(this.label_Instances);
			this.locks_groupbox.Controls.Add(this.label_Executions_Current);
			this.locks_groupbox.Controls.Add(this.label_Instances_Enabled);
			this.locks_groupbox.Controls.Add(this.label_ExpirationDays_Enabled);
			this.locks_groupbox.Controls.Add(this.label_ExpirationDays);
			this.locks_groupbox.Location = new System.Drawing.Point(8, 360);
			this.locks_groupbox.Name = "locks_groupbox";
			this.locks_groupbox.Size = new System.Drawing.Size(608, 216);
			this.locks_groupbox.TabIndex = 23;
			this.locks_groupbox.TabStop = false;
			this.locks_groupbox.Text = "Locks";
			// 
			// panel_devider
			// 
			this.panel_devider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_devider.Location = new System.Drawing.Point(296, 16);
			this.panel_devider.Name = "panel_devider";
			this.panel_devider.Size = new System.Drawing.Size(1, 192);
			this.panel_devider.TabIndex = 24;
			// 
			// label_Custom_Enabled
			// 
			this.label_Custom_Enabled.AutoSize = true;
			this.label_Custom_Enabled.Location = new System.Drawing.Point(328, 120);
			this.label_Custom_Enabled.Name = "label_Custom_Enabled";
			this.label_Custom_Enabled.Size = new System.Drawing.Size(184, 16);
			this.label_Custom_Enabled.TabIndex = 23;
			this.label_Custom_Enabled.Text = "CurrentLicense.Custom_Enabled = ";
			this.label_Custom_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_GlobalTime
			// 
			this.label_GlobalTime.AutoSize = true;
			this.label_GlobalTime.Location = new System.Drawing.Point(344, 40);
			this.label_GlobalTime.Name = "label_GlobalTime";
			this.label_GlobalTime.Size = new System.Drawing.Size(155, 16);
			this.label_GlobalTime.TabIndex = 21;
			this.label_GlobalTime.Text = "CurrentLicense.GlobalTime = ";
			this.label_GlobalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_GlobalTime_Enabled
			// 
			this.label_GlobalTime_Enabled.AutoSize = true;
			this.label_GlobalTime_Enabled.Location = new System.Drawing.Point(328, 24);
			this.label_GlobalTime_Enabled.Name = "label_GlobalTime_Enabled";
			this.label_GlobalTime_Enabled.Size = new System.Drawing.Size(203, 16);
			this.label_GlobalTime_Enabled.TabIndex = 20;
			this.label_GlobalTime_Enabled.Text = "CurrentLicense.GlobalTime_Enabled = ";
			this.label_GlobalTime_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_GlobalTime_Current
			// 
			this.label_GlobalTime_Current.AutoSize = true;
			this.label_GlobalTime_Current.Location = new System.Drawing.Point(344, 56);
			this.label_GlobalTime_Current.Name = "label_GlobalTime_Current";
			this.label_GlobalTime_Current.Size = new System.Drawing.Size(199, 16);
			this.label_GlobalTime_Current.TabIndex = 22;
			this.label_GlobalTime_Current.Text = "CurrentLicense.GlobalTime_Current = ";
			this.label_GlobalTime_Current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Runtime_Enabled
			// 
			this.label_Runtime_Enabled.AutoSize = true;
			this.label_Runtime_Enabled.Location = new System.Drawing.Point(8, 176);
			this.label_Runtime_Enabled.Name = "label_Runtime_Enabled";
			this.label_Runtime_Enabled.Size = new System.Drawing.Size(187, 16);
			this.label_Runtime_Enabled.TabIndex = 18;
			this.label_Runtime_Enabled.Text = "CurrentLicense.Runtime_Enabled = ";
			this.label_Runtime_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_Runtime
			// 
			this.label_Runtime.AutoSize = true;
			this.label_Runtime.Location = new System.Drawing.Point(24, 192);
			this.label_Runtime.Name = "label_Runtime";
			this.label_Runtime.Size = new System.Drawing.Size(139, 16);
			this.label_Runtime.TabIndex = 19;
			this.label_Runtime.Text = "CurrentLicense.Runtime = ";
			this.label_Runtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_status_external_assembly
			// 
			this.label_status_external_assembly.AutoSize = true;
			this.label_status_external_assembly.Location = new System.Drawing.Point(24, 64);
			this.label_status_external_assembly.Name = "label_status_external_assembly";
			this.label_status_external_assembly.Size = new System.Drawing.Size(265, 16);
			this.label_status_external_assembly.TabIndex = 24;
			this.label_status_external_assembly.Text = "CurrentLicense.LicenseStatus_ExternalAssembly = ";
			this.label_status_external_assembly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_status_hdd
			// 
			this.label_status_hdd.AutoSize = true;
			this.label_status_hdd.Location = new System.Drawing.Point(24, 80);
			this.label_status_hdd.Name = "label_status_hdd";
			this.label_status_hdd.Size = new System.Drawing.Size(199, 16);
			this.label_status_hdd.TabIndex = 25;
			this.label_status_hdd.Text = "CurrentLicense.LicenseStatus_HDD = ";
			this.label_status_hdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_license_location
			// 
			this.label_license_location.AutoSize = true;
			this.label_license_location.Location = new System.Drawing.Point(24, 104);
			this.label_license_location.Name = "label_license_location";
			this.label_license_location.Size = new System.Drawing.Size(179, 16);
			this.label_license_location.TabIndex = 26;
			this.label_license_location.Text = "CurrentLicense.LicenseLocation = ";
			this.label_license_location.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.hid_textbox);
			this.groupBox1.Controls.Add(this.hid_mainboard);
			this.groupBox1.Controls.Add(this.hid_os);
			this.groupBox1.Controls.Add(this.hid_hdd);
			this.groupBox1.Controls.Add(this.hid_cpu);
			this.groupBox1.Controls.Add(this.hid_mac);
			this.groupBox1.Controls.Add(this.hid_bios);
			this.groupBox1.Location = new System.Drawing.Point(8, 744);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(608, 56);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Hardware ID";
			// 
			// hid_textbox
			// 
			this.hid_textbox.Location = new System.Drawing.Point(368, 24);
			this.hid_textbox.Name = "hid_textbox";
			this.hid_textbox.Size = new System.Drawing.Size(224, 20);
			this.hid_textbox.TabIndex = 6;
			this.hid_textbox.Text = "####-####-####-####-####-####";
			// 
			// hid_mainboard
			// 
			this.hid_mainboard.Location = new System.Drawing.Point(232, 24);
			this.hid_mainboard.Name = "hid_mainboard";
			this.hid_mainboard.Size = new System.Drawing.Size(80, 24);
			this.hid_mainboard.TabIndex = 5;
			this.hid_mainboard.Text = "Mainboard";
			this.hid_mainboard.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// hid_os
			// 
			this.hid_os.Location = new System.Drawing.Point(312, 24);
			this.hid_os.Name = "hid_os";
			this.hid_os.Size = new System.Drawing.Size(40, 24);
			this.hid_os.TabIndex = 4;
			this.hid_os.Text = "OS";
			this.hid_os.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// hid_hdd
			// 
			this.hid_hdd.Location = new System.Drawing.Point(120, 24);
			this.hid_hdd.Name = "hid_hdd";
			this.hid_hdd.Size = new System.Drawing.Size(48, 24);
			this.hid_hdd.TabIndex = 3;
			this.hid_hdd.Text = "HDD";
			this.hid_hdd.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// hid_cpu
			// 
			this.hid_cpu.Location = new System.Drawing.Point(64, 24);
			this.hid_cpu.Name = "hid_cpu";
			this.hid_cpu.Size = new System.Drawing.Size(48, 24);
			this.hid_cpu.TabIndex = 2;
			this.hid_cpu.Text = "CPU";
			this.hid_cpu.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// hid_mac
			// 
			this.hid_mac.Location = new System.Drawing.Point(176, 24);
			this.hid_mac.Name = "hid_mac";
			this.hid_mac.Size = new System.Drawing.Size(48, 24);
			this.hid_mac.TabIndex = 1;
			this.hid_mac.Text = "MAC";
			this.hid_mac.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// hid_bios
			// 
			this.hid_bios.Location = new System.Drawing.Point(8, 24);
			this.hid_bios.Name = "hid_bios";
			this.hid_bios.Size = new System.Drawing.Size(56, 24);
			this.hid_bios.TabIndex = 0;
			this.hid_bios.Text = "BIOS";
			this.hid_bios.CheckedChanged += new System.EventHandler(this.hid_item_checkedchanged);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "Tasks";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Deactivate License";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Reactivate License";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 813);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label_license_location);
			this.Controls.Add(this.label_status_hdd);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.locks_groupbox);
			this.Controls.Add(this.manager_groupbox);
			this.Controls.Add(this.label_ValidLicenseAvailable);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label_status_external_assembly);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "License Status Checker";
			this.manager_groupbox.ResumeLayout(false);
			this.locks_groupbox.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			UpdateSettings();	
		}

		public void UpdateSettings()
		{
			this.label_ValidLicenseAvailable.Text = "CurrentLicense.LicenseStatus = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString();
			this.label_status_external_assembly.Text = "CurrentLicense.LicenseStatus_ExternalAssembly = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_ExternalAssembly.ToString();
			this.label_status_hdd.Text = "CurrentLicense.LicenseStatus_HDD = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_HDD.ToString();
			this.label_license_location.Text = "CurrentLicense.LicenseLocation = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseLocation.ToString();
			this.label_LicenseServer_Enabled.Text = "CurrentLicense.RequireLicenseServerValidation = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.RequireLicenseServerValidation.ToString();
			this.label_LicenseServer.Text = "CurrentLicense.LicenseServer = \"" + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseServer+"\"";
			this.label_HardwareLock_Enabled.Text = "CurrentLicense.HardwareLock_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_Enabled.ToString();
			this.label_HardwareLock_Bios.Text = "CurrentLicense.HardwareLock_BIOS = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_BIOS.ToString();
			this.label_HardwareLock_OS.Text = "CurrentLicense.HardwareLock_OS = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_OS.ToString();	
			this.label_HardwareLock_CPU.Text = "CurrentLicense.HardwareLock_CPU = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_CPU.ToString();
			this.label_HardwareLock_HDD.Text = "CurrentLicense.HardwareLock_HDD = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_HDD.ToString();
			this.label_HardwareLock_MAC.Text = "CurrentLicense.HardwareLock_MAC = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_MAC.ToString();
			this.label_HardwareLock_Mainboard.Text = "CurrentLicense.HardwareLock_Mainboard = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareLock_Mainboard.ToString();
			this.label_LicenseLocks_Enabled.Text = "CurrentLicense.TrialRestricted = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.TrialRestricted.ToString();
			this.label_LicenseHardwareID.Text = "CurrentLicense.HardwareID = \"" + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.HardwareID+"\"";				
			this.label_ExpirationDays.Text = "CurrentLicense.ExpirationDays = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays.ToString();
			this.label_ExpirationDays_Current.Text = "CurrentLicense.ExpirationDays_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Current.ToString();
			this.label_ExpirationDays_Enabled.Text = "CurrentLicense.ExpirationDays_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Enabled.ToString();
			this.label_ExpirationDate.Text = "CurrentLicense.ExpirationDate = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate.ToString();
			this.label_ExpirationDate_Enabled.Text = "CurrentLicense.ExpirationDate_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate_Enabled.ToString();	
			this.label_Executions.Text = "CurrentLicense.Executions = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions.ToString();
			this.label_Executions_Current.Text = "CurrentLicense.Executions_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Current.ToString();
			this.label_Executions_Enabled.Text = "CurrentLicense.Executions_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Enabled.ToString();		
			this.label_Runtime.Text = "CurrentLicense.Runtime = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime.ToString();
			this.label_Runtime_Enabled.Text = "CurrentLicense.Runtime_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime_Enabled.ToString();
			this.label_GlobalTime.Text = "CurrentLicense.GlobalTime = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime.ToString();
			this.label_GlobalTime_Current.Text = "CurrentLicense.GlobalTime_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Current.ToString();
			this.label_GlobalTime_Enabled.Text = "CurrentLicense.GlobalTime_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Enabled.ToString();
			this.label_Instances.Text = "CurrentLicense.Instances = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Instances.ToString();
			this.label_Instances_Enabled.Text = "CurrentLicense.Instances_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Instances_Enabled.ToString();
			this.label_Custom_Enabled.Text = "CurrentLicense.Custom_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Custom_Enabled.ToString();

			this.listView1.Items.Clear();

			if((IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.EvaluationMode) ||(IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.Licensed))
			{
				for (int i = 0; i < IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.Count; i++)
				{
					this.listView1.Items.Add(new ListViewItem(new string[]{IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetKey(i).ToString(), IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetByIndex(i).ToString()}));
				}
			}
		}

		public void DisplayHardwareID()
		{
			hid_textbox.Text = IntelliLock.Licensing.HardwareID.GetHardwareID(hid_cpu.Checked, hid_hdd.Checked, hid_mac.Checked, hid_mainboard.Checked, hid_bios.Checked, hid_os.Checked);
		}

		private void hid_item_checkedchanged(object sender, System.EventArgs e)
		{
			DisplayHardwareID();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			string deactivationcode = IntelliLock.Licensing.License_DeActivator.DeactivateLicense();

			if (deactivationcode.Length > 0)
			{
				Clipboard.SetDataObject(deactivationcode, true);
				MessageBox.Show("Deactivation Code: " + deactivationcode, "License Deactivated!");
			}
		}
	}
}
