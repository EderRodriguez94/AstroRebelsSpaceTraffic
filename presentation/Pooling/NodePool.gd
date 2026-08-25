extends Node

## Small presentation-only pool. Domain state stays outside pooled nodes.
@export var pooled_scene: PackedScene
@export var initial_size := 0

var available:Array[Node] = []
var active:Array[Node] = []

func _ready() -> void:
	for index in initial_size:
		available.append(_create_node())

func acquire() -> Node:
	var node:Node = available.pop_back() if not available.is_empty() else _create_node()
	active.append(node)
	_set_visible(node, true)
	return node

func release(node:Node) -> void:
	if not active.has(node):
		return
	active.erase(node)
	if node.has_method("reset_presentation"):
		node.reset_presentation()
	_set_visible(node, false)
	available.append(node)

func reset_pool() -> void:
	for node in active.duplicate():
		release(node)

func active_count() -> int:
	return active.size()

func available_count() -> int:
	return available.size()

func _create_node() -> Node:
	if pooled_scene == null:
		return Node.new()
	var node := pooled_scene.instantiate()
	add_child(node)
	_set_visible(node, false)
	return node

func _set_visible(node:Node, value:bool) -> void:
	if node is CanvasItem:
		(node as CanvasItem).visible = value
