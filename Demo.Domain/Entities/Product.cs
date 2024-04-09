using Demo.Domain.Enums;

namespace Demo.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Company Company { get; private set; }

    private Product() { }
    
    public Product(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public Product AddCompany(Company company)
    {
        Company = company;
        return this;
    }
}