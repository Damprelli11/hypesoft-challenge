namespace Hypesoft.Infrastructure.Persistence;

/// <summary>
/// Settings for MongoDB configuration.
/// </summary>
public class MongoDbSettings
{
    /// <summary>
    /// Gets or sets the MongoDB connection string.
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the MongoDB database.
    /// </summary>
    public string DatabaseName { get; set; } = null!;
}
