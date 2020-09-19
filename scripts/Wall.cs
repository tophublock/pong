using Godot;
using System;

public class Wall : Area2D
{

    private bool _isSideWall = false;

    // Called when the node enters the scene tree for the first time.
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
                // TODO: end game
                var nx = -1 * ball.direction.x;
                var ny = ball.direction.y;
                ball.direction = new Vector2(nx, ny).Normalized();
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
