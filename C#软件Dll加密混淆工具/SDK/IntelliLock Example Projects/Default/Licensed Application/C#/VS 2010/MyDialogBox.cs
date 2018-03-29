using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IntelliLock.Licensing;

namespace SDK_TestApp
{
	/// <summary>
	/// Summary description for MyDialogBox.
	/// </summary>
	[IntelliLock.DialogBoxAttribute]
	public class MyDialogBox : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label label_message;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MyDialogBox(string message)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.label_message.Text = message;
		}

		public static void ShowMessage(string message)
		{
			new MyDialogBox(message).ShowDialog();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label_message = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label_message
			// 
			this.label_message.Location = new System.Drawing.Point(8, 8);
			this.label_message.Name = "label_message";
			this.label_message.Size = new System.Drawing.Size(280, 48);
			this.label_message.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 56);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MyDialogBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 85);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label_message);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MyDialogBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MyDialogBox";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
