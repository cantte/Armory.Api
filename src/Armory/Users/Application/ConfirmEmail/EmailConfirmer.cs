using System.Threading.Tasks;
using Armory.Shared.Domain;
using Armory.Users.Domain;

namespace Armory.Users.Application.ConfirmEmail
{
    public class EmailConfirmer
    {
        private readonly IArmoryUserRepository _repository;

        public EmailConfirmer(IArmoryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task ConfirmEmail(string usernameOrEmail, string token)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                throw new ArmoryUserNotFound();
            }

            var result = await _repository.ConfirmEmail(user, Utils.Base64ToString(token));
            if (!result.Succeeded)
            {
                throw new EmailNotConfirmed(result.Errors);
            }
        }
    }
}