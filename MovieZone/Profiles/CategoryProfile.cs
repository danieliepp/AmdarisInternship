using AutoMapper;
using MovieZone.API.Dtos.CategoriesDtos;
using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CreateOrUpdateCategoryDto>();
            CreateMap<CreateOrUpdateCategoryDto, Category>();
        }
    }
}
