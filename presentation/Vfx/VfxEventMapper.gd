extends Node

const DURATIONS := {
	"ship_exited_grid": 0.3,
	"ship_assigned_to_dock": 0.3,
	"group_boarded": 0.25,
	"ship_departed": 0.7,
	"release_error": 0.2,
	"level_won": 0.6
}

const EFFECTS := {
	"ship_exited_grid": "trail",
	"ship_assigned_to_dock": "arrival_flash",
	"group_boarded": "boarding_pulse",
	"ship_departed": "propulsion",
	"release_error": "error_pulse",
	"level_won": "win_burst"
}

func effect_for(event_name: String) -> String:
	return EFFECTS.get(event_name, "")

func duration_for(event_name: String) -> float:
	return DURATIONS.get(event_name, 0.0)

func play_ordered(events: Array) -> void:
	for event in events:
		var duration := duration_for(event.get("name", ""))
		if duration > 0.0:
			await get_tree().create_timer(duration).timeout
