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

        public List<Servicio> GetAllServicios()
        {
            return _context.Servicio.ToList();
        }

        public List<Servicio> GetServiciosActivos()
        {
            return _context.Servicio.Where(s => s.Estado == true).ToList();
        }

        public Servicio GetServicioById(int id)
        {
            return _context.Servicio.Find(id);
        }

        public void AddServicio(Servicio servicio)
        {
            _context.Servicio.Add(servicio);
            _context.SaveChanges();
        }

        public void UpdateServicio(Servicio servicio)
        {
            _context.Servicio.Update(servicio);
            _context.SaveChanges();
        }

        public void DeleteServicio(int id)
        {
            var servicio = GetServicioById(id);
            if (servicio != null)
            {
                _context.Servicio.Remove(servicio);
                _context.SaveChanges();
            }
        }
    }
}