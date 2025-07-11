﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly  ApplicationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext ??= dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public virtual IQueryable<T> Query()
    {
        return _dbSet.AsQueryable();
    }
    
    public virtual List<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
        //return _dbContext.Set<T>().AsNoTracking().ToList();
    }

    public virtual (IEnumerable<T>, int) GetFilter(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? skip = null,
        int? take = null,
        params Func<IQueryable<T>, IQueryable<T>>[]? includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = include(query);
            }
        }

        // Apply the filter if provided
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Apply ordering if provided
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        // Apply pagination: Skip and Take values
        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return (query.ToList(), CountTotalPages(filter, take));
    }

    private int CountTotalPages(Expression<Func<T, bool>>? filter, int? take)
    {
        IQueryable<T> query = _dbSet;

        // Apply the filter if provided
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Count total number of records
        var totalRecords = query.Count();

        // Ensure 'take' has a value and is greater than 0, otherwise assume all records fit on one page
        if (!take.HasValue || take.Value <= 0)
        {
            return 1; // If no 'take' value or invalid 'take', return 1 page
        }

        // Calculate total pages based on total records and take (items per page)
        var totalPages = (int)Math.Ceiling((double)totalRecords / take.Value);

        return totalPages;
    }

    public virtual bool Create(T entity)
    {
        _dbContext.Add(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public virtual bool Create(IEnumerable<T> entities)
    {
        _dbContext.AddRange(entities);
        return _dbContext.SaveChanges() > 0;
    }

    public virtual bool Update(T entity)
    {
        var tracker = _dbContext.Attach(entity);
        tracker.State = EntityState.Modified;
        return _dbContext.SaveChanges() > 0;
    }

    public virtual bool Remove(T entity)
    {
        _dbContext.Remove(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public virtual T? GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public virtual T? GetById(string code)
    {
        return _dbContext.Set<T>().Find(code);
    }

    public virtual T? GetById(Guid code)
    {
        return _dbContext.Set<T>().Find(code);
    }

    public virtual void Detach(T entity)
    {
        var entry = _dbContext.Entry(entity);
        if (entry != null!)
        {
            entry.State = EntityState.Detached;
        }
    }

    #region Asynchronous

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<(IEnumerable<T>, int)> GetFilterAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? skip = null,
        int? take = null,
        params Func<IQueryable<T>, IQueryable<T>>[]? includes)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = include(query);
            }
        }

        // Apply the filter if provided
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Apply ordering if provided
        if (orderBy != null)
        {
            query = orderBy(query);
        }

        // Apply pagination: Skip and Take values
        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return (await query.ToListAsync(), await CountTotalPagesAsync(filter, take));
    }

    public virtual async Task<bool> CreateAsync(T entity)
    {
        _dbContext.Add(entity);
        var result = await _dbContext.SaveChangesAsync() > 0;

        // Detach the entity after saving to avoid tracking conflicts
        _dbContext.Entry(entity).State = EntityState.Detached;

        return result;
    }


    public virtual async Task<bool> CreateAsync(IEnumerable<T> entities)
    {
        await _dbContext.AddRangeAsync(entities);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        var tracker = _dbContext.Attach(entity);
        tracker.State = EntityState.Modified;

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> RemoveAsync(T entity)
    {
        _dbContext.Remove(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetByIdAsync(string code)
    {
        return await _dbContext.Set<T>().FindAsync(code);
    }

    public virtual async Task<T?> GetByIdAsync(Guid code)
    {
        return await _dbContext.Set<T>().FindAsync(code);
    }
    
    public virtual T? GetByIdWithIncludes(Guid id, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query.FirstOrDefault(e => EF.Property<Guid>(e, "Id") == id);
    }

    #endregion


    #region Separating asigned entities and save operators

    public virtual void PrepareCreate(T entity)
    {
        _dbContext.Add(entity);
    }

    public virtual void PrepareCreate(IEnumerable<T> entities)
    {
        _dbContext.AddRange(entities);
    }

    public virtual void PrepareUpdate(T entity)
    {
        var tracker = _dbContext.Attach(entity);
        tracker.State = EntityState.Modified;
    }

    public virtual bool PrepareUpdate(IEnumerable<T> entities)
    {
        _dbContext.Attach(entities);
        return _dbContext.SaveChanges() > 0;
    }

    public virtual void PrepareRemove(T entity)
    {
        _dbContext.Remove(entity);
    }

    public virtual bool Save()
    {
        return _dbContext.SaveChanges() > 0;
    }

    public virtual async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }

    #endregion Separating assign entity and save operators

    private async Task<int> CountTotalPagesAsync(Expression<Func<T, bool>>? filter = null,
        int? take = null)
    {
        IQueryable<T> query = _dbSet;

        // Apply the filter if provided
        if (filter != null)
        {
            query = query.Where(filter);
        }

        // Count total number of records
        var totalRecords = await query.CountAsync();

        // Ensure 'take' has a value and is greater than 0, otherwise assume all records fit on one page
        if (!take.HasValue || take.Value <= 0)
        {
            return 1;
        }

        var totalPages = (int)Math.Ceiling((double)totalRecords / take.Value);

        return totalPages;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    public async Task<List<T>> GetListWithConditionAsync(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.Where(filter).ToListAsync();
    }

}