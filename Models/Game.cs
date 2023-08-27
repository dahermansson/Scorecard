using Scorecard.ViewModels;

namespace Scorecard.Models;
public class Game
{
    public List<Player> Players { get; set; }
    public Course Course { get; set; }
    public Guid GameId { get; set; }
    public string GameName { get; set; }
    public DateTime Created { get; set; }
    public Game()
    {

    }

    public Game(Course course, List<PlayerVM> playerVMs)
    {
        Course = course;
        Players = playerVMs.Select(p => new Player(p.Name, p.Hcp!.Value, p.CourseHcp)).ToList();
        GameId = Guid.NewGuid();
        Created= DateTime.Now;
        GameName = $"{Course.Name} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} {Players.Count} Players";
    }
}
