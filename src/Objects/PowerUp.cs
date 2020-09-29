using Godot;
using System;

public class PowerUp : Area2D
{
    private double _delayDecreaseSec = 0.5;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {

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
