namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IQueryable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual T? FirstOrDefault(Func<T, bool> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
