using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Services.Implementations.Filters;

public class GarageMapNoFilter: IFilter<GarageMapCanvasItemViewModel>
{
    public IEnumerable<GarageMapCanvasItemViewModel> ApplyFilter(IEnumerable<GarageMapCanvasItemViewModel> sequence)
    {
        return sequence;
    }

    public override string ToString() => "Без фильтра";
}