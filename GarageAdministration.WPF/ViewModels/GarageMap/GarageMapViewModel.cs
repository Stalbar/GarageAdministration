using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel: ViewModelBase
{
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public ICommand NavigateToCreateGarageViewCommand { get; }
    
    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation)
    {
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore);
    }
}