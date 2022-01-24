using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IDataResult<T> Add(T entity);
        IDataResult<T> Delete(T entity);
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> filter = null);
        IDataResult<T> Update(T entity);
        T GetById(Guid id);
    }
}
