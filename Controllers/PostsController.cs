using blog_api.CustomExceptions.PostExceptions;
using blog_api.DTOs.General;
using blog_api.DTOs.Post;
using blog_api.Models;
using blog_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostWithCommentCountDto>>> GetPosts()
        {
            try
            {
                return await _postService.GetAll();
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById([FromRoute] int id)
        {
            try
            {
                return await _postService.GetById(id);
            }
            catch(NotFoundPostException notFoundEx)
            {
                var error = new GenericExceptionDto(notFoundEx.Message, 404);
                return StatusCode(404, error);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


        [HttpPost()]
        public async Task<ActionResult<Post>> Create([FromBody] UpsertPostDto upsertPostDto)
        {
            try
            {
                return await _postService.Create(upsertPostDto);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Put([FromRoute] int id, [FromBody] UpsertPostDto upsertPostDto)
        {
            try
            {
                return await _postService.Update(id, upsertPostDto);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> Delete([FromRoute] int id)
        {
            try
            {
                await _postService.Delete(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


    }
}
