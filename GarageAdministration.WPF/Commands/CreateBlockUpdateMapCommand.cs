using System.Windows;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.Commands;

public class CreateBlockUpdateMapCommand: CommandBase
{
    private readonly CreateBlockViewModel _createBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public CreateBlockUpdateMapCommand(CreateBlockViewModel createBlockViewModel, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore)
    {
        _createBlockViewModel = createBlockViewModel;
        _garageBlockStore = garageBlockStore;
        _garageMapInfoStore = garageMapInfoStore;
    }

    public override void Execute(object? parameter)
    {
        var mousePos = Mouse.GetPosition((IInputElement)parameter);
        var id = !_garageBlockStore.GarageBlocks.Any() ? 0 : _garageBlockStore.GarageBlocks.Last().Id + 1;
        var mapInfoId = !_garageMapInfoStore.MapInfos.Any() ? 0 : _garageMapInfoStore.MapInfos.Last().Id + 1;
        var form = _createBlockViewModel.BlockFormViewModel;
        var mapInfo = new MapInfo(mapInfoId, mousePos.Y, mousePos.X, form.Width, form.Height, form.Angle, 0);
        _createBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock = new GarageBlock(id, mapInfo);
    }
}