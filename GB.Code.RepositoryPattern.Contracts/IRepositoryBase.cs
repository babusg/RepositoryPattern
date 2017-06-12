using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        int Add(T entity, string userId = "");

        void Delete(T entity);

        T FindOne(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        void Update(T entity, string userId = "");

        bool UserCanModify(T entity);

        IQueryable<T> FindAndInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
    }
}
