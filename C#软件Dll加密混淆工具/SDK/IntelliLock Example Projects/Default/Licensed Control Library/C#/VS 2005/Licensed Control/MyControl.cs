using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Licensed_Control
{
    /// <summary>
    /// This project demonstrates how to license a control without writing a single line of code. The license file will be automatically 
    /// embedded within the corresponding main application at build time. The IntelliLock SDK library IntelliLock.Licensing.dll is only 
	/// used to display the current license status. 
    /// </summary>
    /// <remarks>
    /// To test this project:
    /// 1.  Build this project
    /// 2.  Open the IntelliLock project file licensed_control.ilproj (located in the debug folder) with IntelliLock
    /// 3.  In IntelliLock click "Finalize" to protect this control library with an evaluation lock
    /// 4.  In IntelliLock click "Create License" (tab "License Manager") to create a license file 
    /// 5.  Copy the license file to the location of your protected DLL
    /// 5.  Optional: Copy the protected DLL together with your license file into the GAC
    /// 6.  Create a new Visual Studio project and add the control to the IDE toolbox (using Choose Items...)    
    /// 7.  Drag the control onto the form. In case no nag screen is shown your control is successfully licensed.
    /// 8.  Now if you build/compile your project the license file will be automatically embedded within your compiled assembly 
    /// </remarks>
    public partial class MyControl : UserControl
    {  
        public MyControl()
        {
            InitializeComponent();
        }
    }
}
