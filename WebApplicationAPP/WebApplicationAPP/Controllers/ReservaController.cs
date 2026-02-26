using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ReservaBusiness _reservaBusiness;
        private readonly ServicioBusiness _servicioBusiness;

        public ReservaController(
            ReservaBusiness reservaBusiness,
            ServicioBusiness servicioBusiness)
        {
            _reservaBusiness = reservaBusiness;
            _servicioBusiness = servicioBusiness;
        }

        // 1️⃣ Listar servicios activos
        public IActionResult ServiciosDisponibles()
        {
            var servicios = _servicioBusiness
                            .GetAll()
                            .Where(s => s.Estado == true);

            return View(servicios);
        }

        // 2️⃣ GET Reservar
        public IActionResult Create(int idServicio)
        {
            var servicio = _servicioBusiness.GetById(idServicio);

            if (servicio == null || !servicio.Estado)
                return NotFound();

            ViewBag.Servicio = servicio;

            var reserva = new Reserva
            {
                IdServicio = idServicio
            };

            return View(reserva);
        }

        // 3️⃣ POST Reservar
        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            try
            {
                _reservaBusiness.Add(reserva);
                return RedirectToAction("Detalle", new { id = reserva.Id });
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;

                ViewBag.Servicio = _servicioBusiness.GetById(reserva.IdServicio);

                return View(reserva);
            }
        }

        // 4️⃣ Buscar
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(int id)
        {
            var reserva = _reservaBusiness.GetById(id);

            if (reserva == null)
            {
                ViewBag.Error = "Estimado asociado, no se ha encontrado la reserva, favor realizar una nueva.";
                return View();
            }

            return RedirectToAction("Detalle", new { id = id });
        }

        // 5️⃣ Detalle
        public IActionResult Detalle(int id)
        {
            var reserva = _reservaBusiness.GetById(id);

            if (reserva == null)
                return NotFound();

            return View(reserva);
        }

        //Modulo Reserva Administrativa

        public IActionResult Historial(int? idServicio)
        {
            if (idServicio.HasValue)
            {
                var reservasFiltradas = _reservaBusiness.GetByServicio(idServicio.Value);
                ViewBag.IdServicio = idServicio.Value;
                return View(reservasFiltradas);
            }

            var reservas = _reservaBusiness.GetAll();
            return View(reservas);
        }
    }
}