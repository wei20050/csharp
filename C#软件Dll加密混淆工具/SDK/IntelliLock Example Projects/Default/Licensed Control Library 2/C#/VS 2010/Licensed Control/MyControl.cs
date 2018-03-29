using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IntelliLock.Licensing;

namespace Licensed_Control
{
    /// <summary>
    /// This project demonstrates how to license a control library using the IntelliLock SDK. The license file will be automatically 
    /// embedded within the corresponding main application at build time.
    /// </summary>
    /// <remarks>
    /// To test this project:
    /// 1.  Build this project
    /// 2.  Open the IntelliLock project file licensed_control.ilproj (located in the debug folder) with IntelliLock
    /// 3.  Click "Finalize" to protect this control library with an evaluation lock
    /// 4.  Click "Create License" (tab "License Manager") to create a license file 
    /// 5.  Optional: Copy the protected DLL into the GAC
    /// 6.  Create a new Visual Studio project and add the control to the IDE toolbox (using Choose Items...)    
    /// 7.  Drag the control onto the form (the install license form should be displayed now)
    /// 8.  Select the created license file (step 4.) and click the "OK" button
    /// 9.  Now if you build/compile your project the license file will be automatically embedded within your compiled assembly 
    /// </remarks>
    public partial class MyControl : UserControl
    {
        /// <summary>
        /// Constructor - Check the current license status and display the install license form in case no license is installed
        /// </summary>    
        public MyControl()
        {
            InitializeComponent();

            // Ensure the following code is only executed after this control library is protected (step 3.)
            // The license status LicenseStatus.NotChecked means this assembly is not yet protected
            //
            if ((LicenseManager.UsageMode == LicenseUsageMode.Designtime) && (EvaluationMonitor.CurrentLicense.LicenseStatus != LicenseStatus.NotChecked))
            {
                // If no valid license is found show the install license form
                //
                if (EvaluationMonitor.CurrentLicense.LicenseStatus != LicenseStatus.Licensed)
                {
                    new InstallLicenseForm().ShowDialog();
                }
            }

            // Display the currect license status
            //
            this.statuslabel.Text = "License Status = " + EvaluationMonitor.CurrentLicense.LicenseStatus.ToString();
        }

        private void MyControl_Paint(object sender, PaintEventArgs e)
        {
            this.statuslabel.Text = "License Status = " + EvaluationMonitor.CurrentLicense.LicenseStatus.ToString();
        }
    }
}
