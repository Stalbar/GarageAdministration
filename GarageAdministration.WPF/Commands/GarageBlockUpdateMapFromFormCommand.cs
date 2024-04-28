using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.Commands;

public class GarageBlockUpdateMapFromFormCommand: CommandBase
{
    private readonly CreateBlockViewModel _createBlockViewModel;

    public GarageBlockUpdateMapFromFormCommand(CreateBlockViewModel createBlockViewModel)
    {
        _createBlockViewModel = createBlockViewModel;
    }

    public override void Execute(object? parameter)
    {
        var garageBlock = _createBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
        var width = _createBlockViewModel.BlockFormViewModel.Width;
        var height = _createBlockViewModel.BlockFormViewModel.Height;
        var angle = _createBlockViewModel.BlockFormViewModel.Angle;
        var newMapInfo = new MapInfo(garageBlock.MapInfo.Id, garageBlock.MapInfo.Top, garageBlock.MapInfo.Left, width,
            height, angle, 0);
        _createBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock = new GarageBlock(garageBlock.Id, newMapInfo);
    }
}