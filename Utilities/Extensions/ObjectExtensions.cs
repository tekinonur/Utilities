using System.Text.Json;

namespace Utilities.Extensions;

public static class ObjectExtensions
{
    private static Random _R = new Random();

    public static void ThrowIfNull<T>(this T @object, string paramName)
    {
        if (@object == null)
        {
            throw new ArgumentNullException(paramName, $"Parameter {paramName} cannot be null.");
        }
    }

    public static bool IsNotNullOrEmpty(this Guid guid)
    {
        return guid == Guid.Empty ? false : true;
    }

    public static bool IsNullOrEmpty(this Guid guid)
    {
        return guid == Guid.Empty ? true : false;
    }

    public static bool IsNotNullOrEmpty(this Guid? guid)
    {
        return guid == null || guid == Guid.Empty ? false : true;
    }

    public static bool IsNullOrEmpty(this Guid? guid)
    {
        return guid == null || guid == Guid.Empty ? true : false;
    }

    public static T GetRandomElement<T>(this T[] arr)
    {
        return arr[_R.Next(0, arr.Length)];
    }

    public static T GetRandomElement<T>(this List<T> list)
    {
        return list[_R.Next(0, list.Count)];
    }

    public static List<T> GetRandomElements<T>(this List<T> list)
    {
        int n = _R.Next(0, list.Count);
        List<T> shuffledList = new List<T>(list);
        int lastIndex = shuffledList.Count - 1;

        for (int i = 0; i < lastIndex; i++)
        {
            int randomIndex = _R.Next(i, lastIndex + 1);
            T temp = shuffledList[i];
            shuffledList[i] = shuffledList[randomIndex];
            shuffledList[randomIndex] = temp;
        }

        List<T> uniqueRandomSelection = shuffledList.GetRange(0, n);

        return uniqueRandomSelection;
    }
}