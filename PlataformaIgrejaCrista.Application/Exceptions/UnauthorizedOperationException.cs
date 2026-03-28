namespace PlataformaIgrejaCrista.Application.Exceptions
{
    public class UnauthorizedOperationException : ApplicationExceptionBase
    {
        public UnauthorizedOperationException(string errorCode, string message)
            : base(errorCode, message)
        {
        }
    }
}