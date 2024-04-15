using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel: ViewModelBase
{
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public GarageMapViewModel(GaragesStore garagesStore)
    {
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore);
    }
}