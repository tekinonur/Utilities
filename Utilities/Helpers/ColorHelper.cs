using System.Text.RegularExpressions;

namespace Utilities.Helpers;

public static class ColorHelper
{
    public static bool IsValidHexColor(string colorCode)
    {
        // Regular expression to match a valid hex color code
        string hexColorPattern = @"^#(?:[0-9a-fA-F]{3}){1,2}$";

        return !string.IsNullOrEmpty(colorCode) && Regex.IsMatch(colorCode, hexColorPattern);
    }
}