using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using IntelliLock.Licensing;

namespace SDK_TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                        
            PropertyInfo[] properties = typeof(IntelliLock.Licensing.License).GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                this.propertyComboBox.Items.Add(properties[i].Name);
            }

            if (properties.Length > 0)
            this.propertyComboBox.SelectedIndex = 0;

            hardwareidlabel.Text = IntelliLock.Licensing.HardwareID.GetHardwareID(true, true, true, true, true, true);

            this.listView1.Items.Clear();

            if ((IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.EvaluationMode) || (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.Licensed))
            {
                for (int i = 0; i < IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.Count; i++)
                {
                    this.listView1.Items.Add(new ListViewItem(new string[] { IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetKey(i).ToString(), IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetByIndex(i).ToString() }));
                }
            }
        }

        private void propertyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propertyComboBox.SelectedIndex >= 0)
            {
                string propertyname = (string)propertyComboBox.Items[propertyComboBox.SelectedIndex];
                PropertyInfo propinfo = typeof(IntelliLock.Licensing.License).GetProperty(propertyname);
                valuelabel.Text = propinfo.GetValue(IntelliLock.Licensing.EvaluationMonitor.CurrentLicense, new object[0]).ToString();
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deactivation Code:\r\n" + IntelliLock.Licensing.License_DeActivator.DeactivateLicense());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}