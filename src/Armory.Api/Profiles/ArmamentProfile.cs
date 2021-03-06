using Armory.Api.Controllers.Armament.Ammunition.Requests;
using Armory.Api.Controllers.Armament.Equipments.Requests;
using Armory.Api.Controllers.Armament.Explosives.Requests;
using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Update;
using Armory.Armament.Explosives.Application.Create;
using Armory.Armament.Explosives.Application.Update;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Update;
using AutoMapper;

namespace Armory.Api.Profiles
{
    public class ArmamentProfile : Profile
    {
        public ArmamentProfile()
        {
            CreateMap<CreateWeaponRequest, CreateWeaponCommand>();
            CreateMap<UpdateWeaponRequest, UpdateWeaponCommand>();

            CreateMap<CreateAmmunitionRequest, CreateAmmunitionCommand>();

            CreateMap<CreateEquipmentRequest, CreateEquipmentCommand>();
            CreateMap<UpdateEquipmentRequest, UpdateEquipmentCommand>();

            CreateMap<CreateExplosiveRequest, CreateExplosiveCommand>();
            CreateMap<UpdateExplosiveRequest, UpdateExplosiveCommand>();
        }
    }
}
