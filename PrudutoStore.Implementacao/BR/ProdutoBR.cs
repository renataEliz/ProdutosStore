using ProdutoStore.Core.BR;
using ProdutoStore.Core.Repositorio;
using ProdutoStore.Dto;
using ProdutoStore.Model.Entidades;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace PrudutoStore.Implementacao.BR
{
    public class ProdutoBR : BusinessRulesAbstrato<Produto>, IProdutoBR, IBusinessRules<Produto>
    {
        public ProdutoBR(IRepositorio<Produto> repositorio) : base(repositorio)
        {
        }

        public async Task<ProdutoDto> CarregarProduto(int? id)
        {
            var produtoDto = new ProdutoDto();
            if (id > 0)
            {
                var produto = await repositorio.PesquisarEntidadeAsync(p => p.Id == id);
                if (produto != null)
                {
                    produtoDto = ConverteEntidadeParaDto(produto);
                }
            }
            produtoDto.Produtos = await CarregarListaProdutos();
            return produtoDto;
        }

        public async Task<List<ProdutoListaDto>> CarregarListaProdutos()
        {
            return ConverteEntidadeParaDto(await repositorio.ListarTodosAsync());
        }

        public async Task<RespostaDto> SalvarProdutoAsync(ProdutoDto produtoDto)
        {
            produtoDto.Ativo = true;
            var produto = ConverteDtoParaEntidade(produtoDto);
            try
            {
                this.BeginTransaction();
                await this.AdicionarAsync(produto);
                await this.CommitAsync();
                return new RespostaDto(true);
            }
            catch (Exception ex)
            {
                this.Rollback();
                return new RespostaDto(false, ex.Message);
            }
        }

        public async Task<RespostaDto> AlterarProdutoAsync(ProdutoDto produtoDto)
        {
            var produto = await repositorio.PesquisarEntidadeAsync(p => p.Id == produtoDto.Id);

            if (produto == null)
            {
                return new RespostaDto(false, "Produto não encontrado.");
            }
            produto = ConverteDtoParaEntidade(produtoDto, produto);
            try
            {
                this.BeginTransaction();
                await this.AtualizarAsync(produto);
                await this.CommitAsync();
                return new RespostaDto(true);
            }
            catch (Exception ex)
            {
                this.Rollback();
                return new RespostaDto(false, ex.Message);
            }
        }

        public async Task<RespostaDto> ExcluirProdutoAsync(int id)
        {
            var produto = await repositorio.PesquisarEntidadeAsync(p => p.Id == id);

            if(produto == null)
            {
                return new RespostaDto(false, "Produto não encontrado.");
            }
            try
            {
                this.BeginTransaction();
                await this.ExcluirAsync(produto);
                await this.CommitAsync();
                return new RespostaDto(true);
            }
            catch (Exception ex)
            {
                this.Rollback();
                return new RespostaDto(false, ex.Message);
            }
        }

        private Produto ConverteDtoParaEntidade(ProdutoDto produtoDto, Produto produto = null)
        {
            if (produto == null)
            {
                produto = new Produto();
            }

            produto.Nome = produtoDto.Nome;
            produto.Descricao = produtoDto.Descricao;
            produto.Ativo = produtoDto.Ativo;
            produto.Perecivel = produtoDto.Perecivel;
            produto.CategoriaId = produtoDto.CategoriaId;

            return produto;

        }

        private List<ProdutoListaDto> ConverteEntidadeParaDto(IList<Produto> produtos)
        {
            if (produtos == null)
            {
                return new List<ProdutoListaDto>();
            }
            return produtos.Select(p => new ProdutoListaDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Ativo = p.Ativo ? "Ativo" : "Não ativo",
                Perecivel = p.Perecivel ? "Sim" : "Não",
                NomeCategoria = p.Categoria.Descricao
            }).ToList();
        }

        private ProdutoDto ConverteEntidadeParaDto(Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Ativo = produto.Ativo,
                Perecivel = produto.Perecivel,
                CategoriaId = produto.CategoriaId
            };
        }

    }
}
