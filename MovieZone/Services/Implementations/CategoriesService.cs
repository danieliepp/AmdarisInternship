using AutoMapper;
using MovieZone.API.Dtos.CategoriesDtos;
using MovieZone.API.Exceptions;
using MovieZone.API.Services.Interfaces;
using MovieZone.Domain;
using MovieZone.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.API.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {

        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddCategory(CreateOrUpdateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            //TODO Please do validation in beginning of the method.
            var categoryWithSameName = await _repository.FindBy(x => x.Name == categoryDto.Name);
            if (categoryWithSameName.Any())
            {
                throw new EntryAlreadyExistsException($"Category with name: '{categoryDto.Name} already exist!");
            }
            var result = await _repository.Add(category);
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var categoryToDelete = await _repository.FirstOrDefault(x => x.Id == id);
            if (categoryToDelete == null)
            {
                //TODO As an idea to create ValidationException
                throw new NotFoundException($"Category you trying to delete doesn't exist!");
            }
            var deleted = await _repository.Remove(categoryToDelete);

            return deleted;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _repository.GetById(id);
            var result = _mapper.Map<CategoryDto>(category);
            if (result == null)
            {
                throw new NotFoundException($"Category with {id} doesn't exist");
            }
            return result;
        }

        public async Task<bool> UpdateCategory(int id, CreateOrUpdateCategoryDto categoryDto)
        {
            var category = await _repository.GetById(id);
            if (category == null)
            {
                throw new NotFoundException($"Category you trying to Update doesn't exist");
            }
            category.Name = categoryDto.Name;

            var saved = await _repository.SaveAll();

            return saved;
        }
    }
}
