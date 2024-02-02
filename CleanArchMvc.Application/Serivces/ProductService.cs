using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Serivces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productE = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productE);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productE = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productE);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productCategoryE = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productCategoryE);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsE = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsE);
        }

        public async Task Remove(int? id)
        {
            var productE = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(productE);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productE = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productE);
        }
    }
}
