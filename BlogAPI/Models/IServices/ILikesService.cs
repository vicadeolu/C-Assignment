using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BusinessLogicLayer.IServices
{
    public interface ILikesService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Likes LikePost(Likes like, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        bool UnlikePost(Likes like, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Likes> GetLikeByPostId(int PostId, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Likes> GetLikeByUserId(int UserId, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Likes> GetAllLikes();
        Likes GetPostByUserIdAndPostId(Likes like, out string message);

    }
}
