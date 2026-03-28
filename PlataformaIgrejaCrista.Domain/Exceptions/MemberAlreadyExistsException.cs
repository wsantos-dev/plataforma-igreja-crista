using PlataformaIgrejaCrista.Domain.Messages;

namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class MemberAlreadyExistsException : DomainException
    {
        public MemberAlreadyExistsException(string errorCode, string message)
            : base("MEMBER_ALREADY_EXISTS", ErrorMessages.MemberAlreadyExists)
        {
        }
    }
}