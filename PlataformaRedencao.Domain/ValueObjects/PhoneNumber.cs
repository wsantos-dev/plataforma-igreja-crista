using System;
using System.Text.RegularExpressions;

namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa um número de telefone no domínio.
    /// 
    /// Encapsula validação e formatação de números de telefone,
    /// garantindo consistência e imutabilidade.
    /// </summary>
    public sealed class PhoneNumber : IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Expressão regular utilizada para validação básica
        /// de números de telefone brasileiros.
        /// </summary>
        private static readonly Regex PhoneRegex = new Regex(
            @"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$",
            RegexOptions.Compiled
        );

        /// <summary>
        /// Número de telefone validado.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="PhoneNumber"/>.
        /// </summary>
        /// <param name="number">Número de telefone.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando o número é nulo, vazio ou inválido.
        /// </exception>
        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("O número de telefone não pode ser vazio.", nameof(number));

            number = number.Trim();

            if (!PhoneRegex.IsMatch(number))
                throw new ArgumentException("Número de telefone inválido.", nameof(number));

            Number = number;
        }

        /// <summary>
        /// Formata o telefone de forma padrão: (XX) 9XXXX-XXXX.
        /// </summary>
        public string Format()
        {
            var digits = Regex.Replace(Number, @"\D", ""); // remove tudo que não é número

            if (digits.Length == 11) // celular com 9
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 5)}-{digits.Substring(7, 4)}";

            if (digits.Length == 10) // fixo
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 4)}-{digits.Substring(6, 4)}";

            return Number; // fallback
        }

        /// <summary>
        /// Implementação de Value Object (igualdade por valor).
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as PhoneNumber);

        public bool Equals(PhoneNumber? other)
            => other is not null && Number == other.Number;

        public override int GetHashCode()
            => Number.GetHashCode();

        public override string ToString()
            => Format();
    }
}
