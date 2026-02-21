using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ServicioBusiness _servicioBusiness;
        private readonly ReservaBusiness _reservaBusiness;

        public ServicioController(ServicioBusiness servicioBusiness, ReservaBusiness reservaBusiness)
        {
            _servicioBusiness = servicioBusiness;
            _reservaBusiness = reservaBusiness;
        }

        // Listar todos los servicios
        public IActionResult Index()
        {
            return View(_servicioBusiness.GetAllServicios());
        }

        // Registrar
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Servicio servicio)
        {
            if (!ModelState.IsValid)
                return View(servicio);

            _servicioBusiness.AddServicio(servicio);
            return RedirectToAction(nameof(Index));
        }

        // Editar
        public IActionResult Edit(int id)
        {
            var servicio = _servicioBusiness.GetServicioById(id);
            if (servicio == null) return NotFound();
            return View(servicio);
        }

        [HttpPost]
        public IActionResult Edit(Servicio servicio)
        {
            if (!ModelState.IsValid)
                return View(servicio);

            _servicioBusiness.UpdateServicio(servicio);
            return RedirectToAction(nameof(Index));
        }

        // Ver reservas de un servicio 
        public IActionResult VerReservas(int id)
        {
            var servicio = _servicioBusiness.GetServicioById(id);
            if (servicio == null) return NotFound();

            ViewBag.NombreServicio = servicio.Nombre;
            ViewBag.IdServicio = id;

            var reservas = _reservaBusiness.GetReservasPorServicio(id);
            return View(reservas);
        }

        // Eliminar
        public IActionResult Delete(int id)
        {
            var servicio = _servicioBusiness.GetServicioById(id);
            if (servicio == null) return NotFound();
            return View(servicio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmar(int id)
        {
            _servicioBusiness.DeleteServicio(id);
            return RedirectToAction(nameof(Index));
        }
    }
}