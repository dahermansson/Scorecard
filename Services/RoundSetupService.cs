﻿using Blazored.LocalStorage;
using Scorecard.Models;
using Scorecard.ViewModels;
using System.Net.Http.Json;

namespace Scorecard.Services;
public class RoundSetupService : IRoundSetupService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    public Game? Game { get; set; }
    private readonly static string GamesIndexKey = "Games";
    public RoundSetupService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }
    
    public async ValueTask<List<ClubVM>> GetClubs()
    {
        return (await _httpClient.GetFromJsonAsync<ClubVM[]>($"data/clubs.json?{Guid.NewGuid()}")).ToList() ?? new List<ClubVM>();
    }

    public async Task<Club> GetClub(string id)
    {
        var club = await _httpClient.GetFromJsonAsync<Club>($"data/{id}.json?{Guid.NewGuid()}");
        return club;
    }

    public async Task<Guid> CreateGame(Club club, string courseId, List<PlayerVM> playerVMs)
    {
        var game = new Game(club.Courses.Single(t => t.ID == courseId), playerVMs);
        var games = await _localStorage.GetItemAsync<Dictionary<Guid, string>>(GamesIndexKey) ?? new Dictionary<Guid, string>();
        games.Add(game.GameId, game.GameName);
        await _localStorage.SetItemAsync(GamesIndexKey, games);
        await _localStorage.SetItemAsync(game.GameId.ToString(), game);
        return game.GameId;
    }

    public async Task SetGame(Game game)
    {
        await _localStorage.SetItemAsync(game.GameId.ToString(), game);
    }

    public async Task<Game> GetGame(Guid gameId)
    {
        return await _localStorage.GetItemAsync<Game>(gameId.ToString());
    }
    public async Task<List<(string Game, Guid GameId)>> GetGames()
    {
        return (await _localStorage.GetItemAsync<Dictionary<Guid, string>>(GamesIndexKey))?.Select(t => (Game: t.Value, GameId: t.Key)).ToList() ?? new List<(string Game, Guid GameId)>();   
    }

    public int CalculatePlayersCourseHcp(double hcp, int par, double cr, int sr) => (int)(hcp * (sr / 113.0) + (cr - par) + 0.5);

    public int GetStableford(int strokes, Hole hole, int courseHcp, int holes)
    {
        if (courseHcp == 0)
            return GetStableford(strokes, hole.Par);
        if(courseHcp > -1)
        {
            var strokesLeft = courseHcp;
            var givenStrokes = hole.Par;
            while(strokesLeft > 0)
            {
                if (strokesLeft >= hole.Index)
                    givenStrokes++;
                strokesLeft -= holes;
            }
            return GetStableford(strokes, givenStrokes);
        }
        if (courseHcp < 0)
        {
            int minIndexesTakenStrokes = holes + courseHcp;
            if (hole.Index >= minIndexesTakenStrokes)
                return GetStableford(strokes, hole.Par - 1);
            else
                return GetStableford(strokes, hole.Par);
        }
        return 0;
    }

    private int GetStableford(int strokes, int givenStrokes)
    {
        return new[] { 0, 2 + givenStrokes - strokes }.Max();   
    }

    public async Task DeleteGame(Guid gameId)
    {
        var games = await _localStorage.GetItemAsync<Dictionary<Guid, string>>(GamesIndexKey) ?? new Dictionary<Guid, string>();
        games.Remove(gameId);
        await _localStorage.SetItemAsync(GamesIndexKey, games);
    }
}
