using Godot;
using System;

public class Main : Node
{

    private int _score;

    public override void _Ready()
    {
        //TODO: refactor into NewGame() function
        _score = 0;

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
            // TODO: update enemy score
        }
        else if (side.Equals("right"))
        {
            // TODO: update player score
        }
    }
}
