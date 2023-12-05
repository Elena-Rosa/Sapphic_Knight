using Godot;
using System;

public partial class player : CharacterBody2D
{
	public float moveSpeed = 150.0f;
	private AnimatedSprite2D _idleSprite;
	private AnimatedSprite2D _walkSprite;
	private Vector2 move_input; // Declare move_input as a class-level field

	public override void _Ready()
	{
		_idleSprite = GetNode<AnimatedSprite2D>("Idle");
		_walkSprite = GetNode<AnimatedSprite2D>("Walk");
	}

	public override void _PhysicsProcess(double delta)
	{
		move_input = Input.GetVector("left", "right", "up", "down"); // Assign value to move_input

		_UpdateSpriteRenderer();

		Velocity = move_input * moveSpeed * (float)delta;

		MoveAndCollide(Velocity);
	}

	private void _UpdateSpriteRenderer()
	{

		if (move_input != Vector2.Zero)
		{
			_walkSprite.Visible = true;
			_idleSprite.Visible = false;
		}
		else
		{
			_walkSprite.Visible = false;
			_idleSprite.Visible = true;
		}
	}
}