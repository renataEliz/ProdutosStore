
using System.Collections.Generic;
using System.Linq;

namespace ProdutoStore.Dto
{
    public class RespostaDto
    {
        public RespostaDto() { }
        public RespostaDto(bool sucesso,
            params string[] erros)
        {
            this.Sucesso = sucesso;
            this.Erros = erros;
        }

        public RespostaDto(bool sucesso,
            ICollection<string> erros)
        {
            this.Sucesso = sucesso;
            this.Erros = erros;
        }

        public RespostaDto(bool sucesso,
            IEnumerable<string> erros)
        {
            this.Sucesso = sucesso;
            this.Erros = erros.ToList();
        }

        public bool Sucesso { get; protected set; }

        public ICollection<string> Erros { get; protected set; }

        public void Deconstruct(out bool sucesso, out ICollection<string> erros)
        {
            sucesso = this.Sucesso;
            erros = this.Erros;
        }
    }
}
