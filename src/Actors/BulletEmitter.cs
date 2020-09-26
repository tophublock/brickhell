using Godot;
using System;

public class BulletEmitter : Node2D
{
    PackedScene _bulletScene;
    public override void _Ready()
    {
        _bulletScene = ResourceLoader.Load("res://src/Objects/Bullet.tscn") as PackedScene;
    }

    public override void _Process(float delta)
    {
        Rotate((float)0.1);

        Bullet b = _bulletScene.Instance() as Bullet;
        b.Position = new Vector2(100, 100);
        b.Rotation = Rotation;
        GetParent().GetParent().AddChild(b);
    }
}
