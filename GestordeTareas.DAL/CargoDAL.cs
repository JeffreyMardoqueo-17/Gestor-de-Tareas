using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.DAL
{
    public class CargoDAL
    {
        //--------------------------------METODO CREAR CARGO.--------------------------
        public static async Task<int> CreateAsync(Cargo cargo)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                dbContexto.Cargo.Add(cargo);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        //--------------------------------METODO MODIFICAR CARGO.--------------------------
        public static async Task<int> UpdateAsync(Cargo cargo)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var cargoBD = await bdContexto.Cargo.FirstOrDefaultAsync(c => c.Id == cargo.Id);
                if (cargoBD != null)
                {
                    cargoBD.Nombre = cargo.Nombre;
                    bdContexto.Update(cargoBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        //--------------------------------METODO ELIMINAR CARGO.--------------------------
        public static async Task<int> DeleteAsync(Cargo cargo)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var cargoBD = await bdContexto.Cargo.FirstOrDefaultAsync(c => c.Id == cargo.Id);
                if (cargoBD != null)
                {
                    bdContexto.Cargo.Remove(cargoBD);
                    result = await bdContexto.SaveChangesAsync();
                }
            }
            return result;
        }

        //--------------------------------METODO OBTENER POR ID CARGO.--------------------------
        public static async Task<Cargo> GetByIdAsync(int cargoId)
        {
            using (var bdContexto = new ContextoBD())
            {
                return await bdContexto.Cargo.FirstOrDefaultAsync(c => c.Id == cargoId);
            }
        }

        //--------------------------------METODO OBTENER TODOS LOS CARGOS.--------------------------
        public static async Task<List<Cargo>> GetAllAsync()
        {
            using (var bdContexto = new ContextoBD())
            {
                return await bdContexto.Cargo.ToListAsync();
            }
        }
    }

}
