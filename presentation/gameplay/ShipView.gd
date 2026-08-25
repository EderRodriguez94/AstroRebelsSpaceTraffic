extends Control

var ship_id := ""
var direction := "Right"
var color_id := ""
var anchor := Vector2.ZERO

func configure(ship: Dictionary) -> void:
	ship_id = ship.get("id", "")
	direction = ship.get("direction", "Right")
	color_id = ship.get("color", "")
	anchor = Vector2(ship.get("x", 0), ship.get("y", 0))

func release_intent() -> String:
	return ship_id

func direction_cue() -> String:
	return "→" if direction == "Right" else "←" if direction == "Left" else "↑" if direction == "Up" else "↓"
