namespace Licensed_Control
{
    partial class InstallLicenseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.okbutton = new System.Windows.Forms.Button();
            this.installbutton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "This message will disappear when a valid license file is installed.";
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(246, 67);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 1;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // installbutton
            // 
            this.installbutton.Location = new System.Drawing.Point(15, 67);
            this.installbutton.Name = "installbutton";
            this.installbutton.Size = new System.Drawing.Size(93, 23);
            this.installbutton.TabIndex = 2;
            this.installbutton.Text = "Install License";
            this.installbutton.UseVisualStyleBackColor = true;
            this.installbutton.Click += new System.EventHandler(this.installbutton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "License files|*.license|All files|*.*";
            // 
            // InstallLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 102);
            this.Controls.Add(this.installbutton);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.label1);
            this.Name = "InstallLicenseForm";
            this.Text = "My Control - Evaluation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button installbutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}