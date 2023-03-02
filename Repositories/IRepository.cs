using System.Linq.Expressions;

namespace Rss_Reader_BackEnd.Repositories;

public interface IRepository<T> {
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression);
    IQueryable<T> FindAllSorting(String orderBy);
    void Create(T entity);
    void Create(List<T> entity);
    void Save();
}