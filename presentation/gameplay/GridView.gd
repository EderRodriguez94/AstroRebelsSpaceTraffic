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
		if not id.is_empty() and ship.get("on_grid", true):
			ship_views[id] = {
				"id": id,
				"color": ship.get("color", ""),
				"direction": ship.get("direction", "Right"),
				"position": Vector2(ship.get("x", 0), ship.get("y", 0)) * cell_size
			}
	queue_redraw()

func _draw() -> void:
	if cell_size <= 0.0:
		return
	for zone in zone_layout:
		var width: int = zone.get("width", 1)
		var height: int = zone.get("height", 1)
		for y in range(height):
			for x in range(width):
				draw_rect(Rect2(Vector2(x, y) * cell_size, Vector2.ONE * cell_size), Color(0.12, 0.16, 0.26, 1), false, 2.0)
	for ship in ship_views.values():
		var color := _ship_color(ship.get("color", ""))
		var rect := Rect2(ship.get("position", Vector2.ZERO) + Vector2(6, 6), Vector2.ONE * (cell_size - 12))
		draw_rect(rect, color, true)
		draw_string(ThemeDB.fallback_font, rect.position + Vector2(rect.size.x * 0.42, rect.size.y * 0.62), _direction_cue(ship.get("direction", "Right")), HORIZONTAL_ALIGNMENT_LEFT, -1, 24, Color.WHITE)

func _ship_color(color_id: String) -> Color:
	return {"blue": Color(0.2, 0.65, 1.0), "red": Color(1.0, 0.3, 0.35), "green": Color(0.3, 0.9, 0.55), "yellow": Color(1.0, 0.8, 0.25)}.get(color_id, Color(0.65, 0.7, 0.8))

func _direction_cue(direction: String) -> String:
	return "→" if direction == "Right" else "←" if direction == "Left" else "↑" if direction == "Up" else "↓"

func ship_count() -> int:
	return ship_views.size()

func cell_pixel_size() -> float:
	return cell_size

func ship_position(ship_id: String) -> Vector2:
	return ship_views.get(ship_id, {}).get("position", Vector2(-1, -1))
