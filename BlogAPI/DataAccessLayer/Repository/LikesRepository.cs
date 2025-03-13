using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Domain.Models;

namespace DataAccessLayer.Repository
{
    public class LikesRepository : ILikesRepository
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public LikesRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<Likes> GetAllLikess()
        {
            List<Likes> AllLikedPost = _applicationDbContext.Likes.ToList();
            return AllLikedPost;
        }

        public List<Likes> GetLikesByPostId(int PostId)
        {
            List<Likes> LikedPostByPostId = _applicationDbContext.Likes.Where(val => val.PostId == PostId).ToList();
            return LikedPostByPostId;
        }

        public List<Likes> GetLikesByUserId(int UserId)
        {
            List<Likes> LikedPostUserId = _applicationDbContext.Likes.Where(val => val.UserId == UserId).ToList();
            return LikedPostUserId;
        }

        public Likes GetPostByUserIdAndPostId(Likes likes)
        {
            Likes? LikedPostByUser = _applicationDbContext.Likes
               .Where(u => u.PostId == likes.PostId && u.UserId == likes.UserId)
               .FirstOrDefault();

            return LikedPostByUser;
        }

        public Likes LikesPost(Likes likes)
        {
            _applicationDbContext.Likes.Add(likes);
            _applicationDbContext.SaveChanges();
            return likes;
        }

        public void UnLikesPost(Likes likes)
        {
            _applicationDbContext.Remove(likes);
            _applicationDbContext.SaveChanges();
        }
    }
}
