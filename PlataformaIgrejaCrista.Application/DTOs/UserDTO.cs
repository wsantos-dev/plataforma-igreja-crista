namespace PlataformaIgrejaCrista.Application.DTOs;

public sealed record UserDTO(
    string UserName,
    string Password,
    string Email
);