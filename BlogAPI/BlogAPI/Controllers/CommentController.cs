using AutoMapper;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using Domain.DTO.CommentDTO;
using Domain.DTO.PostDTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

       

        // Get comment by ID
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            var commentDto = _mapper.Map<CommentDto>(comment);
            return Ok(commentDto);
        }

        // Create a comment
        [HttpPost]
        public IActionResult CreateComment([FromBody] CreateCommentRequestDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            var mappedComment = _mapper.Map<Comments>(commentDto);
            var createdComment = _commentService.CreateComment(mappedComment, out string message);

            if (createdComment == null)
            {
                return BadRequest(message);
            }

            var createdCommentDto = _mapper.Map<CommentDto>(createdComment);
            return Ok(createdCommentDto);
        }

        // Update a comment
        [HttpPut]
        public IActionResult UpdateComment([FromBody] UpdateCommentRequestDto updateCommentDto)
        {
            if (updateCommentDto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            // Ensure correct mapping
            var mappedComment = _mapper.Map<Comments>(updateCommentDto);
            var updatedComment = _commentService.UpdateComment(mappedComment, out string message);

            if (updatedComment == null)
            {
                return BadRequest(message);
            }

            var updatedCommentDto = _mapper.Map<CommentDto>(updatedComment);
            return Ok(new { message = "Update successful", updatedCommentDto });
        }

        // Delete a comment
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            bool isDeleted = _commentService.DeleteComment(id, out string message);
            if (!isDeleted)
            {
                return BadRequest(message);
            }

            return Ok("Comment deleted successfully.");
        }
    }
}
