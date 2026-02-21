using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IServicioRepository
    {
        List<Servicio> GetAllServicios();
        List<Servicio> GetServiciosActivos();
        Servicio GetServicioById(int id);
        void AddServicio(Servicio servicio);
        void UpdateServicio(Servicio servicio);
        void DeleteServicio(int id);
    }
}