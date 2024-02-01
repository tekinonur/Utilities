namespace Utilities.Models;

/// <summary>
/// https://countrycode.org/
/// Bura resferans alınarak dolduralabilir
/// </summary>
public class Country
{
    public int Id { get; set; }
    public int CountryCode { get; set; }
    public string IsoCode { get; set; }
    public string Name { get; set; }
}
