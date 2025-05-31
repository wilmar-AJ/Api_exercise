using System.Globalization;
using Microsoft.Maui.Controls;

namespace Api_exercise.Converters;

public class DrinkNameFormatterConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string drinkName)
        {
            // Reemplaza guiones bajos con espacios y capitaliza correctamente
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string formattedName = textInfo.ToTitleCase(drinkName.Replace("_", " ").ToLower());

            // Remueve números y caracteres especiales
            formattedName = new string(formattedName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            return formattedName.Trim();
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
