extends Control

var groups: Array = []
var front_group: Dictionary = {}
var circular_groups: Array = []

func rebuild(settled_state: Dictionary) -> void:
	groups = settled_state.get("queue", []).duplicate()
	front_group = groups[0] if not groups.is_empty() else {}
	circular_groups.clear()
	for index in range(groups.size()):
		var group: Dictionary = groups[index].duplicate()
		group["slot"] = index
		group["is_front"] = index == 0
		circular_groups.append(group)

func front_color() -> String:
	return front_group.get("color", "")

func circular_slot_count() -> int:
	return circular_groups.size()

func slot_for(index: int) -> Dictionary:
	if index < 0 or index >= circular_groups.size():
		return {}
	return circular_groups[index]
