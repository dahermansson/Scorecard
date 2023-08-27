using Microsoft.AspNetCore.Components;
using Scorecard.Services;

namespace Scorecard.Pages;
public partial class Games
{
    [Inject]
    private IRoundSetupService RoundSetupService { get; set; } = default!;
    public List<(string Game, Guid GameId)> SavedGames { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        SavedGames = await RoundSetupService.GetGames();
    }
}
