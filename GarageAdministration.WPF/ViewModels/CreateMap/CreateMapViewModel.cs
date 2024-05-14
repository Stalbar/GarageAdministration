using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateMap;

public class CreateMapViewModel: ViewModelBase
{
    public SelectedMapViewModel SelectedMapViewModel { get; }
    public MapFormViewModel MapFormViewModel { get; }

    public CreateMapViewModel(INavigationService navigation)
    {
        var submitCommand = new NavigateToGarageMapViewCommand(navigation);
        SelectedMapViewModel = new SelectedMapViewModel();
        MapFormViewModel = new MapFormViewModel(navigation, submitCommand, null);
    }
}