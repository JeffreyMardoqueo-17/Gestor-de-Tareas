using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class ElegirTareaBL
    {
        public async Task<int> CreateAsync(ElegirTarea elegirTarea)
        {
            return await ElegirTareaDAL.CreateAsync(elegirTarea);
        }
        public async Task<int> UpdateAsync(ElegirTarea elegirTarea)
        {
            return await ElegirTareaDAL.UpdateAsync(elegirTarea);
        }
        public async Task<int> DeleteAsync(ElegirTarea elegirTarea)
        {
            return await ElegirTareaDAL.DeleteAsync(elegirTarea);
        }

        public async Task<ElegirTarea> GetById(ElegirTarea elegirTarea)
        {
            return await ElegirTareaDAL.GetByIdAsync(elegirTarea);
        }
        public async Task<List<ElegirTarea>> GetAllAsync()
        {
            return await ElegirTareaDAL.GetAllAsync();
        }

    }
}
