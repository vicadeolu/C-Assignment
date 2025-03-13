using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Domain.Models;

namespace BusinessLogicLayer.Services
{
    public class LikeService : ILikesService
    {
        private readonly ILikesRepository _likesRepository;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="likesRepository">The likes repository</param>
        public LikeService(ILikesRepository likesRepository)
        {
            _likesRepository = likesRepository;
        }
        public List<Likes> GetAllLikes()
        {
            return _likesRepository.GetAllLikess();
        }

        public List<Likes> GetLikeByPostId(int PostId, out string message)
        {
            var likes = _likesRepository.GetLikesByPostId(PostId);
            if (likes == null || likes.Count == 0)
            {
                message = "No likes found for this post.";
                return null;
            }

            message = "Likes retrieved successfully.";
            return likes;
        }

        public List<Likes> GetLikeByUserId(int UserId, out string message)
        {
            var likes = _likesRepository.GetLikesByUserId(UserId);
            if (likes == null || likes.Count == 0)
            {
                message = "No likes found for this user.";
                return null;
            }

            message = "Likes retrieved successfully.";
            return likes;
        }

        public Likes GetPostByUserIdAndPostId(Likes like, out string message)
        {
            var existingLike = _likesRepository.GetPostByUserIdAndPostId(like);
            if (existingLike == null)
            {
                message = "Like not found.";
                return null;
            }

            message = "Like retrieved successfully.";
            return existingLike;
        }

        public Likes LikePost(Likes like, out string message)
        {
            // Check if the user has already liked the post
            var existingLike = _likesRepository.GetPostByUserIdAndPostId(like);
            if (existingLike != null)
            {
                message = "You have already liked this post.";
                return null;
            }

            // Add the like to the database
            var likedPost = _likesRepository.LikesPost(like);
            message = "Post liked successfully.";
            return likedPost;
        }

        public bool UnlikePost(Likes like, out string message)
        {
            // Check if the like exists
            var existingLike = _likesRepository.GetPostByUserIdAndPostId(like);
            if (existingLike == null)
            {
                message = "Like not found.";
                return false;
            }

            // Remove the like from the database
            _likesRepository.UnLikesPost(existingLike);
            message = "Post unliked successfully.";
            return true;
        }
    }
}
