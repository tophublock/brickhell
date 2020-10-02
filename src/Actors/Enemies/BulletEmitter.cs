using Godot;
using System;

public class BulletEmitter : Node2D
{
    protected bool _rotateSelf = true;
    protected float _rotationSpeed = 1.0f;
    protected PackedScene _bulletScene;

    public override void _Ready()
    {
        _bulletScene = ResourceLoader.Load("res://src/Objects/Bullets/Bullet.tscn") as PackedScene;
    }

    public override void _Process(float delta)
    {
        if (_rotateSelf)
        {
            Rotate((float)_rotationSpeed * delta);
        }
    }

    public virtual void Shoot()
    {
        // TODO: Fix bullet distance from enemy center
        Area2D enemy = (Area2D)GetParent();
        Vector2 enemyPosition = enemy.Position;

        Bullet b = _bulletScene.Instance() as Bullet;
        b.Position = enemyPosition;
        b.Rotation = this.Rotation;
        // Make bullets part of the game environment
        enemy.GetParent().AddChild(b);
    }

    public void OnBulletTimerTimeout()
    {
        Shoot();
    }
}
