// using System;
// using Godot;

// public partial class Players :
// Node
// {
// 	private Vector2 velocity = Vector2.Zero;
// 	private Vector2 direction = Vector2.Zero;

// 	private void ReadInput()
// 	{
// 		velocity = Vector2.Zero;

// 		if (Input.IsActionPressed("ui_up"))
// 		{
// 			velocity.y -= 1;
// 			direction = new Vector2(0, -1);
// 		}

// 		if (Input.IsActionPressed("ui_down"))
// 		{
// 			velocity.y += 1;
// 			direction = new Vector2(0, 1);
// 		}

// 		if (Input.IsActionPressed("ui_left"))
// 		{
// 			velocity.x -= 1;
// 			direction = new Vector2(-1, 0);
// 		}

// 		if (Input.IsActionPressed("ui_right"))
// 		{
// 			velocity.x += 1;
// 			direction = new Vector2(1, 0);
// 		}

// 		velocity = velocity.Normalized();
// 		velocity = MoveAndSlide(velocity * 200);
// 	}
// }
