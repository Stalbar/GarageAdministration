using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateBlock;

public class CreateBlockViewModel: ViewModelBase
{
    public CreateBlockMapViewModel CreateBlockMapViewModel { get; }
    public BlockFormViewModel BlockFormViewModel { get; }

    public CreateBlockViewModel(GaragesStore garagesStore, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation)
    {
        ICommand submitCommand = new CreateBlockCommand(this, garageBlockStore, garageMapInfoStore, navigation);
        ICommand cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        ICommand mapUpdateCommand = new GarageBlockUpdateMapFromFormCommand(this);
        ICommand mapClickCommand = new CreateBlockUpdateMapCommand(this, garageBlockStore, garageMapInfoStore);
        CreateBlockMapViewModel = new CreateBlockMapViewModel(garagesStore, garageBlockStore, navigation, mapClickCommand);
        BlockFormViewModel = new BlockFormViewModel(navigation, submitCommand, cancelCommand, mapUpdateCommand);
    }
}