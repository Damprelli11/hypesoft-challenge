namespace Hypesoft.Domain.Entities;

/// <summary>
/// Represents a category entity in the domain.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets the unique identifier of the category.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the name of the category.
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// Gets the creation date and time of the category.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    private Category() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Renames the category to the specified name.
    /// </summary>
    /// <param name="name">The new name for the category.</param>
    public void Rename(string name)
    {
        Name = name;
    }
}
