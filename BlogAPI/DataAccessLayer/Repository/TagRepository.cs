using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using Domain.IRepository;
using Domain.Models;

namespace DataAccessLayer.Repository
{
    public class TagRepository : ITagRepository
    {
        //private readonly ApplicationDbContext applicationDbContext;
        private ApplicationDBContext _applicationDbContext;

        public TagRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Tags Create(Tags tag)
        {
            _applicationDbContext.Tags.Add(tag);
            _applicationDbContext.SaveChanges();
            return tag;
        }

        public void Delete(Tags tag)
        {
            _applicationDbContext.Remove(tag);
            _applicationDbContext.SaveChanges();
        }

        public Tags? Get(int id)
        {
            Tags? category = _applicationDbContext.Tags.Find(id);
            return null;
        }

        public List<Tags> Get()
        {
            return _applicationDbContext.Tags.ToList();
        }

        public Tags? Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            var tags = _applicationDbContext.Tags.FirstOrDefault(t => t.Name == name);
            return tags;
        }

        public Tags? Update(Tags tag)
        {
            Tags? existingTag = _applicationDbContext.Tags.Find(tag.Id);



            existingTag.Name = tag.Name;

            _applicationDbContext.Tags.Update(existingTag);
            _applicationDbContext.SaveChanges();

            return existingTag;
        }
    }
}
