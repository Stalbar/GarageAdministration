using System.Windows;
using GarageAdministration.EF;
using GarageAdministration.WPF.ViewModels.MainWindow;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly GarageAdministrationDbContextFactory _garageAdministrationDbContextFactory;
    
    public App()
    {
        string connectionString = "Data Source=db.db;";
        _garageAdministrationDbContextFactory = new(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (var context = _garageAdministrationDbContextFactory.Create())
        {
            context.Database.Migrate();
        }
        MainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(),
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}