using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Business
{
    public class ServicioBusiness
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioBusiness(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public List<Servicio> GetAllServicios()
        {
            return _servicioRepository.GetAllServicios();
        }

        public List<Servicio> GetServiciosActivos()
        {
            return _servicioRepository.GetServiciosActivos();
        }

        public Servicio GetServicioById(int id)
        {
            return _servicioRepository.GetServicioById(id);
        }

        public void AddServicio(Servicio servicio)
        {
            servicio.FechaDeRegistro = DateTime.Now;
            servicio.FechaDeModificacion = null;
            _servicioRepository.AddServicio(servicio);
        }

        public void UpdateServicio(Servicio servicio)
        {
            servicio.FechaDeModificacion = DateTime.Now;
            _servicioRepository.UpdateServicio(servicio);
        }

        public void DeleteServicio(int id)
        {
            _servicioRepository.DeleteServicio(id);
        }
    }
}