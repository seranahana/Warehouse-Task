using System.Collections.Concurrent;
using Warehouse.Library.Entities;
using Warehouse.Library.Storage.Context;

namespace Warehouse.Library.Storage
{
    public class StatusesRepository : IStatusesRepository
    {
        private static ConcurrentDictionary<Guid, Status> statusesCache;

        private WarehouseContext _db;

        public StatusesRepository(WarehouseContext db)
        {
            _db = db;
            statusesCache ??= new ConcurrentDictionary<Guid, Status>(_db.Statuses.ToDictionary(p => p.Id));
        }

        public async Task<Status> CreateAsync(Status status)
        {
            await _db.Statuses.AddAsync(status);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return statusesCache.AddOrUpdate(status.Id, status, UpdateCache);
            return null;
        }

        public Task<IEnumerable<Status>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Status>>(() => statusesCache.Values);
        }

        public Task<Status> RetrieveAsync(Guid id)
        {
            return Task.Run(() =>
            {
                statusesCache.TryGetValue(id, out Status? status);
                return status;
            });
        }

        public async Task<Status> UpdateAsync(Status status)
        {
            _db.Statuses.Update(status);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return UpdateCache(status.Id, status);
            return null;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            Status? deleted = _db.Statuses.Find(id);
            _db.Statuses.Remove(deleted);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return statusesCache.TryRemove(id, out deleted);
            return null;
        }

        private Status UpdateCache(Guid id, Status status)
        {
            Status? old;
            if (statusesCache.TryGetValue(id, out old))
                if (statusesCache.TryUpdate(id, status, old))
                    return status;
            return null;
        }
    }
}
