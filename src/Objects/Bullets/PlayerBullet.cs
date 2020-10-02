using Godot;
using System;

public class PlayerBullet : Area2D
{
    private int _speed = 200;
    private Vector2 _direction = Vector2.Up;

    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(0, _speed * delta * _direction.y);
        this.Position += velocity;
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
