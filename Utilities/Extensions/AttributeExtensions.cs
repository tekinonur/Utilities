using System.ComponentModel.DataAnnotations.Schema;

namespace Utilities.Extensions;

public static class AttributeExtensions
{
    public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
    {
        var att = type.GetCustomAttributes(
            typeof(TAttribute), true
        ).FirstOrDefault() as TAttribute;

        if (att != null)
            return valueSelector(att);

        return default;
    }

    /// <summary>
    /// Table attribute dolu ise oradaki değeri döner.
    /// Boş ise class ismini döner
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetTableName<T>()
    {
        var dnAttribute = typeof(T)
            .GetCustomAttributes(typeof(TableAttribute), true)
            .FirstOrDefault() as TableAttribute;

        if (dnAttribute != null)
            return dnAttribute.Name;

        return typeof(T).FullName;
    }
}