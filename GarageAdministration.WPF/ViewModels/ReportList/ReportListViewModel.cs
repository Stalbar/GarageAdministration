using System.Collections.ObjectModel;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.Migrations;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.ReportList;

public class ReportListViewModel: ViewModelBase
{
    private readonly ObservableCollection<ReportListItemViewModel> _reportListItemViewModels;
    private readonly ReportsStore _reportsStore;
    public IEnumerable<ReportListItemViewModel> ReportListItemViewModels => _reportListItemViewModels;
    public ICommand CreateReportCommand { get; }

    public ReportListViewModel(GaragesStore garagesStore, ReportsStore reportsStore)
    {
        CreateReportCommand = new SaveExcelReport(garagesStore, reportsStore);
        _reportListItemViewModels = new ObservableCollection<ReportListItemViewModel>();
        _reportsStore = reportsStore;
        _reportsStore.ReportAdded += ReportsStoreOnReportAdded;
        _reportsStore.ReportDeleted += ReportsStoreOnReportDeleted;
        _reportsStore.ReportsLoaded += ReportsStoreOnReportsLoaded;
        
        ReportsStoreOnReportsLoaded();
    }

    private void ReportsStoreOnReportsLoaded()
    {
        _reportListItemViewModels.Clear();
        foreach (var report in _reportsStore.Reports)
        {
            AddReport(report);
        }
    }

    private void ReportsStoreOnReportDeleted(int id)
    {
        var reportViewModel = _reportListItemViewModels.FirstOrDefault(r => r.Report.Id == id);

        if (reportViewModel != null)
        {
            _reportListItemViewModels.Remove(reportViewModel);
        }
    }

    private void ReportsStoreOnReportAdded(Report report)
    {
        AddReport(report);
    }

    private void AddReport(Report report)
    {
        _reportListItemViewModels.Add(new ReportListItemViewModel(report, _reportsStore));
    }
}