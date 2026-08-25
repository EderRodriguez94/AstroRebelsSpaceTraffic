extends Control

var selected_ship_id := ""
var selected_button: Button
var input_locked := false

func _ready() -> void:
	$ReleaseButton.pressed.connect(_on_release_pressed)
	$BackButton.pressed.connect(_on_back_pressed)
	$RestartButton.pressed.connect(_on_restart_pressed)
	$UndoButton.pressed.connect(_on_undo_pressed)
	$Board/BlueShipButton.pressed.connect(_on_ship_pressed.bind("tutorial-blue", $Board/BlueShipButton))
	$Board/RedShipButton.pressed.connect(_on_ship_pressed.bind("tutorial-red", $Board/RedShipButton))
	_refresh_board()

func _on_release_pressed() -> void:
	if input_locked:
		return
	if selected_ship_id.is_empty():
		$Status.text = "Invalid action — select a ship first"
		$Hint.text = "Choose one of the available ships"
		return
	var result: String = $SessionBridge.ReleaseShip(selected_ship_id)
	$Status.text = result
	if result == "Ship released" or result == "Level complete":
		_play_ship_departure()
		$UndoButton.disabled = false
	else:
		$Hint.text = "Release rejected — choose another available action"
	_refresh_board()
	if result == "Level complete":
		$Hint.text = "Route complete — next level unlocked"
		$ReleaseButton.disabled = true

func _on_ship_pressed(ship_id: String, button: Button) -> void:
	if input_locked:
		return
	_reset_ship_button_labels()
	selected_ship_id = ship_id
	selected_button = button
	button.modulate = Color(0.45, 0.95, 1.0)
	var ship_name := "BLUE" if ship_id == "tutorial-blue" else "RED"
	button.text = "SELECTED  •  " + ship_name + "  •  RIGHT"
	$Hint.text = "Ship selected — release when the path is clear"
	$ReleaseButton.text = "RELEASE " + ship_name + " SHIP  →"
	$ReleaseButton.disabled = false

func _play_ship_departure() -> void:
	input_locked = true
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
	input_locked = false
	if $SessionBridge.GetPhaseSummary().contains("WON"):
		$Hint.text = "Route complete — press RESTART LEVEL to play again"
		$Board/BlueShipButton.disabled = true
		$Board/RedShipButton.disabled = true
	else:
		$Hint.text = "Passengers boarded — select the next ship"

func _refresh_board() -> void:
	$Board/VisualGrid.rebuild($SessionBridge.GetPresentationSnapshot())
	$Board/BoardState.text = $SessionBridge.GetBoardSummary()
	$Board/DockState.text = $SessionBridge.GetDockSummary()
	$Board/QueueState.text = $SessionBridge.GetQueueSummary()
	$Board/PathState.text = $SessionBridge.GetPathSummary()
	$Board/PhaseState.text = $SessionBridge.GetPhaseSummary()

func _on_back_pressed() -> void:
	get_parent().show_screen("MainMenu")

func _on_restart_pressed() -> void:
	input_locked = false
	$SessionBridge.ResetSession()
	selected_ship_id = ""
	selected_button = null
	$Board/BlueShipButton.visible = true
	$Board/RedShipButton.visible = true
	$Board/BlueShipButton.position.x = 70.0
	$Board/RedShipButton.position.x = 340.0
	$Board/BlueShipButton.disabled = false
	$Board/RedShipButton.disabled = false
	_reset_ship_button_labels()
	$ReleaseButton.disabled = true
	$ReleaseButton.text = "RELEASE SELECTED SHIP  →"
	$UndoButton.disabled = true
	$Status.text = "Level 1  •  Route the first passengers"
	$Hint.text = "Select a ship to choose an action"
	_refresh_board()

func _on_undo_pressed() -> void:
	if input_locked:
		return
	if not $SessionBridge.UndoLastMove():
		$Status.text = "Nothing to undo"
		return
	selected_ship_id = ""
	selected_button = null
	$Board/BlueShipButton.visible = true
	$Board/RedShipButton.visible = true
	$Board/BlueShipButton.position.x = 70.0
	$Board/RedShipButton.position.x = 340.0
	$Board/BlueShipButton.disabled = false
	$Board/RedShipButton.disabled = false
	_reset_ship_button_labels()
	$ReleaseButton.disabled = true
	$ReleaseButton.text = "RELEASE SELECTED SHIP  →"
	$UndoButton.disabled = true
	$Status.text = "Move undone"
	$Hint.text = "Select a ship to choose an action"
	_refresh_board()

func _reset_ship_button_labels() -> void:
	$Board/BlueShipButton.text = "BLUE SHIP  •  RIGHT"
	$Board/RedShipButton.text = "RED SHIP  •  RIGHT"
	$Board/BlueShipButton.modulate = Color.WHITE
	$Board/RedShipButton.modulate = Color.WHITE
