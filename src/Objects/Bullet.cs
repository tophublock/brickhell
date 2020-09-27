using Godot;
using System;

public class Bullet : Area2D
{
    private int _speed = 100;
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(_speed * delta, _speed * delta).Rotated(this.Rotation);
        this.Position += velocity;
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
