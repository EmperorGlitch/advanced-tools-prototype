using UnityEngine;

using Unity.Entities;
using Random = Unity.Mathematics.Random;

public class WorldRandomAuthoring : MonoBehaviour
{
}
public struct WorldRandom : IComponentData
{
    public Random value;
}

public class WorldRandomBaker : Baker<WorldRandomAuthoring>
{
    public override void Bake(WorldRandomAuthoring authoring)
    {
        Entity etity = GetEntity(TransformUsageFlags.None);
        AddComponent(etity, new WorldRandom { value = new Random(1) });
    }
}
