using System.ComponentModel.DataAnnotations;

namespace ProVarejista.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

    }
}
