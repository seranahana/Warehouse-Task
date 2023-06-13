using System.Collections.Concurrent;
using Warehouse.Library.Entities;
using Warehouse.Library.Storage.Context;

namespace Warehouse.Library.Storage
{
    public class ProductsRepository : IProductsRepository
    {
        private static ConcurrentDictionary<Guid, Product>? productsCache;

        private WarehouseContext _db;

        public ProductsRepository(WarehouseContext db)
        {
            _db = db;
            productsCache ??= new ConcurrentDictionary<Guid, Product>(_db.Products.ToDictionary(p => p.Id));
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return productsCache.AddOrUpdate(product.Id, product, UpdateCache);
            return null;
        }

        public Task<IEnumerable<Product>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Product>>(() => productsCache.Values);
        }

        public Task<IEnumerable<Product>> RetrieveAllWithFiltersAsync(DateTime from, DateTime to, string statusName = null)
        {
            return Task.Run<IEnumerable<Product>>(() =>
            {
                if (statusName is null)
                    return _db.Products.Where(p => p.Transitions.Any(t => t.TransitionDate >= from && t.TransitionDate <= to));
                return _db.Products.Where(p => p.Transitions.Any(t => t.TransitionDate >= from && t.TransitionDate <= to) &&
                                                                                p.Status.Name == statusName);
            });

        }

        public Task<Product> RetrieveAsync(Guid id)
        {
            return Task.Run(() =>
            {
                productsCache.TryGetValue(id, out Product? product);
                return product;
            });
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return UpdateCache(product.Id, product);
            return null;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            Product? deleted = _db.Products.Find(id);
            _db.Products.Remove(deleted);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return productsCache.TryRemove(id, out deleted);
            return null;
        }

        private Product UpdateCache(Guid id, Product product)
        {
            Product? old;
            if (productsCache.TryGetValue(id, out old))
                if (productsCache.TryUpdate(id, product, old))
                    return product;
            return null;
        }
    }
}
