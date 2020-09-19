using Godot;
using System;

// Do not need to override _Ready or _Process
public class Enemy : Paddle 
{
    public override Vector2 GetVelocity()
    {
        var velocity = new Vector2();
        if (Input.IsActionPressed("ui_up"))
        {
            velocity.y -= 1;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            velocity.y += 1;
        }
        return velocity;
    }
}
