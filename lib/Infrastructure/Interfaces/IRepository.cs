namespace Infrastructure.Interfaces;

using Core.Abstractions;

using System.Data;
using System.Linq.Expressions;

public interface IRepository<T> where T : DataModelBase
{
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

    Task<T?> GetByIdAsync(int id);

    IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null);

    IQueryable<T> SearchForAsync(Expression<Func<T, bool>> predicate);

    IDbConnection GetConnection();
}
