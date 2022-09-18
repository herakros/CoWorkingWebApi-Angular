using AutoMapper;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.DTO.CommentDTO;
using CoWorking.Contracts.DTO.UserDTO;
using CoWorking.Core.Services;

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

            CreateMap<Booking, BookingInfoDTO>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description))
                .ForMember(dest => dest.DateStart, act => act.MapFrom(src => src.DateStart))
                .ForMember(dest => dest.DateEnd, act => act.MapFrom(src => src.DateEnd));

            CreateMap<Booking, UserBookingInfoDTO>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.Developer.UserName))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Developer.Surname))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Developer.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Developer.Email));

            CreateMap<Comment, CommentInfoDTO>()
                .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Text))
                .ForMember(dest => dest.DateOfCreate, act => act.MapFrom(src => src.DateOfCreate))
                .ForMember(dest => dest.User, act => act.MapFrom(src => src.User));

            CreateMap<User, UserCommentDTO>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Surname))
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email));

            CreateMap<AddCommentDTO, Comment>()
                .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Text))
                .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.UserId))
                .ForMember(dest => dest.BookingId, act => act.MapFrom(src => src.BookingId));
        }
    }
}
