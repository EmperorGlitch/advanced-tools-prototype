using Godot;
using System;
using System.Collections.Generic;

public partial class MultiMeshSpawner3D : MultiMeshInstance3D
{
	[Export] float radius = 1.5f;
	[Export] float movementSpeed = 1.2f;
	[Export] string action = "spawn";
	[Export] bool isStarted = true;
	[Export] Label prefabCountLabel;
	[Export] Label sceneNameLabel;
	
	int prefabsCountIncrement = 1000;
	
	RandomNumberGenerator random = new RandomNumberGenerator();
	
	Vector3 startPoint = new Vector3(0, 0, 0);
	List<Vector3> nextPoints = new List<Vector3>();
	
	public override void _Ready()
	{
		nextPoints.Clear();
		for (int i = 0; i < Multimesh.InstanceCount; i++)
		{
			Transform3D transform = new Transform3D(Basis, startPoint);
			Multimesh.SetInstanceTransform(i, transform);
			nextPoints.Add(startPoint);
		}
	}
	
	public override void _Process(double delta)
	{
		if (isStarted)
		{
			float df = (float) delta;
			for (int i = 0; i < Multimesh.InstanceCount; i++)
			{
				Transform3D transform = Multimesh.GetInstanceTransform(i);
				Vector3 nextPoint = nextPoints[i];
				
				if (transform.Origin.DistanceSquaredTo(nextPoint) <.01f)
				{
					float angleRad = random.RandfRange(-MathF.PI, MathF.PI);
					nextPoint = startPoint + new Vector3(MathF.Cos(angleRad), MathF.Sin(angleRad), 0) * random.RandfRange(0, radius);
					nextPoints[i] = nextPoint;
				}
				transform.Origin += transform.Origin.DirectionTo(nextPoint) * (movementSpeed * df);
				Multimesh.SetInstanceTransform(i, transform);
			}
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
		
		if (@event.IsActionPressed("restart"))
		{
			Multimesh.InstanceCount = 0;
		}
		
		base._Input(@event);}
}
