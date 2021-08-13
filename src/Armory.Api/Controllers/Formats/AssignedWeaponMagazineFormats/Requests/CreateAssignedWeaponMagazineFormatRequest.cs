using System;
using Armory.Formats.Shared.Domain;

namespace Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests
{
    public class CreateAssignedWeaponMagazineFormatRequest
    {
        public string Code { get; set; }
        public DateTime Validity { get; set; }
        public string SquadronCode { get; set; }
        public string SquadCode { get; set; }
        public Warehouse Warehouse { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
