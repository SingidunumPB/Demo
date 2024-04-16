using Ardalis.SmartEnum;

namespace Demo.Domain.Enums;

public abstract class Category : SmartEnum<Category>
{
    public static Category Tehnika = new TehnikaCategory();
    public static Category Laptop = new LaptopCategory();
    public static Category Kablovi = new KabloviCategory();
    public static Category Hrana = new HranaCategory();

    public abstract string Description { get; }
    public abstract List<Category> Subcategories { get; }

    public Category(string name, int value) : base(name,
        value)
    {
    }

    private sealed class TehnikaCategory : Category
    {
        public TehnikaCategory() : base(nameof(Tehnika),
            1)
        {
        }

        public override string Description => "Opis o tehnici!";

        public override List<Category> Subcategories => new() { Laptop, Kablovi };
    }

    private sealed class HranaCategory : Category
    {
        public HranaCategory() : base(nameof(Hrana),
            2)
        {
        }

        public override string Description => "Opis o Hrani!";

        public override List<Category> Subcategories => new();
    }

    private sealed class LaptopCategory : Category
    {
        public LaptopCategory() : base(nameof(Laptop),
            3)
        {
        }

        public override string Description => "Opis o laptopu!";

        public override List<Category> Subcategories => new();
    }

    private sealed class KabloviCategory : Category
    {
        public KabloviCategory() : base(nameof(Kablovi),
            4)
        {
        }

        public override string Description => "Opis o kablovima!";

        public override List<Category> Subcategories => new();
    }
}
