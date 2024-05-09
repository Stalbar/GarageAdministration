using System.ComponentModel;
using System.Globalization;
using GarageAdministration.Infrastracture.Classes;

namespace GarageAdministration.Infrastracture.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var attributes = value.GetType().GetField(value.ToString())!
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Any())
        {
            return (attributes.First() as DescriptionAttribute)!.Description;
        }

        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(textInfo.ToLower(value.ToString().Replace("_", " ")));
    }

    public static IEnumerable<ValueDescription> GetAllValueDescriptions(Type t)
    {
        if (!t.IsEnum)
        {
            throw new ArgumentException($"{nameof(t)} must be an enum type");
        }

        return Enum.GetValues(t).Cast<Enum>()
            .Select((e) => new ValueDescription() { Value = e, Description = e.GetDescription() }).ToList();
    }
}