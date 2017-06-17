using GB.Code.RepositoryPattern.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GB.Code.RepositoryPattern.Fake
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class, new()
    {

        protected List<T> Entities;
        public Expression<Func<T, int>> KeyExpression { get; set; }


        public RepositoryBase(Expression<Func<T, int>> keyExpression)
        {
            Entities = new List<T>();
            KeyExpression = keyExpression;
        }

        public int Add(T entity, string userId)
        {
            Entities.Add(entity);
            var propInfo = (PropertyInfo)((MemberExpression)KeyExpression.Body).Member;
            propInfo.SetValue(entity, Entities.Count + 1, null);

            return (int) propInfo.GetValue(entity);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public  IQueryable<T> FindAndInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            return Entities.AsQueryable().Where(predicate);
        }

        IQueryable<T> IRepositoryBase<T>.FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().Where(predicate);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().SingleOrDefault(predicate); 
        }

        public IQueryable<T> GetAll()
        {
            return Entities.AsQueryable();
        }

        public void Update(T entity, string userId)
        {
            var keyFunc = KeyExpression.Compile();
            var propInfo = (PropertyInfo)((MemberExpression)KeyExpression.Body).Member;
            var id = (int) propInfo.GetValue(entity);
            var existingEntity= Entities.Where(e => keyFunc(e) == id).FirstOrDefault();
            Entities.Remove(existingEntity);
            Entities.Add(entity);

        }

        bool IRepositoryBase<T>.UserCanModify(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
