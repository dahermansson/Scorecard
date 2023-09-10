using Microsoft.AspNetCore.Components;
using Scorecard.Models;
using Scorecard.Services;

namespace Scorecard.Pages;
public partial class Players
{
    [Inject]
    private IPersonService PersonService { get; set; } = default!;

    private List<Person> AllPlayers { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        AllPlayers = await PersonService.GetPersons();
    }

    protected async Task DeletePlayer(string name)
    {
        await PersonService.DeletePerson(name);
        AllPlayers = await PersonService.GetPersons();
    }
}
