using Godot;
using System;

public class Bullet : Area2D
{
    public Vector2 Direction = Vector2.One;
    protected int _speed = 100;

    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(_speed * delta * Direction.x, _speed * delta * Direction.y).Rotated(this.Rotation);
        this.Position += velocity;
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
