namespace PlataformaIgrejaCrista.Application.DTOs;

public sealed record ContactDTO(
    string EmailAddress,
    string? PhoneNumber
);