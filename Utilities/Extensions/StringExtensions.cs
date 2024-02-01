namespace Utilities.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string val)
    {
        return new Guid(val);
    }

    public static bool IsNotNullOrEmpty(this string val)
    {
        return string.IsNullOrEmpty(val) ? false : true;
    }

    public static bool IsNullOrEmpty(this string val)
    {
        return string.IsNullOrEmpty(val) ? true : false;
    }

    public static bool IsValidDouble(this string val)
    {
        return double.TryParse(val, out double d) &&
               !(double.IsNaN(d) || double.IsInfinity(d));
    }

    public static string RemoveAllWhitespaces(this string input)
    {
        return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
    }
}