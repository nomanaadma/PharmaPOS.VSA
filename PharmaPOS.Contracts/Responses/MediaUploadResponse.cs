namespace PharmaPOS.Contracts.Responses;

public record MediaUploadResponse(
    int Id,
    string Filename,
    int Width, 
    int Height
);
