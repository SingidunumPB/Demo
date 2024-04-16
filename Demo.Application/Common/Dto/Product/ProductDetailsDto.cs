namespace Demo.Application.Common.Dto.Product;

public record ProductDetailsDto(string Name, string Description, string? CompanyName, string CompanyDescription, string CategoryName, List<string> Subcategories);