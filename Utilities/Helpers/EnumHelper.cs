using System.ComponentModel;
using System.Reflection;

namespace Utilities.Helpers;

public static class EnumHelper
{
    public static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new Random().Next(v.Length));
    }

    public static string GetDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}
