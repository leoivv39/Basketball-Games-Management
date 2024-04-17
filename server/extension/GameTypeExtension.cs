using main.dto;
using main.domain;

namespace main.extension;

public static class GameTypeExtension
{
    private static readonly Dictionary<string, GameType> StrToGameType = new()
    {
        { "REGULAR_SEASON", GameType.RegularSeason },
        { "FIRST_ROUND", GameType.FirstRound },
        { "CONFERENCE_SEMIFINALS", GameType.ConferenceSemifinals },
        { "CONFERENCE_FINALS", GameType.ConferenceFinals },
        { "FINALS", GameType.Finals },
    };

    private static readonly Dictionary<GameType, string> GameTypeToStr =
        StrToGameType.ToDictionary(x => x.Value, x => x.Key);
    
    public static GameType Parse(string value)
    {
        return StrToGameType.TryGetValue(value, out var type) ? type : (GameType) Enum.Parse(typeof(GameType), value, true);
    }

    public static string? ParseToString(this GameType gameType)
    {
        return GameTypeToStr.GetValueOrDefault(gameType);
    }
}