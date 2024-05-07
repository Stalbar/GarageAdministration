namespace GarageAdministration.Domain.Models;

public class Contribution
{
    public int Id { get; }
    public decimal ElectricityFee { get; }
    public decimal MembershipFee { get; }
    public Garage Garage { get; }

    public Contribution(int id, decimal electricityFee, decimal membershipFee, Garage garage)
    {
        Id = id;
        ElectricityFee = electricityFee;
        MembershipFee = membershipFee;
        Garage = garage;
    }
}