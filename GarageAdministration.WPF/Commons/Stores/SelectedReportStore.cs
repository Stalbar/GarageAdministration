using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.Stores;

public class SelectedReportStore
{
    private IReport? _report = null;

    public IReport? Report
    {
        get => _report;
        set
        {
            _report = value;
            SelectedReportChanged?.Invoke();
        }
    }

    public event Action? SelectedReportChanged;
}