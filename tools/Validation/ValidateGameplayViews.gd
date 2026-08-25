extends SceneTree

func _initialize() -> void:
	var view_script = load("res://presentation/gameplay/GridView.gd")
	var view = view_script.new()
	view.size = Vector2(580, 240)
	root.add_child(view)
	view.rebuild({
		"zones": [{"id": "zone", "width": 6, "height": 8}],
		"ships": [
			{"id": "blue", "color": "blue", "direction": "Right", "x": 1, "y": 2, "on_grid": true},
			{"id": "red", "color": "red", "direction": "Left", "x": 4, "y": 5, "on_grid": true},
			{"id": "docked", "color": "green", "direction": "Up", "x": 0, "y": 0, "on_grid": false}
		]
	})
	_assert(view.ship_count() == 2, "GridView keeps only ships on the grid")
	_assert(view.cell_pixel_size() > 0.0, "GridView computes a positive cell size")
	_assert(view.ship_position("blue") != Vector2(-1, -1), "GridView maps ship position")
	_assert(view.ship_position("docked") == Vector2(-1, -1), "GridView removes docked ships")
	print("GAMEPLAY_VIEWS_VALIDATION=PASS")
	quit(0)

func _assert(condition: bool, message: String) -> void:
	if not condition:
		push_error(message)
		quit(1)
