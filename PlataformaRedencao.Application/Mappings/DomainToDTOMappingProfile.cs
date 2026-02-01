using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Igreja, IgrejaDTO>().ReverseMap();
            CreateMap<Membro, MembroDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Profissao, ProfissaoDTO>().ReverseMap();
            CreateMap<TermoConsentimento, TermoConsentimentoDTO>().ReverseMap();
            CreateMap<Consentimento, ConsentimentoDTO>().ReverseMap();
            CreateMap<AssinaturaEletronica, AssinaturaEletronicaDTO>().ReverseMap();
        }

    }
}