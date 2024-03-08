using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class ImagenesPruebas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo es Requerido")]
        [Display(Name ="Imagen")]
        public string Imagen { get; set; } = string.Empty;

        [ForeignKey("TareaFinalizada")]
        [Required(ErrorMessage =" Este Campo Es Requeriod")]
        [Display(Name ="Id Tarea Finalizada")]
        public int IdTareaFinalizada { get; set; }
    }
}
