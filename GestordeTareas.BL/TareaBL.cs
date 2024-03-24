using GestordeTaras.EN;
using GestordeTareas.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class TareaBL
    {
        private int _idProyectoSeleccionado;

        public TareaBL(int idProyectoSeleccionado)
        {
            _idProyectoSeleccionado = idProyectoSeleccionado;
        }

        public async Task<int> CreateAsync(Tarea tarea)
        {
            return await TareaDAL.CreateAsync(tarea, _idProyectoSeleccionado);
        }


        public async Task<int> UpdateAsync(Tarea tarea)
        {
            return await TareaDAL.UpdateAsync(tarea);
        }

        public async Task<int> DeleteAsync(Tarea tarea)
        {
            return await TareaDAL.DeleteAsync(tarea);
        }

        public async Task<Tarea> GetByIdAsync(Tarea tarea)
        {
            return await TareaDAL.GetByIdAsync(tarea);
        }

        public async Task<List<Tarea>> GetAllAsync()
        {
            return await TareaDAL.GetAllAsync();
        }
    }
}
