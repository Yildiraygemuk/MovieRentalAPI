using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects;
using Core.Aspects.Autofact;
using Core.Aspects.Autofact.Logging;
using Core.Aspects.Autofact.Performance;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public IDataResult<MovieVm> GetById(Guid id)
        {
            var entity = _movieRepository.Get(x => x.Id == id);
            var dto = _mapper.Map<MovieVm>(entity);
            return new SuccessDataResult<MovieVm>(dto);
        }

        public IDataResult<IQueryable<MovieVm>> GetList()
        {
            var entityList = _movieRepository.GetAllQueryable();
            var dtoList = _mapper.ProjectTo<MovieVm>(entityList);
            return new SuccessDataResult<IQueryable<MovieVm>>(dtoList);
        }
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<IQueryable<MovieVm>> GetListByCategory(Guid categoryId)
        {
            var entityList = _movieRepository.GetAllQueryable(x => x.CategoryId == categoryId);
            var dtoList = _mapper.ProjectTo<MovieVm>(entityList);
            return new SuccessDataResult<IQueryable<MovieVm>>(dtoList);
        }

        public IResult Update(MoviePutDto movie)
        {
            var dto = _mapper.Map<Movie>(movie);
            var entity = _movieRepository.GetById(dto.Id);
            if (entity == null)
                return new ErrorResult(Messages.MovieNotFound);
            _mapper.Map(movie, entity);
            _movieRepository.Update(entity);
            return new SuccessDataResult<Movie>(entity);
        }
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(MovieDto movie)
        {
            IResult result = BusinessRules.Run(CheckIfmovieNameExists(movie.MovieName));
            if (result != null)
            {
                return result;
            }
            var mappedDto = _mapper.Map<Movie>(movie);
            _movieRepository.Add(mappedDto);
            return new SuccessResult(Messages.MovieAdded);
        }

        public IResult RentTheMovie(Guid id)
        {
            IResult result = BusinessRules.Run(CheckIfMovieIsRent(id));
            if (result != null)
            {
                return result;
            }
            var movieEntity = _movieRepository.Get(p => p.Id == id);
            movieEntity.IsRenting = true;
            movieEntity.FinishRentTime = DateTime.Today.AddDays(10);
            var mappedDto = _mapper.Map<MoviePutDto>(movieEntity);
            Update(mappedDto);
            return new SuccessResult(Messages.MovieRentalSuccesfull + movieEntity.FinishRentTime.Value.ToShortDateString());
        }
        public IResult CancelRentTheMovie(Guid id)
        {
            var movieEntity = _movieRepository.Get(p => p.Id == id);
            if (movieEntity == null)
                return new ErrorResult(Messages.MovieNotFound);
            movieEntity.IsRenting = false;
            movieEntity.FinishRentTime = null;
            var mappedDto = _mapper.Map<MoviePutDto>(movieEntity);
            Update(mappedDto);
            return new SuccessResult(Messages.MovieRentalCancalled);
        }
        private IResult CheckIfmovieNameExists(string movieName)
        {
            if (_movieRepository.Get(p => p.MovieName == movieName) != null)
            {
                return new ErrorResult(Messages.MovieNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfMovieIsRent(Guid id)
        {
            var film = _movieRepository.Get(p => p.Id == id);
            if (film == null)
            {
                return new ErrorResult(Messages.MovieNotFound);
            }
            if (film.IsRenting)
            {
                return new ErrorResult(Messages.MovieAlreadyRented + Messages.LastDateFinishTime + film.FinishRentTime);
            }
            return new SuccessResult();
        }

        public IResult Delete(Guid id)
        {
            var model = _movieRepository.GetById(id);
            if (model == null)
                return new ErrorResult(Messages.MovieNotFound);
            _movieRepository.Delete(model);
            return new SuccessResult(Messages.MovieDeleted);
        }

    }
}
