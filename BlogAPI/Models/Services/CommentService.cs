using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Domain.DTO.CommentDTO;
using Domain.Models;
using static BusinessLogicLayer.IServices.ICommentService;

namespace BusinessLogicLayer.Services
{

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository) 
        { 
            _commentRepository = commentRepository;

        }
        //public Comments? CreateComment(CreateCommentRequestDto comment, out string message)
        //{
        //    if (string.IsNullOrWhiteSpace(comment.Content))
        //    {
        //        message = "Comment content cannot be empty.";
        //        return null;
        //    }
        //    var newComment = new Comments
        //    {
        //        Content = comment.Content,
        //        PostId = comment.PostId,
        //        UserId = comment.UserId,
        //        CreatedAt = DateTime.UtcNow
        //    };

        //    var createdComment = _commentRepository.Create(newComment);
        //    message = "Comment created successfully.";
        //    return createdComment;
        //}

        public Comments? CreateComment(Comments comment, out string message)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment content cannot be empty.";
                return null;
            }
            var newComment = new Comments
            {
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
                CreatedAt = DateTime.UtcNow
            };

            var createdComment = _commentRepository.Create(newComment);
            message = "Comment created successfully.";
            return createdComment;
        }

        public bool DeleteComment(int commentId, out string message)
        {
            var comment = _commentRepository.Get(commentId);
            if (comment == null)
            {
                message = "Comment not found.";
                return false;
            }

            _commentRepository.Delete(comment);
            message = "Comment deleted successfully.";
            return true;
        }

        public CommentDto? GetCommentById(int commentId)
        {
            var comment = _commentRepository.Get(commentId);
            if (comment == null)
            {
                return null;
            }

            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
                CreatedAt = comment.CreatedAt
            };
        }

        public IEnumerable<CommentDto> GetCommentsByPostId(int postId)
        {
            var comments = _commentRepository.Get()
                .Where(c => c.PostId == postId)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    PostId = c.PostId,
                    UserId = c.UserId,
                    CreatedAt = c.CreatedAt
                });

            return comments;
        }

        //public Comments? UpdateComment(UpdateCommentRequestDto comment, out string message)
        //{
        //    var existingComment = _commentRepository.Get(comment.Id);
        //    if (existingComment == null)
        //    {
        //        message = "Comment not found.";
        //        return null;
        //    }

        //    if (string.IsNullOrWhiteSpace(comment.Content))
        //    {
        //        message = "Comment content cannot be empty.";
        //        return null;
        //    }

        //    existingComment.Content = comment.Content;
        //    var updatedComment = _commentRepository.Update(existingComment);

        //    if (updatedComment == null)
        //    {
        //        message = "Failed to update comment.";
        //        return null;
        //    }

        //    message = "Comment updated successfully.";
        //    return updatedComment;
        //}

        public Comments? UpdateComment(Comments comment, out string message)
        {
            var existingComment = _commentRepository.Get(comment.Id);
            if (existingComment == null)
            {
                message = "Comment not found.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment content cannot be empty.";
                return null;
            }

            existingComment.Content = comment.Content;
            var updatedComment = _commentRepository.Update(existingComment);

            if (updatedComment == null)
            {
                message = "Failed to update comment.";
                return null;
            }

            message = "Comment updated successfully.";
            return updatedComment;
        }
    }
}
