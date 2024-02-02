using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Serivces
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

        public async Task Add(CategoryDTO categoryDto)
        {
            var categorieE = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(categorieE);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categorieE = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categorieE);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesE = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesE);
        }

        public async Task Remove(int? id)
        {
            var categoryE = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.RemoveAsync(categoryE);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categorieE = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(categorieE);
        }
    }
}
