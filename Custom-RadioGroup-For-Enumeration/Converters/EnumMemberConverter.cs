using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Custom_RadioGroup_For_Enumeration.Converters
{
    public class EnumMemberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
                return null;
            if (value is Enum enumValue)
            {
                return GetEnumMemberValue(enumValue);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value as string;

            // Handle nullable enums
            var actualEnumType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (stringValue != null)
            {
                foreach (Enum enumValue in Enum.GetValues(actualEnumType))
                {
                    if (GetEnumMemberValue(enumValue) == stringValue)
                    {
                        return enumValue;
                    }
                }
            }

            // In case of nullable enum, you can return null if you couldn't find a match
            if (Nullable.GetUnderlyingType(targetType) != null)
            {
                return null;
            }

            // If it's not a nullable enum, and we couldn't find the matching enum value, throw an exception
            throw new ArgumentException($"Cannot convert '{stringValue}' to an enum of type {actualEnumType}.");
        }

        private string GetEnumMemberValue(Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo fieldInfo = type.GetField(enumValue.ToString());
            EnumMemberAttribute attribute = fieldInfo.GetCustomAttribute<EnumMemberAttribute>();
            return attribute?.Value ?? enumValue.ToString();
        }
    }
}
