using System;
using System.Collections.Generic;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Bussines
{
    public class ReservaBusiness
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IServicioRepository _servicioRepository;

        public ReservaBusiness(
            IReservaRepository reservaRepository,
            IServicioRepository servicioRepository)
        {
            _reservaRepository = reservaRepository;
            _servicioRepository = servicioRepository;
        }

        public IEnumerable<Reserva> GetAll()
        {
            return _reservaRepository.GetAll();
        }

        public Reserva GetById(int id)
        {
            return _reservaRepository.GetById(id);
        }

        public void Add(Reserva reserva)
        {
            if (string.IsNullOrWhiteSpace(reserva.NombreDelAsociado))
                throw new Exception("El nombre del asociado es obligatorio.");

            if (string.IsNullOrWhiteSpace(reserva.Identificacion))
                throw new Exception("La identificación es obligatoria.");

            if (string.IsNullOrWhiteSpace(reserva.Telefono))
                throw new Exception("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(reserva.Correo))
                throw new Exception("El correo es obligatorio.");

            if (string.IsNullOrWhiteSpace(reserva.Direccion))
                throw new Exception("La dirección es obligatoria.");

            if (reserva.FechaNacimiento == default)
                throw new Exception("La fecha de nacimiento es obligatoria.");

            if (reserva.FechaDelServicio == default)
                throw new Exception("La fecha del servicio es obligatoria.");

            var servicio = _servicioRepository.GetById(reserva.IdServicio);

            if (servicio == null)
                throw new Exception("Servicio no encontrado.");

            if (!servicio.Estado)
                throw new Exception("El servicio está inactivo y no puede reservarse.");

            // Cálculo automático del monto total
            reserva.MontoTotal = (servicio.Monto * servicio.IVA) + servicio.Monto;

            reserva.FechaDeRegistro = DateTime.Now;

            _reservaRepository.Add(reserva);
            _reservaRepository.Save();
        }
        public IEnumerable<Reserva> GetByServicio(int idServicio)
        {
            return _reservaRepository.GetByServicio(idServicio);
        }
    }
}