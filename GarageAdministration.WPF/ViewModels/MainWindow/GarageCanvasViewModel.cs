using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;

namespace GarageAdministration.WPF.ViewModels.MainWindow;

public class GarageCanvasViewModel: ViewModelBase
{
    private readonly List<Garage> _garages = new List<Garage>()
    {
        new Garage(new Position(150, 20)),
        new Garage(new Position(100, 50)),
        new Garage(new Position(70, 80)),
        new Garage(new Position(50, 20)),
        new Garage(new Position(89, 52)),
        new Garage(new Position(43, 150)),
        new Garage(new Position(200, 110)),
    };

    public IEnumerable<Garage> Garages => _garages;
    
}