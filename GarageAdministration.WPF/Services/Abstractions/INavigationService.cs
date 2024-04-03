using GarageAdministration.WPF.Commons;

namespace GarageAdministration.WPF.Services.Abstractions;

public interface INavigationService
{
    ViewModelBase CurrentView { get; }
    void NavigateTo<T>() where T : ViewModelBase;
}