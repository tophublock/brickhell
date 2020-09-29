using Godot;
using System;

public class HealthPowerUp : PowerUp 
{
    public PowerUp.Type type = PowerUp.Type.Health;
    public override void ApplyPowerUp(Player player)
    {
        player.AddHealth();
    }
}
