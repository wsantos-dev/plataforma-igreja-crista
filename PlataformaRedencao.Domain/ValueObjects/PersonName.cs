namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Representa o nome civil completo de uma pessoa.
    /// </summary>
    /// <remarks>
    /// <see cref="PersonName"/> é um Value Object e, portanto:
    /// - Não possui identidade própria.
    /// - É imutável após sua criação.
    /// - É comparado por valor.
    /// 
    /// Este objeto encapsula o primeiro nome e o sobrenome conforme
    /// registro civil da pessoa.
    /// </remarks>
    public sealed class PersonName
    {
        /// <summary>
        /// Primeiro nome civil da pessoa.
        /// </summary>
        /// <remarks>
        /// Corresponde ao primeiro nome registrado oficialmente.
        /// </remarks>
        public string FirstName { get; }

        /// <summary>
        /// Sobrenome da pessoa.
        /// </summary>
        /// <remarks>
        /// Representa o nome de família conforme registro civil.
        /// </remarks>
        public string LastName { get; }

        private PersonName() { } // EF Core

        /// <summary>
        /// Cria uma nova instância de <see cref="PersonName"/>.
        /// </summary>
        /// <param name="firstName">Primeiro nome civil da pessoa.</param>
        /// <param name="lastName">Sobrenome da pessoa.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando primeiro nome ou sobrenome são inválidos.
        /// </exception>
        public PersonName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("O primeiro nome não pode ser vazio.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("O sobrenome não pode ser vazio.", nameof(lastName));

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        /// <summary>
        /// Retorna o nome completo formatado.
        /// </summary>
        public override string ToString()
            => $"{FirstName} {LastName}";

        /// <summary>
        /// Compara dois <see cref="PersonName"/> por valor.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not PersonName other)
                return false;

            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        /// <summary>
        /// Gera o código hash com base nos valores do objeto.
        /// </summary>
        public override int GetHashCode()
            => HashCode.Combine(FirstName, LastName);
    }
}
