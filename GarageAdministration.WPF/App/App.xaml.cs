using System.Windows;
using GarageAdministration.EF;
using GarageAdministration.WPF.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GarageAdministration.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly GarageAdministrationDbContextFactory _garageAdministrationDbContextFactory;
    private readonly ServiceProvider _serviceProvider;
    
    public App()
    {
        const string connectionString = "Data Source=db.db;";
        _garageAdministrationDbContextFactory = new(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
        _serviceProvider = new InjectionContainer().GetServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (var context = _garageAdministrationDbContextFactory.Create())
        {
            context.Database.Migrate();
        }
        
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}