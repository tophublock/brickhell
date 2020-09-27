using Godot;
using System;

public class Game : Node
{

    private PackedScene _enemyScene;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _enemyScene = ResourceLoader.Load("res://src/Actors/Enemy.tscn") as PackedScene;
    }

    public override void _Process(float delta)
    {

    }

    public void OnEnemySpawnTimerTimeout()
    {
        Enemy enemy = _enemyScene.Instance() as Enemy;
        AddChild(enemy);
    }
}