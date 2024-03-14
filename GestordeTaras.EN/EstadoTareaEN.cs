using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class EstadoTareaEN
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo es requerido")]
        [StringLength(50, ErrorMessage ="Maximo 40 caracteres")]
        public string Nombre { get; set; } = string.Empty;

    }
}
