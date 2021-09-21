using ProdutoStore.Core.BR;
using ProdutoStore.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProdutoStore.Web.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoBR produtoBR;
        private readonly ICategoriaBR categoriaBR;

        public ProdutoController(IProdutoBR produtoBR, ICategoriaBR categoriaBR)
        {
            this.produtoBR = produtoBR;
            this.categoriaBR = categoriaBR;
        }

        public async Task<ActionResult> Index(int? id)
        {
            var retorno = await produtoBR.CarregarProduto(id);
            await CarregarViewsDataAsync();
            return View(retorno);
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(ProdutoDto produtoDto)
        {

            if (!ModelState.IsValid)
            {
                await CarregarViewsDataAsync();
                produtoDto.Produtos = await produtoBR.CarregarListaProdutos();
                return View("Index", produtoDto);
            }
            var resposta = new RespostaDto();
            if (produtoDto.Id > 0)
            {
                resposta = await produtoBR.AlterarProdutoAsync(produtoDto);
                if (resposta.Sucesso)
                {
                    this.Sucesso = "Produto alterado com sucesso.";
                }
                else
                {
                    this.Erros = resposta.Erros;
                }
            }
            else
            {
                resposta = await produtoBR.SalvarProdutoAsync(produtoDto);
                if (resposta.Sucesso)
                {
                    this.Sucesso = "Produto salvo com sucesso.";
                }
                else
                {
                    this.Erros = resposta.Erros;
                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Excluir(int id)
        {
          
            var resposta = await produtoBR.ExcluirProdutoAsync(id);
            if (resposta.Sucesso)
            {
                this.Sucesso = "Produto excluído com sucesso.";
            }
            else
            {
                this.Erros = resposta.Erros;
            }
            return RedirectToAction("Index");
        }

        private async Task CarregarViewsDataAsync()
        {
            var categorias = await categoriaBR.ListarTodosAsync();

            ViewData["Categorias"] = new SelectList(categorias, "Id", "Descricao", null);
        }
    }
}