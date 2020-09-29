using Godot;
using System;

public class HUD : NinePatchRect
{
    private int _lives = 5;
    private int _lifeSize = 30;
    private string _livesContainerPath = "LivesMainContainer/HBoxContainer/LivesImageContainer";

    public override void _Ready()
    {
        var livesContainer = GetNode<BoxContainer>(_livesContainerPath);

        for (int i = 0; i < _lives; i++)
        {
            var textureRect = new TextureRect();
            textureRect.Texture = ResourceLoader.Load("res://assets/playerlife.png") as Texture;
            textureRect.Expand = true;
            textureRect.StretchMode = TextureRect.StretchModeEnum.KeepAspect;
            textureRect.RectMinSize = new Vector2(_lifeSize, _lifeSize);
            livesContainer.AddChild(textureRect);
        }
    }

    public override void _Process(float delta)
    {
        
    }

    public void RemoveLife()
    {
        var lives = GetNode<BoxContainer>(_livesContainerPath).GetChildren();
        if (lives.Count == 0)
        {
            return;
        }

        var lifeNode = (Node)lives[0];
        lifeNode.QueueFree();
        _lives--;
    }
}
