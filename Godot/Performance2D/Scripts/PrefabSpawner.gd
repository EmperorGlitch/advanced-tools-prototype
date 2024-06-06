extends Node

@export var prefab: PackedScene
@export var sceneNameLabel: Label
@export var prefabCountLabel: Label
@export var action = "spawn"

var isStarted = false
var currentPrefabCount = 0
var selectedPrefabsCount = 0
var prefabsCountIncrement = 100

var radius = 1.0

func _ready():
	pass

func _process(delta):
	if isStarted && currentPrefabCount < selectedPrefabsCount:
		var spawnedCount = selectedPrefabsCount - currentPrefabCount
		for n in min(spawnedCount, 200):
			var instance = prefab.instantiate()
			add_child(instance)
			sceneNameLabel.set_text("Scene: %s" % self.name)
			currentPrefabCount += 1
		prefabCountLabel.set_text("Count: %d" % currentPrefabCount)
	
func _input(event):
	if event.is_action_pressed(action):
		isStarted = true
		selectedPrefabsCount += prefabsCountIncrement
		
	if event.is_action_pressed("ui_up") && prefabsCountIncrement < 10000:
		prefabsCountIncrement *= 10
		
	if event.is_action_pressed("ui_down") && prefabsCountIncrement > 100:
		prefabsCountIncrement /= 10
