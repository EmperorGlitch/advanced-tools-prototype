using Godot;
using System;

public partial class Behaviour2D : Node2D
{
	[Export] int movementSpeed = 400;
	[Export] int radius = 300;
	
	Vector2 startPoint;
	Vector2 nextPoint;
	
	RandomNumberGenerator random = new RandomNumberGenerator();
	
	public override void _Ready()
	{
		startPoint = Position;
		nextPoint = Position;
	}

	public override void _Process(double delta)
	{
		if (Position.DistanceSquaredTo(nextPoint) < 144)
		{
			nextPoint = startPoint + new Vector2(random.RandfRange(-radius, radius), random.RandfRange(-radius, radius));
		}
		Position += Position.DirectionTo(nextPoint) * (movementSpeed * (float)delta);
	}
}
