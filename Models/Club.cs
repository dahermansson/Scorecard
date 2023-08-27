using System.Net;

namespace Scorecard.Models;

public class Club
{
    public string Name { get; set; }
    public string ID { get; set; }
    public List<Course> Courses { get; set; }

}