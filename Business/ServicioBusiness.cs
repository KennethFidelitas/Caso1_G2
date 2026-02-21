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
            // Se trae el registro existente para no pisar FechaDeRegistro ni AreaServicio
            var existente = _servicioRepository.GetServicioById(servicio.Id);
            if (existente == null) return;

            // Solo se actualizan los campos permitidos según el enunciado
            existente.Nombre = servicio.Nombre;
            existente.Descripcion = servicio.Descripcion;
            existente.Monto = servicio.Monto;
            existente.IVA = servicio.IVA;
            existente.Encargado = servicio.Encargado;
            existente.Sucursal = servicio.Sucursal;
            existente.Estado = servicio.Estado;
            existente.FechaDeModificacion = DateTime.Now; // Automático, no lo pide el usuario

            _servicioRepository.UpdateServicio(existente);
        }

        public void DeleteServicio(int id)
        {
            _servicioRepository.DeleteServicio(id);
        }
    }
}