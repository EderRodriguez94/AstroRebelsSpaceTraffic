extends Node

var input_locked := false

func play_events(events: Array) -> void:
	input_locked = true
	for event in events:
		await get_tree().process_frame
	input_locked = false

func can_accept_input() -> bool:
	return not input_locked
