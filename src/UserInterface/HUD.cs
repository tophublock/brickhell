using Godot;
using System;

public class HUD : NinePatchRect
{
    private int _maxLives = 5;
    private int _lifeSize = 30;
    private string _livesContainerPath = "LivesMainContainer/HBoxContainer/LivesImageContainer";

    public override void _Ready()
    {
        Start();
    }

    public override void _Process(float delta)
    {
        
    }

    public void Start()
    {
        Console.WriteLine("restarting");
        var livesContainer = GetNode<BoxContainer>(_livesContainerPath);
        if (livesContainer.GetChildren().Count > 0)
        {
            foreach (Node child in livesContainer.GetChildren())
            {
                child.QueueFree();
            }
        }

        for (int i = 0; i < _maxLives; i++)
        {
            Console.WriteLine("adding life");
            var textureRect = CreateLifeTexture();
            livesContainer.AddChild(textureRect);
        }
    }

    // Creates Node holding a player life image
    private TextureRect CreateLifeTexture()
    {
        var textureRect = new TextureRect();
        textureRect.Texture = ResourceLoader.Load("res://assets/playerlife.png") as Texture;
        textureRect.Expand = true;
        textureRect.StretchMode = TextureRect.StretchModeEnum.KeepAspect;
        textureRect.RectMinSize = new Vector2(_lifeSize, _lifeSize);
        return textureRect;
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
    }


}
