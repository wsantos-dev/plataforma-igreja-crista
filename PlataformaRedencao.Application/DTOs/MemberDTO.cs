using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO para transferência de dados de Member.
    /// Value Objects são representados como tipos primitivos para facilitar serialização.
    /// </summary>
    public class MemberDTO
    {
        public int Id { get; set; }

        public string Cpf { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FullName => $"{FirstName} {LastName}";

        public DateOnly BirthDate { get; set; }

        public Gender Gender { get; set; } = null!;

        public ContactDTO Contact { get; set; } = null!;

        public MaritalStatus MaritalStatus { get; set; }

        public EducationLevel EducationLevel { get; set; }

        public int ProfessionId { get; set; }

        public ProfessionDTO? Profession { get; set; }

        public int AddressId { get; set; }

        public AddressDTO? Address { get; set; }

        public int ChurchId { get; set; }

        public ChurchDTO? Church { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public MemberAdmissionType AdmissionType { get; set; }

        public MemberStatus Status { get; set; }
    }
}
