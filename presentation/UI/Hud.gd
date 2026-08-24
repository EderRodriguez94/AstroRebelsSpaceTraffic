extends Control

var level_id := ""
var restart_enabled := true
var optional_controls: Dictionary = {}

func rebuild(settled_state: Dictionary) -> void:
	level_id = settled_state.get("level_id", "")
	for control in ["undo", "scanner", "extra_dock", "vip"]:
		optional_controls[control] = bool(settled_state.get("enabled_" + control, false)) and bool(settled_state.get("available_" + control, false))
