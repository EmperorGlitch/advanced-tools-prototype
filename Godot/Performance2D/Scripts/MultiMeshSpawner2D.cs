using Godot;
using System;
using System.Collections.Generic;

public partial class MultiMeshSpawner2D : MultiMeshInstance2D
{
	[Export] float radius = .2f;
	[Export] float movementSpeed = 3f;
	[Export] string action = "spawn";
	[Export] Label prefabCountLabel;
	[Export] Label sceneNameLabel;
	
	int prefabsCountIncrement = 1000;
	
	RandomNumberGenerator random = new RandomNumberGenerator();
	
	Vector2 startPoint = new Vector2(0, 0);
	List<Vector2> nextPoints = new List<Vector2>();
	
	public override void _Ready()
	{
		nextPoints.Clear();
		
		for (int i = 0; i < Multimesh.InstanceCount; i++)
		{
			Transform2D transform = new Transform2D(0, startPoint);
			Multimesh.SetInstanceTransform2D(i, transform);
			nextPoints.Add(startPoint);
		}
	}
	
	public override void _Process(double delta)
	{
		float df = (float)delta;
		for (int i = 0;i < Multimesh.InstanceCount; i++){
			Transform2D transform = Multimesh.GetInstanceTransform2D(i);
			Vector2 nextPoint = nextPoints[i];
			
			if (transform.Origin.DistanceSquaredTo(nextPoint) < 0.1f)
			{
				float angleRad = random.RandfRange(-MathF.PI, MathF.PI);
				nextPoint = startPoint + new Vector2(MathF.Cos(angleRad), MathF.Sin(angleRad)) * random.RandfRange(0, radius);
				nextPoints[i] = nextPoint;
			}
			
			transform.Origin += transform.Origin.DirectionTo(nextPoint) * (movementSpeed * df);
			Multimesh.SetInstanceTransform2D(i, transform);
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(action))
		{
			Multimesh.InstanceCount += prefabsCountIncrement;
			prefabCountLabel.Text = $"Count: {Multimesh.InstanceCount}";
			sceneNameLabel.Text = $"Scene: {this.Name}";
			_Ready();
		}
		
		if (@event.IsActionPressed("ui_up") && prefabsCountIncrement < 10000)
		{
			prefabsCountIncrement *= 10;
		}
		
		if (@event.IsActionPressed("ui_down") && prefabsCountIncrement > 100)
		{
			prefabsCountIncrement /= 10;
		}
		
		if (@event.IsActionPressed("restart")){
			Multimesh.InstanceCount = 0;
		}
		base._Input(@event);
	}
}
