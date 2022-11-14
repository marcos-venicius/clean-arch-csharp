using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetProducts();
        public Task<ProductDTO> GetById(int id);
        public Task Add(ProductDTO productDto);
        public Task Update(ProductDTO productDto);
        public Task Remove(int? id);
    }
}
