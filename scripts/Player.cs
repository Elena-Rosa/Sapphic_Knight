using Godot;
using System;


public partial class Player : CharacterBody2D
{
    [Export]
    public float MoveSpeed = 100;
    [Export]
    public Vector2 StartingDirection = new Vector2(0, 1);

    private AnimationTree animationTree;
    private AnimationNodeStateMachinePlayback stateMachine;
    private Vector2 velocity;

    public override void _Ready()
    {
        animationTree = GetNode<AnimationTree>("AnimationTree");
        stateMachine = (AnimationNodeStateMachinePlayback)animationTree.Get("parameters/playback");
        UpdateAnimationParameters(StartingDirection);
    }

    public override void _PhysicsProcess(double delta)
    {
        // Get Input direction
        var inputDirection = new Vector2(
            Convert.ToSingle(Input.IsActionPressed("right")) - Convert.ToSingle(Input.IsActionPressed("left")),
            Convert.ToSingle(Input.IsActionPressed("down")) - Convert.ToSingle(Input.IsActionPressed("up"))
        );

        UpdateAnimationParameters(inputDirection);

        // Update Velocity
        velocity = inputDirection.Normalized() * MoveSpeed;

        // Move and slide
        MoveAndSlide();

        PickNewState();
    }

    private void UpdateAnimationParameters(Vector2 moveInput)
    {
        if (moveInput != Vector2.Zero)
        {
            animationTree.Set("parameters/idle/blend_position", moveInput);
            animationTree.Set("parameters/walk/blend_position", moveInput);
        }
    }

    private void PickNewState()
    {
        if (velocity != Vector2.Zero)
        {
            stateMachine.Travel("walk");
        }
        else
        {
            stateMachine.Travel("idle");
        }
    }
}
