using GestordeTaras.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GestordeTareas.DAL
{
    public class ImagenesPruebasDAL
    {
        public static async Task<int> CreateAsync(ImagenesPruebas imagenesPruebas)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                dbContexto.ImagenesPruebas.Add(imagenesPruebas);
                result = await dbContexto.SaveChangesAsync();
            }
            return result; 
        }

        public static async Task<int> UpdateAsync(ImagenesPruebas imagenesPruebas)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                var imagenesPruebasDb = await dbContexto.ImagenesPruebas.FirstOrDefaultAsync(i => i.Id == imagenesPruebas.Id);

                if (imagenesPruebasDb != null)
                {
                    imagenesPruebasDb.Imagen = imagenesPruebas.Imagen;
                    imagenesPruebasDb.IdTareaFinalizada = imagenesPruebas.IdTareaFinalizada;


                    dbContexto.Update(imagenesPruebas);
                    result = await dbContexto.SaveChangesAsync();
                }
                return result;
            }

        }


        public static async Task<int> DeleteAsync(ImagenesPruebas imagenesPruebas)
        {
            int result = 0;
            using (var dbContexto = new ContextoBD())
            {
                var imagenesPruebasDb = await dbContexto.ImagenesPruebas.FirstOrDefaultAsync(i => i.Id == imagenesPruebas.Id);
                if (imagenesPruebasDb != null)
                {
                    dbContexto.ImagenesPruebas.Remove(imagenesPruebasDb);
                    result = await dbContexto.SaveChangesAsync();
                }
            }
            return result;
        }


        public static async Task<List<ImagenesPruebas>> GetAllAsync()
        {
            var _imagenesPruebas = new List<ImagenesPruebas>();
            using (var dbContexto = new ContextoBD())
            {
                _imagenesPruebas = await dbContexto.ImagenesPruebas.ToListAsync();
            }
            return _imagenesPruebas;
        }

        public static async Task<ImagenesPruebas> GetByIdAsync(ImagenesPruebas imagenesPruebas)
        {
            var imagenesPruebasDb = new ImagenesPruebas();
            using (var dbContext = new ContextoBD())
            {
                imagenesPruebasDb = await dbContext.ImagenesPruebas.FirstOrDefaultAsync(i => i.Id == imagenesPruebas.Id);
            }
            return imagenesPruebasDb!;
        }
        
    }
}
