using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapCanvasItemViewModel: ViewModelBase
{
    public Garage Garage { get; private set; }

    public double Top => Garage.MapInfo.Top;
    public double Left => Garage.MapInfo.Left;
    public double Width => Garage.MapInfo.Width;
    public double Height => Garage.MapInfo.Height;

    public GarageMapCanvasItemViewModel(Garage garage)
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
    }
}