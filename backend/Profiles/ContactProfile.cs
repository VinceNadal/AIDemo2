using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ReadContactDTO>().ReverseMap();
            // Generate a Guid for Id of Contact when it gets mapped
            CreateMap<CreateContactDTO, Contact>().ForMember(c => c.Id, opt => 
                opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateContactDTO, Contact>();
        }
    }
}
