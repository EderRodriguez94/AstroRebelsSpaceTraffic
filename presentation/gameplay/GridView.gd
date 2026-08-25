extends Control

var ship_views: Dictionary = {}
var cell_size := 0.0
var board_size := Vector2.ZERO
var zone_layout: Array = []

func rebuild(settled_state: Dictionary) -> void:
	board_size = size
	zone_layout.clear()
	ship_views.clear()
	for zone in settled_state.get("zones", []):
		var width: int = int(zone.get("width", 1))
		var height: int = int(zone.get("height", 1))
		zone_layout.append({"id": zone.get("id", ""), "width": width, "height": height})
		cell_size = min(board_size.x / max(width, 1), board_size.y / max(height, 1))
	for ship in settled_state.get("ships", []):
		var id: String = ship.get("id", "")
		if not id.is_empty():
			ship_views[id] = {
				"id": id,
				"color": ship.get("color", ""),
				"direction": ship.get("direction", "Right"),
				"position": Vector2(ship.get("x", 0), ship.get("y", 0)) * cell_size
			}
	queue_redraw()

func ship_count() -> int:
	return ship_views.size()

func cell_pixel_size() -> float:
	return cell_size

func ship_position(ship_id: String) -> Vector2:
	return ship_views.get(ship_id, {}).get("position", Vector2(-1, -1))
