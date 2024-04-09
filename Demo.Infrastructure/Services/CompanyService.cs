using Demo.Application.Common.Interfaces;

namespace Demo.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    public string CreateAsync()
    {
        return "Create";
    }
}
