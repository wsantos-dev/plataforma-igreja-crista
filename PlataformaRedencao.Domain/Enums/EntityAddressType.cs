using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Defines the types of entities that can have addresses.
    /// </summary>
    public enum EntityAddressType
    {
        [Description("Church")]
        Church = 1,
        [Description("Member")]
        Member = 2,
        [Description("Visitor")]
        Visitor = 3
    }
}
