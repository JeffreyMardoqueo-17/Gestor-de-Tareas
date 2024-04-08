//using GestordeTaras.EN;
//using GestordeTareas.BL;
//using GestordeTareas.UI.Helpers;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace GestordeTareas.UI.Controllers
//{
//    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
//    public class ImagenPruebaController : Controller
//    {
//        private readonly ImagenesPruebaBL imagenpruebaBL;
//        private readonly TareaFinalizadaBL tareaFinalizadaBL;

//        public ImagenPruebaController(ImagenesPruebaBL imagenpruebaBL, TareaFinalizadaBL tareaFinalizadaBL)
//        {
//            this.imagenpruebaBL = imagenpruebaBL;
//            this.tareaFinalizadaBL = tareaFinalizadaBL;
//        }

//        public async Task<IActionResult> Index(TareaFinalizada tareaFinalizada = null)
//        {
//            try
//            {
//                if (tareaFinalizada == null)
//                {
//                    tareaFinalizada = new TareaFinalizada();
//                }

//                if (tareaFinalizada.Top_Aux == 0)
//                {
//                    tareaFinalizada.Top_Aux = 10;
//                }
//                else if (tareaFinalizada.Top_Aux == -1)
//                {
//                    tareaFinalizada.Top_Aux = 0;
//                }

//                var imagenprueba = await imagenpruebaBL.SearchIncludeAdAsync(ConvertToImagenesPrueba(tareaFinalizada));
//                var tareaFinalizadas = await tareaFinalizadaBL.GetAllAsync();

//                ViewBag.Top = tareaFinalizada.Top_Aux;
//                ViewBag.Categories = tareaFinalizadas;

//                return View(tareaFinalizadas);
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Error = $"Error en el método Index: {ex.Message}";
//                return RedirectToAction("Error", "Home");
//            }
//        }

//        private ImagenesPrueba ConvertToImagenesPrueba(TareaFinalizada tareaFinalizada)
//        {
//            return new ImagenesPrueba
//            {
//                Top_Aux = tareaFinalizada.Top_Aux
//            };
//        }

//        public async Task<ActionResult> Details(int id)
//        {
//            var imagen = await imagenpruebaBL.GetByIdAsync(new ImagenesPrueba { Id = id });

//            if (imagen == null)
//            {
//                return NotFound();
//            }

//            imagen.TareaFinalizada = await tareaFinalizadaBL.GetByIdAsync(new TareaFinalizada { Id = imagen.IdTareaFinalizada });
//            imagen.ImagenesPruebas = await imagenpruebaBL.SearchAsync(new ImagenesPrueba { IdTareaFinalizada = imagen.IdTareaFinalizada });

//            return View(imagen);
//        }

//        public async Task<ActionResult> Create()
//        {
//            ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();
//            ViewBag.Error = "";
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create(ImagenesPrueba imagenesPrueba, List<IFormFile> formFiles)
//        {
//            try
//            {
//                List<ImagenesPrueba> images = new List<ImagenesPrueba>();

//                foreach (var file in formFiles)
//                {
//                    var imagePrueba = new ImagenesPrueba
//                    {
//                        IdTareaFinalizada = imagenesPrueba.Id,
//                        Imagen = await ImageHelpers.SubirArchivo(file.OpenReadStream(), file.FileName)
//                    };
//                    images.Add(imagePrueba);  // Añadir la imagen a la lista
//                }

//                imagenesPrueba.ImagenesPruebas = images;
//                int result = await imagenpruebaBL.CreateAsync(imagenesPrueba);

//                return RedirectToAction(nameof(Index));
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Error = $"Error al crear la imagen: {ex.Message}";
//                ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();
//                return View(imagenesPrueba);
//            }
//        }

//        public async Task<ActionResult> Edit(int id)
//        {
//            try
//            {
//                var imagen = await imagenpruebaBL.GetByIdAsync(new ImagenesPrueba { Id = id });

//                if (imagen == null)
//                {
//                    return NotFound();
//                }

//                // Cargar datos relacionados
//                imagen.TareaFinalizada = await tareaFinalizadaBL.GetByIdAsync(new TareaFinalizada { Id = imagen.IdTareaFinalizada });
//                imagen.ImagenesPruebas = await imagenpruebaBL.SearchAsync(new ImagenesPrueba { IdTareaFinalizada = imagen.IdTareaFinalizada });

//                ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();

//                return View(imagen);
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Error = $"Error al cargar la imagen para editar: {ex.Message}";
//                return RedirectToAction(nameof(Index));
//            }
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit(int id, ImagenesPrueba imagenesPrueba, List<IFormFile> formFiles)
//        {
//            try
//            {
//                if (id != imagenesPrueba.Id)
//                {
//                    return NotFound();
//                }

//                List<ImagenesPrueba> images = new List<ImagenesPrueba>();

//                foreach (var file in formFiles)
//                {
//                    var imagePrueba = new ImagenesPrueba
//                    {
//                        IdTareaFinalizada = imagenesPrueba.Id,
//                        Imagen = await ImageHelpers.SubirArchivo(file.OpenReadStream(), file.FileName)
//                    };
//                    images.Add(imagePrueba);  // Añadir la imagen a la lista
//                }

//                imagenesPrueba.ImagenesPruebas = images;
//                int result = await imagenpruebaBL.UpdateAsync(imagenesPrueba);

//                return RedirectToAction(nameof(Index));
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Error = $"Error al editar la imagen: {ex.Message}";
//                ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();
//                return View(imagenesPrueba);
//            }
//        }

//        // Resto del código para los métodos Delete y otros...

//    }
//}
