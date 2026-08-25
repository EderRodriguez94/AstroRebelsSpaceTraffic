using AstroRebelsTraffic.Generator;

namespace AstroRebelsTraffic.Application.BackgroundWork;

public static class BackgroundGenerationService
{
    public static Task<GeneratedCandidate> GenerateAsync(int seed, CancellationToken cancellationToken = default) =>
        Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            var candidate = LevelGenerator.Generate(seed);
            cancellationToken.ThrowIfCancellationRequested();
            return candidate;
        });
}
