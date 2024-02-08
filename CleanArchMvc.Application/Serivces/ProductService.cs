using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Serivces
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            var productE = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(productE);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productQuery = new GetProductByIdQuery(id.Value);

        //    var productCategoryE = await _mediator.Send(productQuery);
        //    return _mapper.Map<ProductDTO>(productCategoryE);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new ApplicationException($"Entity could not be loaded.");

            var productsE = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(productsE);
        }

        public async Task Remove(int? id)
        {
            var productCommand = new ProductRemoveCommand(id.Value);
            await _mediator.Send(productCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            if (productCreateCommand == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _mediator.Send(productCreateCommand);
        }
    }
}
