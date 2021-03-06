using System.Threading.Tasks;
using Armory.Users.Domain;

namespace Armory.Users.Application.GenerateEmailConfirmationToken
{
    public class EmailConfirmationTokenGenerator
    {
        private readonly IArmoryUsersRepository _repository;

        public EmailConfirmationTokenGenerator(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenerateConfirmationTokenResponse> GenerateEmailConfirmationToken(string usernameOrEmail)
        {
            var user = await _repository.FindByUsernameOrEmail(usernameOrEmail);
            if (user == null)
            {
                return new GenerateConfirmationTokenResponse();
            }

            var token = await _repository.GenerateEmailConfirmationToken(user);
            return new GenerateConfirmationTokenResponse(token);
        }
    }
}
