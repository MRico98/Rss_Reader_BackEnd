using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Rss_Reader_BackEnd.Context;

namespace Rss_Reader_BackEnd.Repositories.Impl;

public class Repository<T> : IRepository<T> where T: class
{
    protected RepositoryContext RepositoryContext { get; set; }

    public Repository(RepositoryContext RepositoryContext)
    {
        this.RepositoryContext = RepositoryContext;
    }

    public void Create(T entity)
    {
        this.RepositoryContext.Set<T>().Add(entity);
    }

    public void Create(List<T> entities)
    {
        this.RepositoryContext.Set<T>().AddRange(entities);
    }

    public IQueryable<T> FindAll()
    {
        return this.RepositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
    }

    public IQueryable<T> FindAllSorting(String orderBy){
        return RepositoryContext.Set<T>().OrderBy(orderBy).AsNoTracking();
    }

    public void Save()
    {
        this.RepositoryContext.SaveChanges();
    }
}