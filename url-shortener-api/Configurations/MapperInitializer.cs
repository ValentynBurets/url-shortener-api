using AutoMapper;
using Business.Contract.Models.UrlItemManagement;
using Business.Contract.Models.UserManagement;
using Data.Identity.Data;
using Domain.Entity.UrlManagement;
using Domain.Entity.Users;

namespace url_shortener_api.Configurations
{
    public class MapperInitializer: Profile
    {
        public MapperInitializer()
        {
            CreateMap<AuthorisationUser, PersonDTO>().ReverseMap();

            CreateMap<User, PersonInfoDTO>();

            CreateMap<User, PersonInfoDTO>()
                .ForMember("Role", opt => opt.MapFrom(c => "User"));
            CreateMap<Admin, PersonInfoDTO>()
                .ForMember("Role", opt => opt.MapFrom(a => "Admin"));

            CreateMap<User, PersonInfoDTO>();

            CreateMap<Admin, PersonInfoDTO>();

            CreateMap<CreateUrlItemDTO, UrlItem>();

            CreateMap<UrlItem, UrlItemDTO>().ReverseMap();
            CreateMap<UrlItem, ShortUrlItemDTO>();
        }
    }
}
