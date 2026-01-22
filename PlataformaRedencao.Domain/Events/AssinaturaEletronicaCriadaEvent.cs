using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Events
{
    public sealed class AssinaturaEletronicaCriadaEvent : IDomainEvent
    {
        public AssinaturaEletronica Assinatura { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public AssinaturaEletronicaCriadaEvent(AssinaturaEletronica assinatura)
        {
            Assinatura = assinatura;
        }
    }
}