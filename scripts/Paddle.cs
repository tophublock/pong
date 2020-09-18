using Godot;
using System;

public class Paddle : Area2D 
{

    [Export]
    public int Speed = 400; // How fast paddle moves (px/sec)
    private Vector2 _screenSize;
    private Sprite _sprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        _sprite = GetNode<Sprite>("Sprite");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var velocity = new Vector2();
        if (Input.IsActionJustPressed("ui_up"))
        {
            velocity.y -= 1;
        }
        else if (Input.IsActionJustPressed("ui_down"))
        {
            velocity.y += 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, _screenSize.x),
            y: Mathf.Clamp(Position.y, 0, _screenSize.y)
        );
    }
}
