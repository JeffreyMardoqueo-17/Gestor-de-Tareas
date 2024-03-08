using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Titulo es requerido")]
        [StringLength(50,ErrorMessage ="Maximo 50 caracteres")]
        [Display(Name ="Titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripcion es requerida")]
        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [ForeignKey("Administradores")]
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name = "AdministradorID")]
        public string AdministradorID { get; set; } = string.Empty;

        [Required(ErrorMessage ="El Codigo de Acceso Requerido")]
        [StringLength(100,ErrorMessage =" Maximo 100 caracteres")]
        [Display(Name ="Codigo de Acceso")]
        public string CodigoAcceso { get; set; } = string.Empty;


        [Required(ErrorMessage = "La Fecha de FechaFinalizacion es Requerida")]
        [Display(Name = "Fecha  de FechaFinalizacion")]
        public DateTime FechaFinalizacion { get; set; }

    }
}
