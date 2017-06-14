//GB.Code.RepositoryPattern.Repositories

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GB.Code.RepositoryPattern.Contracts.Repositories;
using GB.Code.RepositoryPattern.ORM;

namespace GB.Code.RepositoryPattern.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>//, IDisposable
        where T : class, new()
        //where D : DbContext, new()
    {
        private string userId = string.Empty;
        //private D dataContext;
        protected DBModel DataContext;
        public RepositoryBase(DBModel dbContext)
        {
            DataContext = dbContext;
            //using (TextWriter logFile = File.CreateText(@"C:\WFColline\Log\EFQueries.log"))
            //{
            //    dbContext.Database.Log = l => logFile.WriteLine("EFQueries", l);
            //    logFile.FlushAsync();
            //}

        }
        //protected D DataContext
        //{
        //	get { if (dataContext == null) dataContext = new D(); return dataContext; }
        //	set { dataContext = value; }
        //}
        public int Add(T entity, string userId = "")
        {
            return TryAdd(entity, userId);
        }

        private int TryAdd(T entity, string userId = "")
        {
            
            //try
            //{
                DataContext.Set<T>().Add(entity);
                //DataContext.Entry(entity).State = EntityState.Added;
                //opStatus.Success = true;
                //opStatus.Entity = entity;
            //}
            //catch (Exception ex)
            //{
            //    opStatus = OperationStatus.CreateFromException(string.Format("Could not add {0}!", typeof(T)), ex);
            //}
            return 1;
        }

        //public OperationStatus AddAndSave(T entity, string userId = "")
        //{
        //	OperationStatus opStatus = new OperationStatus { Success = false };
        //	try
        //	{
        //		opStatus = TryAdd(entity, userId);
        //		if (!opStatus.Success)
        //			return opStatus;
        //		DataContext.SaveChanges();
        //		opStatus.Entity = entity;
        //		opStatus.Success = true;
        //	}
        //	catch (Exception ex)
        //	{
        //		opStatus = OperationStatus.CreateFromException(string.Format("Error adding {0}.", typeof(T)), ex);
        //	}
        //	return opStatus;
        //}

        public void Delete(T entity)
        {
            //OperationStatus opStat = TryDelete(entity);
            TryDelete(entity);
        }

        private void TryDelete(T entity)
        {
            //OperationStatus opStatus = new OperationStatus { Success = false };
            try
            {
                DataContext.Set<T>().Remove(entity);
                //opStatus.Success = true;
            }
            catch (Exception ex)
            {
                //opStatus = OperationStatus.CreateFromException(string.Format("Could not mark {0} for deletion!", typeof(T)), ex);
                throw new Exception(ex.Message ,  ex);
            }
            //return opStatus;
        }

        //public OperationStatus DeleteAndSave(T entity)
        //{
        //	OperationStatus opStatus = new OperationStatus { Success = false };
        //	try
        //	{
        //		opStatus = TryDelete(entity);
        //		if (!opStatus.Success)
        //			return opStatus;
        //		DataContext.SaveChanges();
        //		opStatus.Success = true;
        //	}
        //	catch (Exception ex)
        //	{
        //		opStatus = OperationStatus.CreateFromException(string.Format("{0} Delete failed!", typeof(T)), ex);
        //	}
        //	return opStatus;
        //}

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().Where(predicate);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().SingleOrDefault(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = DataContext.Set<T>();
            return query;
        }

        public IQueryable<T> FindAndInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = DataContext.Set<T>().Where(predicate);

            foreach (var include in includeExpressions)
            {
                query.Include(include).Load();
            }
            return query;
        }

        public void Update(T entity, string userId = "")
        {
            //OperationStatus opStatus = TryUpdate(entity, userId);
            TryUpdate(entity, userId);
        }

        private void TryUpdate(T entity, string userId = "")
        {
            //perationStatus opStatus = new OperationStatus { Success = false };
            try
            {
                DataContext.Entry(entity).State = EntityState.Modified;
                //opStatus.Success = true;
            }
            catch (Exception ex)
            {
                //opStatus.ExMessage = ex.Message;
            }
            //return opStatus;
        }

        //public OperationStatus UpdateAndSave(T entity, string userId = "")
        //{
        //	OperationStatus opStatus = new OperationStatus { Success = false };
        //	try
        //	{
        //		opStatus = TryUpdate(entity, userId);
        //		if (!opStatus.Success)
        //			return opStatus;
        //		DataContext.SaveChanges();
        //		opStatus.Success = true;
        //	}
        //	catch (Exception ex)
        //	{
        //		opStatus = OperationStatus.CreateFromException(string.Format("Could not update {0}!", typeof(T)), ex);
        //	}
        //	return opStatus;
        //}

        public bool UserCanModify(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DataContext != null)
                    DataContext.Dispose();
            }
        }
    }
}
