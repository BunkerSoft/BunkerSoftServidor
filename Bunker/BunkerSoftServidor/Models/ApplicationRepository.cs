using BunkerSoftServidor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


public abstract class ApplicationRepository<T> : IApplicationRepository<T> where T : class, IEntity
{
    private DbContext _context;

    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> FindAllAsync()
    {
        return await this._context.Set<T>().ToListAsync();
    }
 
    public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
    {
        return await this._context.Set<T>().Where(expression).ToListAsync();
    }
 
    public void Create(T entity)
    {
        this._context.Set<T>().Add(entity);
    }
 
    public void Update(T entity)
    {
        this._context.Set<T>().Update(entity);
    }
 
    public void Delete(T entity)
    {
        this._context.Set<T>().Remove(entity);
    }
 
    public async Task SaveAsync()
    {
        await this._context.SaveChangesAsync();
    }

    public void Dispose() {
         if(this._context != null) {
            this._context.Dispose();
            this._context = null;
         }
         }

}