using System.ComponentModel;
using System.Reflection;

namespace Utilities.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo field = type.GetField(name);
            if (field != null)
            {
                DescriptionAttribute attr =
                       Attribute.GetCustomAttribute(field,
                         typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        return null;
    }

    public static string GetDescription<T>(this T value)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name != null)
        {
            FieldInfo field = type.GetField(name);
            if (field != null)
            {
                DescriptionAttribute attr =
                       Attribute.GetCustomAttribute(field,
                         typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
        }
        return value.ToString();
    }

    public static T GetEnumByDescription<T>(this string desc)
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .FirstOrDefault(v => v.GetDescription() == desc);
    }

    public static int ToInt(this Enum enuma)
    {
        return Convert.ToInt32(enuma);
    }
}