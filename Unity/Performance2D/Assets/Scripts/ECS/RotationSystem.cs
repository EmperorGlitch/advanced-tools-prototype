using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

public partial struct RotationSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new RotationJob { deltaTime = SystemAPI.Time.DeltaTime}.ScheduleParallel();
    }
}

[BurstCompile]
public partial struct RotationJob : IJobEntity
{
    public float deltaTime;
    private void Execute(RefRW<RotationBehaviour> rotationBehaviour, RefRW<LocalTransform> transform)
    {
        float randomSpeed = rotationBehaviour.ValueRW.random.NextFloat() * rotationBehaviour.ValueRO.rotationSpeed;
        float newRotation = randomSpeed * deltaTime;

        transform.ValueRW = transform.ValueRO.RotateZ(newRotation);
    }
}