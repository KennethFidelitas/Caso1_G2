using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Reserva> GetAll()
        {
            return _context.Reservas
                           .Include(r => r.Servicio)
                           .ToList();
        }

        public Reserva GetById(int id)
        {
            return _context.Reservas
                           .Include(r => r.Servicio)
                           .FirstOrDefault(r => r.Id == id);
        }

        public void Add(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Reserva> GetByServicio(int idServicio)
        {
            return _context.Reservas
                           .Include(r => r.Servicio)
                           .Where(r => r.IdServicio == idServicio)
                           .ToList();
        }
    }
}