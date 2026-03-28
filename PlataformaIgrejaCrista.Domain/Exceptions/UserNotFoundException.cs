using PlataformaIgrejaCrista.Domain.Messages;

namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException()
            : base("USER_NOT_FOUND_EXCEPTION", ErrorMessages.UserNotFoundException)
        {
        }
    }
}