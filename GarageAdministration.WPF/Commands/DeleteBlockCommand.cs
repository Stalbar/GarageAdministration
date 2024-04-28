using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.Commands;

public class DeleteBlockCommand: AsyncCommandBase
{
    private readonly BlockMapItemViewModel _blockMapItemViewModel;
    private readonly GarageBlockStore _garageBlockStore;

    public DeleteBlockCommand(BlockMapItemViewModel blockMapItemViewModel, GarageBlockStore garageBlockStore)
    {
        _blockMapItemViewModel = blockMapItemViewModel;
        _garageBlockStore = garageBlockStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        GarageBlock garageBlock = _blockMapItemViewModel.GarageBlock;

        await _garageBlockStore.Delete(garageBlock.Id);
    }
}