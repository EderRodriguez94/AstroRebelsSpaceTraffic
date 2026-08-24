extends Control

var groups: Array = []

func rebuild(settled_state: Dictionary) -> void:
	groups = settled_state.get("queue", []).duplicate()
