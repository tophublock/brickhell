using Godot;
using System;

public class AimBulletEmitter : BulletEmitter 
{
    private float _delayBtwnShoot = 0.75f;

    public override void _Ready()
    {
        _bulletScene = ResourceLoader.Load("res://src/Objects/Bullets/AimBullet.tscn") as PackedScene;
        var timer = GetNode<Timer>("BulletTimer");
        timer.WaitTime = _delayBtwnShoot;
    }

    public override void Shoot()
    {
        Area2D enemy = (Area2D)GetParent();
        Area2D player = GetTree().Root.GetNode<Player>("Player");

        Bullet b = (Bullet)_bulletScene.Instance();
        b.Rotation = enemy.Position.AngleTo(player.Position);
        enemy.GetParent().AddChild(b);
    }
}


