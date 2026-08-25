extends Control

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)
	_refresh_board()

func _on_release_pressed() -> void:
	var result: String = $SessionBridge.ReleaseFirstShip()
	$Status.text = result
	_refresh_board()
	if result == "Level complete":
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _refresh_board() -> void:
	$Board/BoardState.text = $SessionBridge.GetBoardSummary()
	$Board/DockState.text = $SessionBridge.GetDockSummary()
	$Board/QueueState.text = $SessionBridge.GetQueueSummary()

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
