using Godot;
using System;

public class Main : Node
{

    private int _score;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //TODO: refactor into NewGame() function
        _score = 0;

        // TODO: make position relative to screen size?
        var player = GetNode<Paddle>("Player");
        var playerPosition = GetNode<Position2D>("PlayerStartPosition");
        player.Start(playerPosition.Position);

        var ball = GetNode<Ball>("Ball");
        var ballPosition = GetNode<Position2D>("BallStartPosition");
        ball.Start(ballPosition.Position);

        // TODO: When Timer reaches 0, start game. Add signal
        GetNode<Timer>("StartTimer").Start();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}