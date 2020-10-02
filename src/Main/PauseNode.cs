using Godot;
using System;

public class PauseNode : Node
{
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("ui_pause"))
        {
            GetTree().Paused = !GetTree().Paused;
        }
    }
}
