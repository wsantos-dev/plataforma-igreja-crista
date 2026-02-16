using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    public sealed record MemberCreationData(
        string Cpf,
        string FirstName,
        string LastName,
        string Email,
        string? Phone,
        DateOnly BirthDate,
        char GenderCode,
        DateOnly AdmissionDate,
        MemberAdmissionType AdmissionType
    );
}