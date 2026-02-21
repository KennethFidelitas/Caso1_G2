using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Business;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteBusiness _clienteBusiness;

        public ClienteController(ClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        public IActionResult Index()
        {
            return View(_clienteBusiness.GetAllClientes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            _clienteBusiness.AddCliente(cliente);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(_clienteBusiness.GetClienteById(id));
        }

        public IActionResult Details(int id)
        {
            return View(_clienteBusiness.GetClienteById(id));
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            _clienteBusiness.UpdateCliente(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_clienteBusiness.GetClienteById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmar(int id)
        {
            _clienteBusiness.DeleteCliente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
