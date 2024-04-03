using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateOwner;
using GarageAdministration.WPF.ViewModels.Home;
using GarageAdministration.WPF.ViewModels.MainWindow;
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

        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
            viewModelType => (ViewModelBase)provider.GetRequiredService(viewModelType));
        
        return services.BuildServiceProvider();
    }
}