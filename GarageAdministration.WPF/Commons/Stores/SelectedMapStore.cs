using GarageAdministration.Domain.Models;

namespace GarageAdministration.WPF.Commons.Stores;

public class SelectedMapStore
{
    private Map? _map = null;

    public Map? Map
    {
        get => _map;
        set
        {
            _map = value;
            SelectedMapChanged?.Invoke();
        }
    }

    public event Action? SelectedMapChanged;
}