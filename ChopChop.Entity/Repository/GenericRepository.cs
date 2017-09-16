using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChopChop.Entity;
using ChopChop.Entity.EntityFramework;

namespace ChopChop.Entity.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        private ChopChopEntities _entities = new ChopChopEntities();

        public ChopChopEntities Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            Save();
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            Save();
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _entities.SaveChanges();
            _entities.Dispose();
        }
    }
}
