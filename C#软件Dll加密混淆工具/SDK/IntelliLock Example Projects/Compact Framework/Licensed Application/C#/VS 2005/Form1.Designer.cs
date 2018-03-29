namespace SDK_TestApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.propertyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.valuelabel = new System.Windows.Forms.Label();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.hardwareidlabel = new System.Windows.Forms.Label();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // propertyComboBox
            // 
            this.propertyComboBox.Location = new System.Drawing.Point(3, 27);
            this.propertyComboBox.Name = "propertyComboBox";
            this.propertyComboBox.Size = new System.Drawing.Size(234, 22);
            this.propertyComboBox.TabIndex = 0;
            this.propertyComboBox.SelectedIndexChanged += new System.EventHandler(this.propertyComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 14);
            this.label1.Text = "EvaluationMonitor.CurrentLicense Properties:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 14);
            this.label2.Text = "Property Value:";
            // 
            // valuelabel
            // 
            this.valuelabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.valuelabel.Location = new System.Drawing.Point(3, 66);
            this.valuelabel.Name = "valuelabel";
            this.valuelabel.Size = new System.Drawing.Size(234, 14);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Tasks";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Deactivate License";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Location = new System.Drawing.Point(3, 135);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(231, 104);
            this.listView1.TabIndex = 7;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 14);
            this.label3.Text = "Your Device Hardware ID:";
            // 
            // hardwareidlabel
            // 
            this.hardwareidlabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.hardwareidlabel.Location = new System.Drawing.Point(3, 94);
            this.hardwareidlabel.Name = "hardwareidlabel";
            this.hardwareidlabel.Size = new System.Drawing.Size(231, 14);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Key";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 126;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 14);
            this.label4.Text = "License Information:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hardwareidlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.valuelabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyComboBox);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "License Status Check";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox propertyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label valuelabel;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label hardwareidlabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
    }
}

