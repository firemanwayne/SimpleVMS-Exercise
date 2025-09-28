namespace Infrastructure.Options;

using System.Text.Json.Serialization;

internal sealed class InfrastructureOptions
{
    [JsonPropertyName("dbName")]
    public string DbName { get; set; } = string.Empty;

    [JsonPropertyName("connectionString")]
    public string ConnectionString { get; set; } = string.Empty;

    public const string AppConfigurationKey = "Infrastructure";
}
