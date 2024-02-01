namespace Utilities.Helpers;

public static class DateTimeHelper
{
    public static DateTime RandomDay(DateTime start, DateTime end)
    {
        int range = (end - start).Days;
        return start.AddDays(new Random().Next(range));
    }

    public static string GetDifferenceStringBetweenDate(DateTime start, DateTime end)
    {
        TimeSpan difference = end - start;
        if (difference.TotalMinutes <= 1)
            return $"Az önce";
        if (difference.TotalMinutes < 60)
            return $"{(int)difference.TotalMinutes} dakika önce";
        if (difference.TotalHours < 24)
            return $"{(int)difference.TotalHours} saat önce";
        if (difference.TotalDays < 30)
            return $"{(int)difference.TotalDays} gün önce";
        if (difference.TotalDays / 365 < 1)
            return $"{(int)difference.TotalDays / 30} ay önce";
        return $"{(int)difference.TotalDays / 365} yıl önce";
    }

    /// <summary>
    /// Local,Kind date'i unspesified a çeviriyor. +3 local damgası atmasın diye date'e
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime GetUnspecifiedDateTime(DateTime dt)
    {
        return new DateTime(dt.Ticks);
    }
}