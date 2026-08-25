extends Node2D

const DURATIONS := {
	"ship_exited_grid": 0.3,
	"ship_assigned_to_dock": 0.3,
	"group_boarded": 0.25,
	"ship_departed": 0.7,
	"release_error": 0.2,
	"blocked_path": 0.2,
	"docks_full": 0.2,
	"level_won": 0.6
}

const EFFECTS := {
	"ship_exited_grid": "trail",
	"ship_assigned_to_dock": "arrival_flash",
	"group_boarded": "boarding_pulse",
	"ship_departed": "propulsion",
	"release_error": "error_pulse",
	"blocked_path": "error_pulse",
	"docks_full": "error_pulse",
	"level_won": "win_burst"
}

var active_effects:Array[Dictionary] = []
var last_event_name := ""
var skip_requested := false

func _process(delta: float) -> void:
	for effect in active_effects:
		effect["remaining"] = maxf(0.0, float(effect["remaining"]) - delta)
	active_effects = active_effects.filter(func(effect:Dictionary) -> bool: return effect["remaining"] > 0.0)
	if not active_effects.is_empty():
		queue_redraw()

func play_event(event: Dictionary, instant := false) -> void:
	var event_name := str(event.get("name", event.get("type", ""))).to_lower()
	var effect_name := effect_for(event_name)
	last_event_name = event_name
	if effect_name.is_empty():
		return
	var position:Vector2 = event.get("position", Vector2.ZERO)
	if instant or skip_requested:
		skip_requested = false
		return
	active_effects.append({
		"name": effect_name,
		"position": position,
		"remaining": duration_for(event_name),
		"duration": duration_for(event_name)
	})
	queue_redraw()

func effect_for(event_name: String) -> String:
	return EFFECTS.get(event_name, "")

func duration_for(event_name: String) -> float:
	return DURATIONS.get(event_name, 0.0)

func play_ordered(events: Array, instant := false) -> void:
	skip_requested = false
	for event in events:
		play_event(event, instant)
		var duration := duration_for(str(event.get("name", event.get("type", ""))).to_lower())
		if duration > 0.0:
			if instant:
				continue
			await get_tree().create_timer(duration).timeout
	active_effects.clear()
	queue_redraw()

func skip() -> void:
	skip_requested = true
	active_effects.clear()
	queue_redraw()

func rebuild() -> void:
	active_effects.clear()
	skip_requested = false
	queue_redraw()

func _draw() -> void:
	for effect in active_effects:
		var duration:float = effect["duration"]
		var remaining:float = effect["remaining"]
		var progress := 1.0 - remaining / duration
		var position:Vector2 = effect["position"]
		match effect["name"]:
			"trail":
				draw_line(position - Vector2(64.0 * (1.0 - progress), 0.0), position, Color("#56d8ff"), 5.0)
			"arrival_flash":
				draw_circle(position, 18.0 + 20.0 * progress, Color(0.35, 0.85, 1.0, 1.0 - progress), false, 4.0)
			"boarding_pulse":
				draw_circle(position, 10.0 + 24.0 * progress, Color(1.0, 0.82, 0.3, 1.0 - progress), false, 3.0)
			"propulsion":
				draw_line(position, position - Vector2(70.0 * progress, 0.0), Color("#ffb347"), 7.0)
			"error_pulse":
				draw_arc(position, 18.0 + 8.0 * sin(progress * PI), 0.0, TAU, 24, Color("#ff6b6b"), 4.0)
			"win_burst":
				draw_circle(position, 16.0 + 42.0 * progress, Color(0.4, 1.0, 0.7, 1.0 - progress), false, 5.0)
