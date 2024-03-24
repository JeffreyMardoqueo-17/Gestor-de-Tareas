using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestordeTareas.DAL
{
    public class ProyectoDAL
    {
        public static async Task<int> CreateAsync(Proyecto proyecto)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                ////proyecto.IdUsuario = idUsuario; // Asignar el IdUsuario al proyecto
                dbContext.Proyecto.Add(proyecto);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> UpdateAsync(Proyecto proyecto)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var existingProyecto = await dbContext.Proyecto.FirstOrDefaultAsync(p => p.Id == proyecto.Id);

                if (existingProyecto != null)
                {
                    existingProyecto.Titulo = proyecto.Titulo;
                    existingProyecto.Descripcion = proyecto.Descripcion;
                    existingProyecto.IdUsuario = proyecto.IdUsuario;
                    existingProyecto.FechaFinalizacion = proyecto.FechaFinalizacion;
                    existingProyecto.FechaFinalizacion = proyecto.FechaFinalizacion;

                    dbContext.Update(existingProyecto);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Proyecto proyecto)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var existingProyecto = await dbContext.Proyecto.FirstOrDefaultAsync(p => p.Id == proyecto.Id);
                if (existingProyecto != null)
                {
                    dbContext.Proyecto.Remove(existingProyecto);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Proyecto> GetByIdAsync(Proyecto proyecto)
        {
            var projectBD = new Proyecto();
            using (var bdContexto = new ContextoBD())
            {
                projectBD = await bdContexto.Proyecto.FirstOrDefaultAsync(p => p.Id == proyecto.Id); //busco el id
            }
            return projectBD;
        }

        public static async Task<List<Proyecto>> GetAllAsync()
        {
            using (var dbContext = new ContextoBD())
            {
                var proyectos = await dbContext.Proyecto.Include(p => p.Usuario).ToListAsync();
                return proyectos;
            }
        }


        // Metodo para buscar
        internal static IQueryable<Proyecto> QuerySelect(IQueryable<Proyecto> query, Proyecto proyecto)
        {
            if (proyecto.Id > 0)
                query = query.Where(p => p.Id == proyecto.Id);

            if (!string.IsNullOrWhiteSpace(proyecto.Titulo))
                query = query.Where(p => p.Titulo.Contains(proyecto.Titulo));

            if (!string.IsNullOrWhiteSpace(proyecto.Descripcion))
                query = query.Where(p => p.Descripcion.Contains(proyecto.Descripcion));

            if (proyecto.FechaFinalizacion.Year > 1000)
            {
                DateTime initialDate = new DateTime(proyecto.FechaFinalizacion.Year, proyecto.FechaFinalizacion.Month, proyecto.FechaFinalizacion.Day, 0, 0, 0);
                DateTime finalDate = initialDate.AddDays(1).AddMilliseconds(-1);
                query = query.Where(p => p.FechaFinalizacion >= initialDate && p.FechaFinalizacion <= finalDate);
            }

            if (proyecto.IdUsuario > 0)
                query = query.Where(p => p.IdUsuario == proyecto.IdUsuario);

            query = query.OrderByDescending(p => p.Id).AsQueryable();

            return query;
        }


        public static async Task<List<Proyecto>> SearchAsync(Proyecto proyectos)
        {
            var projects = new List<Proyecto>();
            using (var dbContext = new ContextoBD())
            {
                var select = dbContext.Proyecto.AsQueryable();
                select = QuerySelect(select, proyectos);
                projects = await select.ToListAsync();
            }
            return projects;
        }
    }
}
