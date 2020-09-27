using Godot;
using System;

public class Player : Area2D 
{

    private int SPEED = 450;
    private int PADDING = 30;
    private Vector2 _normal = new Vector2(0, -1);
    private Vector2 _screenSize;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
    }

    public override void _Process(float delta)
    {
        var velocity = new Vector2(0, 0);

        // Check up/down movement
        if (Input.IsKeyPressed((int)KeyList.W))
        {
            velocity.y -= SPEED * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.S))
        {
            velocity.y += SPEED * delta;
        }

        // Check left/right movement
        if (Input.IsKeyPressed((int)KeyList.A))
        {
            velocity.x -= SPEED * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.D))
        {
            velocity.x += SPEED * delta;
        }

        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: Mathf.Clamp(position.x, PADDING, _screenSize.x - PADDING),
            y: Mathf.Clamp(position.y, PADDING, _screenSize.y - PADDING)
        );
    }

    public void OnPlayerAreaEntered(Area2D area)
    {
        if (area is Bullet b)
        {
            Console.WriteLine("hit!");
        }
    }
}
