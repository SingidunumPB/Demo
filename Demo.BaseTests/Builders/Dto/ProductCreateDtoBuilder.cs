using Demo.Application.Common.Dto.Product;

namespace Demo.BaseTests.Builders.Dto;

public class ProductCreateDtoBuilder
{
    private Guid _companyId;
    private string _name = "-";
    private string _description = "-";

    public ProductCreateDtoBuilder WithCompanyId(Guid companyId)
    {
        _companyId = companyId;
        return this;
    }

    public ProductCreateDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProductCreateDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public ProductCreateDto Build() => new(_companyId, _name, _description);
}