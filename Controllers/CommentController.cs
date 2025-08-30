using blog_api.CustomExceptions.PostExceptions;
using blog_api.DTOs.Comment;
using blog_api.DTOs.General;
using blog_api.DTOs.Post;
using blog_api.Models;
using blog_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace blog_api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    [SwaggerTag("API responsável pelo gerenciamento de comentários no Blog.")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("post/{postId}")]
        [SwaggerOperation(
            Summary = "Obtém todos os comentários de uma postagem",
            Description = "Obtém todos os comentários de uma postagem, sendo necessário passar apenas o id da postagem na rota."
        )]
        public async Task<ActionResult<IEnumerable<CommentWithoutPostDto>>> GetAll([FromRoute] int postId)
        {
            try
            {
                return await _commentService.GetAll(postId);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtém um comentário pelo id",
            Description = "Obtém um comentário específico pelo seu id, basta apenas informar na rota."
        )]
        public async Task<ActionResult<Comment>> GetById([FromRoute] int id)
        {
            try
            {
                return await _commentService.GetById(id);
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
        [SwaggerOperation(
            Summary = "Cria um comentário em uma postagem",
            Description = "Cria um comentário em uma postagem, bastando apenas informar o id da postagem, autor e conteúdo."
        )]
        public async Task<ActionResult<CommentWithoutPostDto>> Create([FromBody] UpsertCommentDto upsertCommentDto)
        {
            try
            {
                return await _commentService.Create(upsertCommentDto);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza um comentário pelo id",
            Description = "Atualiza um comentário pelo id, bastando apenas informar o id do comentário na rota, e o restante como id da postagem, título e autor na requisição."
        )]
        public async Task<ActionResult<CommentWithoutPostDto>> Put([FromRoute] int id, [FromBody] UpsertCommentDto upsertPostDto)
        {
            try
            {
                return await _commentService.Update(id, upsertPostDto);
            }
            catch (Exception ex)
            {
                var error = new GenericExceptionDto(ex.Message, ex.InnerException?.ToString() ?? "Erro desconhecido", 500);
                return StatusCode(error.StatusCode, error);
            }
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Exclui um comentário pelo id",
            Description = "Exclui um comentário pelo id, bastando apenas informar o id do comentário na rota."
        )]
        public async Task<ActionResult<Post>> Delete([FromRoute] int id)
        {
            try
            {
                await _commentService.Delete(id);
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
