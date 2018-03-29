using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using IntelliLock.Licensing;

namespace SDK_TestApp
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            UpdateSettings();	
        }

        public void UpdateSettings()
        {
            this.label_ValidLicenseAvailable.Content = "CurrentLicense.LicenseStatus = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString();
            this.label_status_external_assembly.Content = "CurrentLicense.LicenseStatus_ExternalAssembly = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_ExternalAssembly.ToString();
            this.label_status_hdd.Content = "CurrentLicense.LicenseStatus_HDD = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus_HDD.ToString();
            this.label_license_location.Content = "CurrentLicense.LicenseLocation = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseLocation.ToString();
            this.label_LicenseLocks_Enabled.Content = "CurrentLicense.TrialRestricted = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.TrialRestricted.ToString();
            this.label_ExpirationDays.Content = "CurrentLicense.ExpirationDays = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays.ToString();
            this.label_ExpirationDays_Current.Content = "CurrentLicense.ExpirationDays_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Current.ToString();
            this.label_ExpirationDays_Enabled.Content = "CurrentLicense.ExpirationDays_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDays_Enabled.ToString();
            this.label_ExpirationDate.Content = "CurrentLicense.ExpirationDate = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate.ToString();
            this.label_ExpirationDate_Enabled.Content = "CurrentLicense.ExpirationDate_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.ExpirationDate_Enabled.ToString();
            this.label_Executions.Content = "CurrentLicense.Executions = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions.ToString();
            this.label_Executions_Current.Content = "CurrentLicense.Executions_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Current.ToString();
            this.label_Executions_Enabled.Content = "CurrentLicense.Executions_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Executions_Enabled.ToString();
            this.label_Runtime.Content = "CurrentLicense.Runtime = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime.ToString();
            this.label_Runtime_Enabled.Content = "CurrentLicense.Runtime_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Runtime_Enabled.ToString();
            this.label_GlobalTime.Content = "CurrentLicense.GlobalTime = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime.ToString();
            this.label_GlobalTime_Current.Content = "CurrentLicense.GlobalTime_Current = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Current.ToString();
            this.label_GlobalTime_Enabled.Content = "CurrentLicense.GlobalTime_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.GlobalTime_Enabled.ToString();
            this.label_Custom_Enabled.Content = "CurrentLicense.Custom_Enabled = " + IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.Custom_Enabled.ToString();

            this.listView1.Items.Clear();




            if ((IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.EvaluationMode) || (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus == IntelliLock.Licensing.LicenseStatus.Licensed))
            {
                foreach (KeyValuePair<string, string> kvp in IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation)
                {
                    this.listView1.Items.Add("Key = " + kvp.Key + ", Value = " + kvp.Value);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "License Files (*.license)|*.license";

            if (dlg.ShowDialog() == true)
            {
                System.IO.FileStream fstream = dlg.File.OpenRead();
                byte[] data = new byte[fstream.Length];
                fstream.Read(data, 0, data.Length);
                fstream.Close();
                IntelliLock.Licensing.EvaluationMonitor.LoadLicense(data);
                UpdateSettings();
            }
        }
    }
}
