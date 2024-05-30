using System;

using UnityEngine;

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class SpawnerSystem : SystemBase
{
    public static event Action<int> OnSpawn;
    protected override void OnCreate()
    {
        RequireForUpdate<Spawner>();
    }

    protected override void OnUpdate()
    {
        foreach (var spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawner.ValueRW.isStarted = true;

                spawner.ValueRW.selectedPrefabsCount += spawner.ValueRO.prefabsCountIncrement;
                spawner.ValueRW.radius += 0.1f;
            }

            if (!spawner.ValueRO.isStarted) continue;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (spawner.ValueRO.prefabsCountIncrement < 10000)
                    spawner.ValueRW.prefabsCountIncrement *= 10;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (spawner.ValueRO.prefabsCountIncrement > 100)
                    spawner.ValueRW.prefabsCountIncrement /= 10;
            }

            while (spawner.ValueRO.nextSpawn <= SystemAPI.Time.ElapsedTime)
            {
                if (spawner.ValueRO.currentPrefabsCount >= spawner.ValueRO.selectedPrefabsCount)
                {
                    break;
                }

                spawner.ValueRW.nextSpawn += spawner.ValueRO.spawnRate;
                spawner.ValueRW.currentPrefabsCount++;

                float3 position = new float3(spawner.ValueRO.radius * MathF.Cos(2 * (float)Math.PI * (spawner.ValueRW.selectedPrefabsCount - spawner.ValueRW.currentPrefabsCount) / spawner.ValueRO.prefabsCountIncrement), 
                spawner.ValueRO.radius * MathF.Sin(2 * (float)Math.PI * (spawner.ValueRW.selectedPrefabsCount - spawner.ValueRW.currentPrefabsCount) / spawner.ValueRO.prefabsCountIncrement), 0);

                Entity newEntity = EntityManager.Instantiate(spawner.ValueRO.prefab);

                EntityManager.SetComponentData(newEntity, LocalTransform.FromPositionRotationScale(position, quaternion.identity, 0.05f));
            }

            OnSpawn?.Invoke(spawner.ValueRO.currentPrefabsCount);
        }
    }
}