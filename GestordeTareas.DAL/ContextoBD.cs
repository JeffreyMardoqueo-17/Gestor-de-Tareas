using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GestordeTareas.DAL
{
    public class ContextoBD : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Prioridad> Prioridad { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<EstadoTareaEN> EstadoTareaEN { get; set; }

       
        public DbSet<Tarea> Tarea { get; set; }
       
        public DbSet<AsignacionTareas> AsignacionTareas { get; set; }
        public DbSet<ImagenesPruebas> ImagenesPruebas { get; set; } 
        public DbSet<Proyecto> Proyecto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            optionsBuilder.UseSqlServer(@"Data Source=HERNANDEZ\SQLEXPRESS;
                                           Initial Catalog = GestordeTareasBD;
                                           Integrated Security = true;
                                           Encrypt = false;
                                           TrustServerCertificate = true;");
=======
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=GestorTareasJ;User=Jeffrey;Password=jeffrey20068f;Encrypt=true;TrustServerCertificate=true;");
>>>>>>> 8011157d5a1d1b7cc46fd1140ca820a6530f0af0
        }
    }
}
