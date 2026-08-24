extends Control

var ship_id := ""
var direction := "Right"

func configure(ship: Dictionary) -> void:
	ship_id = ship.get("id", "")
	direction = ship.get("direction", "Right")

func release_intent() -> String:
	return ship_id
