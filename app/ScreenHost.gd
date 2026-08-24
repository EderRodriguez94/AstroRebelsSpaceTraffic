extends Node

var current_screen := ""

func show_screen(screen_name: String) -> void:
	current_screen = screen_name
	for child in get_children():
		if child is CanvasItem:
			child.visible = child.name == screen_name
