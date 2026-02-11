using System.ComponentModel;

namespace PlataformaRedencao.Domain.Enums
{
    /// <summary>
    /// Define os tipos de entidades que podem possuir endereços.
    /// </summary>
    public enum EntityAddressType
    {
        [Description("Igreja")]
        Church = 1,
        [Description("Membro")]
        Member = 2,
        [Description("Visitante")]
        Visitor = 3
    }
}
