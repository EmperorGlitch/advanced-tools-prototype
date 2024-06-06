using Godot;
using System;

public partial class Behaviour3D : Node3D
{
	[Export] int speed = 8;
	[Export] int radius = 6;
	
	Vector3 startPoint;
	Vector3 nextPoint;
	
	RandomNumberGenerator random = new RandomNumberGenerator();
	
	public override void _Ready()
	{
		startPoint = Position;
		nextPoint = Position; 
	}

	public override void _Process(double delta)
	{
		if (Position.DistanceSquaredTo(nextPoint) < 4)
		{
			nextPoint = startPoint + new Vector3(random.RandfRange(-radius, radius), random.RandfRange(-radius, radius), 0);
		}
		
		Position += Position.DirectionTo(nextPoint) * (speed * (float)delta);
	}
}
