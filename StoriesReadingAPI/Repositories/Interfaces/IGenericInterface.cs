﻿using System.Linq.Expressions;

public interface IRepositoryBase<T> where T : class
{
    T? Add(T objModel);
    T? AddNoSave(T objModel);
    void AddRange(IEnumerable<T> objModel);
    void AddRangeNoSave(IEnumerable<T> objModel);
    T? GetId(int id);
    Task<T?> GetIdAsync(int id);
    T? Get(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    int Count();
    Task<int> CountAsync();
    void Update(T objModel);
    void Remove(T objModel);
    void Dispose();
    void SaveChangesExtra();
    bool Exists(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}