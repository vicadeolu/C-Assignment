using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Repository;
using Domain.IRepository;
using Domain.Models;

namespace BusinessLogicLayer.Services
{
    public class TagServices : ITagServices
    {
        private readonly ITagRepository _tagRepository;
        public TagServices(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public Tags? CreateTag(Tags tags, out string message)
        {
            if (string.IsNullOrWhiteSpace(tags.Name))
            {
                message = "Tag name cannot be empty.";
                return null;
            }

            // Check if a tag with the same name already exists
            var existingTag = _tagRepository.Get(tags.Name);
            if (existingTag != null)
            {
                message = "A tag with this name already exists.";
                return null;
            }

            // Create the tag
            var createdTag = _tagRepository.Create(tags);
            message = "Tag created successfully.";
            return createdTag;
        }

        public bool DeleteTags(int id, out string message)
        {
            var tag = _tagRepository.Get(id);
            if (tag == null)
            {
                message = "Tag not found.";
                return false;
            }

            _tagRepository.Delete(tag);
            message = "Tag deleted successfully.";
            return true;
        }

        public List<Tags> GetAllTags()
        {
            return _tagRepository.Get();
        }

        public Tags? GetTagByName(string name)
        {
            return _tagRepository.Get(name);
        }

        public Tags? GetTags(int id)
        {
            return _tagRepository.Get(id);
        }

        public Tags? UpdateTags(Tags tags, out string message)
        {
            var existingTag = _tagRepository.Get(tags.Id);
            if (existingTag == null)
            {
                message = "Tag not found.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(tags.Name))
            {
                message = "Tag name cannot be empty.";
                return null;
            }

            // Check if another tag with the same name already exists
            var duplicateTag = _tagRepository.Get(tags.Name);
            if (duplicateTag != null && duplicateTag.Id != tags.Id)
            {
                message = "A tag with this name already exists.";
                return null;
            }

            // Update the tag
            existingTag.Name = tags.Name;
            var updatedTag = _tagRepository.Update(existingTag);

            if (updatedTag == null)
            {
                message = "Failed to update tag.";
                return null;
            }

            message = "Tag updated successfully.";
            return updatedTag;
        }
    }
}
