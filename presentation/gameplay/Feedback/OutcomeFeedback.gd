extends Control

enum Case { NONE, BLOCKED_PATH, DOCKS_FULL, WIN, LOSS }
var current_case := Case.NONE

func show_domain_outcome(outcome: String) -> void:
	current_case = {"blocked_path": Case.BLOCKED_PATH, "docks_full": Case.DOCKS_FULL, "level_won": Case.WIN, "real_deadlock": Case.LOSS}.get(outcome, Case.NONE)
