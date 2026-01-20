namespace Hypesoft.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }

    private Category() { }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public void Rename(string name)
    {
        Name = name;
    }
}
