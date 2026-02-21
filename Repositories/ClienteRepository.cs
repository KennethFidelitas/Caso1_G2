using WebApplicationAPP.Data;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAllClientes()
        {
            return _context.Cliente.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Cliente.Find(id);
        }

        public void AddCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            var cliente = GetClienteById(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
