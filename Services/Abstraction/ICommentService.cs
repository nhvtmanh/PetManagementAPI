using PetManagementAPI.DTOs.CommentDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface ICommentService
    {
        Task<Review> CreateComment(CommentDTO commentDTO);
    }
}
