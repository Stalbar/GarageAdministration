using GarageAdministration.WPF.Commons;

namespace GarageAdministration.WPF.ViewModels.MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    public GarageCanvasViewModel GarageCanvasViewModel { get; } = new();
}