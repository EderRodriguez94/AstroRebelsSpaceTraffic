using System.Text.Json;

namespace AstroRebelsTraffic.Application.Save.Migrations;

public sealed record MigrationResult(bool Supported, JsonDocument? Document, string? Error);

public static class SaveMigration
{
    public const int CurrentVersion = 1;

    public static MigrationResult Migrate(string json)
    {
        try
        {
            var document = JsonDocument.Parse(json);
            var version = document.RootElement.GetProperty("schemaVersion").GetInt32();
            return version > CurrentVersion
                ? new(false, null, "Future save schema is unsupported.")
                : new(true, document, null);
        }
        catch (Exception ex) when (ex is JsonException or KeyNotFoundException or InvalidOperationException)
        {
            return new(false, null, "Save data is invalid.");
        }
    }
}
