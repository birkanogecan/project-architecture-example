using StudyCase.Model.RepositoryAbstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Repository.RepositoryOperation
{
     public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ReservationContext context = new ReservationContext();
        public IQueryable<T> GetAll(IEnumerable<string> IncludeEntities = null)
         {
             throw new NotImplementedException();
         }

         public T Find(Expression<Func<T, bool>> predicate, IEnumerable<string> IncludeEntities = null)
         {
            using (context = new ReservationContext())
            {
                IQueryable<T> query = context.Set<T>().Where(predicate);
                if (IncludeEntities != null)
                    query = IncludeEntities.Aggregate(query, (current, includePath) => current.Include(includePath));

                return query.FirstOrDefault();
            }
        }

         public IQueryable<T> FindMany(Expression<Func<T, bool>> predicate, IEnumerable<string> IncludeEntities = null)
         {
            using (context = new ReservationContext())
            {
                IQueryable<T> query = context.Set<T>().Where(predicate);
                if (IncludeEntities != null)
                    query = IncludeEntities.Aggregate(query, (current, includePath) => current.Include(includePath));

                return query.ToList().AsQueryable();
            }
        }

         public int Add(T entity)
         {
            using (context = new ReservationContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                DbPropertyValues sa = context.Entry(entity).GetDatabaseValues();
                string keyName = sa.PropertyNames.First();
                int Id = sa.GetValue<int>(keyName);
                return Id;
            }
        }
        public virtual void Edit(T entity)
        {
            using (context = new ReservationContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                //context.Entry(entity).Reload();
            }
        }

        public void Delete(T entity)
         {
             throw new NotImplementedException();
         }
    }
}
