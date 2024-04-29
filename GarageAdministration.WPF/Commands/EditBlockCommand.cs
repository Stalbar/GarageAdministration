using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditBlock;

namespace GarageAdministration.WPF.Commands;

public class EditBlockCommand: AsyncCommandBase
{
    private readonly EditBlockViewModel _editBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public EditBlockCommand(EditBlockViewModel editBlockViewModel, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore)
    {
        _editBlockViewModel = editBlockViewModel;
        _garageBlockStore = garageBlockStore;
        _garageMapInfoStore = garageMapInfoStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garageBlock = _editBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
        await _garageMapInfoStore.Update(garageBlock.MapInfo);
        await _garageBlockStore.Update(garageBlock);
    }
}