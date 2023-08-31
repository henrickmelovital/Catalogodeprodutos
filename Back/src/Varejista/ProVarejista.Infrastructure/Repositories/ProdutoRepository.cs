using Microsoft.EntityFrameworkCore;
using ProVarejista.Domain.Entities;
using ProVarejista.Domain.Interfaces;
using ProVarejista.Infrastructure.Context;

namespace ProVarejista.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppDbContext _productContext;
        public ProdutoRepository(AppDbContext context)
        {
            _productContext = context;
        }

        public async Task<Produto> CreateAsync(Produto product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Produto> GetByIdAsync(int? id)
        {
            //return await _productContext.Produtos.FindAsync(id);
            return await _productContext.Produtos.Include(c => c.Categoria)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _productContext.Produtos.ToListAsync();
        }

        public async Task<Produto> RemoveAsync(Produto product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Produto> UpdateAsync(Produto product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
