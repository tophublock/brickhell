using Godot;
using System;

public class MainMenu : CenterContainer
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
