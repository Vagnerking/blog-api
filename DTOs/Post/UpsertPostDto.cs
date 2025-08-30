using System.ComponentModel.DataAnnotations;

namespace blog_api.DTOs
{
    public class UpsertPostDto
    {
        [Required(ErrorMessage = "O título da postagem é obrigatório")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O conteúdo da postagem é obrigatório")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor da postagem é obrigatório")]
        [MaxLength(5000, ErrorMessage = "Postagem não pode exceder 5000 caracteres")]
        public string AuthorName { get; set; } = string.Empty;
    }
}
