namespace Scorecard.Models;

public class Course
{
    public string Name { get; set; }
    public string ID { get; set; }
    public int Par => Holes.Sum(t => t.Value.Par);
    public Ratings Ratings { get; set; }
    public Dictionary<int, Hole> Holes { get; set; }
    
}