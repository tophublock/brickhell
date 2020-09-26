using Godot;
using System;

public class Enemy : Area2D
{

    private int _speed = 200;
    private Vector2 _direction = new Vector2(0, 1);
    public override void _Ready()
    {
    }

    // Enemy moves down the screen
    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(_direction.x * _speed * delta, _direction.y * _speed * delta);
        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: position.x,
            y: position.y
        );
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
