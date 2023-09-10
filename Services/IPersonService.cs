
using Scorecard.Models;

namespace Scorecard.Services;

public interface IPersonService
{
    Task<List<Person>> GetPersons();
    Task CreatePerson(Person person);
    Task DeletePerson(string name);
}
