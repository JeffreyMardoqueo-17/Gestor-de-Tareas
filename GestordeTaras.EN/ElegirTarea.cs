using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class ElegirTarea
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tarea")]
        [Required(ErrorMessage ="Campo Requerido")]
        [Display(Name ="Id Tarea")]
        public int IdTarea { get; set; }

        [ForeignKey("Colaborador")]
        [Required(ErrorMessage ="Id colaborador es Requerido")]
        [Display(Name ="Id Colaborador")]
        public int IdColaborador { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha Asignacion ")]
        public DateTime FechaAsignacion { get; set; }

        [ForeignKey("EstadoTarea")]
        [Required(ErrorMessage ="Id Estado es Requerido ")]
        [Display(Name ="Id Estado Tarea")]
        public int IdEstadoTarea { get; set; }

    }
}
