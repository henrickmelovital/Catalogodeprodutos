using ProVarejista.Infrastructure.Context;
using ProVarejista.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProVarejista.Domain.Interfaces;

namespace ProVarejista.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private AppDbContext _categoryContext;
        public CategoriaRepository(AppDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Categoria> CreateAsync(Categoria category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            try
            {
                var categorias = await _categoryContext.Categorias.ToListAsync();
                return categorias;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                var erro2 = ex.InnerException;
                var erro3 = ex.StackTrace;
                throw;
            }

        }

        public async Task<Categoria> RemoveAsync(Categoria category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Categoria> UpdateAsync(Categoria category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
