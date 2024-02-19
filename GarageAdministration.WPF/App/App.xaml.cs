using System.Windows;
using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using GarageAdministration.EF;
using GarageAdministration.EF.Commands;
using GarageAdministration.EF.Queries;
using GarageAdministration.WPF.ViewModels.MainWindow;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly GarageAdministrationDbContextFactory _garageAdministrationDbContextFactory;
    private readonly ICreateCommand<Position> _createPositionCommand;
    private readonly IGetAllQuery<Garage> _getAllGarages;
    
    public App()
    {
        string connectionString = "Data Source=db.db;";
        _garageAdministrationDbContextFactory = new(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
        _createPositionCommand = new CreatePositionCommand(_garageAdministrationDbContextFactory);
        _getAllGarages = new GetAllGarages(_garageAdministrationDbContextFactory);
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