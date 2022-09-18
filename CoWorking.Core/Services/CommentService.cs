using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.CommentDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public CommentService(IRepository<Comment> commentRepository,
            IRepository<Booking> bookingRepository,
            IRepository<User> userRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddCommentAsync(AddCommentDTO model)
        {
            var booking = await _bookingRepository.GetByKeyAsync(model.BookingId);

            if(booking == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "Booking not found!");
            }

            var user = await _userRepository.GetByKeyAsync(model.UserId);

            if(user == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User not found!");
            }

            var comment = new Comment()
            {
                DateOfCreate = new DateTimeOffset(DateTime.UtcNow, TimeSpan.Zero)
            };
            _mapper.Map(model, comment);

            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}
