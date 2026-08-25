extends Control

var released := 0

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)

func _on_release_pressed() -> void:
	released += 1
	$Status.text = "Ship released: %d / 1" % released
	if released >= 1:
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
