using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Business
{
    public class ClienteBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes();
        }

        public Cliente GetClienteById(int id)
        {
            return _clienteRepository.GetClienteById(id);
        }

        public void AddCliente(Cliente cliente)
        {
            cliente.FechaRegistro = DateTime.Now;
            _clienteRepository.AddCliente(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.UpdateCliente(cliente);
        }

        public void DeleteCliente(int id)
        {
            _clienteRepository.DeleteCliente(id);
        }
    }
}
