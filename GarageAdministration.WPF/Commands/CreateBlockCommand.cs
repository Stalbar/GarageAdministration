using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.Commands;

public class CreateBlockCommand: AsyncCommandBase
{
    private readonly CreateBlockViewModel _createBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public CreateBlockCommand(CreateBlockViewModel createBlockViewModel, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore)
    {
        _createBlockViewModel = createBlockViewModel;
        _garageBlockStore = garageBlockStore;
        _garageMapInfoStore = garageMapInfoStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garageBlock = _createBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
        await _garageMapInfoStore.Add(garageBlock.MapInfo);
        await _garageBlockStore.Add(garageBlock);
    }
}