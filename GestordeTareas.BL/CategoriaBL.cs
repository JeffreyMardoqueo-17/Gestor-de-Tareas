using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class CategoriaBL
    {
        public async Task<int> CreateAsync(Categoria categoria)
        {
            try
            {
                return await CategoriaDAL.CreateAsync(categoria);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según las necesidades de tu aplicación.
                // Aquí puedes registrar el error, lanzar una excepción diferente, etc.
                Console.WriteLine($"Error en CreateAsync: {ex.Message}");
                return 0; // O algún valor que indique un error.
            }
        }

        public async Task<int> UpdateAsync(Categoria categoria)
        {
            try
            {
                return await CategoriaDAL.UpdateAsync(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateAsync: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> DeleteAsync(Categoria categoria)
        {
            try
            {
                return await CategoriaDAL.DeleteAsync(categoria);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteAsync: {ex.Message}");
                return 0;
            }
        }

        public async Task<Categoria> GetById(Categoria categoria)
        {
            try
            {
                return await CategoriaDAL.GetByIdAsync(categoria.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetById: {ex.Message}");
                return null; // O algún valor que indique un error.
            }
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            try
            {
                return await CategoriaDAL.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetAllAsync: {ex.Message}");
                return new List<Categoria>(); // Otra opción puede ser lanzar la excepción.
            }
        }

    }
}
