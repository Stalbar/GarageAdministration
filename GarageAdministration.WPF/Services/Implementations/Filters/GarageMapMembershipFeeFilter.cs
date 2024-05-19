using GarageAdministration.Infrastracture.Enums;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Services.Implementations.Filters;

public class GarageMapMembershipFeeFilter: IFilter<GarageMapCanvasItemViewModel>
{
    public IEnumerable<GarageMapCanvasItemViewModel> ApplyFilter(IEnumerable<GarageMapCanvasItemViewModel> sequence)
    {
        return sequence.Where(g => g.Garage.Contribution.MembershipFeePaymentStatus == PaymentStatus.NotPaid);
    }

    public override string ToString() => "Не заплачен членский взнос";
}