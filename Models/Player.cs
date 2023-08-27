namespace Scorecard.Models;
public class Player
{
    public string Name { get; set; }
    public Dictionary<int, int> Strokes { get; set; }
    public Dictionary<int, int> Stableford { get; set; }
    public double Hcp { get; set; }
    public int CourseHcp { get; init; }
    public Player(string name, double hcp, int courseHcp)
    {
        Name = name;
        Hcp = hcp;
        CourseHcp = courseHcp;
        Strokes= new();
        Stableford = new();
    }


}