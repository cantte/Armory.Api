using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem
{
    public class AddAssignedWeaponMagazineFormatItemCommand : Command<AssignedWeaponMagazineFormatItemResponse>
    {
        public AddAssignedWeaponMagazineFormatItemCommand(int formatId, string troopId, string weaponSeries,
            bool safetyCartridge, bool verifiedInPhysical, bool novelty, int ammunitionQuantity, string ammunitionLot,
            string observations)
        {
            FormatId = formatId;
            TroopId = troopId;
            WeaponSeries = weaponSeries;
            SafetyCartridge = safetyCartridge;
            VerifiedInPhysical = verifiedInPhysical;
            Novelty = novelty;
            AmmunitionQuantity = ammunitionQuantity;
            AmmunitionLot = ammunitionLot;
            Observations = observations;
        }

        public int FormatId { get; }
        public string TroopId { get; }
        public string WeaponSeries { get; }
        public bool SafetyCartridge { get; }
        public bool VerifiedInPhysical { get; }
        public bool Novelty { get; }
        public int AmmunitionQuantity { get; }
        public string AmmunitionLot { get; }
        public string Observations { get; }
    }
}
