
using System.Threading;
using System.Threading.Tasks;

using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.Exceptions;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.Application.CQRS.Products.Handlers.Commands
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var productOnDatabase = await _productRepository.GetByIdAsync(request.Id);

            if (productOnDatabase is null)
            {
                throw new NotFoundException("Product not found");
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category is null)
            {
                throw new NotFoundException("Category not found");
            }

            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image)
            {
                CategoryId = request.CategoryId
            };

            return await _productRepository.UpdateAsync(product);
        }
    }
}
