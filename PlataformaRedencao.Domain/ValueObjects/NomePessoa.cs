namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Representa o Primeiro civil completo de uma pessoa.
    /// </summary>
    /// <remarks>
    /// <see cref="NomePessoa"/> é um Value Object e, portanto:
    /// - Não possui identidade própria.
    /// - É imutável após sua criação.
    /// - É comparado por valor.
    /// 
    /// Este objeto encapsula o Primeiro e o SobreNome conforme
    /// registro civil da pessoa.
    /// </remarks>
    public sealed class NomePessoa
    {
        /// <summary>
        /// Primeiro civil da pessoa.
        /// </summary>
        /// <remarks>
        /// Corresponde ao prePrimeiro registrado oficialmente.
        /// </remarks>
        public string PrimeiroNome { get; }

        /// <summary>
        /// SobreNome da pessoa.
        /// </summary>
        /// <remarks>
        /// Representa o Primeiro de família conforme registro civil.
        /// </remarks>
        public string SobreNome { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="NomePessoa"/>.
        /// </summary>
        /// <param name="Primeiro">Primeiro civil da pessoa.</param>
        /// <param name="SobreNome">SobreNome da pessoa.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando Primeiro ou SobreNome são inválidos.
        /// </exception>
        public NomePessoa(string primeiro, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(primeiro))
                throw new ArgumentException("O Primeiro não pode ser vazio.", nameof(primeiro));

            if (string.IsNullOrWhiteSpace(primeiro))
                throw new ArgumentException("O SobreNome não pode ser vazio.", nameof(sobrenome));

            PrimeiroNome = primeiro.Trim();
            SobreNome = sobrenome.Trim();
        }

        /// <summary>
        /// Retorna o Primeiro completo formatado.
        /// </summary>
        public override string ToString()
            => $"{PrimeiroNome} {SobreNome}";

        /// <summary>
        /// Compara dois <see cref="NomePessoa"/> por valor.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not NomePessoa other)
                return false;

            return PrimeiroNome == other.PrimeiroNome
                && SobreNome == other.SobreNome;
        }

        /// <summary>
        /// Gera o código hash com base nos valores do objeto.
        /// </summary>
        public override int GetHashCode()
            => HashCode.Combine(PrimeiroNome, SobreNome);
    }
}
