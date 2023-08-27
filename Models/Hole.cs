namespace Scorecard.Models;

public class Hole
{
    public int Par { get; set; } = default;
    public int Index { get; set; } = default;
    public Dictionary<string, int> Distances { get; set; } = new();
}
