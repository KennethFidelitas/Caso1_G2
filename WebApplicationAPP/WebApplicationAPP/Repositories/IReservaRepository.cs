using System.Collections.Generic;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IReservaRepository
    {
        IEnumerable<Reserva> GetAll();

        Reserva GetById(int id);

        void Add(Reserva reserva);

        void Save();

        IEnumerable<Reserva> GetByServicio(int idServicio);
    }
}