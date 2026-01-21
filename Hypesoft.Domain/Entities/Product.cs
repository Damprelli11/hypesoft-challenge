namespace Hypesoft.Domain.Entities;

/// <summary>
/// Represents a product entity in the domain.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets the unique identifier of the product.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// Gets the description of the product.
    /// </summary>
    public string Description { get; private set; } = null!;

    /// <summary>
    /// Gets the price of the product.
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Gets the category identifier associated with the product.
    /// </summary>
    public Guid CategoryId { get; private set; }

    /// <summary>
    /// Gets the stock quantity of the product.
    /// </summary>
    public int Stock { get; private set; }

    /// <summary>
    /// Gets the creation date and time of the product.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    private Product() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified details.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="description">The description of the product.</param>
    /// <param name="price">The price of the product.</param>
    /// <param name="categoryId">The category identifier.</param>
    /// <param name="stock">The stock quantity.</param>
    public Product(
        string name,
        string description,
        decimal price,
        Guid categoryId,
        int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Updates the product with new details.
    /// </summary>
    /// <param name="name">The new name of the product.</param>
    /// <param name="description">The new description of the product.</param>
    /// <param name="price">The new price of the product.</param>
    /// <param name="categoryId">The new category identifier.</param>
    /// <param name="stock">The new stock quantity.</param>
    public void Update(
        string name,
        string description,
        decimal price,
        Guid categoryId,
        int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        Stock = stock;
    }

    /// <summary>
    /// Updates the stock quantity of the product.
    /// </summary>
    /// <param name="newStock">The new stock quantity.</param>
    public void UpdateStock(int newStock)
    {
        Stock = newStock;
    }
}
