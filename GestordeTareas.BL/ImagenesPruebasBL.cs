﻿using GestordeTaras.EN;
using GestordeTareas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeTareas.BL
{
    public class ImagenesPruebasBL
    {
        public async Task<int> CreateAsync(GestordeTaras.EN.ImagenesPrueba imagenesPruebas)
        {
            return await ImagenTareaDAL.CreateAsync(imagenesPruebas);
        }
        public async Task<int> UpdateAsync(GestordeTaras.EN.ImagenesPrueba imagenesPruebas)
        {
            return await ImagenTareaDAL.UpdateAsync(imagenesPruebas);
        }
        public async Task<int> DeleteAsync(GestordeTaras.EN.ImagenesPrueba imagenesPruebas)
        {
            return await ImagenTareaDAL.DeleteAsync(imagenesPruebas);
        }
        public async Task<GestordeTaras.EN.ImagenesPrueba> GetById(GestordeTaras.EN.ImagenesPrueba imagenesPruebas)
        {
            return await ImagenTareaDAL.GetByIdAsync(imagenesPruebas);
        }
        public async Task<List<GestordeTaras.EN.ImagenesPrueba>> GetAllAsync()
        {
            return await ImagenTareaDAL.GetAllAsync();
        }
    }
}
