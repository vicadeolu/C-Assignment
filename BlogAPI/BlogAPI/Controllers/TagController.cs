using AutoMapper;
using BusinessLogicLayer.IServices;
using Domain.DTO.TagDTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagServices _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagServices tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = _tagService.GetAllTags();
            var tagDtos = _mapper.Map<IEnumerable<TagDto>>(tags);
            return Ok(tagDtos);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var tag = _tagService.GetTags(id);

            if (tag == null)
            {
                return NotFound("Tag not found.");
            }

            var tagDto = _mapper.Map<TagDto>(tag);
            return Ok(tagDto);
        }

        [HttpPost]
        public IActionResult CreateTag([FromBody] CreateRequestTagDto tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Invalid tag data.");
            }

            var mappedTag = _mapper.Map<Tags>(tagDto);

            var createdTag = _tagService.CreateTag(mappedTag, out string message);

            if (createdTag == null)
            {
                return BadRequest(message);
            }

            var createdTagDto = _mapper.Map<TagDto>(createdTag);
            return Ok(createdTagDto);
        }

        [HttpPost]
        public IActionResult UpdateTag([FromBody] UpdateRequestTagDto tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Invalid tag data.");
            }

            var mappedTag = _mapper.Map<Tags>(tagDto);

            var updatedTag = _tagService.UpdateTags(mappedTag, out string message);

            if (updatedTag == null)
            {
                return BadRequest(message);
            }

            var updatedTagDto = _mapper.Map<TagDto>(updatedTag);
            return Ok(updatedTagDto);
        }

        [HttpDelete]
        public IActionResult DeleteTag([FromBody] DeleteRequestDto tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Invalid tag data.");
            }

            bool isDeleted = _tagService.DeleteTags(tagDto.Id, out string message);

            if (!isDeleted)
            {
                return BadRequest(message);
            }

            return Ok("Tag deleted successfully.");
        }
    }
}
