using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Domain.DTO.PostDTO;
using Domain.Models;

namespace BusinessLogicLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="blogPostRepository">The blog post repository</param>
        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public BlogPost? CreatePost(BlogPost post, out string message)
        {
            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Title cannot be empty.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Content cannot be empty.";
                return null;
            }

            var newBlogPost = new BlogPost
            {
                Title = post.Title,
                Content = post.Content,
                AuthorId = post.AuthorId,
                CreatedAt = DateTime.Now
            };

            var createdBlogPost = _blogPostRepository.CreateBlogPost(newBlogPost);
            message = "Blog post created successfully.";
            return createdBlogPost;
        }

        public bool DeletePost(int id, out string message)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);
            if (blogPost == null)
            {
                message = "Blog post not found.";
                return false;
            }

            _blogPostRepository.DeleteBlogPost(blogPost);
            message = "Blog post deleted successfully.";
            return true;
        }

        public List<BlogPost> GetAllPost()
        {
            var blogPosts = _blogPostRepository.GetAllBlogPosts()
                .Select(p => new BlogPost
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    AuthorId = p.AuthorId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    TagId = p.TagId 
                })
                .ToList(); // Convert to List

            return blogPosts;
        }

        /// <inheritdoc />
        public IEnumerable<PostDto> GetAllBlogPosts()
        {
            var blogPosts = _blogPostRepository.GetAllBlogPosts()
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    AuthorId = p.AuthorId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                });

            return blogPosts;
        }

        public BlogPost? GetPost(int id)
        {
            var blogPost = _blogPostRepository.GetBlogPostById(id);
            return blogPost;
        }

        public List<BlogPost> GetPostByAuthorId(int AuthorId, out string message)
        {
            throw new NotImplementedException();
        }

        public BlogPost? UpdatePost(BlogPost post, out string message)
        {
            var existingBlogPost = _blogPostRepository.GetBlogPostById(post.Id);
            if (existingBlogPost == null)
            {
                message = "Blog post not found.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Title cannot be empty.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Content cannot be empty.";
                return null;
            }

            existingBlogPost.Title = post.Title;
            existingBlogPost.Content = post.Content;
            existingBlogPost.UpdatedAt = DateTime.UtcNow;

            var updatedBlogPost = _blogPostRepository.UpdateBlogPost(existingBlogPost);

            if (updatedBlogPost == null)
            {
                message = "Failed to update blog post.";
                return null;
            }

            message = "Blog post updated successfully.";
            return updatedBlogPost;

        }
    }
}
