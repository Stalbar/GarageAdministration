using System.Windows;
using System.Windows.Controls;

namespace GarageAdministration.WPF.Views.OwnersList;

public partial class OwnersListView : UserControl
{
    public OwnersListView()
    {
        InitializeComponent();
    }

    private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        var listView = sender as ListView;
        var gridView = listView!.View as GridView;
        var width = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
        const double col1 = 0.1;
        const double col2 = 0.1;
        const double col3 = 0.1;
        const double col4 = 0.1;
        const double col5 = 0.15;
        const double col6 = 0.15;
        const double col7 = 0.15;
        const double col8 = 0.15;
        gridView!.Columns[0].Width = width * col1;
        gridView!.Columns[1].Width = width * col2;
        gridView!.Columns[2].Width = width * col3;
        gridView!.Columns[3].Width = width * col4;
        gridView!.Columns[4].Width = width * col5;
        gridView!.Columns[5].Width = width * col6;
        gridView!.Columns[6].Width = width * col7;
        gridView!.Columns[7].Width = width * col8;
    }
}