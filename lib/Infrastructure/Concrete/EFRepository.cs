namespace Infrastructure.Concrete;

using Core.Abstractions;

using Infrastructure.Contexts;
using Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

internal sealed class EFRepository<T>(SimpleVMSDbContext context) : IRepository<T> where T : DataModelBase
{
    readonly DbSet<T> _dbSet = context.Set<T>();

    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? predicate)
    {
        return predicate is null
            ? _dbSet
                .AsQueryable()
            : _dbSet
            .Where(predicate);

    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IDbConnection GetConnection()
    {
        return context.Database.GetDbConnection();
    }

    public IQueryable<T> SearchForAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet
            .Where(predicate);
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }


}