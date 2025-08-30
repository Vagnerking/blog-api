using System.ComponentModel.DataAnnotations;

namespace blog_api.DTOs.Comment
{
    public class UpsertCommentDto
    {
        [Required(ErrorMessage = "É necessário informar a postagem que será feita o comentário")]
        public int PostId { get; set; }

        public string AuthorName { get; set; } = "Anônimo";

        [Required(ErrorMessage = "O conteúdo do comentário é obrigatório")]
        [MaxLength(250, ErrorMessage = "Comentário não pode exceder 250 caracteres")]
        public string Content { get; set; } = string.Empty;

    }
}
