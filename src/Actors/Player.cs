using Godot;
using System;

public class Player : Area2D 
{

    private int _health = 5;
    private int _speed = 450;
    private int _padding = 30;
    private Vector2 _size;
    private Vector2 _screenSize;
    private PackedScene _bulletScene;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        _size = GetNode<Sprite>("Sprite").Texture.GetSize();
        _bulletScene = ResourceLoader.Load("res://src/Objects/PlayerBullet.tscn") as PackedScene;
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

        if (Input.IsKeyPressed((int)KeyList.Space))
        {
            shoot();
        }

        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: Mathf.Clamp(position.x, _padding, _screenSize.x - _padding),
            y: Mathf.Clamp(position.y, _padding, _screenSize.y - _padding)
        );
    }

    private void shoot()
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
        // TODO: delete bullet on hit
        // TODO: end game on player health = 0
        if (area is Bullet b)
        {
            Console.WriteLine("hit!");
            _health--;
            b.QueueFree();

            if (_health == 0)
            {
                Console.WriteLine("player is dead!");
            }
        }
    }
}
