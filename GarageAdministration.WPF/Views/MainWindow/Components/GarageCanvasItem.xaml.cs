using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GarageAdministration.WPF.Views.MainWindow.Components;

public partial class GarageCanvasItem : UserControl
{
    public GarageCanvasItem()
    {
        InitializeComponent();
    }

    protected override void OnMouseEnter(MouseEventArgs e)
    {
        base.OnMouseEnter(e);
        ContextMenu cm = (this.FindResource("cmCanvasItem") as ContextMenu)!;
        cm.PlacementTarget = this;
        cm.IsOpen = true;
    }
}