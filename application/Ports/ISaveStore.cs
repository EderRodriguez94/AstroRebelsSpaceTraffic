using AstroRebelsTraffic.Application.Save;

namespace AstroRebelsTraffic.Application.Ports;

public interface ISaveStore
{
    bool TrySave(SaveData data);
    SaveData LoadOrDefault();
}
