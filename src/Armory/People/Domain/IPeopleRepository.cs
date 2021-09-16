using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Armory.People.Domain
{
    public interface IPeopleRepository
    {
        Task Save(Person person);

        Task<Person> Find(string personId, bool noTracking);
        Task<Person> Find(string personId);
        Task<Person> FindByArmoryUserId(string armoryUserId, bool noTracking);
        Task<Person> FindByArmoryUserId(string armoryUserId);

        Task<IEnumerable<Person>> SearchAll(bool noTracking);
        Task<IEnumerable<Person>> SearchAll();
        Task<IEnumerable<Person>> SearchAllByRole(string roleName, bool noTracking);
        Task<IEnumerable<Person>> SearchAllByRole(string roleName);
        Task<IEnumerable<Person>> SearchAllByRank(string rankName);
        Task<bool> Any(Expression<Func<Person, bool>> predicate);

        Task Update(Person newPerson);
        Task Delete(Person person);
    }
}
