using System;
using System.Collections.Generic;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Bussines
{
    public class ServicioBusiness
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioBusiness(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public IEnumerable<Servicio> GetAll()
        {
            return _servicioRepository.GetAll();
        }

        public Servicio GetById(int id)
        {
            return _servicioRepository.GetById(id);
        }

        public void Add(Servicio servicio)
        {
            if (string.IsNullOrWhiteSpace(servicio.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(servicio.Descripcion))
                throw new Exception("La descripción es obligatoria.");

            if (servicio.Monto <= 0)
                throw new Exception("El monto debe ser mayor a 0.");

            if (servicio.IVA <= 0)
                throw new Exception("El IVA debe ser mayor a 0.");

            if (servicio.AreaServicio < 1 || servicio.AreaServicio > 3)
                throw new Exception("Área de servicio inválida.");

            if (string.IsNullOrWhiteSpace(servicio.Encargado))
                throw new Exception("El encargado es obligatorio.");

            if (string.IsNullOrWhiteSpace(servicio.Sucursal))
                throw new Exception("La sucursal es obligatoria.");

            servicio.FechaDeRegistro = DateTime.Now;
            servicio.Estado = true;

            _servicioRepository.Add(servicio);
            _servicioRepository.Save();
        }

        public void Update(Servicio servicio)
        {
            var servicioBD = _servicioRepository.GetById(servicio.Id);

            if (servicioBD == null)
                throw new Exception("Servicio no encontrado.");

            if (string.IsNullOrWhiteSpace(servicio.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(servicio.Descripcion))
                throw new Exception("La descripción es obligatoria.");

            if (servicio.Monto <= 0)
                throw new Exception("El monto debe ser mayor a 0.");

            if (servicio.IVA <= 0)
                throw new Exception("El IVA debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(servicio.Encargado))
                throw new Exception("El encargado es obligatorio.");

            if (string.IsNullOrWhiteSpace(servicio.Sucursal))
                throw new Exception("La sucursal es obligatoria.");

            servicioBD.Nombre = servicio.Nombre;
            servicioBD.Descripcion = servicio.Descripcion;
            servicioBD.Monto = servicio.Monto;
            servicioBD.IVA = servicio.IVA;
            servicioBD.Encargado = servicio.Encargado;
            servicioBD.Sucursal = servicio.Sucursal;
            servicioBD.Estado = servicio.Estado;
            servicioBD.FechaDeModificacion = DateTime.Now;

            _servicioRepository.Update(servicioBD);
            _servicioRepository.Save();
        }
    }
}