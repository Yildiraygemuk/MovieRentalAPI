using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Linq;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<CategoryVm> GetById(Guid categoryId);
        IDataResult<IQueryable<CategoryVm>> GetList();
        IResult Add(CategoryDto category);
        IResult Delete(Guid id);
        IResult Update(CategoryPutDto category);
        IDataResult<IQueryable<CategoryVm>> GetListByCategory(Guid categoryId);
    }
}
