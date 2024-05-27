using System.IO;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.Services.Implementations.Reports;

namespace GarageAdministration.WPF.Commands;

public class SaveExcelReport : AsyncCommandBase
{
    private readonly GaragesStore _garagesStore;
    private readonly ReportsStore _reportsStore;
    private readonly SelectedReportStore _selectedReportStore;

    public SaveExcelReport(GaragesStore garagesStore, ReportsStore reportsStore,
        SelectedReportStore selectedReportStore)
    {
        _garagesStore = garagesStore;
        _reportsStore = reportsStore;
        _selectedReportStore = selectedReportStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var report = _selectedReportStore.Report!;
        var bytes = report.Generate();
        var time = DateTime.Now;
        var fileName = report + $" {time.Day}-{time.Month}-{time.Year} {time.Hour}.{time.Minute}.{time.Second}" +
                       ".xlsx";
        await File.WriteAllBytesAsync(fileName, bytes.ToArray());
        var reportId = _reportsStore.Reports.Last().Id + 1;
        var reportModel = new Report(reportId, fileName, time);
        await _reportsStore.Add(reportModel);
    }
}