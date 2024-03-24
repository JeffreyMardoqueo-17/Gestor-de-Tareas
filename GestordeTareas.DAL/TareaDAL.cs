using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestordeTareas.DAL
{
    public class TareaDAL
    {
        public static async Task<int> CreateAsync(Tarea tarea, int idProyectoSeleccionado)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                tarea.IdProyecto = idProyectoSeleccionado; // Asignar el ID del proyecto a la tarea
                dbContexto.Tarea.Add(tarea);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }


        public static async Task<int> UpdateAsync(Tarea tarea)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var tareaBD = await bdContexto.Tarea.FirstOrDefaultAsync(c => c.Id == tarea.Id);
                if (tareaBD != null)
                {
                    // Actualizar solo las propiedades que necesitan ser actualizadas
                    tareaBD.Nombre = tarea.Nombre;
                    tareaBD.Descripcion = tarea.Descripcion;
                    tareaBD.FechaCreacion = tarea.FechaCreacion;
                    tareaBD.FechaVencimiento = tarea.FechaVencimiento;
                    tareaBD.IdCategoria = tarea.IdCategoria;
                    tareaBD.IdPrioridad = tarea.IdPrioridad;
                    tareaBD.IdEstadoTarea = tarea.IdEstadoTarea;
                    tareaBD.IdProyecto = tarea.IdProyecto;

                    // Guardar cambios solo si hay propiedades actualizadas
                    bdContexto.Update(tareaBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Tarea tarea)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var tareaBD = await bdContexto.Tarea.FirstOrDefaultAsync(t => t.Id == tarea.Id);
                if (tareaBD != null)
                {
                    bdContexto.Tarea.Remove(tareaBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Tarea> GetByIdAsync(Tarea tarea)
        {
            var tareaBD = new Tarea();
            using (var bdContexto = new ContextoBD())
            {
                tareaBD = await bdContexto.Tarea.FirstOrDefaultAsync(t => t.Id == tarea.Id);
            }
            return tareaBD;
        }

        public static async Task<List<Tarea>> GetAllAsync()
        {
            using (var dbContext = new ContextoBD())
            {
                var tareas = await dbContext.Tarea
                    .Include(c => c.Categoria)
                    .Include(p => p.Prioridad)
                    .Include(e => e.EstadoTarea)
                    .Include(r => r.Proyecto)
                    .ToListAsync();

                return tareas;
            }
        }
    }
}
