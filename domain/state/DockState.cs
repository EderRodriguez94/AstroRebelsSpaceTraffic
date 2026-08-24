namespace AstroRebelsTraffic.Domain.State;

public sealed record DockState
{
    public int VisualIndex { get; }
    public bool IsActive { get; }
    public ShipState? Occupant { get; }
    public bool IsVip { get; }
    private DockState(int visualIndex, bool isActive, ShipState? occupant)
    {
        if (visualIndex is < 0 or > 7) throw new ArgumentOutOfRangeException(nameof(visualIndex));
        if (!isActive && occupant is not null) throw new InvalidOperationException("Inactive docks cannot have occupants.");
        VisualIndex = visualIndex; IsActive = isActive; Occupant = occupant; IsVip = false;
    }
    public static IReadOnlyList<DockState> CreateInitial() => Enumerable.Range(0, 8).Select(index => new DockState(index, index < 4, null)).ToArray();
    public DockState WithOccupant(ShipState? occupant)
    {
        if (!IsActive && occupant is not null) throw new InvalidOperationException("Inactive docks cannot have occupants.");
        return new DockState(VisualIndex, IsActive, occupant);
    }

    public DockState Activate()
    {
        if (IsActive) return this;
        return new DockState(VisualIndex, true, null);
    }
}
