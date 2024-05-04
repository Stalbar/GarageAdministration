using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.ViewModels.EditBlock;

public class EditBlockViewModel : ViewModelBase
{
    public int GarageBlockId { get; }
    public CreateBlockMapViewModel CreateBlockMapViewModel { get; }
    public BlockFormViewModel BlockFormViewModel { get; }

    public EditBlockViewModel(GarageBlock garageBlock, GarageBlockStore garageBlockStore, GaragesStore garagesStore,
        GarageMapInfoStore garageMapInfoStore, INavigationService navigation, ICommand deleteCommand)

    {
        GarageBlockId = garageBlock.Id;
        ICommand mapClickCommand = new EditBlockUpdateMapCommand(this, garageBlockStore);
        CreateBlockMapViewModel =
            new CreateBlockMapViewModel(garagesStore, garageBlockStore, navigation, mapClickCommand)
            {
                IsBlockCreated = true,
                CreatedGarageBlock = garageBlock,
            };
        ICommand submitCommand = new EditBlockCommand(this, garageBlockStore, garageMapInfoStore, navigation);
        ICommand cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        ICommand updateMapFromFormCommand = new UpdateMapFromEditBlockFormCommand(this);
        BlockFormViewModel = new BlockFormViewModel(navigation, submitCommand, cancelCommand, updateMapFromFormCommand, deleteCommand:deleteCommand)
        {
            Width = garageBlock.MapInfo.Width,
            Height = garageBlock.MapInfo.Height,
            Angle = garageBlock.MapInfo.Angle,
        };
    }
}