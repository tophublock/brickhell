using Godot;
using System;

public class Enemy : Area2D
{

    public override void _Ready()
    {
         
    }

    public override void _Process(float delta)
    {

    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
