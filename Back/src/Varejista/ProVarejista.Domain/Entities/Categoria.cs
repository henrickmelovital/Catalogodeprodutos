using ProVarejista.Domain.Entities;
using ProVarejista.Domain.Validation;

namespace ProVarejista.Domain.Entities
{
    public class Categoria : Entity
    {
        public Categoria(string nome)
        {
            ValidateDomain(nome);
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(nome);
        }

        public string Nome { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
               "O nome deve ter no mínimo 3 caracteres");

            Nome = nome;
        }
    }
}
