using System.Collections.ObjectModel;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.Migrations;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.Services.Implementations.Reports;

namespace GarageAdministration.WPF.ViewModels.ReportList;

public class ReportListViewModel: ViewModelBase
{
    private readonly ObservableCollection<ReportListItemViewModel> _reportListItemViewModels;
    private readonly ReportsStore _reportsStore;
    private readonly SelectedReportStore _selectedReportStore;
    private List<IReport> _reports;

    public IReport? SelectedReport
    {
        get => _selectedReportStore.Report;
        set
        {
            _selectedReportStore.Report = value;
            OnPropertyChanged(nameof(SelectedReport));
        }
    }

    public IEnumerable<IReport> Reports
    {
        get => _reports;
        set
        {
            _reports = value.ToList();
            OnPropertyChanged(nameof(Reports));
        }
    }
    
    public IEnumerable<ReportListItemViewModel> ReportListItemViewModels => _reportListItemViewModels;
    public ICommand CreateReportCommand { get; }

    public ReportListViewModel(GaragesStore garagesStore, ReportsStore reportsStore, SelectedReportStore selectedReportStore,
        OwnersStore ownersStore)
    {
        Reports = new IReport[]
        {
            new GarageReport(garagesStore),
            new OwnersReport(ownersStore),
        };
        _selectedReportStore = selectedReportStore;
        _selectedReportStore.SelectedReportChanged += SelectedReportStoreOnSelectedReportChanged;
        _selectedReportStore.Report = Reports.First();
        CreateReportCommand = new SaveExcelReport(garagesStore, reportsStore, selectedReportStore);
        _reportListItemViewModels = new ObservableCollection<ReportListItemViewModel>();
        _reportsStore = reportsStore;
        _reportsStore.ReportAdded += ReportsStoreOnReportAdded;
        _reportsStore.ReportDeleted += ReportsStoreOnReportDeleted;
        _reportsStore.ReportsLoaded += ReportsStoreOnReportsLoaded;
        
        ReportsStoreOnReportsLoaded();
    }

    private void SelectedReportStoreOnSelectedReportChanged()
    {
        OnPropertyChanged(nameof(SelectedReport));
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