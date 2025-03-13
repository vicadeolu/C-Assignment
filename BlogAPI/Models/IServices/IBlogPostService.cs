using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO.PostDTO;
using Domain.Models;

namespace BusinessLogicLayer.IServices
{
    public interface IBlogPostService 
    {
        BlogPost? CreatePost(BlogPost post, out string message);

        List<BlogPost> GetPostByAuthorId(int AuthorId, out string message);

        bool DeletePost(int id, out string message);

        IEnumerable<PostDto> GetAllBlogPosts();

        List<BlogPost> GetAllPost();

        BlogPost? GetPost(int id);

        BlogPost? UpdatePost(BlogPost post, out string message);
    }
}
