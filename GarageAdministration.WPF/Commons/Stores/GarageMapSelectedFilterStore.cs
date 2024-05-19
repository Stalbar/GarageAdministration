using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commons.Stores;

public class GarageMapSelectedFilterStore
{
    private IFilter<GarageMapCanvasItemViewModel> _filter;

    public IFilter<GarageMapCanvasItemViewModel> Filter
    {
        get => _filter;
        set
        {
            _filter = value;
            SelectedFilterChanged?.Invoke();
        }
    }

    public event Action? SelectedFilterChanged;
}