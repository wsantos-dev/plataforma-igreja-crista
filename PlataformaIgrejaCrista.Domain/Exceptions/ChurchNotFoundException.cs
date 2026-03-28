namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class ChurchNotFoundException : DomainException
    {
        public ChurchNotFoundException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}