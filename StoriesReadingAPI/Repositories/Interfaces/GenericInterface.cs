﻿using Microsoft.EntityFrameworkCore;
using StoriesReadingAPI.Models.Contexts;
using System.Linq.Expressions;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{

    protected readonly SampleDBContext _context;
    public RepositoryBase(SampleDBContext context)
    {
        _context = context;
    }

    public TEntity Add(TEntity model)
    {
        _context.Set<TEntity>().Add(model);
        _context.SaveChanges();
        return model;
    }

    public TEntity AddNoSave(TEntity model)
    {
        _context.Set<TEntity>().Add(model);
        return model;
    }

    public void AddRange(IEnumerable<TEntity> model)
    {
        _context.Set<TEntity>().AddRange(model);
        _context.SaveChanges();
    }

    public void AddRangeNoSave(IEnumerable<TEntity> model)
    {
        _context.Set<TEntity>().AddRange(model);
    }

    public TEntity? GetId(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public async Task<TEntity?> GetIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Where<TEntity>(predicate).ToList();
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Task.Run(() => _context.Set<TEntity>().Where<TEntity>(predicate));
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Task.Run(() => _context.Set<TEntity>());
    }

    public int Count()
    {
        return _context.Set<TEntity>().Count();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    public void Update(TEntity objModel)
    {
        _context.Entry(objModel).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(TEntity objModel)
    {
        _context.Set<TEntity>().Remove(objModel);
        _context.SaveChanges();
    }

    public void SaveChangesExtra()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().Any(predicate);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate);
    }
}