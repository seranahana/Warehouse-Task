using Warehouse.Library.Entities;

namespace Warehouse.Library.Storage
{
    public interface IProductsRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<bool?> DeleteAsync(Guid id);
        Task<IEnumerable<Product>> RetrieveAllAsync();
        Task<IEnumerable<Product>> RetrieveAllWithFiltersAsync(DateTime from, DateTime to, string statusName = null);
        Task<Product> RetrieveAsync(Guid id);
        Task<Product> UpdateAsync(Product product);
    }
}