namespace Hypesoft.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = null!;
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Product() { }

    public Product(
        string name,
        string description,
        decimal price,
        string category,
        int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string name,
        string description,
        decimal price,
        string category,
        int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Stock = stock;
    }

    public void UpdateStock(int newStock)
    {
        Stock = newStock;
    }
}
