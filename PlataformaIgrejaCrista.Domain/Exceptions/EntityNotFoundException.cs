using PlataformaIgrejaCrista.Domain.Messages;

namespace PlataformaIgrejaCrista.Domain.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string errorCode, string message)
            : base("ENTITY_NOT_FOUND", ErrorMessages.EntityNotFound)
        {
        }
    }
}