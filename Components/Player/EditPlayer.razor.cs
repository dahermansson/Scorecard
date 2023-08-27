using Microsoft.AspNetCore.Components;
using Scorecard.Models;
using Scorecard.ViewModels;

namespace Scorecard.Components.Player;
public partial class EditPlayer
{
    [Parameter]
    public EventCallback<PlayerVM> OnPlayerAdded { get; set; }
    private PlayerVM Player { get; set; } = new();
    [Parameter]
    public Ratings Ratings { get; set; } = default!;
    private bool IsValid => !string.IsNullOrWhiteSpace(Player.Name) && !string.IsNullOrEmpty(Player.Gender) && !string.IsNullOrEmpty(Player.Tee);
    private void AddPlayer()
    {
        OnPlayerAdded.InvokeAsync(Player);
        Player = new();
    }
}
