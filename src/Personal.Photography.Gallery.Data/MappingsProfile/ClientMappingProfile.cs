using AutoMapper;
using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.Data.MappingsProfile
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile() {
            //CreateMap<ClientRequest, Client>()
            //    .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date));
            CreateMap<Client, ClientResponse>();
            CreateMap<List<Client>, ClientResponse>();
        }
    }
}
