using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Bussines
{
    public class PersonaBussiness
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaBussiness(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public List<Persona> GetAllPersonas()
        {
            return _personaRepository.GetAllPersonas();
        }

        public Persona GetPersonaById(int id)
        {
            return _personaRepository.GetPersonaById(id);
        }

        public void AddPersona(Persona persona)
        {
            _personaRepository.AddPersona(persona);
        }

        public void UpdatePersona(Persona persona)
        {
            _personaRepository.UpdatePersona(persona);
        }

        public void DeletePersona(int id) {
            _personaRepository.DeletePersona(id);
        }   


    }
}
