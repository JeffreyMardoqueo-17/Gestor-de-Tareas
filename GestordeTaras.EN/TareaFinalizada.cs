using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestordeTaras.EN
{
    public class TareaFinalizada
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha de finalización")]
        public DateTime FechaFinalizacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Comentarios")]
        public string Comentarios { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio")]
        [ForeignKey("ElegirTarea")]
        [Display(Name = "Elegir Tarea")]
        public int IdElegirTarea { get; set; }

        [ForeignKey("ImagenPrueba")]
        [Display(Name = "Imagen de prueba")]
        public int? ImagenPruebaId { get; set; } // Propiedad para la clave externa de ImagenPrueba

        public List<ImagenesPrueba> ImagenesPruebaLista { get; set; } = new List<ImagenesPrueba>(); // Propiedad de navegación a ImagenesPrueba

        public int Top_Aux { get; set; } // propiedad auxiliar
        public string UrlImagen { get; set; } // Propiedad para la URL de la imagen

        [NotMapped] // Indica que esta propiedad no se mapea a la base de datos
        public List<IFormFile> ImageFiles { get; set; } // Propiedad para almacenar los archivos subidos
    }
}
