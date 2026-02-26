using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Bussines;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaBussiness _personaBussiness;
        
        public PersonaController(PersonaBussiness personaBussiness)
        {
            _personaBussiness = personaBussiness;
        }


        public IActionResult Index()
        {
            return View(_personaBussiness.GetAllPersonas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if(!ModelState.IsValid)
            {
                return View(persona);
            }
            _personaBussiness.AddPersona(persona);

            return RedirectToAction(nameof(Index));
        }



        public IActionResult Edit(int id)
        {
            return View(_personaBussiness.GetPersonaById(id));
        }


        public IActionResult Details(int id)
        {
            return View(_personaBussiness.GetPersonaById(id));
        }


        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            _personaBussiness.UpdatePersona(persona);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            return View(_personaBussiness.GetPersonaById(id));
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmar(int id)
        {
            _personaBussiness.DeletePersona(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
