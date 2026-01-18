using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Validation;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um membro de uma igreja.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Membro"/> é uma especialização de <see cref="Pessoa"/>
    /// e representa o vínculo formal de uma pessoa com uma igreja local.
    ///'Membro': cannot derive from sealed type 'Pessoa'CS0509
    /// Nem toda pessoa cadastrada no sistema é necessariamente um membro.
    /// O vínculo como membro implica regras e responsabilidades específicas
    /// do contexto eclesiástico.
    /// </remarks>
    public sealed class Membro : Pessoa
    {
        /// <summary>
        /// Data de admissão do membro na igreja.
        /// </summary>
        /// <remarks>
        /// Normalmente corresponde à data de batismo, aclamação
        /// ou transferência, conforme o caso.
        /// </remarks>
        public DateOnly DataAdmissao { get; private set; }

        /// <summary>
        /// Tipo de admissão do membro.
        /// </summary>
        /// <remarks>
        /// Indica como o membro ingressou na igreja:
        /// batismo, aclamação ou transferência.
        /// </remarks>
        public TipoAdmissaoMembro TipoAdmissao { get; private set; }

        /// <summary>
        /// Situação atual do membro na igreja.
        /// </summary>
        /// <remarks>
        /// Controla o status eclesiástico do membro,
        /// como ativo, afastado, desligado ou falecido.
        /// </remarks>
        public SituacaoMembro Situacao { get; private set; }

        /// <summary>
        /// Indica se o membro está atualmente ativo.
        /// </summary>
        /// <remarks>
        /// Um membro inativo não participa das atividades regulares,
        /// mas seu histórico permanece preservado.
        /// </remarks>
        public bool Ativo { get; private set; }
        /// <summary>
        /// Cria um novo membro a partir de uma pessoa existente.
        /// </summary>
        /// <remarks>
        /// A criação de um membro representa um ato formal
        /// de ingresso na igreja.
        /// </remarks>
        public Membro(
            Pessoa pessoa,
            DateOnly dataAdmissao,
            TipoAdmissaoMembro tipoAdmissao)
            : base(
                pessoa.NomePessoa,
                pessoa.DataNascimento,
                pessoa.Sexo,
                pessoa.Endereco,
                pessoa.Contato,
                pessoa.Profissao)
        {
            DataAdmissao = dataAdmissao;
            TipoAdmissao = tipoAdmissao;
            Situacao = SituacaoMembro.Ativo;
            Ativo = true;
        }

        /// <summary>
        /// Atualiza os dados do membro.
        /// </summary>
        /// <remarks>
        /// Este método centraliza a alteração dos dados do membro,
        /// garantindo consistência do estado e respeito às regras de negócio.
        /// </remarks>
        public void AtualizarMembro(
            DateOnly dataAdmissao,
            TipoAdmissaoMembro tipoAdmissao,
            SituacaoMembro situacao)
        {
            AlterarDataAdmissao(dataAdmissao);
            AlterarTipoAdmissao(tipoAdmissao);
            AlterarSituacao(situacao);
        }

        /// <summary>
        /// Altera a data de admissão do membro na igreja.
        /// </summary>
        /// <param name="data">
        /// Nova data de admissão do membro.
        /// </param>
        /// <remarks>
        /// A data de admissão representa o marco formal de ingresso do membro na igreja,
        /// normalmente associada ao batismo, aclamação ou transferência.
        ///
        /// A alteração desta data deve ocorrer apenas em situações excepcionais,
        /// como correção de dados históricos ou ajustes administrativos devidamente autorizados.
        /// </remarks>
        public void AlterarDataAdmissao(DateOnly data)
        {
            DataAdmissao = data;
        }

        /// <summary>
        /// Altera o tipo de admissão do membro.
        /// </summary>
        /// <param name="tipoAdmissao">
        /// Novo tipo de admissão atribuído ao membro.
        /// </param>
        /// <remarks>
        /// O tipo de admissão indica a forma pela qual o membro ingressou na igreja,
        /// como batismo, aclamação ou transferência.
        ///
        /// A alteração deste dado deve ocorrer apenas para correção de informações
        /// ou ajustes administrativos devidamente justificados, de modo a preservar
        /// a coerência do histórico eclesiástico.
        /// </remarks>
        public void AlterarTipoAdmissao(TipoAdmissaoMembro tipoAdmissao)
        {
            TipoAdmissao = tipoAdmissao;
        }

        /// <summary>
        /// Altera a situação eclesiástica do membro.
        /// </summary>
        /// <param name="novaSituacao">
        /// Nova situação do membro no contexto da igreja.
        /// </param>
        /// <remarks>
        /// A situação do membro representa seu status eclesiástico atual,
        /// como ativo, afastado, desligado ou falecido.
        ///
        /// Ao alterar a situação, a propriedade <see cref="Ativo"/> é atualizada
        /// automaticamente para refletir se o membro permanece em plena atividade,
        /// garantindo consistência entre o estado lógico e o estado operacional do membro.
        /// </remarks>
        public void AlterarSituacao(SituacaoMembro novaSituacao)
        {
            Situacao = novaSituacao;
            Ativo = novaSituacao == SituacaoMembro.Ativo;
        }

        private void ValidateDomain(Membro membro)
        {
            DomainValidationException.When(string.IsNullOrEmpty(membro.NomePessoa.PrimeiroNome),
                "Primeiro nome inválido. O primeiro nome é obrigatório.");

            DomainValidationException.When(membro.NomePessoa.PrimeiroNome.Length < 3,
                "Primeiro nome inválido. O primeiro nome deve ter no mínimo 3 caracteres.");

            DomainValidationException.When(string.IsNullOrEmpty(membro.NomePessoa.SobreNome),
                "Sobrenome inválido. O sobrenome é obrigatório.");

            DomainValidationException.When(membro.NomePessoa.SobreNome.Length < 7,
                "Sobrenome nome inválido. O sobrenome nome deve ter no mínimo 7 caracteres.");

            DomainValidationException.When(membro.DataNascimento == default,
                "Data de nascimento inválida. A data de nascimento é obrigatória.");

            DomainValidationException.When(membro.DataNascimento == DateOnly.FromDateTime(DateTime.Now),
                "Data de nascimento inválida. A data de nascimento não pode ser a data atual.");

            DomainValidationException.When(membro.DataNascimento > DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                "Data de nascimento inválida. O membro deve ter no mínimo 10 anos de idade.");

            DomainValidationException.When(membro.Sexo.Codigo == null,
                "Sexo inválido. O sexo é obrigatório.");

            DomainValidationException.When(string.IsNullOrEmpty(membro.Sexo.Codigo) || !membro.Sexo.Codigo.Any(c => c.Equals('M') || c.Equals('F')),
                "Sexo inválido. O código de sexo deve ser 'M' ou 'F'.");

            DomainValidationException.When(membro.Endereco.Id <= 0,
                "Endereço inválido. O endereço é obrigatório.");

            DomainValidationException.When(membro.Profissao.Id <= 0,
                "Profissão inválida. A profissão é obrigatória.");

            DomainValidationException.When(membro.DataAdmissao == default,
                "Data de admissão inválida. A data de admissão é obrigatória.");

            DomainValidationException.When(membro.DataAdmissao < DateOnly.FromDateTime(DateTime.Now),
                "Data de admissão inválida. A data de admissão não pode ser no passado.");

            DomainValidationException.When(membro?.TipoAdmissao == null,
                "Tipo de admissão inválido. O tipo de admissão é obrigatório.");

            DomainValidationException.When(membro?.Situacao == null,
                "Situaão inválida. A situação é obrigatório");

        }
    }
}
