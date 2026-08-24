extends Control

var docks: Array = []

func rebuild(settled_state: Dictionary) -> void:
	docks = settled_state.get("docks", []).duplicate()
