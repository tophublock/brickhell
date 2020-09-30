using Godot;
using System;

public class WaveBulletEmitter : BulletEmitter 
{
    private int _bulletsPerWave = 20;
    private float _delayBtwnShoot = 3.0f;

    public override void _Ready()
    {
        _bulletScene = ResourceLoader.Load("res://src/Objects/Bullets/WaveBullet.tscn") as PackedScene;
        var timer = GetNode<Timer>("BulletTimer");
        timer.WaitTime = _delayBtwnShoot;
    }

    public override void Shoot()
    {
        // TODO: Fix bullet distance from enemy center
        Area2D enemy = (Area2D)GetParent();
        Vector2 enemyPosition = enemy.Position;

        for (int i = 0; i < _bulletsPerWave; i++)
        {
            Bullet b = _bulletScene.Instance() as Bullet;
            b.Position = enemyPosition;
            b.Rotation = (float)Math.PI * ((float) 2 * i / _bulletsPerWave);
            enemy.GetParent().AddChild(b);
        }
    }
}
