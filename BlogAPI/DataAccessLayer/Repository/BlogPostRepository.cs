using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Domain.DTO.PostDTO;
using Domain.Models;

namespace DataAccessLayer.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public BlogPostRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<PostDto> GetAllBlogPosts()
        {
            var blogPosts = _applicationDbContext.BlogPosts
                .Select(bp => new PostDto
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    AuthorId = bp.AuthorId,
                    CreatedAt = bp.CreatedAt,
                    UpdatedAt = bp.UpdatedAt
                })
                .ToList();

            return blogPosts;
        }

        BlogPost IBlogPostRepository.CreateBlogPost(BlogPost blogPost)
        {
            _applicationDbContext.BlogPosts.Add(blogPost);
            _applicationDbContext.SaveChanges();
            return blogPost;
        }

        void IBlogPostRepository.DeleteBlogPost(BlogPost blogPost)
        {
            _applicationDbContext.Remove(blogPost);
            _applicationDbContext.SaveChanges();
        }

       

        List<BlogPost> IBlogPostRepository.GetBlogPostByAuthorId(int AuthorId)
        {
            List<BlogPost> post = _applicationDbContext.BlogPosts.Where(id => id.AuthorId == AuthorId).ToList();
            return post;
        }

        BlogPost? IBlogPostRepository.GetBlogPostById(int id)
        {
            BlogPost? blogPost = _applicationDbContext.BlogPosts.Find(id);
            return blogPost;
        }

        BlogPost? IBlogPostRepository.UpdateBlogPost(BlogPost blogPost)
        {
            BlogPost? existingPost = _applicationDbContext.BlogPosts.Find(blogPost.Id);

            existingPost.Title = blogPost.Title;
            existingPost.Content = blogPost.Content;
            existingPost.UpdatedAt = blogPost.UpdatedAt;
            existingPost.TagId = blogPost.TagId;

            _applicationDbContext.BlogPosts.Update(existingPost);
            _applicationDbContext.SaveChanges();

            return existingPost;
        }
    }
}
