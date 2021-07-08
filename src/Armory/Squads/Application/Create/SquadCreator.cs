using System.Threading.Tasks;
using Armory.Squads.Domain;

namespace Armory.Squads.Application.Create
{
    public class SquadCreator
    {
        private readonly ISquadRepository _repository;

        public SquadCreator(ISquadRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(string code, string name, string personId, string squadronCode)
        {
            var squad = Squad.Create(code, name, personId, squadronCode);
            await _repository.Save(squad);
        }
    }
}