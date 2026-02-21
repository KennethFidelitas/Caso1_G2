using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaBusiness _reservaBusiness;
        private readonly ServicioBusiness _servicioBusiness;

        public ReservaController(ReservaBusiness reservaBusiness, ServicioBusiness servicioBusiness)
        {
            _reservaBusiness = reservaBusiness;
            _servicioBusiness = servicioBusiness;
        }

        // Listar servicios disponibles para reservar
        public IActionResult Index()
        {
            return View(_servicioBusiness.GetServiciosActivos());
        }

        // Buscar reserva por ID
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(int idReserva)
        {
            var reserva = _reservaBusiness.GetReservaById(idReserva);

            if (reserva == null)
            {
                ViewBag.Mensaje = "Estimado asociado, no se ha encontrado la reserva, favor realizar una nueva.";
                return View();
            }

            return View("DetallesReserva", reserva);
        }

        // Crear nueva reserva
        public IActionResult Crear(int idServicio)
        {
            var servicio = _servicioBusiness.GetServicioById(idServicio);

            if (servicio == null || !servicio.Estado)
            {
                TempData["Error"] = "El servicio no está disponible para reservas.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Servicio = servicio;
            return View(new Reserva { IdServicio = idServicio });
        }

        [HttpPost]
        public IActionResult Crear(Reserva reserva)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Servicio = _servicioBusiness.GetServicioById(reserva.IdServicio);
                return View(reserva);
            }

            try
            {
                _reservaBusiness.AddReserva(reserva);
                TempData["Success"] = $"Reserva creada exitosamente. ID de reserva: {reserva.Id}";
                return RedirectToAction("DetallesReserva", new { id = reserva.Id });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Servicio = _servicioBusiness.GetServicioById(reserva.IdServicio);
                return View(reserva);
            }
        }

        public IActionResult DetallesReserva(int id)
        {
            var reserva = _reservaBusiness.GetReservaById(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }
    }
}