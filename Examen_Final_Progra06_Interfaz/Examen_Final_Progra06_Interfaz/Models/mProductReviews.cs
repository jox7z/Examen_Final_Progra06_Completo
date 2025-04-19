using System.ComponentModel.DataAnnotations;

namespace Examen_Final_Progra06_Interfaz.Models
{
    public class mProductReview
    {
        [Display(Name = "Código de Reseña")]
        public int ProductReviewId { get; set; }

        [Display(Name = "Código del Producto")]
        public int ProductId { get; set; }

        [Display(Name = "Nombre del Reseñador")]
        [Required(ErrorMessage = "El nombre del reseñador es obligatorio")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string ReviewerName { get; set; } = null!;

        [Display(Name = "Fecha de Reseña")]
        [Required(ErrorMessage = "La fecha de reseña es obligatoria")]
        public DateTime ReviewDate { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string EmailAddress { get; set; } = null!;

        [Display(Name = "Calificación")]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5")]
        public int Rating { get; set; }

        [Display(Name = "Comentarios")]
        [MaxLength(250, ErrorMessage = "Máximo 250 caracteres")]
        public string? Comments { get; set; }

        [Display(Name = "Fecha Modificación")]
        public DateTime ModifiedDate { get; set; }
    }
}
