using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Ammunition.Application.Update
{
    public class UpdateAmmunitionCommand : Command
    {
        public string Code { get; }
        public string Type { get; }
        public string Mark { get; }
        public string Caliber { get; }
        public string Series { get; }
        public string Lot { get; }
        public int QuantityAvailable { get; }

        public UpdateAmmunitionCommand(string code, string type, string mark, string caliber, string series, string lot,
            int quantityAvailable)
        {
            Code = code;
            Type = type;
            Mark = mark;
            Caliber = caliber;
            Series = series;
            Lot = lot;
            QuantityAvailable = quantityAvailable;
        }
    }
}
