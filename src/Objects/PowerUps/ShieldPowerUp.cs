using Godot;
using System;

public class ShieldPowerUp: PowerUp 
{
    public PowerUp.Type type = PowerUp.Type.Shield;
    public override void ApplyPowerUp(Player player)
    {
        player.TurnOnShield();
    }
}
