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
        _rotateSelf = false;
    }

    public override void Shoot()
    {
        Area2D enemy = (Area2D)GetParent();
        Player player = GetTree().Root.GetNode<Player>("Game/Player");

        AimBullet b = (AimBullet)_bulletScene.Instance();
        b.Position = enemy.Position;
        b.Direction = (player.Position - enemy.Position).Normalized();
        enemy.GetParent().AddChild(b);
    }
}


