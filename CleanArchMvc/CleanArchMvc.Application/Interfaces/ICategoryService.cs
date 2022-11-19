using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetCategories();
        public Task<CategoryDTO> GetById(int id);
        public Task Add(CategoryDTO categoryDto);
        public Task Update(CategoryDTO categoryDto);
        public Task Remove(int? id);
    }
}
