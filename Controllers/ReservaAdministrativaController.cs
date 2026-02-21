using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;

namespace WebApplicationAPP.Controllers
{
    public class ReservaAdministrativaController : Controller
    {
        private readonly ReservaBusiness _reservaBusiness;
        private readonly ServicioBusiness _servicioBusiness;

        public ReservaAdministrativaController(ReservaBusiness reservaBusiness, ServicioBusiness servicioBusiness)
        {
            _reservaBusiness = reservaBusiness;
            _servicioBusiness = servicioBusiness;
        }

        // Listar todas las reservas o filtrar por servicio
        public IActionResult Index(int? idServicio)
        {
            ViewBag.Servicios = _servicioBusiness.GetAllServicios();

            if (idServicio.HasValue && idServicio.Value > 0)
            {
                ViewBag.IdServicioSeleccionado = idServicio.Value;
                return View(_reservaBusiness.GetReservasPorServicio(idServicio.Value));
            }

            return View(_reservaBusiness.GetAllReservas());
        }
    }
}