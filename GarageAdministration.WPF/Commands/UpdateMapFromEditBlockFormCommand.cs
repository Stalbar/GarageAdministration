using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.EditBlock;

namespace GarageAdministration.WPF.Commands;

public class UpdateMapFromEditBlockFormCommand : CommandBase
{
    private readonly EditBlockViewModel _editBlockViewModel;

    public UpdateMapFromEditBlockFormCommand(EditBlockViewModel editBlockViewModel)
    {
        _editBlockViewModel = editBlockViewModel;
    }

    public override void Execute(object? parameter)
    {
        if (_editBlockViewModel.BlockFormViewModel != null)
        {
            var garageBlock = _editBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
            var form = _editBlockViewModel.BlockFormViewModel;
            var width = form.Width;
            var height = form.Height;
            var angle = form.Angle;
            var newMapInfo = new MapInfo(garageBlock.MapInfo.Id, garageBlock.MapInfo.Top, garageBlock.MapInfo.Left,
                width, height, angle, 0);
            _editBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock =
                new GarageBlock(garageBlock.Id, newMapInfo);
        }
    }
}