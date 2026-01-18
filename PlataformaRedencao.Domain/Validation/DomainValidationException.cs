namespace PlataformaRedencao.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        { }

        public static void When(bool temErro, string erro)
        {
            if (temErro)
                throw new DomainValidationException(erro);
        }

    }
}