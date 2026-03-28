using PlataformaIgrejaCrista.Domain.Exceptions;

public class IdentityOperationException : DomainException
{
    public IdentityOperationException(string errors)
    : base("IDENTITY_OPERATION_EXCEPTION", errors)
    {
    }
}