using System.Text.Json;
using AstroRebelsTraffic.Levels.Loader;
using AstroRebelsTraffic.Solver.Search;

var root = Path.GetFullPath(args.ElementAtOrDefault(0) ?? "levels/Definitions/tutorial");
var reportPath = Path.GetFullPath(args.ElementAtOrDefault(1) ?? "build/reports/level-validation.json");
var entries = new List<object>();
var errors = new List<string>();
var solvedCount = 0;

foreach (var file in Directory.EnumerateFiles(root, "*.json").OrderBy(path => path, StringComparer.Ordinal))
{
    var json = File.ReadAllText(file);
    var loaded = LevelLoader.Load(json);
    var solved = loaded.Success && BaselineSolver.Solve(loaded.State!).Solved;
    if (solved) solvedCount++;
    if (!loaded.Success) errors.Add($"{Path.GetFileName(file)}:loader");
    if (!solved) errors.Add($"{Path.GetFileName(file)}:solver");
    entries.Add(new { level_id = loaded.State?.LevelId ?? Path.GetFileNameWithoutExtension(file), path = file, valid_shape = loaded.Success, solver = solved ? "solved" : "unsolved" });
}

var report = new
{
    generated_at_utc = DateTime.UtcNow.ToString("o"),
    source = root,
    entries,
    entry_count = entries.Count,
    shape_valid = errors.All(error => !error.EndsWith(":loader", StringComparison.Ordinal)),
    solver_status = errors.Any(error => error.EndsWith(":solver", StringComparison.Ordinal)) ? "failed" : "solved",
    solver_budget = 64,
    solved_count = solvedCount,
    human_review_state = "pending_product_review",
    errors = errors.OrderBy(error => error).ToArray()
};
Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
File.WriteAllText(reportPath, JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }));
return errors.Count == 0 ? 0 : 1;
