using main.dto;
using main.domain;

namespace main.extension;

public static class CityExtension
{
    private static readonly Dictionary<string, City> StrToCity = new()
    {
        { "LOS_ANGELES", City.LosAngeles },
        { "NEW_YORK", City.NewYork },
        { "CHICAGO", City.Chicago },
        { "BOSTON", City.Boston },
        { "PHILADELPHIA", City.Philadelphia },
        { "UTAH", City.Utah },
        { "SAN_ANTONIO", City.SanAntonio },
        { "CLEVELAND", City.Cleveland },
        { "MIAMI", City.Miami }
    };

    private static readonly Dictionary<City, string> CityToStr = StrToCity.ToDictionary(x => x.Value, x => x.Key);
    public static City Parse(string value)
    {
        return StrToCity.TryGetValue(value, out var city) ? city : (City) Enum.Parse(typeof(City), value, true);
    }

    public static string? ParseToString(this City city)
    {
        return CityToStr.GetValueOrDefault(city);
    }
}
