extends Control

func _ready() -> void:
	$Content/StartButton.pressed.connect(_on_start_pressed)
	$Content/SettingsButton.pressed.connect(_on_settings_pressed)

func _on_start_pressed() -> void:
	get_parent().show_screen("Gameplay")

func _on_settings_pressed() -> void:
	get_parent().show_screen("Settings")
