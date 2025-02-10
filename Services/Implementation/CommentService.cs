using AutoMapper;
using PetManagementAPI.DTOs.CommentDTOs;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Review> CreateComment(CommentDTO commentDTO)
        {
            var comment = _mapper.Map<Review>(commentDTO);

            comment.ReviewDate = DateTime.Now;

            return await _commentRepository.Create(comment);
        }
    }
}
