using Microsoft.AspNetCore.Components;
using Scorecard.Models;
using Scorecard.Services;
using Scorecard.ViewModels;

namespace Scorecard.Pages;
public partial class Index
{
    [Inject]
    private IRoundSetupService RoundSetupService { get; set; } = default!;
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;
    private List<ClubVM> Clubs {get; set;} = default!;
    private Club? Club { get; set;}

    private string SelectedClub { get; set; } = "";
    private string SelectedCourse { get; set; } = "";

    private List<PlayerVM> Players { get; } = new List<PlayerVM>();
    
    protected override async Task OnInitializedAsync()
    {
        Clubs = await RoundSetupService.GetClubs();
    }

    private async Task OnClubChange(ChangeEventArgs changEventArgs)
    {
        if (changEventArgs != null)
        {
            SelectedClub = changEventArgs.Value.ToString();
            Club = await RoundSetupService.GetClub(SelectedClub);
        }
    }

    private async Task OnCourseChange(ChangeEventArgs changEventArgs)
    {
        if (changEventArgs != null && changEventArgs.Value is string)
        {
            SelectedCourse = changEventArgs.Value.ToString();
        }
        await Task.CompletedTask;
    }

    private void AddPlayer(PlayerVM playerVM)
    {
        var course = Club!.Courses.Single(t => t.ID == SelectedCourse);
        var rating = playerVM.Gender == "men" ? course.Ratings.Men[playerVM.Tee] : course.Ratings.Women[playerVM.Tee];
        playerVM.CourseHcp = RoundSetupService.CalculatePlayersCourseHcp(playerVM.Hcp.Value, course.Par,
            rating.CR!.Value, rating.SR!.Value!);
        Players.Add(playerVM);
    }

    private async Task CreateGame()
    {
        if (Club != null)
        {
            var createdGameId = await RoundSetupService.CreateGame(Club, SelectedCourse, Players);
            NavigationManager.NavigateTo($"/game/{createdGameId}");
        }
    }
    private void RemovePlayer(string name)
    {
        Players.Remove(Players.First(t => t.Name == name));
    }
}
