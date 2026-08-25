extends Control

var docks: Array = []
var active_docks: Array = []
var locked_docks: Array = []

func rebuild(settled_state: Dictionary) -> void:
	docks = settled_state.get("docks", []).duplicate()
	active_docks.clear()
	locked_docks.clear()
	for index in range(8):
		var dock: Dictionary = docks[index].duplicate() if index < docks.size() else {"visual_index": index, "active": false}
		dock["visual_index"] = index
		if dock.get("active", false):
			active_docks.append(dock)
		else:
			locked_docks.append(dock)

func active_count() -> int:
	return active_docks.size()

func locked_count() -> int:
	return locked_docks.size()

func occupied_count() -> int:
	return active_docks.filter(func(dock: Dictionary) -> bool: return dock.get("occupant", null) != null).size()
