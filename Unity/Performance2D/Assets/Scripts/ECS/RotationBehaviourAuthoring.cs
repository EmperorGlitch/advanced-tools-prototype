using UnityEngine;

using Unity.Entities;

public class RotationBehaviourAuthoring : MonoBehaviour
{
    public float rotationSpeed;
}

public class RotationBehaviourBaker : Baker<RotationBehaviourAuthoring>
{
    public override void Bake(RotationBehaviourAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new RotationBehaviour { 
            rotationSpeed = authoring.rotationSpeed,
            random = new Unity.Mathematics.Random((uint) UnityEngine.Random.Range(-10,10))
        });
    }
}