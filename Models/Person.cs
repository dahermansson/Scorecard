namespace Scorecard.Models;
public class Person
{
    public string Name { get; set; }
    public double Hcp { get; set; }
    public string Gender { get; set; }
    public Person(string name, double hcp, string gender)
    {
        Name = name;
        Hcp = hcp;
        Gender = gender;
    }
}
