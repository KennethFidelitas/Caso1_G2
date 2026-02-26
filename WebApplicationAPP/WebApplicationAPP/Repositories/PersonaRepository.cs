using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        ///Declarar nuestras funciones por ejemplo
        /////CRUD
        ///
        private readonly AppDbContext _context;
        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Persona> GetAllPersonas() { 
            return _context.Persona.ToList();
        }
        public Persona GetPersonaById(int id) { 
            return _context.Persona.Find(id);
        }

        public void AddPersona(Persona persona) { 
            _context.Persona.Add(persona);
            _context.SaveChanges();
        }

        public void UpdatePersona(Persona persona)
        {
            _context.Persona.Update(persona);
            _context.SaveChanges();       
        }

        public void DeletePersona(int id) { 
            var persona = GetPersonaById(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
                _context.SaveChanges();
            }
        }

    }
}
