using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Armory.Users.Domain
{
    public interface IArmoryUsersRepository
    {
        Task<IdentityResult> Save(ArmoryUser user, string password);
        Task<ArmoryUser> FindByUsernameOrEmail(string usernameOrEmail);
        Task<SignInResult> Authenticate(ArmoryUser user, string password, bool isPersistent);
        Task<string> GeneratePasswordResetToken(ArmoryUser user);
        Task<IdentityResult> ResetPassword(ArmoryUser user, string token, string newPassword);
        Task<IdentityResult> ChangePassword(ArmoryUser user, string oldPassword, string newPassword);
        Task<string> GenerateEmailConfirmationToken(ArmoryUser user);
        Task<IdentityResult> ConfirmEmail(ArmoryUser user, string token);
        Task Logout();

        Task<IEnumerable<ArmoryUser>> SearchAllUsersInRole(string roleName);
        Task<IEnumerable<ArmoryRole>> SearchAllRoles();
        Task<IEnumerable<string>> SearchAllUserRoles(ArmoryUser user);

        Task<IdentityResult> AddToRole(ArmoryUser user, string roleName);
        Task<bool> Any(Expression<Func<ArmoryUser, bool>> predicate);
    }
}
