using PlataformaIgrejaCrista.Domain.Messages;

namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class InvalidCpfException : DomainException
    {
        public InvalidCpfException()
            : base("CPF_ALREADY_EXISTS_FOR_ANOTHER_MEMBER", ErrorMessages.CpfAlreadyExistsForAnotherMember)
        {
        }
    }
}