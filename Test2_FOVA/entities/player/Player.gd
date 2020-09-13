extends RigidBody2D

var movespeed = 500;

func _ready():
	pass # Replace with function body.

func _process(delta):
	print(Engine.get_frames_per_second());
	pass
	

func _physics_process(delta):
	var motion = Vector2();
	
	if Input.is_action_pressed("up"):
		motion.y -= 1
	if Input.is_action_pressed("down"):
		motion.y += 1
	if Input.is_action_pressed("left"):
		motion.x -= 1
	if Input.is_action_pressed("right"):
		motion.x += 1

	motion = motion.normalized();
	motion = set_linear_velocity(motion * movespeed);
	
	rotation_degrees = 0;
