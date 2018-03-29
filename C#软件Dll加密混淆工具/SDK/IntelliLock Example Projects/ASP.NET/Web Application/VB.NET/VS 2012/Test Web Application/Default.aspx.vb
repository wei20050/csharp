Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Label1.Text = ("License Status = " & IntelliLock.Licensing.EvaluationMonitor.CurrentLicense.LicenseStatus.ToString)
    End Sub

End Class