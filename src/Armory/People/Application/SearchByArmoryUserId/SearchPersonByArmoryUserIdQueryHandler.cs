using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchByArmoryUserId
{
    public class SearchPersonByArmoryUserIdQueryHandler : IQueryHandler<SearchPersonByArmoryUserIdQuery, PersonResponse>
    {
        private readonly PersonByArmoryUserIdSearcher _searcher;

        public SearchPersonByArmoryUserIdQueryHandler(PersonByArmoryUserIdSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<PersonResponse> Handle(SearchPersonByArmoryUserIdQuery query)
        {
            return await _searcher.SearchByArmoryUserId(query.ArmoryUserId);
        }
    }
}