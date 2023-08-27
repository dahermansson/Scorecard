using Scorecard.Models;
using Scorecard.ViewModels;

namespace Scorecard.Services;
public interface IRoundSetupService
{
    public Task<Guid> CreateGame(Club club, string courseId, List<PlayerVM> playerVMs);
    public ValueTask<List<ClubVM>> GetClubs();
    public Task<Game> GetGame(Guid gameId);
    public Task<Club> GetClub(string id);
    public int CalculatePlayersCourseHcp(double hcp, int par, double cr, int sr);
    public int GetStableford(int strokes, Hole hole, int courseHcp, int holes);
}