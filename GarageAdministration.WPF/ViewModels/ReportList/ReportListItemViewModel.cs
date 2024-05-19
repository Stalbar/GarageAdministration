using System.Windows.Shapes;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;
using System.IO;
using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.ViewModels.ReportList;

public class ReportListItemViewModel: ViewModelBase
{
    public Report Report { get; private set; }
    public string Name => System.IO.Path.GetFileName((System.IO.Path.Combine(Environment.CurrentDirectory, Report.PathToFile)));
    public ICommand StartCommand { get; }
    public ICommand DeleteCommand { get; }

    public ReportListItemViewModel(Report report, ReportsStore reportsStore)
    {
        StartCommand = new OpenExcelReportCommand(this);
        DeleteCommand = new DeleteReportCommand(this, reportsStore);
        Report = report;
    }
}