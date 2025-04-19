using System.ComponentModel.DataAnnotations;

namespace Examen_Final_Progra06_Interfaz.Models
{
    public class mDepartments
    {
        [Display(Name = "Código Departamento")]
        public int DepartmentId { get; set; }

        [Display(Name = "Nombre del Departamento")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Name { get; set; } = null!;

        [Display(Name = "Nombre del Grupo")]
        [Required(ErrorMessage = "El nombre del grupo es obligatorio")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string GroupName { get; set; } = null!;

        [Display(Name = "Fecha de Modificación")]
        public DateTime ModifiedDate { get; set; }
    }
}
