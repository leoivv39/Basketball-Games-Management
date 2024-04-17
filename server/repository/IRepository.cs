using main.domain;

namespace main.repository;

public interface IRepository<TId, T> where T : Entity<TId> where TId : struct
{
    T? Save(T entity);
    T? Update(T entity);
    T? DeleteById(TId id);
    T? FindById(TId id);
    IEnumerable<T> FindAll();
}