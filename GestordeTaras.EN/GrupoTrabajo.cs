using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class GrupoTrabajo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Administradores")]
        [Required(ErrorMessage =" Este campo es Requerido")]
        [Display(Name ="Id del Adminstrador")]
        public int AdministradorId { get; set; }

        [ForeignKey("Colaboradores")]   
        [Required(ErrorMessage = " Este campo es Requerido")]
        [Display(Name = "Id del Colaborador")]
        public int ColaboradorID { get; set; }


        [ForeignKey("Proyecto")]
        [Required(ErrorMessage = " Este campo es Requerido")]
        [Display(Name = "Id del Proyecto")]
        public int ProyectoID { get; set; }

       
    }
}
