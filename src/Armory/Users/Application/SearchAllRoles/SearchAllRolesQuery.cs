using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.SearchAllRoles
{
    public class SearchAllRolesQuery : Query<IEnumerable<ArmoryRoleResponse>>
    {
    }
}
