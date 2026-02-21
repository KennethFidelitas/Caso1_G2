using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
    }
}
