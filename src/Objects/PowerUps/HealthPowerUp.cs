using Godot;
using System;

public class HealthPowerUp : PowerUp 
{
    public override void ApplyPowerUp(Player player)
    {
        player.AddHealth();
    }
}
