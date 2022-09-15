using AutoMapper;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.DTO.UserDTO;

namespace CoWorking.Core.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UserRegistrationDTO, User>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email));

            CreateMap<UserInfoDTO, User>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email));

            CreateMap<User, UserInfoDTO>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email));

            CreateMap<CreateBookingDTO, Booking>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description));

            CreateMap<BookingDTO, Booking>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                .ForMember(dest => dest.DateStart, act => act.MapFrom(src => src.DateStart))
                .ForMember(dest => dest.DateEnd, act => act.MapFrom(src => src.DateEnd));

            CreateMap<Booking, BookingDTO>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                .ForMember(dest => dest.DateStart, act => act.MapFrom(src => src.DateStart))
                .ForMember(dest => dest.DateEnd, act => act.MapFrom(src => src.DateEnd));
        }
    }
}
