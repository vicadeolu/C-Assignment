using AutoMapper;
using BusinessLogicLayer.IServices;
using Domain.DTO.LikesDTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : Controller
    {
        private readonly ILikesService _likeService;
        private readonly IMapper _mapper;

        public LikeController(IMapper mapper, ILikesService likeService)
        {
            _mapper = mapper;
            _likeService = likeService;
        }

        [HttpGet]
        public IActionResult GetAllLikes()
        {
            var likes = _likeService.GetAllLikes();
            var likeDtos = _mapper.Map<IEnumerable<LikesDto>>(likes);
            return Ok(likeDtos);
        }

        [HttpGet]
        public IActionResult GetLikeByUserId(int userId)
        {
            var userLikes = _likeService.GetLikeByUserId(userId, out string message);

            if (userLikes == null || !userLikes.Any())
            {
                return NotFound(message);
            }

            var likeDtos = _mapper.Map<IEnumerable<LikesDto>>(userLikes);
            return Ok(likeDtos);
        }

        [HttpGet]
        public IActionResult GetLikeByPostId(int postId)
        {
            var postLikes = _likeService.GetLikeByPostId(postId, out string message);

            if (postLikes == null || !postLikes.Any())
            {
                return NotFound(message);
            }

            var likeDtos = _mapper.Map<IEnumerable<LikesDto>>(postLikes);
            return Ok(likeDtos);
        }

        [HttpDelete]
        public IActionResult Unlike([FromBody] LikesDto likeDetails)
        {
            if (likeDetails == null)
            {
                return BadRequest("Invalid like data.");
            }

            var mappedLike = _mapper.Map<Likes>(likeDetails);

            bool isUnliked = _likeService.UnlikePost(mappedLike, out string message);

            if (!isUnliked)
            {
                return BadRequest(message);
            }

            return Ok("Post unliked successfully.");
        }

        [HttpGet]
        public IActionResult GetPostByUserIdAndPostId([FromBody] LikesDto likeDetails)
        {
            if (likeDetails == null)
            {
                return BadRequest("Invalid like data.");
            }

            var mappedLike = _mapper.Map<Likes>(likeDetails);

            var likedPostByUser = _likeService.GetPostByUserIdAndPostId(mappedLike, out string message);

            if (likedPostByUser == null)
            {
                return NotFound(message);
            }

            var likedPostDto = _mapper.Map<LikesDto>(likedPostByUser);
            return Ok(likedPostDto);
        }
    }
}
