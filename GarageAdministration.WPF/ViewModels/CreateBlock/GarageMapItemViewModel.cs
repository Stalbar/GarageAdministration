using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.CreateBlock;

public class GarageMapItemViewModel: ViewModelBase
{
    public Garage Garage { get; private set; }
    public double Top => Garage.MapInfo.Top;
    public double Left => Garage.MapInfo.Left;
    public double Width => Garage.MapInfo.Width;
    public double Height => Garage.MapInfo.Height;
    public double Angle => Garage.MapInfo.Angle;

    public GarageMapItemViewModel(Garage garage)
    {
        Garage = garage;
    }

    public void Update(Garage garage)
    {
        Garage = garage;
        OnPropertyChanged(nameof(Top));
        OnPropertyChanged(nameof(Left));
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(Height));
        OnPropertyChanged(nameof(Angle));
    }
}