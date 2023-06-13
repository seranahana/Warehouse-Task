using Warehouse.Library.Entities;

namespace Warehouse.Library.Storage
{
    public interface IStatusesRepository
    {
        Task<Status> CreateAsync(Status status);
        Task<bool?> DeleteAsync(Guid id);
        Task<IEnumerable<Status>> RetrieveAllAsync();
        Task<Status> RetrieveAsync(Guid id);
        Task<Status> UpdateAsync(Status status);
    }
}