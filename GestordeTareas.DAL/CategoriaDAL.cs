using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.DAL
{
    public class CategoriaDAL
    {
        //--------------------------------METODO CREAR CATEGORIA.--------------------------
        public static async Task<int> CreateAsync(Categoria categoria)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                dbContexto.Categoria.Add(categoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        //--------------------------------METODO MODIFICAR CATEGORIA.--------------------------
        public static async Task<int> UpdateAsync(Categoria categoria)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var categoriaBD = await bdContexto.Categoria.FirstOrDefaultAsync(c => c.Id == categoria.Id);
                if (categoriaBD != null)
                {
                    categoriaBD.Nombre = categoria.Nombre;
                    bdContexto.Update(categoriaBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        //--------------------------------METODO ELIMINAR CATEGORIA.--------------------------
        public static async Task<int> DeleteAsync(Categoria categoria)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var categoriaBD = await bdContexto.Categoria.FirstOrDefaultAsync(c => c.Id == categoria.Id);
                if (categoriaBD != null)
                {
                    bdContexto.Categoria.Remove(categoriaBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }
        //--------------------------------METODO obtenerporID CATEGORIA.--------------------------
        public static async Task<Categoria> GetByIdAsync(Categoria categoria)
        {
            var categoryBD = new Categoria();
            using (var bdContexto = new ContextoBD())
            {
                categoryBD = await bdContexto.Categoria.FirstOrDefaultAsync(c => c.Id == categoria.Id); //busco el id
            }
            return categoryBD;
        }

        //--------------------------------METODO OBTENER TODAS LAS CATEGORIAS.--------------------------
        public static async Task<List<Categoria>> GetAllAsync()
        {
            using (var bdContexto = new ContextoBD())
            {
                return await bdContexto.Categoria.ToListAsync();
            }
        }
    }
<<<<<<< HEAD

}
=======
}
>>>>>>> ea87e274bbe99a6e5b22a5d2cbac394901ef50f8
