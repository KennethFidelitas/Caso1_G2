using Microsoft.EntityFrameworkCore;
using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Reserva> GetAllReservas()
        {
            return _context.Reserva
                .Include(r => r.Servicio)
                .ToList();
        }

        public List<Reserva> GetReservasPorServicio(int idServicio)
        {
            return _context.Reserva
                .Include(r => r.Servicio)
                .Where(r => r.IdServicio == idServicio)
                .ToList();
        }

        public Reserva GetReservaById(int id)
        {
            return _context.Reserva
                .Include(r => r.Servicio)
                .FirstOrDefault(r => r.Id == id);
        }

        public void AddReserva(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            _context.SaveChanges();
        }

        public void UpdateReserva(Reserva reserva)
        {
            _context.Reserva.Update(reserva);
            _context.SaveChanges();
        }

        public void DeleteReserva(int id)
        {
            var reserva = GetReservaById(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                _context.SaveChanges();
            }
        }
    }
}