using Godot;
using System;


change file name to .cs 
public class EnemyAI : KinematicBody2D
{
	public float moveSpeed = 100.0f;
	public float attackCooldown = 2.0f; // Cooldown for the attack in seconds
	private AnimatedSprite2D _idleSprite;
	private AnimatedSprite2D _walkSprite;
	private Node2D player; // Reference to the player node
	private Vector2 moveDirection = Vector2.Zero;
	private float attackTimer = 0.0f;
	private bool isAttacking = false;

	public override void _Ready()
	{
		_idleSprite = GetNode<AnimatedSprite2D>("Idle");
		_walkSprite = GetNode<AnimatedSprite2D>("Walk");

		// Assume the player node is named "Player" in the scene
		player = GetNode<Node2D>("/root/MainScene/player");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (player != null)
		{
			if (!isAttacking)
			{
				_UpdateMovement();
			}

			_UpdateSpriteRenderer();
			_UpdateAttack(delta);
		}
	}

	private void _UpdateMovement()
	{
		// Calculate direction towards the player
		moveDirection = (player.GlobalPosition - GlobalPosition).Normalized();

		// Move towards the player
		MoveAndCollide(moveDirection * moveSpeed * GetProcessDeltaTime());
	}

	private void _UpdateSpriteRenderer()
	{
		if (moveDirection.x < 0)
		{
			// Facing left
			_walkSprite.FlipH = true;
		}
		else if (moveDirection.x > 0)
		{
			// Facing right
			_walkSprite.FlipH = false;
		}

		if (moveDirection != Vector2.Zero)
		{
			// Walking animation
			_walkSprite.Visible = true;
			_idleSprite.Visible = false;
		}
		else
		{
			// Idle animation
			_walkSprite.Visible = false;
			_idleSprite.Visible = true;
		}
	}

	private void _UpdateAttack(float delta)
	{
		attackTimer -= delta;

		if (attackTimer <= 0.0f)
		{
			// Initiate attack combo
			if (Input.IsActionJustPressed("attack"))
			{
				GD.Print("Enemy performs a powerful attack!");
				isAttacking = true;
				// Implement your attack logic here

				// Set the attack cooldown
				attackTimer = attackCooldown;
			}
			else
			{
				// Reset attack state when not attacking
				isAttacking = false;
			}
		}
	}
}
