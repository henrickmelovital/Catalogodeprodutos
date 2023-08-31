using ProVarejista.Domain.Validation;

namespace ProVarejista.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public Produto(string nome, string descricao, decimal preco,
        int quantidade, DateTime dataCadastro)
        {
            ValidateDomain(nome, descricao, preco, quantidade, dataCadastro);
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void Update(string nome, string descricao, decimal preco,
            int quantidade, DateTime dataCadastro, int categoriaId)
        {
            ValidateDomain(nome, descricao, preco, quantidade, dataCadastro);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string descricao, decimal preco,
            int quantidade, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

            DomainExceptionValidation.When(quantidade < 0, "Estoque inválido");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
            DataCadastro = dataCadastro;

        }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
