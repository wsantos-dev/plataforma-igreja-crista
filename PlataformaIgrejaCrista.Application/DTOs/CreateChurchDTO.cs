public sealed record CreateChurchDTO(
    string OfficialName,
    string TradeName,
    string? Denomination,
    string LeadPastor,
    DateOnly FoundationDate,
    string Cnpj,
    string Email,
    string Website,
    int? AddressId
);