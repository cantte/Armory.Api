using System;
using Armory.Formats.Shared.Domain;
using Armory.Shared.Domain.Bus.Command.Generic;

namespace Armory.Formats.AssignedWeaponMagazineFormats.Application.Create
{
    public class CreateAssignedWeaponMagazineFormatCommand : Command<int>
    {
        public CreateAssignedWeaponMagazineFormatCommand(string code, DateTime validity, string squadronCode,
            string squadCode, Warehouse warehouse, DateTime date, string comments)
        {
            Code = code;
            Validity = validity;
            SquadronCode = squadronCode;
            SquadCode = squadCode;
            Warehouse = warehouse;
            Date = date;
            Comments = comments;
        }

        public string Code { get; }
        public DateTime Validity { get; }
        public string SquadronCode { get; }
        public string SquadCode { get; }
        public Warehouse Warehouse { get; }
        public DateTime Date { get; }
        public string Comments { get; }
    }
}
