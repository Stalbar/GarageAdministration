using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.MainWindow;

public class GarageCanvasViewModel: ViewModelBase
{
    private readonly List<Garage> _garages = new List<Garage>()
    {
        
    };

    public IEnumerable<Garage> Garages => _garages;
    
}