using Godot;
using System;

public class Ball : Area2D
{

    public Vector2 direction = Vector2.Left;
    private float _speed = 100;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        _speed += delta * 2;
        Position += _speed * delta * direction;
    }

    public void Start(Vector2 pos)
    {
        Position = pos;
        Show();
    }
}
