using Godot;
using System;

public class CornerBulletEmitter: BulletEmitter 
{
    private int _numCorners = 4;
    private float _delayBtwnShoot = 0.75f;

    public override void _Ready()
    {
        base._Ready();
        var timer = GetNode<Timer>("BulletTimer");
        timer.WaitTime = _delayBtwnShoot;
    }

    public override void Shoot()
    {
        // TODO: Fix bullet distance from enemy center
        Area2D enemy = (Area2D)GetParent();
        Vector2 enemyPosition = enemy.Position;

        for (int i = 0; i < _numCorners; i++)
        {
            Bullet b = _bulletScene.Instance() as Bullet;
            b.Position = enemyPosition;
            b.Rotation = this.Rotation + (float)Math.PI * ((float) 2 * i / _numCorners);
            enemy.GetParent().AddChild(b);
        }
    }
}

