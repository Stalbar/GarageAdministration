using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.CreateMap;

public class SelectedMapViewModel: ViewModelBase
{
    private string _backgroundImage;

    public string BackgroundImage
    {
        get => _backgroundImage;
        set
        {
            _backgroundImage = value;
            OnPropertyChanged(nameof(BackgroundImage));
        }
    }
    
    public double Width => System.Windows.SystemParameters.PrimaryScreenWidth;
    public double Height => System.Windows.SystemParameters.PrimaryScreenHeight;

    public SelectedMapViewModel()
    {
        _backgroundImage = "";
    }
}