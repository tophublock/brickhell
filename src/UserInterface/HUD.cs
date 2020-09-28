using Godot;
using System;

public class HUD : NinePatchRect
{
    private int _lives = 5;
    private int _lifeSize = 30;

    public override void _Ready()
    {
        var lives = GetNode<BoxContainer>("LivesContainer/HBoxContainer/Lives");

        for (int i = 0; i < _lives; i++)
        {
            var textureRect = new TextureRect();
            textureRect.Texture = ResourceLoader.Load("res://assets/playerlife.png") as Texture;
            textureRect.Expand = true;
            textureRect.StretchMode = TextureRect.StretchModeEnum.KeepAspect;
            textureRect.RectMinSize = new Vector2(_lifeSize, _lifeSize);
            lives.AddChild(textureRect);
        }
    }

    public override void _Process(float delta)
    {
        
    }
}
