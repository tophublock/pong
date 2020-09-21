using Godot;
using System;

public class Main : Node
{

    public int MAX_SCORE = 10;
    private int _playerScore;
    private int _enemyScore;
    private Ball _ball;
    private Paddle _player;
    private Enemy _enemy;
    private Gui _gui;

    public override void _Ready()
    {
        _gui = GetNode<Gui>("Gui");
        // TODO: make position relative to screen size?
        _player = GetNode<Paddle>("Player");
        _enemy = GetNode<Enemy>("Enemy");
        _ball = GetNode<Ball>("Ball");

        // TODO: When Timer reaches 0, start game. Add signal
        GetNode<Timer>("StartTimer").Start();
        newGame();
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

        if (_enemyScore == 10 || _playerScore == 10)
        {
            gameOver();
        }
        else
        {
            newRound();
        }
    }

    private void resetPositions()
    {
        var ballPosition = GetNode<Position2D>("BallStartPosition");
        _ball.SetPosition(ballPosition.Position);

        var playerPosition = GetNode<Position2D>("PlayerStartPosition");
        _player.SetPosition(playerPosition.Position);

        var enemyPosition = GetNode<Position2D>("EnemyStartPosition");
        _enemy.SetPosition(enemyPosition.Position);
    }

    private void stopEntities()
    {
        _player.Stop();
        _enemy.Stop();
        _ball.Stop();
    }

    private void startEntities()
    {
        _player.Start();
        _enemy.Start();
        _ball.Start();
    }

    private void newGame()
    {
        _playerScore = 0;
        _gui.UpdatePlayerScore(_playerScore);

        _enemyScore = 0;
        _gui.UpdateEnemyScore(_enemyScore);

        resetPositions();
        startEntities();
    }

    async private void gameOver()
    {
        stopEntities();
        await ToSignal(GetTree().CreateTimer(1), "timeout");
        _gui.PromptNewGame();
    }

    // Reset paddles and ball to start positions
    async private void newRound()
    {
        stopEntities();
        resetPositions();

        var startTimer = GetNode<Timer>("StartTimer");
        startTimer.Start();
        await ToSignal(startTimer, "timeout");
        startEntities();
    }

    public void OnGuiNewGame()
    {
        newGame();
    }

    public void OnGuiEndGame()
    {
        GetTree().Quit();
    }
}
