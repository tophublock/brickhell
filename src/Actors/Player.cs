using Godot;
using System;

public class Player : Area2D 
{

    [Signal]
    public delegate void Hit();
    [Signal]
    public delegate void Death();
    [Signal]
    public delegate void HitHealthPowerUp();
    public int Health = 5;
    private bool _shieldOn = false;
    private int _startHealth = 5;
    private int _speed = 450;
    private int _padding = 30;
    private float _shieldSec = 3.0f;
    private double _shootCountdownSec = 0.0;
    private double _shootDelaySec = 1.0;
    private readonly double _minShootDelaySec = 0.1;
    private Vector2 _size;
    private Vector2 _screenSize;
    private Sprite _shield;
    private AudioStreamPlayer2D _laserSound;
    private AudioStreamPlayer2D _pickUpSound;
    private PackedScene _bulletScene;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        _size = GetNode<Sprite>("PlayerSprite").Texture.GetSize();
        _shield = GetNode<Sprite>("Shield");
        _laserSound = GetNode<AudioStreamPlayer2D>("LaserSound");
        _pickUpSound = GetNode<AudioStreamPlayer2D>("PickUpSound");
        _bulletScene = ResourceLoader.Load("res://src/Objects/Bullets/PlayerBullet.tscn") as PackedScene;
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
        _shield.Hide();
        _shootCountdownSec = _shootDelaySec;
        Health = _startHealth;
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
        _laserSound.Play();
    }

    public void OnPlayerAreaEntered(Area2D area)
    {
        if (!_shieldOn && area is Bullet bullet)
        {
            Health--;
            bullet.QueueFree();
            EmitSignal(nameof(Hit));

            if (Health == 0)
            {
                EmitSignal(nameof(Death));
            }
        }
    }

    public void PlayPickUpSound()
    {
        _pickUpSound.Play();
    }

    public double GetShootDelay()
    {
        return _shootDelaySec;
    }

    public void SetShootDelay(double seconds)
    {
        _shootDelaySec = Math.Max(seconds, _minShootDelaySec);
    }

    public void AddHealth()
    {
        EmitSignal(nameof(HitHealthPowerUp));
        Health++;
    }

    public void TurnOnShield()
    {
        var timer = new Timer();
        timer.OneShot = true;
        timer.WaitTime = _shieldSec;
        timer.Connect("timeout", this, nameof(TurnOffShield));
        AddChild(timer);

        _shieldOn = true;
        _shield.Show();
        timer.Start();
    }

    private void TurnOffShield()
    {
        _shieldOn = false;
        _shield.Hide();
    }
}
