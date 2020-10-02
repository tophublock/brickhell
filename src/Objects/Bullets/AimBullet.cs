using Godot;
using System;

public class AimBullet : Bullet 
{
    public override void _Ready()
    {
        base._Ready();
        _speed = 250;
    }
    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(_speed * delta * Direction.x, _speed * delta * Direction.y);
        this.Position += velocity;
    }
}
