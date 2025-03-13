using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.CommentDTO;
using Domain.Models;

namespace BusinessLogicLayer.IServices
{
    public interface ICommentService
    {
       
            // Retrieve all comments for a specific blog post
            IEnumerable<CommentDto> GetCommentsByPostId(int postId);

            // Retrieve a specific comment by its ID
            CommentDto? GetCommentById(int commentId);

            // Create a new comment
            Comments? CreateComment(CreateCommentRequestDto comment, out string message);

            // Update an existing comment
            Comments? UpdateComment(UpdateCommentRequestDto comment, out string message);

            // Delete a comment by its ID
            bool DeleteComment(int commentId, out string message);
        }
    
}
