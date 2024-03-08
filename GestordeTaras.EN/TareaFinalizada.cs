using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class TareaFinalizada
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ElegirTarea")]
        [Required(ErrorMessage ="El Id es Requerido")]
        [Display(Name ="Id Elegir Tareas")]
        public int IdElegirTarea { get; set; }

        [Required(ErrorMessage ="La Fecha Finalizacio es Reqeurida")]
        [Display(Name = "FechaFinalizacion")]
        public DateTime FechaFinalizacion { get; set; }

        [Display(Name = "Comentarios")]
        public string Comentarios { get; set; } = string.Empty;
    }
}
