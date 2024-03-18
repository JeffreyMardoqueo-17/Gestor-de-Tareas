﻿using GestordeTaras.EN;
using GestordeTareas.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestordeTareas.UI.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly ProyectoBL _proyectoBL;
        public ProyectoController()
        {
            _proyectoBL = new ProyectoBL(); // Inicializamos la capa de negocio
        }

        // GET: ProyectoController
        public async Task<ActionResult> Index()
        {
            List<Proyecto> Lista = await _proyectoBL.GetAllAsync();

            return View(Lista);
        }


        // GET: ProyectoController/Details/5
        public async Task<ActionResult> DetailsPartial(int id)
        {
            var proyecto = await _proyectoBL.GetById(new Proyecto { Id = id });
            return PartialView("Details", proyecto);
        }

        // GET: ProyectoController/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }


        // POST: ProyectoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proyecto proyecto)
        {
            try
            {
                int result = await _proyectoBL.CreateAsync(proyecto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return PartialView("Create", proyecto);
            }
        }

        // GET: ProyectoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var proyecto = await _proyectoBL.GetById(new Proyecto { Id = id });
            return PartialView("Edit", proyecto);
        }

        // POST: ProyectoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Proyecto proyecto)
        {
            try
            {
                int result = await _proyectoBL.UpdateAsync(proyecto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(proyecto);
            }
        }

        // GET: ProyectoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var proyecto = await _proyectoBL.GetById(new Proyecto { Id = id });
            return PartialView("Delete", proyecto);

        }

        // POST: ProyectoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Proyecto proyecto)
        {
            try
            {
                await _proyectoBL.DeleteAsync(proyecto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(proyecto);
            }
        }
    }
}