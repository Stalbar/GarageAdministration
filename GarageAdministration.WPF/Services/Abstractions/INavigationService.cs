using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.Services.Abstractions;

public interface INavigationService
{
    ViewModelBase CurrentView { get; }
    void NavigateTo<T>() where T : ViewModelBase;

    void NavigateTo(ViewModelBase viewModel);
}