namespace Hypesoft.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public Guid CategoryId { get; private set; }
    public int Stock { get; private set; }

    protected Product() { }

    public Product(
        string name,
        string description,
        decimal price,
        Guid categoryId,
        int stock
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        Stock = stock;
    }

    public void UpdateStock(int newStock)
    {
        Stock = newStock;
    }
}
