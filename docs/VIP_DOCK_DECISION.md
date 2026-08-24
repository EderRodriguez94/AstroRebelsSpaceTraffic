# VIP Dock routing decision

- Activation source: an explicit authorized attempt-local command.
- Duration: one attempt; it expires on restart, win or loss.
- Routing: player-commanded, never automatic.
- Priority: VIP routing is evaluated before standard dock assignment only when explicitly requested.
- Deadlock eligibility: the offer is unavailable during resolution and does not change core deadlock classification.
- Boarding: VIP passengers use their configured color; no universal-color boarding exists.

Status: approved implementation decision for the repository backlog. No VIP gameplay code is enabled by this document alone.
