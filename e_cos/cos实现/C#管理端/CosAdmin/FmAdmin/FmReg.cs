using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CosAdmin.FmAdmin
{
    public partial class FmReg : Form
    {
        public FmReg()
        {
            _cos = Cos.GetCos("Admin");
            InitializeComponent();
        }
        private readonly Cos _cos;

        private void btnQX_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDL_Click(object sender, EventArgs e)
        {
            txtKey.Text = _cos.KeyXz("30");
            _cos.KeyYz(txtKey.Text,txtApp.Text);
        }
    }
}
