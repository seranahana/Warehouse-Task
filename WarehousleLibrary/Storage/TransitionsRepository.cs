using System.Collections.Concurrent;
using Warehouse.Library.Entities;
using Warehouse.Library.Storage.Context;

namespace Warehouse.Library.Storage
{
    public class TransitionsRepository : ITransitionsRepository
    {
        private static ConcurrentDictionary<Guid, Transition> transitionsCache;

        private WarehouseContext _db;

        public TransitionsRepository(WarehouseContext db)
        {
            _db = db;
            transitionsCache ??= new ConcurrentDictionary<Guid, Transition>(_db.Transitions.ToDictionary(p => p.Id));
        }

        public async Task<Transition> CreateAsync(Transition transition)
        {
            await _db.Transitions.AddAsync(transition);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return transitionsCache.AddOrUpdate(transition.Id, transition, UpdateCache);
            return null;
        }

        public Task<IEnumerable<Transition>> RetrieveAllAsync()
        {
            return Task.Run<IEnumerable<Transition>>(() => transitionsCache.Values);
        }

        public Task<Transition> RetrieveAsync(Guid id)
        {
            return Task.Run(() =>
            {
                transitionsCache.TryGetValue(id, out Transition? transition);
                return transition;
            });
        }

        public async Task<Transition> UpdateAsync(Transition transition)
        {
            _db.Transitions.Update(transition);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return UpdateCache(transition.Id, transition);
            return null;
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            Transition? deleted = _db.Transitions.Find(id);
            _db.Transitions.Remove(deleted);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
                return transitionsCache.TryRemove(id, out deleted);
            return null;
        }

        private Transition UpdateCache(Guid id, Transition transition)
        {
            Transition? old;
            if (transitionsCache.TryGetValue(id, out old))
                if (transitionsCache.TryUpdate(id, transition, old))
                    return transition;
            return null;
        }
    }
}
