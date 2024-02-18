using System.Configuration;
using System.Data;
using System.Windows;
using GarageAdministration.WPF.ViewModels.MainWindow;

namespace GarageAdministration.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(),
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}