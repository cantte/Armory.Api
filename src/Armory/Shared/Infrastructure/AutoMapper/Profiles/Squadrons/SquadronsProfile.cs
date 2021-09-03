﻿using Armory.Squadrons.Application;
using Armory.Squadrons.Domain;
using AutoMapper;

namespace Armory.Shared.Infrastructure.AutoMapper.Profiles.Squadrons
{
    public class SquadronsProfile : Profile
    {
        public SquadronsProfile()
        {
            CreateMap<Squadron, SquadronResponse>()
                .ForMember(s => s.OwnerName,
                    ownerName => ownerName.MapFrom(src => src.Owner == null ? string.Empty : src.Owner.FullName));
        }
    }
}
