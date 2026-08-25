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
		dock["presentation_state"] = "empty" if dock.get("active", false) and dock.get("occupant", null) == null else "occupied" if dock.get("active", false) else "locked"
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

func state_for_visual_index(index: int) -> String:
	for dock in active_docks + locked_docks:
		if dock.get("visual_index", -1) == index:
			return dock.get("presentation_state", "locked")
	return "locked"
