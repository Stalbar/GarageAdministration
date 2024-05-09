using System.ComponentModel;

namespace GarageAdministration.Infrastracture.Enums;

public enum PaymentStatus
{
    [Description("Не оплачено")]
    NotPaid,
    [Description("Оплачено")]
    Paid
}