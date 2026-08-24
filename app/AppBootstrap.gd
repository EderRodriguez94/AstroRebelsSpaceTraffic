extends Node

@export var screen_host: NodePath

func _ready() -> void:
	if screen_host != NodePath():
		get_node(screen_host).show_screen("MainMenu")
