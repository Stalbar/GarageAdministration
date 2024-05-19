using GarageAdministration.Infrastracture.Enums;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Services.Implementations.Filters;

public class GarageMapElectricityFeeFilter: IFilter<GarageMapCanvasItemViewModel>
{
    public IEnumerable<GarageMapCanvasItemViewModel> ApplyFilter(IEnumerable<GarageMapCanvasItemViewModel> sequence)
    {
        return sequence.Where(g => g.Garage.Contribution.ElectricityFeePaymentStatus == PaymentStatus.NotPaid);
    }

    public override string ToString() => "Не выплачено электричество";
}