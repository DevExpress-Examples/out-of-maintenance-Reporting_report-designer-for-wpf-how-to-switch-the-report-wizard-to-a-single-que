using DevExpress.Xpf.Reports.UserDesigner.ReportWizard;
using DevExpress.DataAccess.Wizard.Model;
using DevExpress.Xpf.DataAccess.DataSourceWizard;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Wizards;
using DevExpress.DataAccess.Wizard;
using System.Drawing;

namespace SingleQueryWizard {
    public class MyWizardCustomizationService : IWizardCustomizationService {
        void IDataSourceWizardCustomizationService.CustomizeDataSourceWizard(DataSourceWizardCustomizationModel customization, ViewModelSourceIntegrityContainer container) {
            var wizardOptions = container.Resolve<SqlWizardOptions>();
            wizardOptions &= ~SqlWizardOptions.MultiQueryWizard; //or you can use 'var wizardOptions = SqlWizardOptions.None'
            container.RegisterInstance(wizardOptions);
        }

        void IWizardCustomizationService.CustomizeReportWizard(ReportWizardCustomizationModel customization, ViewModelSourceIntegrityContainer container) {
            var wizardOptions = container.Resolve<SqlWizardOptions>();
            wizardOptions &= ~SqlWizardOptions.MultiQueryWizard; //or you can use 'var wizardOptions = SqlWizardOptions.None'
            container.RegisterInstance(wizardOptions);
        }

        bool IDataSourceWizardCustomizationService.TryCreateDataSource(IDataSourceModel model, out object dataSource, out string dataMember) {
            dataSource = null;
            dataMember = null;
            return false;
        }

        bool IWizardCustomizationService.TryCreateReport(XtraReportModel model, out XtraReport report) {
            report = null;
            return false;
        }
    }
}
