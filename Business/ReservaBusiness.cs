using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Business
{
    public class ReservaBusiness
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IServicioRepository _servicioRepository;

        public ReservaBusiness(IReservaRepository reservaRepository, IServicioRepository servicioRepository)
        {
            _reservaRepository = reservaRepository;
            _servicioRepository = servicioRepository;
        }

        public List<Reserva> GetAllReservas()
        {
            return _reservaRepository.GetAllReservas();
        }

        public List<Reserva> GetReservasPorServicio(int idServicio)
        {
            return _reservaRepository.GetReservasPorServicio(idServicio);
        }

        public Reserva GetReservaById(int id)
        {
            return _reservaRepository.GetReservaById(id);
        }

        public void AddReserva(Reserva reserva)
        {
            // Obtener el servicio para calcular el monto total
            var servicio = _servicioRepository.GetServicioById(reserva.IdServicio);

            if (servicio == null)
            {
                throw new Exception("Servicio no encontrado");
            }

            if (!servicio.Estado)
            {
                throw new Exception("El servicio no está activo y no puede ser reservado");
            }

            // Cálculo del monto total: MontoTotal = (Monto * IVA) + Monto
            reserva.MontoTotal = (servicio.Monto * servicio.IVA) + servicio.Monto;
            reserva.FechaDeRegistro = DateTime.Now;

            _reservaRepository.AddReserva(reserva);
        }

        public void UpdateReserva(Reserva reserva)
        {
            _reservaRepository.UpdateReserva(reserva);
        }

        public void DeleteReserva(int id)
        {
            _reservaRepository.DeleteReserva(id);
        }
    }
}