using Ganesha.Core;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ganesha.Service {
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext, new() {

        private C _entities = new C();
        public C Context {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll() {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate) {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity) {
            _entities.Set<T>().Add(entity);
            Save();
        }

        public virtual void Delete(T entity) {
            _entities.Set<T>().Remove(entity);
            Save();
        }

        public virtual void Update(T entity) {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _entities.Set<T>().Attach(entity);
            _entities.Entry(entity).State = EntityState.Modified;
            Save();

        }

        public virtual void Save() {
            _entities.SaveChanges();

        }
    }
}