using DQ.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ.Store.UI.ViewModels.Produtos.AddEdit.Maps
{
    public static class Extensions
    {
        public static ProdutoAddEditVM ToProdutoAddEditVM(this Produto model)
        {
            return new ProdutoAddEditVM()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Qtde = model.Qtde,
                DataCadastro = model.DataCadastro
            };
        }
        public static Produto ToProduto(this ProdutoAddEditVM model)
        {
            return new Produto()
            {
                Id = model.Id,
                Nome = model.Nome,
                Preco = model.Preco,
                TipoProdutoId = model.TipoProdutoId,
                Qtde = model.Qtde,
                DataCadastro = model.DataCadastro
            };
        }
    }
}
