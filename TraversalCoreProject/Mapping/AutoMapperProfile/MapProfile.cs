using AutoMapper;
using Dto.DTOs.AnnouncementDtos;
using Dto.DTOs.AppUserDtos;
using Dto.DTOs.ContactDtos;
using Entity.Concrete;

namespace TraversalCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
        }
    }
}
