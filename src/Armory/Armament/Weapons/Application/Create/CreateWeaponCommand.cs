using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Armament.Weapons.Application.Create
{
    public class CreateWeaponCommand : Command<string>
    {
        public string Serial { get; init; }
        public string Type { get; init; }
        public string Mark { get; init; }
        public string Model { get; init; }
        public string Caliber { get; init; }
        public int NumberOfProviders { get; init; }
        public int ProviderCapacity { get; init; }
        public string FlightCode { get; init; }
    }
}
