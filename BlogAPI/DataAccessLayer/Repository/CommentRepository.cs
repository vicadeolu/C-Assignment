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
    public class CommentRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        /// <param name="context">The database context</param>
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Comments? Get(int id)
        {
            return _context.Comments.Find(id);
        }

        /// <inheritdoc />
        public List<Comments> GetAll()
        {
            return _context.Comments.ToList();
        }

        /// <inheritdoc />
        public void Delete(Comments comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        /// <inheritdoc />
        public Comments Create(Comments comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        /// <inheritdoc />
        public Comments? Update(Comments comment)
        {
            var existingComment = _context.Comments.Find(comment.Id);
            if (existingComment == null)
            {
                return null;
            }

            // Update the properties of the existing comment
            _context.Entry(existingComment).CurrentValues.SetValues(comment);
            _context.SaveChanges();
            return existingComment;
        }

    }
}
