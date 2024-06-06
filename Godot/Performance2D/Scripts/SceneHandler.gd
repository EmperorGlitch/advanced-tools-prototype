extends Node

func _ready():
	pass

func _prcess(delta):
	pass

func _input(event):
	if event.is_action_pressed("2D"):
		get_tree().change_scene_to_file("res://Performance2D/Scenes/Performance2D.tscn")
		
	if event.is_action_pressed("3D"):
		get_tree().change_scene_to_file("res://Performance3D/Scenes/Performance3D.tscn")
		
	if event.is_action_released("restart"):
		get_tree().reload_current_scene()
		
	if event.is_action_pressed("vsync"):
		if (DisplayServer.window_get_vsync_mode() == DisplayServer.VSYNC_ENABLED):
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_DISABLED)
		else:
			DisplayServer.window_set_vsync_mode(DisplayServer.VSYNC_ENABLED)
