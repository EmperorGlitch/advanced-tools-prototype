using UnityEngine;

using Unity.Entities;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public double spawnRate;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        
        AddComponent(entity, new Spawner
        {
            prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            spawnRate = authoring.spawnRate,
            nextSpawn = Time.timeAsDouble,
            isStarted = false,
            currentPrefabsCount = 0,
            selectedPrefabsCount = 0,
            prefabsCountIncrement = 100,
            radius = 1.0f
        });
    }
}