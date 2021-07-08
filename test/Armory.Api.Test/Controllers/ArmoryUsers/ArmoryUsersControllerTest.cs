using System.Linq;
using System.Threading.Tasks;
using Armory.Api.Controllers.ArmoryUsers;
using Armory.Shared.Domain;
using Armory.Users.Application.GeneratePasswordResetToken;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.ArmoryUsers
{
    [TestFixture]
    public class ArmoryUsersControllerTest : ApiTest
    {
        private ArmoryUsersController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new ArmoryUsersController(CommandBus.Object, QueryBus.Object);
        }

        private void ShouldHaveForgottenPasswordQuery()
        {
            QueryBus.Verify(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()),
                Times.AtLeastOnce());
        }

        [Test, Order(3)]
        public async Task Forgotten_Password_With_An_Existing_User()
        {
            QueryBus.Setup(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()))
                .ReturnsAsync(new PasswordResetTokenResponse("reset_token"));

            var result = await _controller.ForgottenPassword("admin");

            ShouldHaveForgottenPasswordQuery();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<string>(okResult.Value);
            Assert.AreEqual("reset_token", Utils.Base64ToString(okResult.Value as string));
        }

        [Test, Order(4)]
        public async Task Forgotten_Password_With_A_Non_Existent_User()
        {
            QueryBus.Setup(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()))
                .ReturnsAsync(new PasswordResetTokenResponse());

            var result = await _controller.ForgottenPassword("fail");

            ShouldHaveForgottenPasswordQuery();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);

            var notFoundResult = result as NotFoundObjectResult;

            Assert.IsNotNull(notFoundResult);
            Assert.IsInstanceOf<ValidationProblemDetails>(notFoundResult.Value);

            var validationDetails = notFoundResult.Value as ValidationProblemDetails;

            Assert.IsNotNull(validationDetails);
            Assert.IsTrue(validationDetails.Errors.TryGetValue("UserNotFound", out var errors));
            Assert.IsTrue(errors.Any());
            Assert.AreEqual("El usuario identificado con 'fail' no se encuentra registrado.", errors[0]);
        }
    }
}