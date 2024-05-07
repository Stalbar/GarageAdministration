namespace GarageAdministration.Domain.Models;

public class Contribution
{
    public int Id { get; }
    public decimal MembershipFee { get; }
    public decimal WaterFee { get; }
    public Garage Garage { get; }

    public Contribution(int id, decimal membershipFee, decimal waterFee, Garage garage)
    {
        Id = id;
        MembershipFee = membershipFee;
        WaterFee = waterFee;
        Garage = garage;
    }
}