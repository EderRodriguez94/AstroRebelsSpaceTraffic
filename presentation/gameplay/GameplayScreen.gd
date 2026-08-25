extends Control

var selected_ship_id := ""
var selected_button: Button

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)
	$Board/BlueShipButton.pressed.connect(_on_ship_pressed.bind("tutorial-blue", $Board/BlueShipButton))
	$Board/RedShipButton.pressed.connect(_on_ship_pressed.bind("tutorial-red", $Board/RedShipButton))
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

func _on_ship_pressed(ship_id: String, button: Button) -> void:
	if not selected_ship_id.is_empty() and $ReleaseButton.disabled:
		return
	selected_ship_id = ship_id
	selected_button = button
	$Board/BlueShipButton.modulate = Color.WHITE
	$Board/RedShipButton.modulate = Color.WHITE
	button.modulate = Color(0.45, 0.95, 1.0)
	button.text = "SELECTED  •  " + ("BLUE" if ship_id == "tutorial-blue" else "RED") + "  •  RIGHT"
	$Hint.text = "Ship selected — release when the path is clear"
	$ReleaseButton.disabled = false

func _play_ship_departure() -> void:
	selected_button.disabled = true
	$ReleaseButton.disabled = true
	selected_button.text = "SHIP DEPARTING  →"
	var tween := create_tween()
	tween.tween_property(selected_button, "position:x", 720.0, 0.45)
	tween.tween_callback(_finish_ship_departure)

func _finish_ship_departure() -> void:
	selected_button.visible = false
	selected_ship_id = ""
	selected_button = null
	$Hint.text = "Passengers boarded — dock assignment settled"

func _refresh_board() -> void:
	$Board/BoardState.text = $SessionBridge.GetBoardSummary()
	$Board/DockState.text = $SessionBridge.GetDockSummary()
	$Board/QueueState.text = $SessionBridge.GetQueueSummary()
	$Board/PathState.text = $SessionBridge.GetPathSummary()

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")
