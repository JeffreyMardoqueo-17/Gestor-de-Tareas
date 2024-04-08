using GestordeTaras.EN;
using GestordeTareas.BL;
using GestordeTareas.UI.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestordeTareas.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TareaFinalizadaController : Controller
    {
        // creación de objetos de acceso a la capa BL
        ImagenesPruebaBL imagenpruebaBL = new ImagenesPruebaBL();
        TareaFinalizadaBL tareaFinalizadaBL = new TareaFinalizadaBL();


        // GET: TareaFinalizadaController
        public async Task <ActionResult> Index(TareaFinalizada tareaFinalizada = null)
        {
            try
            {
                // Verifica si tareaFinalizada es null y crea una nueva instancia si es necesario
                if (tareaFinalizada == null)
                {
                    tareaFinalizada = new TareaFinalizada();
                }

                // Ajusta el valor de Top_Aux según ciertas condiciones
                if (tareaFinalizada.Top_Aux == 0)
                {
                    tareaFinalizada.Top_Aux = 10;
                }
                else if (tareaFinalizada.Top_Aux == -1)
                {
                    tareaFinalizada.Top_Aux = 0;
                }

                // Realiza una búsqueda asincrónica de imagenprueba
                var imagenprueba = await imagenpruebaBL.SearchIncludeAdAsync(ConvertToImagenesPrueba(tareaFinalizada));

                // Obtiene todas las tareas finalizadas asincrónicamente
                var tareaFinalizadas = await tareaFinalizadaBL.GetAllAsync();

                ViewBag.Top = tareaFinalizada.Top_Aux;
                ViewBag.Categories = tareaFinalizadas;

                // Retorna la vista con todas las tareaFinalizadas
                return View(imagenprueba);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el método Index: {ex.Message}");
                return RedirectToAction("Error", "Home");
            }
        }

        // Método para convertir TareaFinalizada a ImagenesPrueba
        private ImagenesPrueba ConvertToImagenesPrueba(TareaFinalizada tareaFinalizada)
        {
            // Implementa la lógica de conversión aquí
            // Por ejemplo:
            ImagenesPrueba imagenprueba = new ImagenesPrueba
            {
                // Copiar propiedades relevantes de tareaFinalizada a imagenprueba
                // Por ejemplo:
                Top_Aux = tareaFinalizada.Top_Aux
            };
            return imagenprueba;
        }

        // GET: TareaFinalizadaController/Details/5
        public async Task <ActionResult> Details(int id)
        {

            var imagen = await imagenpruebaBL.GetByIdAsync(new ImagenesPrueba { Id = id });

            if (imagen != null)
            {
                imagen.TareaFinalizada = await tareaFinalizadaBL.GetByIdAsync(new TareaFinalizada { Id = imagen.IdTareaFinalizada });
                imagen.ImagenesPruebas = await imagenpruebaBL.SearchAsync(new ImagenesPrueba { IdTareaFinalizada = imagen.IdTareaFinalizada });
            }
            else
            {
                return NotFound(); // Retorna un error 404 si la imagen no se encuentra
            }

            return View(imagen);
        }

        // GET: TareaFinalizadaController/Create
        public async Task <ActionResult> Create()
        {

            ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: TareaFinalizadaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(ImagenesPrueba imagenesPrueba, List<IFormFile> formFiles)
        {
            try
            {
                List<ImagenesPrueba> images = new List<ImagenesPrueba>();

                foreach (IFormFile file in formFiles)
                {
                    ImagenesPrueba imagesprueba = new ImagenesPrueba();
                    imagesprueba.IdTareaFinalizada = imagenesPrueba.Id;
                    imagesprueba.Imagen = await ImageHelpers.SubirArchivo(file.OpenReadStream(), file.FileName);
                }
                imagenesPrueba.ImagenesPruebas = images;
                int result = await imagenpruebaBL.CreateAsync(imagenesPrueba);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categories = await tareaFinalizadaBL.GetAllAsync();
                return View(imagenesPrueba);
            }
        }

        // GET: TareaFinalizadaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var tareaFinalizada = await tareaFinalizadaBL.GetByIdAsync(new TareaFinalizada { Id = id });

                if (tareaFinalizada == null)
                {
                    return NotFound();
                }

                ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();

                return View(tareaFinalizada);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al cargar la tarea finalizada para editar: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: TareaFinalizadaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, TareaFinalizada tareaFinalizada, List<IFormFile> formFiles)
        {
            try
            {
                if (id != tareaFinalizada.Id)
                {
                    return NotFound();
                }

                List<ImagenesPrueba> images = new List<ImagenesPrueba>();

                foreach (var file in formFiles)
                {
                    var imagePrueba = new ImagenesPrueba
                    {
                        IdTareaFinalizada = tareaFinalizada.Id,
                        Imagen = await ImageHelpers.SubirArchivo(file.OpenReadStream(), file.FileName)
                    };
                    images.Add(imagePrueba);
                }

                // Añadir las nuevas imágenes a la TareaFinalizada
                await tareaFinalizadaBL.AddImagesToTareaFinalizadaAsync(tareaFinalizada.Id, images);

                // Actualizar la TareaFinalizada
                int result = await tareaFinalizadaBL.UpdateAsync(tareaFinalizada);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al editar la tarea finalizada: {ex.Message}";
                ViewBag.tareaterminada = await tareaFinalizadaBL.GetAllAsync();
                return View(tareaFinalizada);
            }
        }



        // GET: TareaFinalizadaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TareaFinalizadaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
