using Unity.Entities;

public struct RotationBehaviour : IComponentData
{
    public float rotationSpeed;
    public Unity.Mathematics.Random random;
}