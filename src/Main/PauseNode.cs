using Godot;
using System;

public class PauseNode : Node
{
    private CenterContainer _pause;
    public override void _Ready()
    {
        _pause = GetNode<CenterContainer>("Pause");
        _pause.Hide();
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("ui_pause"))
        {
            GetTree().Paused = !GetTree().Paused;
            if (GetTree().Paused)
            {
                _pause.Show();
            }
            else
            {
                _pause.Hide();
            }
        }
    }
}
