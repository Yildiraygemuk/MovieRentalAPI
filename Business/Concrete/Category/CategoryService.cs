using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IDataResult<CategoryVm> GetById(Guid id)
        {
            var entity = _categoryRepository.Get(x => x.Id == id);
            var dto = _mapper.Map<CategoryVm>(entity);
            return new SuccessDataResult<CategoryVm>(dto);
        }

        public IDataResult<IQueryable<CategoryVm>> GetList()
        {
            var entityList = _categoryRepository.GetAllQueryable();
            var dtoList = _mapper.ProjectTo<CategoryVm>(entityList);
            return new SuccessDataResult<IQueryable<CategoryVm>>(dtoList);
        }

        public IDataResult<IQueryable<CategoryVm>> GetListByCategory(Guid categoryId)
        {
            var entityList = _categoryRepository.GetAllQueryable(x => x.Id == categoryId);
            var dtoList = _mapper.ProjectTo<CategoryVm>(entityList);
            return new SuccessDataResult<IQueryable<CategoryVm>>(dtoList);
        }

        public IResult Update(CategoryPutDto category)
        {
            var dto = _mapper.Map<Category>(category);
            var entity = _categoryRepository.GetById(dto.Id);
            if (entity == null)
                return new ErrorResult(Messages.CategoryNotFound);
            _mapper.Map(category, entity);
            _categoryRepository.Update(entity);
            return new SuccessDataResult<Category>(entity);
        }

        public IResult Add(CategoryDto category)
        {
            var mappedDto = _mapper.Map<Category>(category);
            _categoryRepository.Add(mappedDto);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Guid id)
        {
            var model = _categoryRepository.GetById(id);
            if(model == null)
                return new ErrorResult(Messages.CategoryNotFound);
            _categoryRepository.Delete(model);
            return new SuccessResult(Messages.CategoryDeleted);
        }
    }
}
