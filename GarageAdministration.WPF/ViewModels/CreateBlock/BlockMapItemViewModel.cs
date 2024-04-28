using System.Windows.Media;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.ViewModels;

namespace GarageAdministration.WPF.ViewModels.CreateBlock;

public class BlockMapItemViewModel: ViewModelBase
{
    public GarageBlock GarageBlock { get; private set; }
    public double Top => GarageBlock.MapInfo.Top;
    public double Left => GarageBlock.MapInfo.Left;
    public double Width => GarageBlock.MapInfo.Width;
    public double Height => GarageBlock.MapInfo.Height;
    public double Angle => GarageBlock.MapInfo.Angle;
    
    public Brush IconColor { get; set; }

    public BlockMapItemViewModel(GarageBlock garageBlock, Brush color)
    {
        IconColor = color;
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
    }
}