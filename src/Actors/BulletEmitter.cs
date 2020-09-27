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
        // TODO: Fix bullet distance from enemy center
        Rotate((float)0.1);
        Area2D enemy = (Area2D)GetParent();
        Vector2 enemyPosition = enemy.Position;

        Bullet b = _bulletScene.Instance() as Bullet;
        b.Position = enemyPosition;
        b.Rotation = this.Rotation;
        // Make bullets part of the game environment
        enemy.GetParent().AddChild(b);
    }
}
