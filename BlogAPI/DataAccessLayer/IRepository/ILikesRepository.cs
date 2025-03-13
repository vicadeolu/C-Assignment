using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DataAccessLayer.IRepository
{
    public interface ILikesRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="likes"></param>
        /// <returns></returns>
        Likes LikesPost(Likes likes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="likes"></param>
        void UnLikesPost(Likes likes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Like"></param>
        /// <returns></returns>
        List<Likes> GetLikesByPostId(int PostId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Like"></param>
        /// <returns></returns>
        List<Likes> GetLikesByUserId(int PostId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Likes> GetAllLikess();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="likes"></param>
        /// <returns></returns>
        Likes GetPostByUserIdAndPostId(Likes likes);
    }
}
