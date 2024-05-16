using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateMap;

public class CreateMapViewModel: ViewModelBase
{
    public SelectedMapViewModel SelectedMapViewModel { get; }
    public MapFormViewModel MapFormViewModel { get; }

    public CreateMapViewModel(INavigationService navigation, MapsStore mapsStore)
    {
        var cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        var selectFileCommand = new OpenFileDialogCommand(this);
        var createMapInDatabaseCommand = new CreateMapCommand(mapsStore, navigation);
        var createCommand = new SaveImageToFileSystemCommand(this, createMapInDatabaseCommand);
        SelectedMapViewModel = new SelectedMapViewModel();
        MapFormViewModel = new MapFormViewModel(navigation, createCommand, cancelCommand, selectFileCommand);
    }
}