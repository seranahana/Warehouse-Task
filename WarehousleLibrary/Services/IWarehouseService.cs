using Warehouse.Library.Entities;

namespace Warehouse.Library.Services
{
    public interface IWarehouseService
    {
        Task ChangeProductStatus(Guid productId, ProductStatus productStatus);
        Task RecieveNewProduct(string name, decimal price);
        Task<IEnumerable<Product>> RetrieveAllProductsAsync();
        Task<IEnumerable<Product>> RetrieveAllProductsByFilter(string statusName, DateTime from, DateTime to);
        Task<IEnumerable<Product>> RetrieveAllProductsByStatus(ProductStatus productStatus);
    }
}