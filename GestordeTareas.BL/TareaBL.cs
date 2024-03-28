using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class TareaBL
    {
        public async Task<int> CreateAsync(Tarea tarea)
        {
            try
            {
                return await TareaDAL.CreateAsync(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la tarea: {ex.Message}");
                throw; // Lanzar la excepción para manejarla en el controlador
            }
        }

        public async Task<int> UpdateAsync(Tarea tarea)
        {
            try
            {
                return await TareaDAL.UpdateAsync(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la tarea: {ex.Message}");
                throw; // Lanzar la excepción para manejarla en el controlador
            }
        }

        public async Task<int> DeleteAsync(Tarea tarea)
        {
            try
            {
                return await TareaDAL.DeleteAsync(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la tarea: {ex.Message}");
                throw; // Lanzar la excepción para manejarla en el controlador
            }
        }

        public async Task<Tarea> GetById(Tarea tarea)
        {
            try
            {
                return await TareaDAL.GetByIdAsync(tarea);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la tarea por ID: {ex.Message}");
                throw; // Lanzar la excepción para manejarla en el controlador
            }
        }

        public async Task<List<Tarea>> GetAllAsync()
        {
            try
            {
                return await TareaDAL.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las tareas: {ex.Message}");
                throw; // Lanzar la excepción para manejarla en el controlador
            }
        }
    }

}
