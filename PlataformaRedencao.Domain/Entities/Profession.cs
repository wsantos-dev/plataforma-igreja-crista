namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa uma profissão exercida por uma pessoa.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Profession"/> é utilizada como referência
    /// para classificar a ocupação profissional de uma pessoa.
    ///
    /// Algumas profissões possuem significado especial no domínio,
    /// como a profissão padrão "Não informado".
    /// </remarks>
    public sealed class Profession : BaseEntity
    {
        /// <summary>
        /// Código utilizado para representar profissão não informada.
        /// </summary>
        public const string NotInformedCode = "0000";

        /// <summary>
        /// Nome da profissão.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Código oficial da profissão (ex.: CBO).
        /// </summary>
        public string? Code { get; private set; }

        public Profession(int id, string name, string? code = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "O nome da profissão não pode ser vazio.",
                    nameof(name));

            Id = id;
            Name = name.Trim();
            Code = string.IsNullOrWhiteSpace(code) ? null : code.Trim();
        }

        /// <summary>
        /// Indica se esta profissão representa o valor padrão
        /// "Não informado".
        /// </summary>
        public bool IsNotInformed()
            => Code == NotInformedCode;

        /// <summary>
        /// Cria a instância padrão de profissão "Não informado".
        /// </summary>
        /// <remarks>
        /// Deve ser utilizada exclusivamente para seed inicial
        /// ou cenários controlados de inicialização.
        /// </remarks>
        public static Profession CreateNotInformed()
        {
            const int DefaultId = 999;
            return new Profession(DefaultId, "Não informado", NotInformedCode);
        }
    }
}
