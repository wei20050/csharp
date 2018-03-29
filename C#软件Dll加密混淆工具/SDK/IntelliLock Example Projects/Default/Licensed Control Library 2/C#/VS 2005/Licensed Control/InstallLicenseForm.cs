using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IntelliLock.Licensing;

namespace Licensed_Control
{
    public partial class InstallLicenseForm : Form
    {
        public InstallLicenseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows an open file dialog and installs the selected license file
        /// </summary>   
        private void installbutton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Embedded the selected license file within the corresponding main application.
                //
                EvaluationMonitor.StoreLicenseAsResource(openFileDialog1.FileName);

                // Load the license file to update the current license status. The next time you run the main application the stored
                // license file will be found and loaded automatically.
                //
                EvaluationMonitor.LoadLicense(openFileDialog1.FileName);
            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}