using Ardalis.SmartEnum;
using Microsoft.EntityFrameworkCore.Query;

namespace Demo.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Tehnika = new TehnikaCategory();
    public static Category Hrana;
    
    public abstract string Description { get; }
    
    public Category(string name, int value) : base(name, value)
    {
    }
    
    private sealed class TehnikaCategory : Category
    {
        public TehnikaCategory() : base(nameof(Tehnika), 1)
        {
        }

        public override string Description => "Opis o tehnici!";
    }
    
    private sealed class HranaCategory : Category
    {
        public HranaCategory() : base(nameof(Tehnika), 1)
        {
        }

        public override string Description => "Opis o Hrani!";
    }
}
