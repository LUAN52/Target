using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tarefa.repository
{
    
        public interface IRepository<T> where T : class
        {
            
            List<T> GetAll();

            int Update(T entity);

            int Delete(T entity);

            int insert(T entity);

            List<T> Query(Expression<Func<T, bool>> filter);

        }
    
}