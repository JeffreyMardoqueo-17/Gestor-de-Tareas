using GestordeTaras.EN;
using GestordeTareas.BL;
using GestordeTareas.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestordeTareas.UI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TareaController : Controller
    {
        private readonly TareaBL _tareaBL;
        private readonly CategoriaBL _categoriaBL;
        private readonly PrioridadBL _prioridadBL;
<<<<<<< HEAD
=======
        private readonly EstadoTareaBL _estadoTareaBL;
>>>>>>> b534d9f8831c29814da1321ba4ea8e73f7a671f5
        private readonly ProyectoBL _proyectoBL;

        public TareaController()
        {
<<<<<<< HEAD
            // Obtener el idProyectoSeleccionado de la sesión
            int idProyectoSeleccionado = HttpContext.Session.GetInt32("IdProyectoSeleccionado") ?? 0;

            _tareaBL = new TareaBL(idProyectoSeleccionado);
            _categoriaBL = new CategoriaBL();
            _prioridadBL = new PrioridadBL();
=======
            _tareaBL = new TareaBL(); 
            _categoriaBL = new CategoriaBL();
            _prioridadBL = new PrioridadBL();
            _estadoTareaBL = new EstadoTareaBL();
>>>>>>> b534d9f8831c29814da1321ba4ea8e73f7a671f5
            _proyectoBL = new ProyectoBL();
        }
        // Mostrar la lista de tareas
        public async Task<ActionResult> Index()
        {
            List<Tarea> Lista = await _tareaBL.GetAllAsync();
            return View(Lista);
        }

        // Mostrar el detalle de una tarea
        public async Task<ActionResult> Details(int id)
        {
            var tarea = await _tareaBL.GetByIdAsync(new Tarea { Id = id });
            return PartialView("Details", tarea);
        }

<<<<<<< HEAD
        // Mostrar el formulario de creación de tarea
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await LoadDropDownListsAsync();
            return View();
        }

        // Procesar la creación de una nueva tarea
=======
        // GET: TareaController/Create
        public async Task<ActionResult> Create()
        {
            await LoadDropDownListsAsync(); //Se llama al método y se espera que cargue
            return PartialView("Create");
        }

        // POST: CategoriaController/Create
>>>>>>> b534d9f8831c29814da1321ba4ea8e73f7a671f5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tarea tarea)
        {
            try
            {
<<<<<<< HEAD
                if (ModelState.IsValid)
                {
                    int estadoPendienteId = await EstadoTareaDAL.GetEstadoPendienteIdAsync();
                    tarea.IdEstadoTarea = estadoPendienteId;

                    var proyectos = await _proyectoBL.SearchAsync(new Proyecto { Titulo = User.Identity.Name });
                    var proyectoUsuario = proyectos.FirstOrDefault();

                    if (proyectoUsuario != null)
                    {
                        tarea.IdProyecto = proyectoUsuario.Id;
                        await LoadDropDownListsAsync();

                        await _tareaBL.CreateAsync(tarea);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Error = "No se encontró el proyecto del usuario.";
                        await LoadDropDownListsAsync();
                        return View(tarea);
                    }
                }
                await LoadDropDownListsAsync();
                return View(tarea);
=======
                tarea.FechaCreacion = DateTime.Now;
                int estadoPendienteId = await EstadoTareaDAL.GetEstadoPendienteIdAsync();
                tarea.IdEstadoTarea = estadoPendienteId;

                int result = await _tareaBL.CreateAsync(tarea);
                return RedirectToAction(nameof(Index));
>>>>>>> b534d9f8831c29814da1321ba4ea8e73f7a671f5
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                await LoadDropDownListsAsync();
                return View(tarea);
            }
        }
       

<<<<<<< HEAD
        // Mostrar el formulario de edición de tarea
        public async Task<ActionResult> Edit(int id)
        {
            var tarea = await _tareaBL.GetByIdAsync(new Tarea { Id = id });
            await LoadDropDownListsAsync();
=======
        //MÉTODO PARA CARGAR LISTAS DESPLEGABLES SELECCIONABLES 
        private async Task LoadDropDownListsAsync()
        {
            // Obtener todos los datos de cada una disponibles
            var categorias = await _categoriaBL.GetAllAsync();
            var prioridades = await _prioridadBL.GetAllAsync();
            var estadosTarea = await _estadoTareaBL.GetAllAsync();
            var proyectos = await _proyectoBL.GetAllAsync();

            // Se crean SelectList para cada entidad con las propiedades Id como valor y Nombre como texto visible
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
            ViewBag.Prioridades = new SelectList(prioridades, "Id", "Nombre");
            ViewBag.EstadosTarea = new SelectList(estadosTarea, "Id", "Nombre");
            ViewBag.Proyectos = new SelectList(proyectos, "Id", "Titulo");
        }


        // GET: TareaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tarea = await _tareaBL.GetById(new Tarea { Id = id });
            await LoadDropDownListsAsync(); //Se llama al método y se espera que cargue
>>>>>>> b534d9f8831c29814da1321ba4ea8e73f7a671f5
            return PartialView("Edit", tarea);
        }

        // Procesar la edición de una tarea existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Tarea tarea)
        {
            try
            {
                int result = await _tareaBL.UpdateAsync(tarea);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                await LoadDropDownListsAsync();
                return View(tarea);
            }
        }

        // Mostrar el formulario de confirmación de eliminación de tarea
        public async Task<ActionResult> Delete(int id)
        {
            var tarea = await _tareaBL.GetByIdAsync(new Tarea { Id = id });
            return PartialView("Delete", tarea);
        }

        // Procesar la eliminación de una tarea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Tarea tarea)
        {
            try
            {
                await _tareaBL.DeleteAsync(tarea);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tarea);
            }
        }

        // Método privado para cargar las listas desplegables de categorías, prioridades y proyectos
        private async Task LoadDropDownListsAsync()
        {
            var categorias = await _categoriaBL.GetAllAsync();
            var prioridades = await _prioridadBL.GetAllAsync();
            var proyectos = await _proyectoBL.GetAllAsync();

            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
            ViewBag.Prioridades = new SelectList(prioridades, "Id", "Nombre");
            ViewBag.Proyectos = new SelectList(proyectos, "Id", "Titulo");
        }

        // Método para acceder a un proyecto seleccionado
        [HttpPost]
        public async Task<IActionResult> AccederProyecto(int idProyecto)
        {
            HttpContext.Session.SetInt32("IdProyectoSeleccionado", idProyecto);
            return RedirectToAction("Index", "Tarea");
        }
    }
}
