using Godot;
using System;

public class Game : Node
{

    private Player _player;
    private PackedScene _enemyScene;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _enemyScene = ResourceLoader.Load("res://src/Actors/Enemy.tscn") as PackedScene;
        _player = GetNode<Player>("Player");

        var startPosition = GetNode<Position2D>("PlayerStartPosition");
        _player.Position = startPosition.Position;
    }

    public override void _Process(float delta)
    {

    }

    public void OnEnemySpawnTimerTimeout()
    {
        Enemy enemy = _enemyScene.Instance() as Enemy;
        AddChild(enemy);
    }

    public void OnPlayerDeath()
    {
        // Show GameOver UI
        var gameOverScene = ResourceLoader.Load("res://src/UserInterface/GameOver.tscn") as PackedScene;
        var gameOverUI = gameOverScene.Instance() as Node;
        AddChild(gameOverUI);

        // Remove all enemies from screen
        var enemies = GetTree().GetNodesInGroup("Enemy");
        foreach (Enemy enemy in enemies)
        {
            enemy.QueueFree();
        }

        // Stop spawning enemies
        var timer = GetNode<Timer>("EnemySpawnTimer");
        timer.Stop();
    }
}
