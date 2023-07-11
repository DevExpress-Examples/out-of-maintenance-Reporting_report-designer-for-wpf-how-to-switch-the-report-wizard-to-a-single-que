Imports DevExpress.Xpf.Reports.UserDesigner.ReportWizard
Imports DevExpress.DataAccess.Wizard.Model
Imports DevExpress.Xpf.DataAccess.DataSourceWizard
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Wizards
Imports DevExpress.DataAccess.Wizard
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace SingleQueryWizard

    Public Class MyWizardCustomizationService
        Implements IWizardCustomizationService

        Private Sub CustomizeDataSourceWizard(ByVal customization As DataSourceWizardCustomizationModel, ByVal container As ViewModelSourceIntegrityContainer) Implements IDataSourceWizardCustomizationService.CustomizeDataSourceWizard
            Dim wizardOptions = container.Resolve(Of SqlWizardOptions)()
            wizardOptions = wizardOptions And Not SqlWizardOptions.MultiQueryWizard 'or you can use 'var wizardOptions = SqlWizardOptions.None'
            container.RegisterInstance(wizardOptions)
        End Sub

        Private Sub CustomizeReportWizard(ByVal customization As ReportWizardCustomizationModel, ByVal container As ViewModelSourceIntegrityContainer) Implements IWizardCustomizationService.CustomizeReportWizard
            Dim wizardOptions = container.Resolve(Of SqlWizardOptions)()
            wizardOptions = wizardOptions And Not SqlWizardOptions.MultiQueryWizard 'or you can use 'var wizardOptions = SqlWizardOptions.None'
            container.RegisterInstance(wizardOptions)
        End Sub

        Private Function TryCreateDataSource(ByVal model As IDataSourceModel, <Out> ByRef dataSource As Object, <Out> ByRef dataMember As String) As Boolean Implements IDataSourceWizardCustomizationService.TryCreateDataSource
            dataSource = Nothing
            dataMember = Nothing
            Return False
        End Function

        Private Function TryCreateReport(ByVal model As XtraReportModel, <Out> ByRef report As XtraReport) As Boolean Implements IWizardCustomizationService.TryCreateReport
            report = Nothing
            Return False
        End Function
    End Class
End Namespace
