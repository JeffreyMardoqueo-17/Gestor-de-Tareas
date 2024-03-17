﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTaras.EN
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = " El Nombre es Requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 Caractéres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Escriba la Descripción")]
        [MaxLength(600, ErrorMessage = "Máximo 600 caracteres")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha de creacion es Requerida")]
        [Display(Name = "Fecha  de creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "La Fecha de Vencimiento es Requerida")]
        [Display(Name = "Fecha  de vencimiento")]
        public DateTime FechaVencimiento { get; set; }
       
       
        [Display(Name = "Fecha  de Creacion")]
        public DateTime FechaCreacion { get; set; }


        [ForeignKey("Categoria")]
        [Required(ErrorMessage = " La Categoría es Requerida")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("Prioridad")]
        [Required(ErrorMessage = "La Prioridad es Requerida")]
        [Display(Name = "Prioridad de la Tarea")]
        public int IdPrioridad { get; set; }

        [ForeignKey("EstadoTarea")]
        [Required(ErrorMessage = "El Estado es Requerido")]
        [Display(Name = "Estado de la Tarea")]
        public int IdEstadoTarea { get; set; }

        [ForeignKey("Proyecto")]
<<<<<<< HEAD
        [Required(ErrorMessage = "El proyecto es requerido")]
        [Display(Name = "Proyecto")]
        public int IdProyecto { get; set; }
=======
        [Required(ErrorMessage = "El proyecto es Requerido")]
        [Display(Name = "Proyecto")]
        public int ProyectoID { get; set; }
        
        
        [ForeignKey("GrupoTrabajo")]
        [Required(ErrorMessage = "El GrupoTrabajo es Requerido")]
        [Display(Name = "Grupo de Trabajo")]
        public int GrupoTrabajoID { get; set; }


>>>>>>> dff9044fdaea6a59a1e888c274b2ff2395000048
    }
}
