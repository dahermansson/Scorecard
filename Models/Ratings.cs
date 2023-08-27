namespace Scorecard.Models;

public class Ratings
{
    public Dictionary<string, Rating> Men { get; set; } = new();
    public Dictionary<string, Rating> Women { get; set; } = new();
    
}