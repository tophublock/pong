using Godot;
using System;

public class Gui : Control
{

    private MarginContainer _scoreContainer;
    private MarginContainer _newGameContainer;

    public override void _Ready()
    {
        _scoreContainer = GetNode<MarginContainer>("Score");
        _newGameContainer = GetNode<MarginContainer>("NewGame");
        _newGameContainer.Hide();
    }

    public void UpdatePlayerScore(int score)
    {

    }

    public void UpdateEnemyScore(int score)
    {

    }
}
