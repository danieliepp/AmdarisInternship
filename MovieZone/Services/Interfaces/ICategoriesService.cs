using MovieZone.API.Dtos;
using MovieZone.API.Dtos.CategoriesDtos;
using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<bool> UpdateCategory(int id, CreateOrUpdateCategoryDto category);
        Task<bool> DeleteCategory(int id);
        Task<CategoryDto> AddCategory(CreateOrUpdateCategoryDto category);

        Task<CategoryDto> GetCategoryById(int id);
    }
}
