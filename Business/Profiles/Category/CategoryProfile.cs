using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Vms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryVm>();
            CreateMap<CategoryVm, Category>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryPutDto>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
