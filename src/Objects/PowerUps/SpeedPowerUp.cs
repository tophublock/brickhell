using Godot;
using System;

public class SpeedPowerUp : PowerUp 
{
    public PowerUp.Type type = PowerUp.Type.Speed;
    private readonly double _delayDecreaseSec = 0.1;

    public override void ApplyPowerUp(Player player)
    {
        double delay = player.GetShootDelay();
        player.SetShootDelay(delay - _delayDecreaseSec);
    }
}
