using Godot;
using System;

public class MainMenu : CenterContainer
{
    private string _buttonContainerPath = "MainMenu/VBoxContainer/MarginContainer/VBoxContainer/";
    private Button _startButton;
    private Button _quitButton;

    public override void _Ready()
    {
        _startButton = GetNode<Button>(_buttonContainerPath + "Start");
        _quitButton = GetNode<Button>(_buttonContainerPath + "Quit");
    }
}
