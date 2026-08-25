extends Control

var selected_ship_id := ""

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)
	$Board/ShipButton.pressed.connect(_on_ship_pressed)
	_refresh_board()

func _on_release_pressed() -> void:
	if selected_ship_id.is_empty():
		$Status.text = "Select a ship first"
		return
	var result: String = $SessionBridge.ReleaseShip(selected_ship_id)
	$Status.text = result
	_refresh_board()
	if result == "Level complete":
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _on_ship_pressed() -> void:
	selected_ship_id = "tutorial-ship"
	$Board/ShipButton.text = "SHIP SELECTED  •  BLUE  •  RIGHT"
	$Hint.text = "Ship selected — release when the path is clear"
	$ReleaseButton.disabled = false

func _refresh_board() -> void:
	$Board/BoardState.text = $SessionBridge.GetBoardSummary()
	$Board/DockState.text = $SessionBridge.GetDockSummary()
	$Board/QueueState.text = $SessionBridge.GetQueueSummary()
	$Board/PathState.text = $SessionBridge.GetPathSummary()

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
