using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using yx;

namespace dmDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			//DmSoft.Ini();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DmSoft dm = new DmSoft();
			dm.Delay(2000);
			dm.KeyPressStr(".ddaccJJdAA23JKDJSK23dlaJdjlj666");
		}
	}
}
