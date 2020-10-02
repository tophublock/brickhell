using Godot;
using System;

public class Enemy : Area2D
{
    [Signal]
    public delegate void Death();
    private int _health = 2;
    private readonly int _speed = 50;
    private Vector2 _direction = Vector2.Down;

    public override void _Ready()
    {
        Vector2 screenSize = GetViewport().Size;
        var rand = new Random();
        // Set x to random coordinate from [0, screenSize.x]
        // Set y to random coordinate in top 1/6th of screen
       Vector2 start = new Vector2(
            x: rand.Next(0, (int)screenSize.x + 1),
            y: -50
        );
        Vector2 target = new Vector2(
            x: start.x,
            y: rand.Next(30, 30 + (int)screenSize.y / 6)
        );
        this.Position = start;

        var MoveTween = GetNode<Tween>("MoveTween");
        MoveTween.InterpolateProperty(this, "position", start, target, (float)0.5, Tween.TransitionType.Linear, Tween.EaseType.Out);
        MoveTween.Start();
    }

    // Enemy moves down the screen
    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2(_direction.x * _speed * delta, _direction.y * _speed * delta);
        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: position.x,
            y: position.y
        );
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }

    public void OnEnemyAreaEntered(Area2D area)
    {
        if (area is PlayerBullet bullet)
        {
            _health -= 1;
            bullet.QueueFree();

            if (_health == 0)
            {
                EmitSignal(nameof(Death));
                QueueFree();
            }
        }
    }
}
