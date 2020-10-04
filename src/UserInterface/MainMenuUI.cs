using Godot;
using System;

public class MainMenuUI : CenterContainer
{
    public void OnStartPressed()
    {
        GetTree().ChangeScene("res://src/Main/Game.tscn");
    }

    public void OnQuitPressed()
    {
        GetTree().Quit();
    }
}
