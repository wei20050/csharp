''' <summary>
''' This project demonstrates how license a control library using the IntelliLock SDK. The license file will be automatically 
''' embedded within the corresponding main application at build time. 
''' </summary>
''' <remarks>
''' To test this project:
''' 1.  Build this project
''' 2.  Open the IntelliLock project file licensed_control.ilproj (located in the debug folder) with IntelliLock
''' 3.  Click "Finalize" to protect this control library with an evaluation lock
''' 4.  Click "Create License" (tab "License Manager") to create a license file 
''' 5.  Optional: Copy the protected DLL into the GAC
''' 6.  Create a new Visual Studio project and add the control to the IDE toolbox (using Choose Items...)    
''' 7.  Drag the control onto the form (the install license form should be displayed now)
''' 8.  Select the created license file (step 4.) and click the "OK" button
''' 9.  Now if you build/compile your project the license file will be automatically embedded within your compiled assembly 
''' </remarks>

Public Class MyControl

    Public Sub New()
        Me.components = Nothing
        Me.InitializeComponent()


        ' Ensure the following code is only executed after this control library is protected (step 3.)
        ' The license status LicenseStatus.NotChecked means this assembly is not yet protected
        If (((System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) AndAlso (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus <> IntelliLock.Licensing.LicenseStatus.NotChecked)) AndAlso (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus <> IntelliLock.Licensing.LicenseStatus.Licensed)) Then
            Dim licinstallform As InstallLicenseForm = New InstallLicenseForm()
            licinstallform.ShowDialog()
        End If

        ' Display the currect license status
        Me.statuslabel.Text = ("License Status = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString)
    End Sub

    Private Sub MyControl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Me.statuslabel.Text = ("License Status = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString)
    End Sub
End Class
