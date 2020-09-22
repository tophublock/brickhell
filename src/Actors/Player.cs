using Godot;
using System;

public class Player : KinematicBody2D
{

    private int _speed = 450;
    private Vector2 _normal = new Vector2(0, -1);

    public override void _Ready()
    {
        
    }

    // MoveAndSlide takes care of delta, so don't need to multiply speed by delta
    public override void _Process(float delta)
    {
        var velocity = new Vector2(0, 0);

        // Check up/down movement
        if (Input.IsKeyPressed((int)KeyList.W))
        {
            velocity.y -= _speed;
        }
        else if (Input.IsKeyPressed((int)KeyList.S))
        {
            velocity.y += _speed;
        }

        // Check left/right movement
        if (Input.IsKeyPressed((int)KeyList.A))
        {
            velocity.x -= _speed;
        }
        else if (Input.IsKeyPressed((int)KeyList.D))
        {
            velocity.x += _speed;
        }

        MoveAndSlide(velocity, _normal);
    }
}
