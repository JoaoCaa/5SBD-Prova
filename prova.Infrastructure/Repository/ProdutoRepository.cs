using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.Infra.Context;

namespace Prova.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProvaContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await Db.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetProduto(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
