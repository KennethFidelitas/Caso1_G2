using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServicioBusiness _servicioBusiness;

        public ServicioController(ServicioBusiness servicioBusiness)
        {
            _servicioBusiness = servicioBusiness;
        }

        public IActionResult Index()
        {
            return View(_servicioBusiness.GetAllServicios());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return View(servicio);
            }

            _servicioBusiness.AddServicio(servicio);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(_servicioBusiness.GetServicioById(id));
        }

        [HttpPost]
        public IActionResult Edit(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return View(servicio);
            }

            _servicioBusiness.UpdateServicio(servicio);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_servicioBusiness.GetServicioById(id));
        }

        public IActionResult VerReservas(int id)
        {
            ViewBag.IdServicio = id;
            ViewBag.NombreServicio = _servicioBusiness.GetServicioById(id)?.Nombre;
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View(_servicioBusiness.GetServicioById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmar(int id)
        {
            _servicioBusiness.DeleteServicio(id);
            return RedirectToAction(nameof(Index));
        }
    }
}