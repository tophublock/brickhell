using Godot;
using System;

public class PowerUp : Area2D
{
    private readonly int _speed = 40;
    private readonly double _delayDecreaseSec = 0.1;
    private Vector2 _direction = Vector2.Down;

    public override void _Ready()
    {
        Vector2 screenSize = GetViewport().Size;
        var rand = new Random();
        this.Position = new Vector2(
            x: rand.Next(0, (int)screenSize.x + 1),
            y: -20
        );
    }

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

    public void OnPowerUpAreaEntered(Area2D area)
    {
        if (area is Player player)
        {
            double delay = player.GetShootDelay();
            player.SetShootDelay(delay - _delayDecreaseSec);
            QueueFree();
        }
    }
}
