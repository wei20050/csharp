namespace CosAdmin.FmAdmin
{
    partial class FmReg
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQX = new System.Windows.Forms.Button();
            this.btnDL = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 107;
            this.label3.Text = "应用:";
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(102, 76);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(117, 21);
            this.txtApp.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(81, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 48);
            this.label2.TabIndex = 103;
            this.label2.Text = "注册";
            // 
            // btnQX
            // 
            this.btnQX.Location = new System.Drawing.Point(144, 141);
            this.btnQX.Name = "btnQX";
            this.btnQX.Size = new System.Drawing.Size(75, 23);
            this.btnQX.TabIndex = 106;
            this.btnQX.Text = "关闭";
            this.btnQX.UseVisualStyleBackColor = true;
            this.btnQX.Click += new System.EventHandler(this.btnQX_Click);
            // 
            // btnDL
            // 
            this.btnDL.Location = new System.Drawing.Point(63, 141);
            this.btnDL.Name = "btnDL";
            this.btnDL.Size = new System.Drawing.Size(75, 23);
            this.btnDL.TabIndex = 105;
            this.btnDL.Text = "注册";
            this.btnDL.UseVisualStyleBackColor = true;
            this.btnDL.Click += new System.EventHandler(this.btnDL_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(126, 107);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(93, 21);
            this.txtKey.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 111;
            this.label1.Text = "返回密钥:";
            // 
            // FmReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQX);
            this.Controls.Add(this.btnDL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FmReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FmReg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQX;
        private System.Windows.Forms.Button btnDL;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
    }
}