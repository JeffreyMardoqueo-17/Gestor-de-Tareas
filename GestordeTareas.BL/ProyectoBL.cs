using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class ProyectoBL
    {
        public async Task<int> CreateAsync(Proyecto proyecto)
        {
            return await ProyectoDAL.CreateAsync(categoria);
        }
        public async Task<int> UpdateAsync(Categoria categoria)
        {
            return await ProyectoDAL.UpdateAsync(proyecto);
        }
        public async Task<int> DeleteAsync(Categoria categoria)
        {
            return await ProyectoDAL.DeleteAsync(categoria);
        }

        public async Task<Proyecto> GetById(Proyecto categoria)
        {
            return await ProyectoDAL.GetByIdAsync(categoria);
        }
        public async Task<List<Proyecto>> GetAllAsync()
        {
            return await ProyectoDAL.GetAllAsync();
        }
    }
}