extends Control

var ship_views: Dictionary = {}

func rebuild(settled_state: Dictionary) -> void:
	ship_views.clear()
	for ship in settled_state.get("ships", []):
		ship_views[ship.get("id", "")] = ship

func ship_count() -> int:
	return ship_views.size()
