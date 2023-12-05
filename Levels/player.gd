extends CharacterBody2D

@export var move_speed : float = 150
@export var starting_direction : Vector2 = Vector2(0, 1)

@onready var animation_tree = $AnimationTree
@onready var state_machine = animation_tree.get("parameters/playback")				#tells the animation_tree state machine which animation to play depending on input

func _ready():
	update_animation_parameters(starting_direction)
	
func _physics_process(_delta):														#gets input direction
	var input_direction = Vector2(
		Input.get_action_strength("right") - Input.get_action_strength("left"),		#whenever a direction is no longer pressed, its opposite direction stops it
		Input.get_action_strength("down") - Input.get_action_strength("up")			#setting it up this way allows the character to remain facing the last direction walked
	)
	
	update_animation_parameters(input_direction)
	
	velocity = input_direction * move_speed											#updatees player velocity
	
	move_and_slide()																#uses velocity of body to move character on map
	
	pick_new_state()

func update_animation_parameters(move_input : Vector2):								#no animation parameters change if there is no movement
	if(move_input != Vector2.ZERO):
		animation_tree.set("parameters/Idle/blend_position", move_input)			#these paths refer to the Idle and Walk animation states in the animation_tree
		animation_tree.set("parameters/Walk/blend_position", move_input)

func pick_new_state():
	if (velocity != Vector2.ZERO):
		state_machine.travel("Walk")
	else:
		state_machine.travel("Idle")
