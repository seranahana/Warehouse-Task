using Warehouse.Library.Entities;

namespace Warehouse.Library.Storage
{
    public interface ITransitionsRepository
    {
        Task<Transition> CreateAsync(Transition transition);
        Task<bool?> DeleteAsync(Guid id);
        Task<IEnumerable<Transition>> RetrieveAllAsync();
        Task<Transition> RetrieveAsync(Guid id);
        Task<Transition> UpdateAsync(Transition transition);
    }
}