using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaRedencao.Application.DTOs
{
    public class CreateMemberRequest
    {
        public string? Cpf { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public DateOnly BirthDate { get; set; }
        public char Gender { get; set; }

        public int ProfessionId { get; set; }
        public int ChurchId { get; set; }

        public DateOnly AdmissionDate { get; set; }
        public int AdmissionType { get; set; }

        public AddressRequest? Address { get; set; }
    }

}