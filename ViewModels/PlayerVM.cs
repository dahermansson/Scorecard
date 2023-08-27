namespace Scorecard.ViewModels;
public class PlayerVM
{
    public string Name { get; set; } = string.Empty;
    public double? Hcp { get; set; }
    public string Tee { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public int CourseHcp { get; set; } = 0;
}
