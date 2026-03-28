using PlataformaIgrejaCrista.Domain.Messages;

namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class ProfessionAlreadyRegisteredException : DomainException
    {
        public ProfessionAlreadyRegisteredException()
            : base("PROFESSION_ALREADY_REGISTERED_EXCEPTION",
                    ErrorMessages.ProfessionalNotFound)
        {
        }
    }
}