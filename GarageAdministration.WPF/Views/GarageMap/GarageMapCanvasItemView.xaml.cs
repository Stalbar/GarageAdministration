using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Forms.Application;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace GarageAdministration.WPF.Views.GarageMap;

public partial class GarageMapCanvasItemView : UserControl
{
    public GarageMapCanvasItemView()
    {
        InitializeComponent();
    }
    
    private void Icon_OnMouseEnter(object sender, MouseEventArgs e)
    {
        Popup.IsOpen = true;
    }

    private void Icon_OnMouseLeave(object sender, MouseEventArgs e)
    {
        Popup.IsOpen = false;   
    }
}