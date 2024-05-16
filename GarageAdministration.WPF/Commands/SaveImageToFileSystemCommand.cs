using System.IO;
using System.Windows;
using System.Windows.Input;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.CreateMap;

namespace GarageAdministration.WPF.Commands;

public class SaveImageToFileSystemCommand: AsyncCommandBase
{
    private readonly CreateMapViewModel _createMapViewModel;
    private readonly ICommand? _createMapInDatabaseCommand;

    public SaveImageToFileSystemCommand(CreateMapViewModel createMapViewModel, ICommand? createMapInDatabaseCommand)
    {
        _createMapViewModel = createMapViewModel;
        _createMapInDatabaseCommand = createMapInDatabaseCommand;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var form = _createMapViewModel.MapFormViewModel;
        var selectedPath = form.SelectedPath;
        var extension = Path.GetExtension(selectedPath);
        var fileName = $@"{Guid.NewGuid()}{extension}";
        await using var sourceStream = new FileStream(selectedPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        await using var destinationStream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        await sourceStream.CopyToAsync(destinationStream);
        _createMapInDatabaseCommand?.Execute(fileName);
    }
}