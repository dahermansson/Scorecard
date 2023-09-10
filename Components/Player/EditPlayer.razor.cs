using Microsoft.AspNetCore.Components;
using Scorecard.Models;
using Scorecard.Services;
using Scorecard.ViewModels;

namespace Scorecard.Components.Player;
public partial class EditPlayer
{
    [Parameter]
    public EventCallback<PlayerVM> OnPlayerAdded { get; set; }
    [Inject]
    private IPersonService personService { get; set; } = default!;
    private PlayerVM Player { get; set; } = new();
    [Parameter]
    public Ratings Ratings { get; set; } = default!;
    private bool IsValid => !string.IsNullOrWhiteSpace(Player.Name) && !string.IsNullOrEmpty(Player.Gender) && !string.IsNullOrEmpty(Player.Tee);
    private List<Person> Persons { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Persons = await personService.GetPersons();
    }

    private void AddPlayer()
    {
        OnPlayerAdded.InvokeAsync(Player);
        Player = new();
    }

    private void LoadPlayer(ChangeEventArgs changeEventArgs)
    {
        var selectedPlayer = Persons.SingleOrDefault(t => t.Name == changeEventArgs.Value as string);
        if (selectedPlayer != null)
        {
            Player.Name = selectedPlayer.Name;
            Player.Gender = selectedPlayer.Gender;
            Player.Hcp = selectedPlayer.Hcp;
        }
    }
}
