using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using GarageAdministration.Infrastracture.Classes;
using GarageAdministration.Infrastracture.Extensions;

namespace GarageAdministration.WPF.Commons.Converters;

[ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
public class EnumToCollectionConverter: MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        EnumExtension.GetAllValueDescriptions(value.GetType());

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
}