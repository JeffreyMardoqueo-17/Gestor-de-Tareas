using GestordeTaras.EN;
using GestordeTareas.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestordeTareas.UI.Controllers
{
    public class CargoController : Controller
    {
        private readonly CargoBL _cargoBL;
        public CargoController()
        {
            _cargoBL = new CargoBL();
        }

        // GET: CargoController
        public async Task<ActionResult> Index()
        {
            var cargo = await _cargoBL.GetAllAsync();
            return View(cargo);
        }

        // GET: CargoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cargo = await _cargoBL.GetById(new Cargo { Id = id });
            return View(cargo);
        }

        // GET: CargoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CargoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cargo cargo)
        {
            try
            {
                int result = await _cargoBL.CreateAsync(cargo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CargoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cargo = await _cargoBL.GetById(new Cargo { Id = id });
            return View(cargo);
        }

        // POST: CargoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cargo cargo)
        {
            try
            {
                int result = await _cargoBL.UpdateAsync(cargo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(cargo);
            }
        }

        // GET: CargoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var cargo = await _cargoBL.GetById(new Cargo { Id = id });
            return View(cargo);

        }

        // POST: CargoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Cargo cargo)
        {
            try
            {
                await _cargoBL.DeleteAsync(cargo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(cargo);
            }
        }
    }
}
