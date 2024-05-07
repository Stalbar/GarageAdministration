namespace GarageAdministration.WPF.Commons.Stores;

public class GarageMapSearchTextStore
{
    private string _searchText = "";

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            SearchTextChanged?.Invoke();
        }
    }

    public event Action? SearchTextChanged;
}