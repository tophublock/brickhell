using Godot;
using System;

public class Player : Area2D 
{

    [Signal]
    public delegate void Hit();
    [Signal]
    public delegate void Death();
    private int _health = 5;
    private int _maxHealth = 5;
    private int _speed = 450;
    private int _padding = 30;
    private double _shootCountdownSec = 0.0;
    private double _shootDelaySec = 1.0;
    private Vector2 _size;
    private Vector2 _screenSize;
    private PackedScene _bulletScene;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        _size = GetNode<Sprite>("Sprite").Texture.GetSize();
        _bulletScene = ResourceLoader.Load("res://src/Objects/PlayerBullet.tscn") as PackedScene;
        Start();
    }

    public override void _Process(float delta)
    {
        var velocity = new Vector2(0, 0);

        // Check up/down movement
        if (Input.IsKeyPressed((int)KeyList.W))
        {
            velocity.y -= _speed * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.S))
        {
            velocity.y += _speed * delta;
        }

        // Check left/right movement
        if (Input.IsKeyPressed((int)KeyList.A))
        {
            velocity.x -= _speed * delta;
        }
        else if (Input.IsKeyPressed((int)KeyList.D))
        {
            velocity.x += _speed * delta;
        }

        // Check if Player can shoot and is pressing space
        if (_shootCountdownSec <= 0.0 && Input.IsKeyPressed((int)KeyList.Space))
        {
            Shoot();
            _shootCountdownSec = _shootDelaySec;
        }

        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: Mathf.Clamp(position.x, _padding, _screenSize.x - _padding),
            y: Mathf.Clamp(position.y, _padding, _screenSize.y - _padding)
        );
        _shootCountdownSec -= delta;
    }

    public void Start()
    {
        _shootCountdownSec = _shootDelaySec;
        _health = _maxHealth;
    }

    private void Shoot()
    {
        PlayerBullet b = _bulletScene.Instance() as PlayerBullet;
        int bulletPadding = 10;
        Vector2 position = new Vector2(
            x: this.Position.x,
            y: this.Position.y - _size.y / 2 - bulletPadding
        );
        b.Position = position;
        // Make bullets part of the game environment
        GetParent().AddChild(b);
    }

    public void OnPlayerAreaEntered(Area2D area)
    {
        if (area is Bullet bullet)
        {
            _health--;
            bullet.QueueFree();
            EmitSignal(nameof(Hit));

            if (_health == 0)
            {
                EmitSignal(nameof(Death));
            }
        }
    }

    public double GetShootDelay()
    {
        return _shootDelaySec;
    }

    public void SetShootDelay(double seconds)
    {
        _shootDelaySec = seconds;
    }
}
