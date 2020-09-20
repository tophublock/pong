using Godot;
using System;

public class Walls : Node
{
   [Signal]
   public delegate void OutOfBounds(string side);

   public void OnLeftWallOutOfBounds()
    {
        EmitSignal(nameof(OutOfBounds), "left");
    }
    public void OnRightWallOutOfBounds()
    {
        EmitSignal(nameof(OutOfBounds), "right");
    }
}

