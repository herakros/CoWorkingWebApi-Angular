using AutoMapper;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.DTO.CommentDTO;
using CoWorking.Contracts.DTO.ManagerDTO;
using CoWorking.Contracts.DTO.UserDTO;

namespace CoWorking.Core.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UserRegistrationDTO, User>();

            CreateMap<UserInfoDTO, User>();

            CreateMap<User, UserInfoDTO>();

            CreateMap<CreateBookingDTO, Booking>();

            CreateMap<BookingDTO, Booking>();

            CreateMap<Booking, BookingDTO>();

            CreateMap<Booking, BookingInfoDTO>();

            CreateMap<Booking, UserBookingInfoDTO>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.Developer.UserName))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Developer.Surname))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Developer.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Developer.Email));

            CreateMap<Comment, CommentInfoDTO>();

            CreateMap<User, UserCommentDTO>();

            CreateMap<AddCommentDTO, Comment>();

            CreateMap<SubscribeUserDTO, Booking>();

            CreateMap<User, UserProfileDTO>();
        }
    }
}
