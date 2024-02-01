using Utilities.Models;

namespace Utilities.Helpers;

public static class CoordinateHelper
{
    public static double DegreeToRadian(double degree)
    {
        return degree * Math.PI / 180;
    }

    /// <summary>
    /// KM sonuç
    /// </summary>
    /// <param name="coord1"></param>
    /// <param name="coord2"></param>
    /// <returns></returns>
    public static double CalculateDistance(GeoCordinate coord1, GeoCordinate coord2)
    {
        const double EarthRadius = 6371; // Earth's radius in kilometers

        double dLat = DegreeToRadian(coord1.Latitude - coord2.Latitude);
        double dLon = DegreeToRadian(coord1.Longitude - coord2.Longitude);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(DegreeToRadian(coord2.Latitude)) * Math.Cos(DegreeToRadian(coord1.Latitude)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        double distance = EarthRadius * c;

        return distance;
    }

    public static double CalculateDistance(double coord1Lat, double cood1Long, double cord2Lat, double coord2Long)
    {
        const double EarthRadius = 6371; // Earth's radius in kilometers

        double dLat = CoordinateHelper.DegreeToRadian(coord1Lat - cord2Lat);
        double dLon = CoordinateHelper.DegreeToRadian(cood1Long - coord2Long);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(CoordinateHelper.DegreeToRadian(cord2Lat)) * Math.Cos(CoordinateHelper.DegreeToRadian(coord1Lat)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        double distance = EarthRadius * c;

        return distance;
    }
}