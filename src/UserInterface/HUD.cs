using Godot;
using System;

public class HUD : NinePatchRect
{
    private int _maxLives = 5;
    private int _lifeSize = 30;
    private string _livesContainerPath = "LivesMainContainer/HBoxContainer/LivesImageContainer";
    private string _scorePath = "ScoreMainContainer/HBoxContainer/Score";
    private Label _scoreLabel;
    private BoxContainer _livesContainer;

    public override void _Ready()
    {
        Start();
    }


    public void Start()
    {
        _scoreLabel = GetNode<Label>(_scorePath);
        _scoreLabel.Text = (5).ToString();

        _livesContainer = GetNode<BoxContainer>(_livesContainerPath);
        if (_livesContainer.GetChildren().Count > 0)
        {
            foreach (Node child in _livesContainer.GetChildren())
            {
                child.QueueFree();
            }
        }

        for (int i = 0; i < _maxLives; i++)
        {
            var textureRect = CreateLifeTexture();
            _livesContainer.AddChild(textureRect);
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
        var lives = _livesContainer.GetChildren();
        if (lives.Count == 0)
        {
            return;
        }

        var lifeNode = (Node)lives[0];
        lifeNode.QueueFree();
    }

    public void AddLife()
    {
        var textureRect = CreateLifeTexture();
        _livesContainer.AddChild(textureRect);
    }

    public void UpdateScore(int score)
    {
        _scoreLabel.Text = score.ToString();
    }
}
