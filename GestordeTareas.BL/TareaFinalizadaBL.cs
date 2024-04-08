        using GestordeTaras.EN;
        using GestordeTareas.DAL;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

        namespace GestordeTareas.BL
        {
            public class TareaFinalizadaBL
            {
                public async Task<int> CreateAsync(TareaFinalizada tareaFinalizada)
                {
                    return await TareaFinalizadaDAL.CreateAsync(tareaFinalizada);
                }
                public async Task<int> UpdateAsync(TareaFinalizada tareaFinalizada)
                {
                    return await TareaFinalizadaDAL.UpdateAsync(tareaFinalizada);
                }
                public async Task<int> DeleteAsync(TareaFinalizada tareaFinalizada)
                {
                    return await TareaFinalizadaDAL.DeleteAsync(tareaFinalizada);
                }
                public async Task<TareaFinalizada> GetByIdAsync(TareaFinalizada tareaFinalizada)
                {
                    return await TareaFinalizadaDAL.GetByIdAsync(tareaFinalizada);
                }
                public async Task<List<TareaFinalizada>> GetAllAsync()
                {
                    return await TareaFinalizadaDAL.GetAllAsync();
                }

                public async Task<List<TareaFinalizada>> GetAllWithImageAsync()
                {
                    return await TareaFinalizadaDAL.GetAllWithImageAsync();
                }
                public async Task<int> AddImagesToTareaFinalizadaAsync(int tareaFinalizadaId, List<ImagenesPrueba> images)
                {
                    // Obtener la TareaFinalizada por su ID
                    var tareaFinalizada = await GetByIdAsync(new TareaFinalizada { Id = tareaFinalizadaId });

                    if (tareaFinalizada == null)
                    {
                        throw new Exception("TareaFinalizada no encontrada");
                    }

                    // Añadir las nuevas imágenes a la lista existente
                    tareaFinalizada.ImagenesPruebaLista.AddRange(images);

                    // Actualizar la TareaFinalizada en la base de datos
                    return await UpdateAsync(tareaFinalizada);
                }
            }
        }

