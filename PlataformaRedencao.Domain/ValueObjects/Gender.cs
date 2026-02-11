using System;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa o sexo de uma pessoa no domínio.
    /// 
    /// Trata-se de um conceito de domínio com conjunto fechado de valores válidos,
    /// representados por códigos simbólicos persistíveis.
    /// 
    /// Este objeto é imutável e possui igualdade definida por valor.
    /// </summary>
    public sealed class Gender : IEquatable<Gender>
    {
        /// <summary>
        /// Código simbólico que representa o sexo da pessoa.
        /// 
        /// Valores válidos:
        /// <list type="bullet">
        /// <item><description><c>M</c> - Masculino</description></item>
        /// <item><description><c>F</c> - Feminino</description></item>
        /// </list>
        /// 
        /// Este código é utilizado para persistência e integração entre camadas.
        /// </summary>
        public char Code { get; }

        /// <summary>
        /// Descrição textual do sexo, destinada a uso semântico
        /// e apresentação em camadas externas.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Construtor privado para garantir a criação controlada
        /// das instâncias válidas do Value Object.
        /// </summary>
        /// <param name="code">Código simbólico do sexo.</param>
        /// <param name="description">Descrição textual do sexo.</param>
        private Gender(char code, string description)
        {
            Code = code;
            Description = description;
        }

        /// <summary>
        /// Representa o sexo masculino.
        /// </summary>
        public static readonly Gender Male = new('M', "Masculino");

        /// <summary>
        /// Representa o sexo feminino.
        /// </summary>
        public static readonly Gender Female = new('F', "Feminino");

        /// <summary>
        /// Cria uma instância de <see cref="Gender"/> a partir de um código simbólico.
        /// </summary>
        /// <param name="code">Código do sexo (ex.: M, F).</param>
        /// <returns>Instância correspondente de <see cref="Gender"/>.</returns>
        /// <exception cref="ArgumentException">
        /// Lançada quando o código é nulo, vazio ou não corresponde a um valor válido do domínio.
        /// </exception>
        public static Gender FromCode(char code)
        {
            if (char.IsWhiteSpace(code))
                throw new ArgumentException("Código do sexo é obrigatório.");

            return char.ToUpperInvariant(code) switch
            {
                'M' => Male,
                'F' => Female,
                _ => throw new ArgumentException($"Código de sexo inválido: '{code}'.")
            };
        }

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// <c>true</c> se os objetos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
            => Equals(obj as Gender);

        /// <summary>
        /// Determina se outro <see cref="Gender"/> é igual ao objeto atual,
        /// com base no código do domínio.
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Gender"/>.</param>
        /// <returns>
        /// <c>true</c> se os códigos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Gender? other)
            => other is not null && Code == other.Code;

        /// <summary>
        /// Retorna o código hash baseado no valor do domínio.
        /// </summary>
        /// <returns>Código hash do objeto.</returns>
        public override int GetHashCode()
            => Code.GetHashCode();

        /// <summary>
        /// Operador de igualdade entre dois objetos <see cref="Gender"/>.
        /// </summary>
        public static bool operator ==(Gender left, Gender right)
            => Equals(left, right);

        /// <summary>
        /// Operador de desigualdade entre dois objetos <see cref="Gender"/>.
        /// </summary>
        public static bool operator !=(Gender left, Gender right)
            => !Equals(left, right);

        /// <summary>
        /// Retorna a descrição textual do sexo.
        /// </summary>
        /// <returns>Descrição do sexo.</returns>
        public override string ToString()
            => Description;
    }
}
