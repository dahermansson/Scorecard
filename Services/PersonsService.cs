using Blazored.LocalStorage;
using Scorecard.Models;
using System;

namespace Scorecard.Services;

public class PersonsService : IPersonService
{
    private readonly ILocalStorageService _localStorage;

    private readonly static string PersonsIndexKey = "Persons";

    public PersonsService(ILocalStorageService localStorageService)
    {
          _localStorage = localStorageService;
    }

    public async Task<List<Person>> GetPersons()
    {
        return (await _localStorage.GetItemAsync<List<Person>>(PersonsIndexKey)) ?? new List<Person>();
    }
    public async Task CreatePerson(Person person)
    {
        var persons = await GetPersons();
        var currentPerson = persons.SingleOrDefault(t => t.Name == person.Name);
        if(currentPerson != null)
        {
            persons.Remove(currentPerson);
        }

        persons.Add(person);
        await _localStorage.SetItemAsync<List<Person>>(PersonsIndexKey, persons);
    }

    public async Task DeletePerson(string name)
    {
        var persons = await GetPersons();
        var currentPerson = persons.SingleOrDefault(t => t.Name == name);
        if (currentPerson != null)
        {
            persons.Remove(currentPerson);
        }
        await _localStorage.SetItemAsync<List<Person>>(PersonsIndexKey, persons);
    }
}
