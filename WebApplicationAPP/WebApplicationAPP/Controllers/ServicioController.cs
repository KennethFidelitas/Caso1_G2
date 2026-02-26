using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Bussines;
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

        // LISTAR
        public IActionResult Index()
        {
            var servicios = _servicioBusiness.GetAll();
            return View(servicios);
        }

        // GET: Crear
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        public IActionResult Create(Servicio servicio)
        {
            try
            {
                _servicioBusiness.Add(servicio);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(servicio);
            }
        }

        // GET: Editar
        public IActionResult Edit(int id)
        {
            var servicio = _servicioBusiness.GetById(id);

            if (servicio == null)
                return NotFound();

            return View(servicio);
        }

        // POST: Editar
        [HttpPost]
        public IActionResult Edit(Servicio servicio)
        {
            try
            {
                _servicioBusiness.Update(servicio);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(servicio);
            }
        }
    }
}