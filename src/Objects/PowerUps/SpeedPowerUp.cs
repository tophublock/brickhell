using Godot;
using System;

public class SpeedPowerUp : PowerUp 
{
    private readonly double _delayDecreaseSec = 0.1;
    public override void ApplyPowerUp(Player player)
    {
        double delay = player.GetShootDelay();
        player.SetShootDelay(delay - _delayDecreaseSec);
    }
}
