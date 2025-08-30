using blog_api.CustomExceptions.CommentExceptions;
using blog_api.CustomExceptions.PostExceptions;
using blog_api.DTOs.Comment;
using blog_api.Models;
using blog_api.Repository.Interfaces;
using blog_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace blog_api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(
            ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetAll(int postId)
        {
            try
            {
                return await _commentRepository.GetAll(postId);
            }
            catch (DbException ex)
            {
                throw new Exception("Não foi possível capturar os comentários da postagem devido a um erro no banco de dados", ex);
            }
        }

        public async Task<Comment> GetById(int id)
        {
            try
            {
                return await _commentRepository.GetById(id) ?? throw new NotFoundCommentException($"Nenhum comentário encontrado com o id {id}");
            }
            catch (DbException ex)
            {
                throw new Exception("Não foi possível capturar o comentário devido a um erro no banco de dados", ex);
            }
        }

        public async Task<Comment> Create(UpsertCommentDto commentDto)
        {
            try
            {
                Comment newComment = new();
                newComment.UpdateFromDto(commentDto);
                return await _commentRepository.Create(newComment);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível criar o comentário na postagem devido a um erro no banco de dados", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Comment? commentToDelete = await _commentRepository.GetById(id) ?? throw new NotFoundCommentException($"Nenhum comentário encontrado com o id {id}");
                await _commentRepository.Delete(commentToDelete);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível excluir o comentário da postagem devido a um erro no banco de dados", ex);
            }
        }

        public async Task<Comment> Update(int id, UpsertCommentDto commentDto)
        {
            try
            {
                Comment? commentToUpdate = await _commentRepository.GetById(id)
                    ?? throw new NotFoundPostException($"Nenhuma postagem encontrada para para o id {id}, impossível atualizar.");

                commentToUpdate.UpdateFromDto(commentDto);

                return await _commentRepository.Update(commentToUpdate);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Não foi possível atualizar o comentário no blog devido a um erro no banco de dados", ex);
            }
        }
    }
}
