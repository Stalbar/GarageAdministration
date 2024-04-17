using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using UserControl = System.Windows.Controls.UserControl;

namespace GarageAdministration.WPF.Views.GarageMap;

public partial class GarageMapCanvasItemView : UserControl
{
    public GarageMapCanvasItemView()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("hee");
    }
}