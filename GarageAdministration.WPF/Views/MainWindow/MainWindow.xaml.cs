using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GarageAdministration.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    
    private void PanelControlBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var helper = new WindowInteropHelper(this);
        SendMessage(helper.Handle, 161, 2, 0);
    }

    private void PanelControlBar_OnMouseEnter(object sender, MouseEventArgs e)
    {
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }

    private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void ButtonMaximize_OnClick(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
    }
}