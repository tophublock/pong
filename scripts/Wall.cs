using Godot;
using System;

public class Wall : Area2D
{

    [Signal]
    public delegate void OutOfBounds();
    private bool _isSideWall = false;

    public override void _Ready()
    {
        string name = Name.ToLower();
        if (name.Equals("leftwall") || name.Equals("rightwall"))
        {
            _isSideWall = true;
        }
    }

    public void OnWallAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            if (_isSideWall)
            {
                EmitSignal(nameof(OutOfBounds));
            }
            else
            {
                var nx = ball.direction.x;
                var ny = -1 * ball.direction.y;
                ball.direction = new Vector2(nx, ny).Normalized();
            }
        }
    }
}
