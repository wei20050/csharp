Public Class Form1
    Inherits Form

    Public Sub New()
        Dim num As Integer
        Me.components = Nothing
        Me.InitializeComponent()

        Dim properties As System.Reflection.PropertyInfo() = GetType(IntelliLock.Licensing.License).GetProperties

        For num = 0 To properties.Length - 1
            Me.PropertyComboBox.Items.Add(properties(num).Name)
        Next num

        If (properties.Length > 0) Then
            Me.PropertyComboBox.SelectedIndex = 0
        End If

        Me.hardwareidlabel.Text = IntelliLock.Licensing.HardwareID.GetHardwareID(True, True, True, True, True, True)
        Me.ListView1.Items.Clear()

        If ((IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus = IntelliLock.Licensing.LicenseStatus.EvaluationMode) OrElse (IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus = IntelliLock.Licensing.LicenseStatus.Licensed)) Then
            For num = 0 To IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.Count - 1
                Me.ListView1.Items.Add(New ListViewItem(New String() {IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetKey(num).ToString, IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseInformation.GetByIndex(num).ToString}))
            Next num
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PropertyComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyComboBox.SelectedIndexChanged
        If (Me.PropertyComboBox.SelectedIndex >= 0) Then
            Dim name As String = CStr(Me.PropertyComboBox.Items.Item(Me.PropertyComboBox.SelectedIndex))
            Dim _property As System.Reflection.PropertyInfo = GetType(IntelliLock.Licensing.License).GetProperty(name)
            Me.valuelabel.Text = [_property].GetValue(IntelliLock.Licensing.EvaluationMonitor.CurrentLicense, New Object(0 - 1) {}).ToString
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        MessageBox.Show(("Deactivation Code:" & ChrW(13) & ChrW(10) & IntelliLock.Licensing.License_DeActivator.DeactivateLicense))
    End Sub
End Class
