using System.Windows.Media;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageMapItemViewModel: ViewModelBase
{
    public Garage Garage { get; private set; }

    public double Top => Garage.MapInfo.Top;
    public double Left => Garage.MapInfo.Left;
    public double Width => Garage.MapInfo.Width;
    public double Height => Garage.MapInfo.Height;

    public System.Windows.Media.Brush IconColor { get; set; }
    
    public CreateGarageMapItemViewModel(Garage garage, System.Windows.Media.Brush iconColor)
    {
        IconColor = iconColor;
        Garage = garage;
    }
    
    public void Update(Garage garage)
    {
        Garage = garage;
        OnPropertyChanged(nameof(Top));
        OnPropertyChanged(nameof(Left));
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(Height));
    }
}