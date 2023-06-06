using MinimalWebApiHelpDesk.Models;
using ServerAppHelpDesk.Interfaces;
using System.Linq.Expressions;

namespace MinimalWebApiHelpDesk.Interfaces
{
    public interface IDataStore
    {
        public abstract Task AddAsync<T>(T entity) where T : Entity;
        public abstract Task UpdateAsync<T>(T entity) where T : Entity;
        public abstract Task DeleteAsync<T>(int id) where T : Entity;
        public abstract Task<List<T>?> GetAllAsync<T>() where T : Entity;
        public abstract Task<IEnumerable<T>?> GetAllFilteredAsync<T>(Expression<Func<T, bool>> filter) where T : Entity;
        public abstract Task<T?> GetFirstAsync<T>() where T : Entity;
        public abstract Task<T?> GetFirstFilteredAsync<T>(Expression<Func<T, bool>> filter) where T : Entity;
        public abstract Task Save();
    }
}
