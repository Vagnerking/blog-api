using blog_api.CustomExceptions.PostExceptions;
using blog_api.DTOs.Post;
using blog_api.Models;
using blog_api.Repository.Interfaces;
using blog_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blog_api.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(
            IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> Create(UpsertPostDto postDto)
        {
            try
            {
                Post newPost = new();
                newPost.UpdateFromDto(postDto);

                return await _postRepository.Create(newPost);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível criar a postagem no blog devido a um erro no banco de dados", ex);
            }
        }


        public async Task<Post> Update(int id, UpsertPostDto postDto)
        {
            try
            {
                Post? postToUpdate = await _postRepository.GetPostById(id)
                    ?? throw new NotFoundPostException($"Nenhuma postagem encontrada para para o id {id}, impossível atualizar.");

                postToUpdate.UpdateFromDto(postDto);

                return await _postRepository.Create(postToUpdate);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível criar a postagem no blog devido a um erro no banco de dados", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Post? postToDelete = await _postRepository.GetById(id)
                    ?? throw new NotFoundPostException($"Nenhuma postagem encontrada para para o id {id}, impossível excluir.");

                await _postRepository.Delete(postToDelete);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível excluir a postagem do blog devido a um erro no banco de dados", ex);
            }
        }

        public async Task<List<PostWithCommentCountDto>> GetAll()
        {
            try
            {
                return await _postRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível capturar as postagens do blog devido a um erro no banco de dados", ex);
            }
        }

        public async Task<Post> GetById(int id)
        {
            try
            {
                return await _postRepository.GetPostById(id)
                    ?? throw new NotFoundPostException($"Nenhuma postagem encontrada para para o id {id}.");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível capturas as postagens do blog devido a um erro no banco de dados", ex);
            }
        }
    }
}
