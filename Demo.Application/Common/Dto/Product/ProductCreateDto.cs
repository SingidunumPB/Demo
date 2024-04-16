namespace Demo.Application.Common.Dto.Product;

public record ProductCreateDto(Guid CompanyId, string Name, string Description, int Category);