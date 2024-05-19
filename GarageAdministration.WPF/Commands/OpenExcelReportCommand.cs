using System.Diagnostics;
using System.IO;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.ReportList;

namespace GarageAdministration.WPF.Commands;

public class OpenExcelReportCommand: CommandBase
{
    private readonly ReportListItemViewModel _reportListItemViewModel;

    public OpenExcelReportCommand(ReportListItemViewModel reportListItemViewModel)
    {
        _reportListItemViewModel = reportListItemViewModel;
    }

    public override void Execute(object? parameter)
    {
        var report = _reportListItemViewModel.Report;
        var fullPath = Path.Combine(Environment.CurrentDirectory, report.PathToFile);
        var process = new Process();
        process.StartInfo = new ProcessStartInfo(fullPath)
        {
            UseShellExecute = true,
        };
        process.Start();
    }
}