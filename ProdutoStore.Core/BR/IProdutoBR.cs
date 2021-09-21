using ProdutoStore.Dto;
using ProdutoStore.Model.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoStore.Core.BR
{
    public interface IProdutoBR : IBusinessRules<Produto>
    {
        Task<RespostaDto> AlterarProdutoAsync(ProdutoDto produtoDto);
        Task<List<ProdutoListaDto>> CarregarListaProdutos();
        Task<ProdutoDto> CarregarProduto(int? id);
        Task<RespostaDto> ExcluirProdutoAsync(int id);
        Task<RespostaDto> SalvarProdutoAsync(ProdutoDto produtoDto);
    }
}
