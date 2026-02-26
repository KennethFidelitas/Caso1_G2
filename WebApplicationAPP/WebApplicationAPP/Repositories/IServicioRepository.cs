using WebApplicationAPP.Models;
using System.Collections.Generic;

namespace WebApplicationAPP.Repositories
{
    public interface IServicioRepository
    {
        IEnumerable<Servicio> GetAll();

        Servicio GetById(int id);

        void Add(Servicio servicio);

        void Update(Servicio servicio);

        void Save();

    }
}
