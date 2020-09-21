using Godot;
using System;

public class Ball : Area2D
{

    public Vector2 direction = Vector2.Left;
    private float DEFAULT_SPEED = 350;
    private bool _isMoving = false;
    private float _speed;

    public override void _Ready()
    {
        _speed = DEFAULT_SPEED;
    }

    public override void _Process(float delta)
    {
        if (_isMoving)
        {
            _speed += delta * 2;
            Position += _speed * delta * direction;
        }
    }

    public void SetPosition(Vector2 pos)
    {
        Position = pos;
        Show();
    }

    public void Start()
    {
        _isMoving = true;
    }

    public void Stop()
    {
        _isMoving = false;
        _speed = DEFAULT_SPEED;
    }
}
