using DQ.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DQ.Store.UI.ViewModels.Produtos.Index.Maps
{
    public static class Extensions
    {
        public static IEnumerable<ProdutoIndexVM> ToProdutoIndexVM(this IEnumerable<Produto> data)
        {
            return data.Select(prod => new ProdutoIndexVM()
            {
                Id = prod.Id,
                Nome = prod.Nome,
                Preco = prod.Preco,
                Tipo = prod.TipoProduto.Nome,
                Qtde = prod.Qtde,
                DataCadastro = prod.DataCadastro
            });
        }
        
    }
}
