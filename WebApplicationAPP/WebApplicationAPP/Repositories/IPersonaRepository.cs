using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IPersonaRepository
    {
        List<Persona> GetAllPersonas();
        Persona GetPersonaById(int id);
        void AddPersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(int id);

    }
}
