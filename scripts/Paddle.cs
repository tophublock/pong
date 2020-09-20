using Godot;
using System;

public class Paddle : Area2D 
{

    [Export]
    public int Speed = 400; // How fast paddle moves (px/sec)
    private int _padding = 30;
    private Vector2 _screenSize;
    private Sprite _sprite;

    public override void _Ready()
    {
        _screenSize = GetViewport().Size;
        _sprite = GetNode<Sprite>("Sprite");
        Hide();
    }

    public override void _Process(float delta)
    {
        var velocity = GetVelocity();
        velocity *= Speed * delta;
        _processPosition(velocity);
    }

    public virtual Vector2 GetVelocity()
    {
        var velocity = new Vector2();
        if (Input.IsKeyPressed((int)KeyList.W))
        {
            velocity.y -= 1;
        }
        else if (Input.IsKeyPressed((int)KeyList.S))
        {
            velocity.y += 1;
        }
        return velocity;
    }

    private void _processPosition(Vector2 velocity)
    {
        Vector2 position = Position;
        position += velocity;
        Position = new Vector2(
            x: Mathf.Clamp(position.x, _padding, _screenSize.x - _padding),
            y: Mathf.Clamp(position.y, _padding, _screenSize.y - _padding)
        );
    }

    public void Start(Vector2 pos)
    {
        Position = pos;
        Show();
    }

    public void OnPaddleAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            var nx = -1 * ball.direction.x;
            // Get number between [-1, 1)
            var ny = ((float)new Random().NextDouble()) * 2 - 1;
            ball.direction = new Vector2(nx, ny).Normalized();
        }
    }
}
