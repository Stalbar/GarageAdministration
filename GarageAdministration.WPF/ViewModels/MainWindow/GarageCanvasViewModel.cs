using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;

namespace GarageAdministration.WPF.ViewModels.MainWindow;

public class GarageCanvasViewModel: ViewModelBase
{
    private readonly List<Garage> _garages = new List<Garage>()
    {
        new Garage(1, new Position(1, 150, 20)),
    };

    public IEnumerable<Garage> Garages => _garages;
    
}