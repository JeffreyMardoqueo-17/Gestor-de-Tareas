﻿using GestordeTaras.EN;
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
        public DbSet<IniciarSesionEN> IniciarSesionEN { get; set; }
        public DbSet<EstadoTareaEN> EstadoTareaEN { get; set; }



        public DbSet<IniciarSesionEN> IniciarSesion { get; set; }
        public DbSet<EstadoTareaEN> EstadoTarea { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<ImagenTarea> ImagenTarea { get; set; }
        public DbSet<AsignacionTareas> AsignacionTareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HERNANDEZ\SQLEXPRESS;
                                           Initial Catalog = GestordeTareasBD;
                                           Integrated Security = true;
                                           Encrypt = false;
                                           TrustServerCertificate = true;");
        }
    }
}
