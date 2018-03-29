Public Class InstallLicenseForm

    Private Sub okbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okbutton.Click
        Close()
    End Sub

    ''' <summary>
    ''' Shows an open file dialog and installs the selected license file
    ''' </summary>   
    Private Sub installbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles installbutton.Click
        If (Me.openFileDialog1.ShowDialog = DialogResult.OK) Then

            ' Embedded the selected license file within the corresponding main application.
            IntelliLock.Licensing.EvaluationMonitor.StoreLicenseAsResource(Me.openFileDialog1.FileName)

            ' Load the license file to update the current license status. The next time you run the main application the stored
            ' license file will be found and loaded automatically.
            IntelliLock.Licensing.EvaluationMonitor.LoadLicense(Me.openFileDialog1.FileName)
        End If
    End Sub
End Class