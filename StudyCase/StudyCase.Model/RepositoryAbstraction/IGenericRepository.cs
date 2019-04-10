using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Model.RepositoryAbstraction
{
        public interface IGenericRepository<T> where T : class
        {
            IQueryable<T> GetAll(IEnumerable<string> IncludeEntities = null);
            T Find(Expression<Func<T, bool>> predicate, IEnumerable<string> IncludeEntities = null);
            IQueryable<T> FindMany(Expression<Func<T, bool>> predicate, IEnumerable<string> IncludeEntities = null);
            int Add(T entity);
            void Delete(T entity);
            void Edit(T entity);
        }
    }

