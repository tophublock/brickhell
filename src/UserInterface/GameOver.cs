using Godot;
using System;

public class GameOver : NinePatchRect
{
    [Signal]
    public delegate void NewGame();
    [Signal]
    public delegate void EndGame();

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {

    }

    public void OnYesButtonPressed()
    {
        EmitSignal(nameof(NewGame));
        Hide();
    }

    public void OnNoButtonPressed()
    {
        EmitSignal(nameof(EndGame));
        Hide();
    }
}
