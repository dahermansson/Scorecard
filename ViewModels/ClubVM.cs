namespace Scorecard.ViewModels;
public record ClubVM
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public List<CourseVM>? Courses { get; set; }
}

public record CourseVM
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}
