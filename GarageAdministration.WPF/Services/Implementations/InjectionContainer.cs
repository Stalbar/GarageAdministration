using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using GarageAdministration.EF;
using GarageAdministration.EF.Commands;
using GarageAdministration.EF.Queries;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateOwner;
using GarageAdministration.WPF.ViewModels.Home;
using GarageAdministration.WPF.ViewModels.MainWindow;
using GarageAdministration.WPF.ViewModels.OwnersList;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GarageAdministration.WPF.Services.Implementations;

public class InjectionContainer
{
    public ServiceProvider GetServiceProvider()
    {
        IServiceCollection services = new ServiceCollection();
        
        services.AddSingleton<MainWindow>(provider => new MainWindow()
        {
            DataContext = provider.GetRequiredService<MainWindowViewModel>(),
        });
        
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<CreateOwnerViewModel>();
        services.AddSingleton<OwnersListViewModel>();

        string connectionString = "Data Source=db.db;";
        services.AddSingleton<DbContextOptions>(_ => new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
        services.AddSingleton<GarageAdministrationDbContextFactory>();
                    
        services.AddSingleton<ICreateCommand<Owner>, CreateOwnerCommand>();
        services.AddSingleton<IUpdateCommand<Owner>, UpdateOwnerCommand>();
        services.AddSingleton<IGetAllQuery<Owner>, GetAllOwners>();
        services.AddSingleton<OwnersStore>(provider => new OwnersStore(
            provider.GetRequiredService<ICreateCommand<Owner>>(),
            provider.GetRequiredService<IUpdateCommand<Owner>>(),
            new DeleteOwnerCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<Owner>>())
        );

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
            viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
        
        return services.BuildServiceProvider();
    }
}