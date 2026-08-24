using System.Text.Json;
using AstroRebelsTraffic.Application.Ports;
using AstroRebelsTraffic.Application.Save;

namespace AstroRebelsTraffic.Infrastructure.Save;

public sealed class LocalSaveStore : ISaveStore
{
    private readonly string primaryPath;
    private readonly string backupPath;
    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    public LocalSaveStore(string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        primaryPath = Path.Combine(directoryPath, "save.json");
        backupPath = Path.Combine(directoryPath, "save.backup.json");
    }

    public bool TrySave(SaveData data)
    {
        var temp = primaryPath + ".tmp";
        try
        {
            File.WriteAllText(temp, JsonSerializer.Serialize(data, Options));
            if (File.Exists(primaryPath)) File.Copy(primaryPath, backupPath, true);
            File.Move(temp, primaryPath, true);
            return true;
        }
        catch (IOException) { if (File.Exists(temp)) File.Delete(temp); return false; }
    }

    public SaveData LoadOrDefault()
    {
        foreach (var path in new[] { primaryPath, backupPath })
        {
            try
            {
                if (File.Exists(path)) return JsonSerializer.Deserialize<SaveData>(File.ReadAllText(path), Options) ?? new SaveData();
            }
            catch (JsonException) { }
        }
        return new SaveData();
    }
}
