using Warehouse.Library.Entities;
using Warehouse.Library.Storage;

namespace Warehouse.Library.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IStatusesRepository _statusesRepository;
        private readonly ITransitionsRepository _transitionsRepository;

        public WarehouseService(IProductsRepository productsRepository, IStatusesRepository statusesRepository, ITransitionsRepository transitionsRepository)
        {
            _productsRepository = productsRepository;
            _statusesRepository = statusesRepository;
            _transitionsRepository = transitionsRepository;
        }

        public async Task<IEnumerable<Product>> RetrieveAllProductsAsync() => await _productsRepository.RetrieveAllAsync();

        public async Task<IEnumerable<Product>> RetrieveAllProductsByStatus(ProductStatus productStatus)
        {
            string statusName = ResolveStatusName(productStatus);
            Status status = await RetrieveStatusByNameAsync(statusName);
            if (status is not null)
                return status.Products;
            throw new ArgumentException("Status not found", nameof(productStatus));
        }

        public async Task<IEnumerable<Product>> RetrieveAllProductsByFilter(string statusName, DateTime from, DateTime to)
        {
            if (statusName == nameof(ProductStatus.All))
                return await _productsRepository.RetrieveAllWithFiltersAsync(from, to);

            return await _productsRepository.RetrieveAllWithFiltersAsync(from, to, statusName);
        }

        public async Task RecieveNewProduct(string name, decimal price)
        {
            Status status = await RetrieveStatusByNameAsync(nameof(ProductStatus.Recieved)) ?? throw new Exception("Status not found");
            Guid newProductId = Guid.NewGuid();
            Product newProduct = new(newProductId, name, price, status.Id);
            Product created = await _productsRepository.CreateAsync(newProduct) ?? throw new DBOperationException("Products");
            Guid newTransitionId = Guid.NewGuid();
            DateTime transitionDate = DateTime.UtcNow;
            Transition transition = new(newTransitionId, transitionDate, created.Id, status.Id);
            _ = await _transitionsRepository.CreateAsync(transition) ?? throw new DBOperationException("Transitions");
        }

        public async Task ChangeProductStatus(Guid productId, ProductStatus productStatus)
        {
            string statusName = ResolveStatusName(productStatus);
            Status status = await RetrieveStatusByNameAsync(statusName) ?? throw new ArgumentException("Status not found", nameof(productStatus));
            Product product = await _productsRepository.RetrieveAsync(productId) ?? throw new ArgumentException("Product not found", nameof(productId));
            product.StatusId = status.Id;
            product.Status = status;
            Product updated = await _productsRepository.UpdateAsync(product) ?? throw new DBOperationException("Products");
            Guid newTransitionId = Guid.NewGuid();
            DateTime transitionDate = DateTime.UtcNow;
            Transition transition = new(newTransitionId, transitionDate, updated.Id, status.Id);
            _ = await _transitionsRepository.CreateAsync(transition) ?? throw new DBOperationException("Transitions");
        }

        private string ResolveStatusName(ProductStatus productStatus)
        {
            return productStatus switch
            {
                ProductStatus.Recieved => nameof(ProductStatus.Recieved),
                ProductStatus.InStock => nameof(ProductStatus.InStock),
                ProductStatus.Sold => nameof(ProductStatus.Sold),
                _ => throw new NotImplementedException(),
            };
        }

        private async Task<Status> RetrieveStatusByNameAsync(string statusName)
        {
            IEnumerable<Status> statuses = await _statusesRepository.RetrieveAllAsync();
            foreach (Status status in statuses)
            {
                if (status.Name == statusName)
                    return status;
            }
            return null;
        }
    }
}
