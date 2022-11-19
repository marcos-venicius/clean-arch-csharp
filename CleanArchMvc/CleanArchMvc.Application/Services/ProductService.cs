using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.CQRS.Products.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;

using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCommand = _mapper.Map<ProductCreateCommand>(productDto);

            await _mediator.Send(productCommand);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productQuery = new GetProductByIdQuery(id);

            var product = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productQuery = new GetProductsQuery();

            var products = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task Remove(int id)
        {
            var productCommand = new ProductRemoveCommand(id);

            await _mediator.Send(productCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            await _mediator.Send(productCommand);
        }
    }
}
