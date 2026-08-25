extends Control

var groups: Array = []
var front_group: Dictionary = {}
var circular_groups: Array = []
var passenger_pool: Array = []
var visible_passengers: Array = []

func rebuild(settled_state: Dictionary) -> void:
	_reset_pool()
	groups = settled_state.get("queue", []).duplicate()
	front_group = groups[0] if not groups.is_empty() else {}
	circular_groups.clear()
	for index in range(groups.size()):
		var group: Dictionary = groups[index].duplicate()
		group["slot"] = index
		group["is_front"] = index == 0
		circular_groups.append(group)
		var count: int = int(group.get("size", group.get("count", 0)))
		for passenger_index in range(count):
			var passenger := _acquire_passenger()
			passenger["color"] = group.get("color", group.get("color_id", ""))
			passenger["group_index"] = index
			passenger["index"] = passenger_index
			visible_passengers.append(passenger)

func _reset_pool() -> void:
	for passenger in visible_passengers:
		passenger["visible"] = false
	visible_passengers.clear()

func _acquire_passenger() -> Dictionary:
	for passenger in passenger_pool:
		if not passenger.get("visible", false):
			passenger["visible"] = true
			return passenger
	var created := {"visible": true, "color": "", "group_index": -1, "index": -1}
	passenger_pool.append(created)
	return created

func front_color() -> String:
	return front_group.get("color", "")

func circular_slot_count() -> int:
	return circular_groups.size()

func slot_for(index: int) -> Dictionary:
	if index < 0 or index >= circular_groups.size():
		return {}
	return circular_groups[index]

func passenger_count() -> int:
	return visible_passengers.size()

func pooled_count() -> int:
	return passenger_pool.size()
