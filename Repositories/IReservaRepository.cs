using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IReservaRepository
    {
        List<Reserva> GetAllReservas();
        List<Reserva> GetReservasPorServicio(int idServicio);
        Reserva GetReservaById(int id);
        void AddReserva(Reserva reserva);
        void UpdateReserva(Reserva reserva);
        void DeleteReserva(int id);
    }
}