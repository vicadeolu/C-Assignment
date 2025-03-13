using AutoMapper;
using BusinessLogicLayer.IServices;
using Domain.DTO.PostDTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class BlogPostController : Controller
{
    private readonly IBlogPostService _blogPostService;
    private readonly IMapper _mapper;

    public BlogPostController(IBlogPostService blogPostService, IMapper mapper)
    {
        _blogPostService = blogPostService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        var posts = _blogPostService.GetAllPost();
        var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);
        return Ok(postDtos);
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        BlogPost post = _blogPostService.GetPost(id);

        if (post == null)
        {
            return NotFound("Post not found.");
        }

        var postDto = _mapper.Map<PostDto>(post);
        return Ok(postDto);
    }

    [HttpGet]
    public IActionResult GetByAuthorId(int authorId)
    {
        var postList = _blogPostService.GetPostByAuthorId(authorId, out string message);

        if (postList == null || !postList.Any())
        {
            return NotFound(message);
        }

        var postDtos = _mapper.Map<IEnumerable<PostDto>>(postList);
        return Ok(postDtos);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreatePostRequestDto postDto)
    {
        if (postDto == null)
        {
            return BadRequest("Invalid post data.");
        }

        var mappedPost = _mapper.Map<BlogPost>(postDto);

        BlogPost? createdPost = _blogPostService.CreatePost(mappedPost, out string message);

        if (createdPost == null)
        {
            return BadRequest(message);
        }

        var createdPostDto = _mapper.Map<PostDto>(createdPost);
        return Ok(createdPostDto);
    }

    [HttpPost]
    public IActionResult UpdatePost([FromBody] UpdatePostRequestDto postDto)
    {
        if (postDto == null)
        {
            return BadRequest("Invalid post data.");
        }

        var mappedPost = _mapper.Map<BlogPost>(postDto);

        BlogPost? updatedPost = _blogPostService.UpdatePost(mappedPost, out string message);

        if (updatedPost == null)
        {
            return BadRequest(message);
        }

        var updatedPostDto = _mapper.Map<PostDto>(updatedPost);
        return Ok(updatedPostDto);
    }

    [HttpDelete]
    public IActionResult DeletePost([FromBody] DeletePostRequestDto postDto)
    {
        if (postDto == null)
        {
            return BadRequest("Invalid post data.");
        }

        bool isDeleted = _blogPostService.DeletePost(postDto.Id, out string message);

        if (!isDeleted)
        {
            return BadRequest(message);
        }

        return Ok("Post deleted successfully.");
    }
}