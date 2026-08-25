extends Control

enum Case { NONE, BLOCKED_PATH, DOCKS_FULL, WIN, LOSS }
var current_case := Case.NONE
var current_message := ""
var current_action := ""

@onready var message_label: Label = $FeedbackPanel/Message
@onready var action_label: Label = $FeedbackPanel/Action

func _ready() -> void:
	_clear_feedback()

func show_domain_event(event_type: String, reason: String = "") -> void:
	if event_type == "ShipReleaseRejected":
		show_domain_outcome("docks_full" if reason == "docks-full" else "blocked_path")
	elif event_type == "LevelWon":
		show_domain_outcome("level_won")
	elif event_type == "RealDeadlockDetected":
		show_domain_outcome("real_deadlock")

func _clear_feedback() -> void:
	current_case = Case.NONE
	current_message = ""
	current_action = ""
	if is_node_ready():
		message_label.text = ""
		action_label.text = ""
		visible = false

func show_domain_outcome(outcome: String) -> void:
	var feedback := {
		"blocked_path": {"case": Case.BLOCKED_PATH, "message": "ROUTE BLOCKED", "action": "Choose another ship."},
		"docks_full": {"case": Case.DOCKS_FULL, "message": "DOCKS FULL", "action": "Wait for an available dock."},
		"level_won": {"case": Case.WIN, "message": "TRAFFIC CLEARED", "action": "Continue to the next level."},
		"real_deadlock": {"case": Case.LOSS, "message": "NO VALID MOVE", "action": "Restart the level."}
	}.get(outcome, {})
	if feedback.is_empty():
		_clear_feedback()
		return
	current_case = feedback["case"]
	current_message = feedback["message"]
	current_action = feedback["action"]
	if is_node_ready():
		message_label.text = current_message
		action_label.text = current_action
		visible = true
