using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armory.Squadrons.Domain;

namespace Armory.Squadrons.Application.SearchAll
{
    public class SquadronsSearcher
    {
        private readonly ISquadronsRepository _repository;

        public SquadronsSearcher(ISquadronsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SquadronResponse>> SearchAll()
        {
            var squadrons = await _repository.SearchAll();
            return squadrons.Select(SquadronResponse.FromAggregate);
        }
    }
}
