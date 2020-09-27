using Godot;
using System;

public class Player : Area2D 
{

    private int _health = 5;
    private int _speed = 450;
    private int _padding = 30;
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
            velocity.y -= _speed * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.S))
        {
            velocity.y += _speed * delta;
        }

        // Check left/right movement
        if (Input.IsKeyPressed((int)KeyList.A))
        {
            velocity.x -= _speed * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.D))
        {
            velocity.x += _speed * delta;
        }

        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: Mathf.Clamp(position.x, _padding, _screenSize.x - _padding),
            y: Mathf.Clamp(position.y, _padding, _screenSize.y - _padding)
        );
    }

    public void OnPlayerAreaEntered(Area2D area)
    {
        // TODO: delete bullet on hit
        // TODO: end game on player health = 0
        if (area is Bullet b)
        {
            Console.WriteLine("hit!");
            _health--;

            if (_health == 0)
            {
                Console.WriteLine("player is dead!");
            }
        }
    }
}
