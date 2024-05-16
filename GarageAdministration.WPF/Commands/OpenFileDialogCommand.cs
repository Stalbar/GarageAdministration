using System.Windows.Forms;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.CreateMap;

namespace GarageAdministration.WPF.Commands;

public class OpenFileDialogCommand: CommandBase
{
    private readonly CreateMapViewModel _createMapViewModel;

    public OpenFileDialogCommand(CreateMapViewModel createMapViewModel)
    {
        _createMapViewModel = createMapViewModel;
    }

    public override void Execute(object? parameter)
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "Изображения (*.png;*.jpg)|*.png;*.jpg";
        dialog.ShowDialog();
        if (!dialog.FileName.Equals(""))
        {
            _createMapViewModel.MapFormViewModel.SelectedPath = dialog.FileName;
            _createMapViewModel.SelectedMapViewModel.BackgroundImage = dialog.FileName;
        }
    }
}