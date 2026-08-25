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
	if result == "Ship released" or result == "Level complete":
		_play_ship_departure()
	_refresh_board()
	if result == "Level complete":
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _on_ship_pressed() -> void:
	if $ReleaseButton.disabled and not selected_ship_id.is_empty():
		return
	selected_ship_id = "tutorial-ship"
	$Board/ShipButton.text = "SHIP SELECTED  •  BLUE  •  RIGHT"
	$Hint.text = "Ship selected — release when the path is clear"
	$ReleaseButton.disabled = false

func _play_ship_departure() -> void:
	$Board/ShipButton.disabled = true
	$ReleaseButton.disabled = true
	$Board/ShipButton.text = "SHIP DEPARTING  →"
	var tween := create_tween()
	tween.tween_property($Board/ShipButton, "position:x", 720.0, 0.45)
	tween.tween_callback(_finish_ship_departure)

func _finish_ship_departure() -> void:
	$Board/ShipButton.visible = false
	$Hint.text = "Passengers boarded — dock assignment settled"

func _refresh_board() -> void:
	$Board/BoardState.text = $SessionBridge.GetBoardSummary()
	$Board/DockState.text = $SessionBridge.GetDockSummary()
	$Board/QueueState.text = $SessionBridge.GetQueueSummary()
	$Board/PathState.text = $SessionBridge.GetPathSummary()

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
