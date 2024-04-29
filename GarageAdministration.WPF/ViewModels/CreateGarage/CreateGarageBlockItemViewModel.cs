using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageBlockItemViewModel: ViewModelBase
{
    public GarageBlock GarageBlock { get; private set; }

    public double Top => GarageBlock.MapInfo.Top;
    public double Left => GarageBlock.MapInfo.Left;
    public double Width => GarageBlock.MapInfo.Width;
    public double Height => GarageBlock.MapInfo.Height;
    public double Angle => GarageBlock.MapInfo.Angle;
    public double ZIndex => GarageBlock.MapInfo.ZIndex;

    public CreateGarageBlockItemViewModel(GarageBlock garageBlock)
    {
        GarageBlock = garageBlock;
    }

    public void Update(GarageBlock garageBlock)
    {
        GarageBlock = garageBlock;
        OnPropertyChanged(nameof(Top));
        OnPropertyChanged(nameof(Left));
        OnPropertyChanged(nameof(Width));
        OnPropertyChanged(nameof(Height));
        OnPropertyChanged(nameof(Angle));
        OnPropertyChanged(nameof(ZIndex));
    }
}