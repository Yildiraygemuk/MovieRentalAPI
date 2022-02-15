using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<MovieVm> GetById(Guid id);
        IDataResult<IQueryable<MovieVm>> GetList();
        IDataResult<IQueryable<MovieVm>> GetListByCategory(Guid categoryId);
        IResult Add(MovieDto movie);
        IResult Delete(Guid id);
        IResult Update(MoviePutDto movie);
        IResult RentTheMovie(Guid id);
        IResult CancelRentTheMovie(Guid id);
        void SendEmail(string filePath, string toEmail);
    }
}
