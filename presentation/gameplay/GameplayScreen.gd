extends Control

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)

func _on_release_pressed() -> void:
	var result: String = $SessionBridge.ReleaseFirstShip()
	$Status.text = result
	if result == "Level complete":
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
