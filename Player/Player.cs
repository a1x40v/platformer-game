using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    private AnimationPlayer _anim;

    public override void _Ready()
    {
        _anim = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
            velocity.Y += gravity * (float)delta;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
            _anim.Play("Jump");
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        float direction = Input.GetAxis("ui_left", "ui_right");

        if (direction == -1)
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
        }
        else
        {
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
        }

        if (direction != 0)
        {
            velocity.X = direction * Speed;
            if (velocity.Y == 0)
                _anim.Play("Run");
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            if (velocity.Y == 0)
                _anim.Play("Idle");
        }

        if (velocity.Y > 0)
            _anim.Play("Fall");

        Velocity = velocity;
        MoveAndSlide();
    }
}
