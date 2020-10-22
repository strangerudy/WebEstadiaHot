using DQ.Store.Domain.Contracts.Repositories;
using DQ.Store.UI.ViewModels.Produtos.AddEdit;
using DQ.Store.UI.ViewModels.Produtos.AddEdit.Maps;
using DQ.Store.UI.ViewModels.Produtos.Index.Maps;
using System.Web.Mvc;

namespace Buya.App.UI.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ITipoProdutoRepository _tipoProdutoRepository;

        /* Inversão de Controller
          Se não passar os parametros do 2º construtor executa o primeiro 
             
        */
        
        public ProdutosController(IProdutoRepository produtoRepository, ITipoProdutoRepository tipoProdutoRepository)
        {
            _produtoRepository = produtoRepository;
            _tipoProdutoRepository = tipoProdutoRepository;
        }

        public ViewResult Index()
        {
            var produtos = _produtoRepository.Get().ToProdutoIndexVM(); //Buscar os tipos de produtos e acoplar numa única ViewModel
            return View(produtos);
        }

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var produto = new ProdutoAddEditVM();
            if (id != null)
            {
                produto = _produtoRepository.Get((int)id).ToProdutoAddEditVM();
            }

            var tipos = _tipoProdutoRepository.Get(); //Buscar os tipos de produtos
            ViewBag.Tipos = tipos; //Carregar na View e DropDownList
            return View(produto);
        } 

        [HttpPost]
        public ActionResult AddEdit(ProdutoAddEditVM produtoVM) //Guardar na Tabela
        {
            var produto = produtoVM.ToProduto();

            //Falta fazer a validação
            if (ModelState.IsValid)
            {
                if (produto.Id == 0) //Para salvar novo produto
                {
                    _produtoRepository.Add(produto);
                }
                else //Para actualizar produto existente
                {
                    _produtoRepository.Edit(produto);
                }

                return RedirectToAction("Index");
            }

            var tipos = _tipoProdutoRepository.Get(); //Buscar os tipos de produtos
            ViewBag.Tipos = tipos; //Carregar na View e DropDownList
            return View(produto);
        }

        public ActionResult DelProd(int id)
        {
            var produto = _produtoRepository.Get(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            _produtoRepository.Delete(produto);
            return null; //null
        }

        protected override void Dispose(bool disposing) //Fechar conexão
        {}
    }
}
