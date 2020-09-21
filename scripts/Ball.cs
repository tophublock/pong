using Godot;
using System;

public class Ball : Area2D
{

    public Vector2 direction = Vector2.Left;
    private bool _isMoving = false;
    private float _speed = 500;

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
    }
}
