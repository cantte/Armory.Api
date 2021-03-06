using System.Threading;
using System.Threading.Tasks;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Update
{
    public class UpdateExplosiveCommandHandler : CommandHandler<UpdateExplosiveCommand>
    {
        private readonly ExplosiveFinder _finder;
        private readonly ExplosiveUpdater _updater;

        public UpdateExplosiveCommandHandler(ExplosiveUpdater updater, ExplosiveFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdateExplosiveCommand request, CancellationToken cancellationToken)
        {
            var explosive = await _finder.Find(request.Serial, false);
            if (explosive == null)
            {
                throw new ExplosiveNotFoundException();
            }

            await _updater.Update(explosive, request);
        }
    }
}
