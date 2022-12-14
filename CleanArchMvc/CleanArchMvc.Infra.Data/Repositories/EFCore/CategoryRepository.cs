using System.Collections.Generic;
using System.Threading.Tasks;

using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories.EFCore
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return category;
        }
    }
}
