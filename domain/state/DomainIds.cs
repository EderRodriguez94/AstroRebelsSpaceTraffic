namespace AstroRebelsTraffic.Domain.State;

public readonly record struct DomainId
{
    public string Value { get; }

    public DomainId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("An identifier cannot be empty.", nameof(value));
        Value = value;
    }

    public override string ToString() => Value;
}

public readonly record struct ZoneId
{
    public string Value { get; }
    public ZoneId(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Zone ID cannot be empty.", nameof(value));
        Value = value;
    }
    public override string ToString() => Value;
}

public readonly record struct ShipId
{
    public string Value { get; }
    public ShipId(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Ship ID cannot be empty.", nameof(value));
        Value = value;
    }
    public override string ToString() => Value;
}
