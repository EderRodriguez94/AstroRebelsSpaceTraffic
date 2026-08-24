namespace AstroRebelsTraffic.Domain.Rules.EndConditions;

public sealed record DeadlockEvidence(string Code, bool Satisfied, string Detail);
