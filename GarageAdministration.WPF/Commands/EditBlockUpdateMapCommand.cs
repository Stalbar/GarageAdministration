using System.Windows;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditBlock;

namespace GarageAdministration.WPF.Commands;

public class EditBlockUpdateMapCommand: CommandBase
{
    private readonly EditBlockViewModel _editBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;

    public EditBlockUpdateMapCommand(EditBlockViewModel editBlockViewModel, GarageBlockStore garageBlockStore)
    {
        _editBlockViewModel = editBlockViewModel;
        _garageBlockStore = garageBlockStore;
    }

    public override void Execute(object? parameter)
    {
        var mousePos = Mouse.GetPosition((IInputElement)parameter);
        var garageBlock = _garageBlockStore.GarageBlocks.First(g => g.Id == _editBlockViewModel.GarageBlockId);
        var form = _editBlockViewModel.BlockFormViewModel;
        var mapInfo = new MapInfo(garageBlock.MapInfo.Id, mousePos.Y, mousePos.X, form.Width, form.Height, form.Angle,
            0);
        _editBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock = new GarageBlock(garageBlock.Id, mapInfo);
    }
}