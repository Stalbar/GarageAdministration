using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using GarageAdministration.EF;
using GarageAdministration.EF.Commands;
using GarageAdministration.EF.Queries;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.CreateGarage;
using GarageAdministration.WPF.ViewModels.CreateMap;
using GarageAdministration.WPF.ViewModels.CreateOwner;
using GarageAdministration.WPF.ViewModels.GarageMap;
using GarageAdministration.WPF.ViewModels.MainWindow;
using GarageAdministration.WPF.ViewModels.OwnersList;
using GarageAdministration.WPF.ViewModels.ReportList;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GarageAdministration.WPF.Services.Implementations;

public static class InjectionContainer
{
    public static ServiceProvider GetServiceProvider()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<MainWindow>(provider => new MainWindow()
        {
            DataContext = provider.GetRequiredService<MainWindowViewModel>(),
        });

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<CreateOwnerViewModel>();
        services.AddSingleton<OwnersListViewModel>();
        services.AddSingleton<GarageMapViewModel>();
        services.AddTransient<CreateGarageViewModel>();
        services.AddSingleton<ReportListViewModel>();
        services.AddTransient<CreateBlockViewModel>();
        services.AddTransient<CreateMapViewModel>();

        const string connectionString = "Data Source=db.db;";
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

        services.AddSingleton<ICreateCommand<Garage>, CreateGarageCommand>();
        services.AddSingleton<IUpdateCommand<Garage>, UpdateGarageCommand>();
        services.AddSingleton<IGetAllQuery<Garage>, GetAllGarages>();
        services.AddSingleton<GaragesStore>(provider => new GaragesStore(
            provider.GetRequiredService<ICreateCommand<Garage>>(),
            provider.GetRequiredService<IUpdateCommand<Garage>>(),
            new DeleteGarageCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<Garage>>()
        ));

        services.AddSingleton<ICreateCommand<MapInfo>, CreatePositionCommand>();
        services.AddSingleton<IUpdateCommand<MapInfo>, UpdatePositionCommand>();
        services.AddSingleton<IGetAllQuery<MapInfo>, GetAllMapInfos>();
        services.AddSingleton<GarageMapInfoStore>(provider => new GarageMapInfoStore(
            provider.GetRequiredService<ICreateCommand<MapInfo>>(),
            provider.GetRequiredService<IUpdateCommand<MapInfo>>(),
            new DeletePositionCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<MapInfo>>()
        ));

        services.AddSingleton<ICreateCommand<GarageBlock>, CreateGarageBlockCommand>();
        services.AddSingleton<IUpdateCommand<GarageBlock>, UpdateGarageBlockCommand>();
        services.AddSingleton<IGetAllQuery<GarageBlock>, GetAllGarageBlocks>();
        services.AddSingleton<GarageBlockStore>(provider => new GarageBlockStore(
            provider.GetRequiredService<ICreateCommand<GarageBlock>>(),
            provider.GetRequiredService<IUpdateCommand<GarageBlock>>(),
            new DeleteGarageBlockCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<GarageBlock>>()
        ));

        services.AddSingleton<ICreateCommand<Map>, CreateMapCommand>();
        services.AddSingleton<IUpdateCommand<Map>, UpdateMapCommand>();
        services.AddSingleton<IGetAllQuery<Map>, GetAllMaps>();
        services.AddSingleton<MapsStore>(provider => new MapsStore(
            provider.GetRequiredService<ICreateCommand<Map>>(),
            provider.GetRequiredService<IUpdateCommand<Map>>(),
            new DeleteMapCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<Map>>()
        ));

        services.AddSingleton<ICreateCommand<Contribution>, CreateContributionCommand>();
        services.AddSingleton<IUpdateCommand<Contribution>, UpdateContributionCommand>();
        services.AddSingleton<IGetAllQuery<Contribution>, GetAllContributions>();
        services.AddSingleton<ContributionsStore>(provider => new ContributionsStore(
            provider.GetRequiredService<ICreateCommand<Contribution>>(),
            provider.GetRequiredService<IUpdateCommand<Contribution>>(),
            new DeleteContributionCommand(provider.GetRequiredService<GarageAdministrationDbContextFactory>()),
            provider.GetRequiredService<IGetAllQuery<Contribution>>()
        ));

        services.AddSingleton<GarageMapSearchTextStore>();
        services.AddSingleton<SelectedMapStore>();
        services.AddSingleton<GarageMapSelectedFilterStore>();
        
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
            viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));

        return services.BuildServiceProvider();
    }
}