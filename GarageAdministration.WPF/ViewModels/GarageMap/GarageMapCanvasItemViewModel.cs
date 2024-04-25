using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapCanvasItemViewModel : ViewModelBase
{
    public Garage Garage { get; private set; }

    public double Top => Garage.MapInfo.Top;
    public double Left => Garage.MapInfo.Left;
    public double Width => Garage.MapInfo.Width;
    public double Height => Garage.MapInfo.Height;

    public ICommand DeleteCommand { get; }
    public ICommand IconCommand { get; }

    public GarageMapCanvasItemViewModel(Garage garage, GaragesStore garagesStore, INavigationService navigation,
        GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore)
    {
        Garage = garage;
        DeleteCommand = new DeleteGarageCommand(this, garagesStore);
        IconCommand =
            new NavigateToEditGarageViewCommand(navigation, this, garagesStore, ownersStore, garageMapInfoStore);
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