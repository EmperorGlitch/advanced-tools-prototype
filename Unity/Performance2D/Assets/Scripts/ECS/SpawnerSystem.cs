using System;

using UnityEngine;

using Unity.Entities;

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
                Entity newEntity = EntityManager.Instantiate(spawner.ValueRO.prefab);
            }

            OnSpawn?.Invoke(spawner.ValueRO.currentPrefabsCount);
        }
    }
}