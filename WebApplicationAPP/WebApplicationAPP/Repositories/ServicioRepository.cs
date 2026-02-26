using System.Collections.Generic;
using System.Linq;
using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly AppDbContext _context;

        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servicio> GetAll()
        {
            return _context.Servicios.ToList();
        }

        public Servicio GetById(int id)
        {
            return _context.Servicios.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
        }

        public void Update(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
