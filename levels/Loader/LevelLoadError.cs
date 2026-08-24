namespace AstroRebelsTraffic.Levels.Loader;

public sealed record LevelLoadError(string Path, string Code, string Message);
public sealed record LevelLoadResult(bool Success, AstroRebelsTraffic.Domain.State.GameState? State, IReadOnlyList<LevelLoadError> Errors)
{
    public static LevelLoadResult Failure(params LevelLoadError[] errors) => new(false, null, errors);
}
