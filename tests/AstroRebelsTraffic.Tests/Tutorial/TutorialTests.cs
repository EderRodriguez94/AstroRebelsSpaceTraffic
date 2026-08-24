using AstroRebelsTraffic.Application.Tutorial;

namespace AstroRebelsTraffic.Tests.Tutorial;

public sealed class TutorialTests
{
    [Fact]
    public void Disallowed_action_keeps_tutorial_state_unchanged()
    {
        var state = new TutorialState(true, 0, new HashSet<string>(new[] { "ship-a" }));
        Assert.False(state.Allows("ship-b"));
        Assert.Equal(state, state.Advance("ship-b", "ship-c"));
    }

    [Fact]
    public void Allowed_action_advances_deterministically_and_disabled_mode_has_no_gate()
    {
        var state = new TutorialState(true, 0, new HashSet<string>(new[] { "ship-a" }));
        var next = state.Advance("ship-a", "ship-b");
        Assert.Equal(1, next.Step);
        Assert.True(next.Allows("ship-b"));
        Assert.True(TutorialState.Disabled().Allows("any-ship"));
    }
}
