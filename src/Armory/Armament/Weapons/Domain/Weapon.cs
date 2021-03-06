using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Armory.Flights.Domain;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Domain;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Domain;
using Armory.Troopers.Domain;

namespace Armory.Armament.Weapons.Domain
{
    public class Weapon
    {
        public Weapon(string type, string mark, string model, string caliber, string serial,
            int numberOfProviders, int providerCapacity, string flightCode)
        {
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Serial = serial;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
            FlightCode = flightCode;
        }

        internal Weapon()
        {
        }

        [Key] [MaxLength(256)] public string Serial { get; set; }
        [Required] [MaxLength(128)] public string Type { get; set; }
        [Required] [MaxLength(256)] public string Mark { get; set; }
        [Required] [MaxLength(256)] public string Model { get; set; }
        [Required] [MaxLength(256)] public string Caliber { get; set; }
        [Required] public int NumberOfProviders { get; set; }
        [Required] public int ProviderCapacity { get; set; }
        [Required] public WeaponState State { get; set; }

        public string TroopId { get; set; }
        [ForeignKey("TroopId")] public Troop Holder { get; set; }

        public string FlightCode { get; set; }
        [ForeignKey("FlightCode")] public Flight Flight { get; set; }


        public ICollection<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>
            WarMaterialAndSpecialEquipmentAssignmentFormatWeapons { get; set; } =
            new HashSet<WarMaterialAndSpecialEquipmentAssignmentFormatWeapon>();

        public ICollection<WarMaterialDeliveryCertificateFormatWeapon> WarMaterialDeliveryCertificateFormatWeapons
        {
            get;
            set;
        } =
            new HashSet<WarMaterialDeliveryCertificateFormatWeapon>();

        public void Update(string type, string mark, string model, string caliber, string series, int numberOfProviders,
            int providerCapacity)
        {
            Type = type;
            Mark = mark;
            Model = model;
            Caliber = caliber;
            Serial = series;
            NumberOfProviders = numberOfProviders;
            ProviderCapacity = providerCapacity;
        }
    }
}
