using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class UsuarioBL
    {
        public async Task<int> CreateAsync(Usuarios usuario)
        {
            return await UsuarioDAL.CreateAsync(usuario);
        }

        public async Task<int> UpdateAsync(Usuarios usuario)
        {
            return await UsuarioDAL.UpdateAsync(usuario);
        }

        public async Task<int> DeleteAsync(Usuarios usuario)
        {
            return await UsuarioDAL.DeleteAsync(usuario);
        }

        public async Task<Usuarios> GetByIdAsync(Usuarios usuario)
        {
            return await UsuarioDAL.GetByIdAsync(usuario);
        }

        public async Task<List<Usuarios>> GetAllAsync()
        {
            return await UsuarioDAL.GetAllAsync();
        }

        public async Task<List<Usuarios>> SearchAsync(Usuarios usuario)
        {
            return await UsuarioDAL.SearchAsync(usuario);
        }

    }
}
