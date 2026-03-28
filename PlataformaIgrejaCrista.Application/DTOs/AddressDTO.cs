using PlataformaIgrejaCrista.Domain.Enums;
namespace PlataformaIgrejaCrista.Application.DTOs;

public sealed record AddressDTO(
    int Id,
    int EntityId,
    EntityAddressType EntityType,
    string? Street,
    string? Number,
    string? Complement,
    string? Neighborhood,
    string? City,
    string? State,
    string? Country,
    string? PostalCode
);
