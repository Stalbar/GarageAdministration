using System.Windows;
using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using GarageAdministration.EF;
using GarageAdministration.EF.Commands;
using GarageAdministration.EF.Queries;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.Services.Implementations;
using GarageAdministration.WPF.ViewModels.Home;
using GarageAdministration.WPF.ViewModels.MainWindow;
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
        string connectionString = "Data Source=db.db;";
        _garageAdministrationDbContextFactory = new(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
        _serviceProvider = new InjectionContainer().GetServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (var context = _garageAdministrationDbContextFactory.Create())
        {
            context.Database.Migrate();
        }

        _serviceProvider.GetRequiredService<INavigationService>().NavigateTo<HomeViewModel>();
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }
}