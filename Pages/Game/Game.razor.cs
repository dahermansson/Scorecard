using Microsoft.AspNetCore.Components;
using Scorecard.Models;
using Scorecard.Services;

namespace Scorecard.Pages.Game;
public partial class Game
{
    [Parameter]
    public Guid GameId { get; set; }

    [Inject]
    private IRoundSetupService GameService { get; set; } = default!;

    private Models.Game ActiveGame { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        ActiveGame = await GameService.GetGame(GameId);
    }

    private void SetStroke(Player player, object? value, int hole)
    {
        if (value != null && int.TryParse(value.ToString(), out int strokes) && strokes > 0)
        {
            player.Strokes[hole] = strokes;
            player.Stableford[hole] = GameService.GetStableford(strokes, ActiveGame.Course.Holes[hole], player.CourseHcp, ActiveGame.Course.Holes.Count);
        }
        else
        {
            player.Strokes.Remove(hole);
            player.Stableford.Remove(hole);
        }
    }

    private void SetStableford(Player player, int hole, int strokes)
    {
        var index = ActiveGame.Course.Holes[hole].Index;
    }
}
