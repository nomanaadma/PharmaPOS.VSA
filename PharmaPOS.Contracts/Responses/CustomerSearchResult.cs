namespace PharmaPOS.Contracts.Responses;

public record CustomerSearchResult(int Id, string Label, string? Email, string? Mobile);
