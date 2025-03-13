using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.PostDTO;
using Domain.Models;

namespace DataAccessLayer.IRepository
{
    public interface IBlogPostRepository
    {

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user Object by Id</returns>
        BlogPost? GetBlogPostById(int Id);


        /// <summary>
        /// Get user by role
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <returns>user Object by Id</returns>
        List<BlogPost> GetBlogPostByAuthorId(int AuthorId);


        /// <summary>
        /// All users
        /// </summary>
        /// <returns>List of users</returns>
        IEnumerable<PostDto> GetAllBlogPosts();



        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="blogPost"></param>
        void DeleteBlogPost(BlogPost blogPost);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="BlogPost"></param>
        /// <returns>User Object</returns>
        BlogPost CreateBlogPost(BlogPost blogPost);

        /// <summary>
        /// Update user Details
        /// </summary>
        /// <param name="BlogPost"></param>
        /// <returns>Updated Object</returns>
        BlogPost? UpdateBlogPost(BlogPost blogPost);
    }
}
