using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapCanvasBlockItemViewModel: ViewModelBase
{
    public GarageBlock GarageBlock { get; private set; }
    public double Top => GarageBlock.MapInfo.Top;
    public double Left => GarageBlock.MapInfo.Left;
    public double Width => GarageBlock.MapInfo.Width;
    public double Height => GarageBlock.MapInfo.Height;
    public double Angle => GarageBlock.MapInfo.Angle;
    public double ZIndex => GarageBlock.MapInfo.ZIndex;

    public ICommand IconCommand { get; }
    public ICommand DeleteCommand { get; }
    
    public GarageMapCanvasBlockItemViewModel(GarageBlock garageBlock, GarageBlockStore garageBlockStore, INavigationService navigation, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore)
    {
        GarageBlock = garageBlock;
        DeleteCommand = new DeleteBlockCommand(garageBlockStore, this, navigation);
        IconCommand = new NavigateToEditGarageBlockCommand(navigation, this, garageBlockStore, garagesStore, garageMapInfoStore, DeleteCommand);
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