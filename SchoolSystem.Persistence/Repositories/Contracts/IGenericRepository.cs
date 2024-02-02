namespace SchoolSystem.Persistence.Repositories.Contracts
{
    using System;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T : class
    {
        T? GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        T? FirstOrDefault(Func<T, bool> predicate);
        void Add(T entity);
        void AddRange(IQueryable<T> entities);
        void Remove(T entity);
        void RemoveRange(IQueryable<T> entities);
    }
}
