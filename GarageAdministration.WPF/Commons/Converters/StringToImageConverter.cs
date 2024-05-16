using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GarageAdministration.WPF.Commons.Converters;

public class StringToImageConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value.GetType() != typeof(string))
        {
            throw new InvalidOperationException("Value must be string");
        }

        try
        {
            var fileName = (string)value;
            var fileInfo = new FileInfo(fileName);
            return new BitmapImage(new Uri(fileInfo.FullName));
        }
        catch
        {
            return null;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}