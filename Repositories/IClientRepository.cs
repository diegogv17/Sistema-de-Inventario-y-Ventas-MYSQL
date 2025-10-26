using InventoryApp.Domain;

namespace InventoryApp.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetByNitAsync(string nit);
        Task<Client?> GetByNameAsync(string nombre);
        Task<List<Client?>> GetByEmailAsync(string email);
    }
}
