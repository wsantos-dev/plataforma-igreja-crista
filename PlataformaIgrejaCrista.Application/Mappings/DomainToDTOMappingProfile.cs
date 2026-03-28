using AutoMapper;
using PlataformaIgrejaCrista.Application.DTOs;
using PlataformaIgrejaCrista.Domain.Entities;

namespace PlataformaIgrejaCrista.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Church, ChurchDTO>().ReverseMap();
            CreateMap<Profession, ProfessionDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }

    }
}