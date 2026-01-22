using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Events
{
    public sealed class ConsentimentoRevogadoEvent : IDomainEvent
    {
        public Consentimento Consentimento { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public ConsentimentoRevogadoEvent(Consentimento consentimento)
        {
            Consentimento = consentimento;
        }
    }
}