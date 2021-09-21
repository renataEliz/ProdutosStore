using System.Collections.Generic;

namespace ProdutoStore.Dto
{
    public class RespostaDto<T> : RespostaDto
    {
        public RespostaDto() { }

        public RespostaDto(bool sucesso,
            T conteudo,
            params string[] erros)
            : base(sucesso, erros)
        {
            this.Conteudo = conteudo;
        }

        public RespostaDto(bool sucesso,
            T conteudo,
            ICollection<string> erros)
            : base(sucesso, erros)
        {
            this.Conteudo = conteudo;
        }

        public RespostaDto(RespostaDto respostaDto)
            : base(respostaDto.Sucesso, respostaDto.Erros)
        {
        }

        public RespostaDto(bool sucesso, params string[] erros)
            : base(sucesso, erros)
        {
        }

        public RespostaDto(bool sucesso, ICollection<string> erros)
            : base(sucesso, erros)
        {
        }

        public T Conteudo { get; protected set; }

        public void Deconstruct(out bool sucesso, out T conteudo, out ICollection<string> erros)
        {
            sucesso = this.Sucesso;
            conteudo = this.Conteudo;
            erros = this.Erros;
        }
    }
}
