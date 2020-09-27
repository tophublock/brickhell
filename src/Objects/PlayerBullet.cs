using Godot;
using System;

public class PlayerBullet : Area2D
{
    private int _speed = 100;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(0, _speed * delta);
        this.Position += velocity;
    }
}
