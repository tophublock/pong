using Godot;
using System;

public class Main : Node
{

    private int _playerScore;
    private int _enemyScore;
    private Gui _gui;

    public override void _Ready()
    {
        NewGame();
        _gui = GetNode<Gui>("Gui");

        // TODO: make position relative to screen size?
        var player = GetNode<Paddle>("Player");
        var playerPosition = GetNode<Position2D>("PlayerStartPosition");
        player.Start(playerPosition.Position);

        var enemy = GetNode<Enemy>("Enemy");
        var enemyPosition = GetNode<Position2D>("EnemyStartPosition");
        enemy.Start(enemyPosition.Position);

        var ball = GetNode<Ball>("Ball");
        var ballPosition = GetNode<Position2D>("BallStartPosition");
        ball.Start(ballPosition.Position);

        // TODO: When Timer reaches 0, start game. Add signal
        GetNode<Timer>("StartTimer").Start();
    }

    public void OnWallsOutOfBounds(string side)
    {
        if (side.Equals("left"))
        {
            _gui.UpdateEnemyScore(++_enemyScore);
        }
        else if (side.Equals("right"))
        {
            _gui.UpdatePlayerScore(++_playerScore);
        }

        NewRound();
    }

    private void NewGame()
    {
        _playerScore = 0;
        _enemyScore = 0;
    }

    async private void GameOver()
    {
        await ToSignal(GetTree().CreateTimer(1), "timeout");
        _gui.PromptNewGame();
    }

    async private void NewRound()
    {
        // Reset ball to middle
        var ball = GetNode<Ball>("Ball");
        ball.Stop();

        var startTimer = GetNode<Timer>("StartTimer");
        startTimer.Start();
        await ToSignal(startTimer, "timeout");

        var ballPosition = GetNode<Position2D>("BallStartPosition");
        ball.Start(ballPosition.Position);
    }
}
