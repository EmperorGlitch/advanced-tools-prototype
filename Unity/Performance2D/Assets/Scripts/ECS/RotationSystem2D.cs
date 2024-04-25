using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

public partial struct RotationSystem2D : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new Rotation2DJob { deltaTime = SystemAPI.Time.DeltaTime}.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct Rotation2DJob : IJobEntity
{
    public float deltaTime;
    private void Execute(RefRW<RotationBehaviour> rotationBehaviour, RefRW<LocalTransform> transform)
    {
        float randomSpeed = rotationBehaviour.ValueRW.random.NextFloat() * rotationBehaviour.ValueRO.rotationSpeed;
        float newRotation = randomSpeed * deltaTime;

        transform.ValueRW = transform.ValueRO.RotateZ(newRotation);
    }
}